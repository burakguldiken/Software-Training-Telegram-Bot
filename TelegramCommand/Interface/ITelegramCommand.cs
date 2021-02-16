using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SoftwareTraining.TelegramCommand.Interface
{
    public interface ITelegramCommand
    {
        /// <summary>
        /// Execute operation for all methods
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task ExecuteCommand(Message message,int category = 1);
    }
}
