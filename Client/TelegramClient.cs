using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace SoftwareTraining.Client
{
    public class TelegramClient : ITelegramClient
    {
        public ITelegramBotClient botClient { get; set; }

        private static readonly object lockObject = new object();

        private string telegramBotKey { get; set; }

        public TelegramClient()
        {
            telegramBotKey = "";
        }

        /// <summary>
        /// Create new bot client instance
        /// </summary>
        /// <returns></returns>
        public ITelegramBotClient CreateInstance()
        {
            if(botClient == null)
            {
               lock(lockObject)
                {
                    botClient = new TelegramBotClient(telegramBotKey);
                } 
            }

            return botClient;
        }
    }
}
