using Microsoft.Extensions.DependencyInjection;
using SoftwareTraining.Client;
using SoftwareTraining.CommandFactory;
using SoftwareTraining.Constant;
using SoftwareTraining.DependencyInjection;
using SoftwareTraining.Entity;
using SoftwareTraining.Enum;
using SoftwareTraining.HttpClientFactory;
using SoftwareTraining.Repository.Dapper.Interface;
using SoftwareTraining.TelegramCommand.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace SoftwareTraining.TelegramBotEvent
{
    public class OnMessage
    {
        public static ITelegramClient telegramClient { get; set; }
        public static ITelegramBotClient telegramBotClient { get; set; }
        public static TelegramDependency telegramDependency = new TelegramDependency();
        public static ITelegramCommand telegramCommand { get; set; }
        public static IClientFactory clientFactory { get; set; }
        public static IQuestionRepository questionRepositoy { get; set; }
        public static IHistoryRepository historyRepository { get; set; }
        public static ITelegramCommandFactory telegramCommandFactory { get; set; }

        public static void Builder()
        {
            IServiceProvider serviceProvider = telegramDependency.Dependencies();

            telegramClient = serviceProvider.GetRequiredService<ITelegramClient>();
            clientFactory = serviceProvider.GetRequiredService<IClientFactory>();
            questionRepositoy = serviceProvider.GetRequiredService<IQuestionRepository>();
            historyRepository = serviceProvider.GetRequiredService<IHistoryRepository>();
            telegramCommandFactory = serviceProvider.GetRequiredService<ITelegramCommandFactory>();
            
            telegramBotClient = telegramClient.CreateInstance();
        }

        public static async void BotOnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Builder();

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

            if (historyId <= 0)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, Messages.basicError);
            }

            try
            {
                var result = telegramCommandFactory.NewCommand(e.Message);
                if (result != null)
                {
                    int category = result.Item2;
                    await result.Item1.ExecuteCommand(e.Message, category);
                }
                else
                {
                    await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, Messages.wrongTextError);
                }
            }
            catch (Exception ex)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, Messages.wrongTextError);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
