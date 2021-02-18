using Microsoft.Extensions.DependencyInjection;
using SoftwareTraining.Enum;
using SoftwareTraining.TelegramCommand.Interface;
using SoftwareTraining.TelegramCommand.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace SoftwareTraining.CommandFactory
{
    public class TelegramCommandFactory : ITelegramCommandFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public TelegramCommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Tuple<ITelegramCommand,int> NewCommand(Message command)
        {
            Tuple<ITelegramCommand, int> result = null;

            string cmd = command.Text;

            switch (cmd)
            {
                case "/csharpquestion":
                    result = Tuple.Create<ITelegramCommand,int>(_serviceProvider.GetRequiredService<SendPollCommand>(), (int)EnumCategory.Csharp);
                    break;

                case "/sqlserverquestion":
                    result = Tuple.Create<ITelegramCommand, int>(_serviceProvider.GetRequiredService<SendPollCommand>(), (int)EnumCategory.SqlServer);
                    break;

                case "/javascriptquestion":
                    result = Tuple.Create<ITelegramCommand, int>(_serviceProvider.GetRequiredService<SendPollCommand>(), (int)EnumCategory.Javascript);
                    break;
            }

            return result;
        }
    }
}
