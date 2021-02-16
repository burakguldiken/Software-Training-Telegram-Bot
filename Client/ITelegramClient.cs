using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace SoftwareTraining.Client
{
    public interface ITelegramClient
    {
        /// <summary>
        /// Create new Botclient instance
        /// </summary>
        /// <returns></returns>
        public ITelegramBotClient CreateInstance();
    }
}
