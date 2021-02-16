using Microsoft.Extensions.DependencyInjection;
using SoftwareTraining.Client;
using SoftwareTraining.CommandFactory;
using SoftwareTraining.DependencyInjection;
using SoftwareTraining.Entity;
using SoftwareTraining.Enum;
using SoftwareTraining.HttpClientFactory;
using SoftwareTraining.Repository.Dapper.Interface;
using SoftwareTraining.TelegramCommand.Interface;
using SoftwareTraining.TelegramCommand.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SoftwareTraining
{
    class Program
    {
        public static ITelegramClient telegramClient { get; set; }
        public static ITelegramBotClient telegramBotClient { get; set; }
        public static TelegramDependency telegramDependency = new TelegramDependency();
        public static ITelegramCommand telegramCommand { get; set; }
        public static IClientFactory clientFactory { get; set; } 
        public static IQuestionRepository questionRepositoy { get; set; }
        public static IHistoryRepository historyRepository { get; set; }
        public static ITelegramCommandFactory telegramCommandFactory { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Bot Started...");

            IServiceProvider serviceProvider = telegramDependency.Dependencies();

            telegramClient = serviceProvider.GetRequiredService<ITelegramClient>();
            clientFactory = serviceProvider.GetRequiredService<IClientFactory>();
            questionRepositoy = serviceProvider.GetRequiredService<IQuestionRepository>();
            historyRepository = serviceProvider.GetRequiredService<IHistoryRepository>();
            telegramCommandFactory = serviceProvider.GetRequiredService<ITelegramCommandFactory>();

            clientFactory.RequestTest();

            telegramBotClient = telegramClient.CreateInstance();

            telegramBotClient.StartReceiving();
            telegramBotClient.OnMessage += BotOnMessage;

            Console.ReadLine();
        }

        private static async void BotOnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            History history = new History()
            {
                firstName = e.Message.From.FirstName,
                lastName = e.Message.From.LastName,
                text = e.Message.Text,
                userId = e.Message.From.Id,
                creationDate = e.Message.Date,
                statusId = (int)EnumStatus.Active
            };

            var historyId = historyRepository.InsertHistory(history);

            if(historyId <= 0)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "An unexpected error was encountered!");
            }

            try
            {
                var result = telegramCommandFactory.NewCommand(e.Message);
                if (result != null)
                {
                    int category = result.Item2;
                    await result.Item1.ExecuteCommand(e.Message,category);
                }
                else
                {
                    await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Press the / character then call the command you want");
                }
            }
            catch (Exception ex)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id,"Press the / character then call the command you want");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
