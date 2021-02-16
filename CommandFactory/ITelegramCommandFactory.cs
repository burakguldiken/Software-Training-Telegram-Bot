using SoftwareTraining.TelegramCommand.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace SoftwareTraining.CommandFactory
{
    public interface ITelegramCommandFactory
    {
        Tuple<ITelegramCommand,int> NewCommand(Message command);
    }
}
