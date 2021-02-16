using Microsoft.Extensions.DependencyInjection;
using SoftwareTraining.Client;
using SoftwareTraining.CommandFactory;
using SoftwareTraining.HttpClientFactory;
using SoftwareTraining.Repository.Dapper.Interface;
using SoftwareTraining.Repository.Dapper.Service;
using SoftwareTraining.TelegramCommand.Interface;
using SoftwareTraining.TelegramCommand.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.DependencyInjection
{
    public class TelegramDependency
    {
        public static IServiceProvider serviceProvider { get; set; }

        public IServiceProvider Dependencies()
        {
            serviceProvider = new ServiceCollection()
                .AddSingleton<ITelegramClient, TelegramClient>()
                .AddSingleton<SendMessageCommand>()
                .AddSingleton<SendPhotoCommand>()
                .AddSingleton<SendVideoCommand>()
                .AddSingleton<SendAudioCommand>()
                .AddSingleton<SendPollCommand>()
                .AddSingleton<IClientFactory,ClientFactory>()
                .AddSingleton<IBaseRepository,BaseRepository>()
                .AddSingleton<IQuestionRepository,QuestionRepository>()
                .AddSingleton<IHistoryRepository,HistoryRepository>()
                .AddSingleton<ITelegramCommandFactory,TelegramCommandFactory>()
                .AddHttpClient()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
