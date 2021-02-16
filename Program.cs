using Microsoft.Extensions.DependencyInjection;
using SoftwareTraining.Client;
using SoftwareTraining.CommandFactory;
using SoftwareTraining.Constant;
using SoftwareTraining.DependencyInjection;
using SoftwareTraining.Entity;
using SoftwareTraining.Enum;
using SoftwareTraining.HttpClientFactory;
using SoftwareTraining.Repository.Dapper.Interface;
using SoftwareTraining.TelegramBotEvent;
using SoftwareTraining.TelegramCommand.Interface;
using SoftwareTraining.TelegramCommand.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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

        static void Main(string[] args)
        {
            Console.WriteLine("Bot Started...");

            IServiceProvider serviceProvider = telegramDependency.Dependencies();

            telegramClient = serviceProvider.GetRequiredService<ITelegramClient>();

            telegramBotClient = telegramClient.CreateInstance();

            telegramBotClient.StartReceiving();
            telegramBotClient.OnMessage += OnMessage.BotOnMessage;

            while(true)
            {
                Task.Delay(TimeSpan.FromSeconds(5)).Wait();
            }
        }
    }
}
