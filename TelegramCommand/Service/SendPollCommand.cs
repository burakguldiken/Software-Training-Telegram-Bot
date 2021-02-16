using SoftwareTraining.Client;
using SoftwareTraining.Constant;
using SoftwareTraining.Repository.Dapper.Interface;
using SoftwareTraining.TelegramCommand.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SoftwareTraining.TelegramCommand.Service
{
    public class SendPollCommand : ITelegramCommand
    {
        private ITelegramBotClient telegramBotClient { get; set; }
        private IQuestionRepository questionRepository { get; set; }

        public SendPollCommand(ITelegramClient telegramClient,IQuestionRepository questionRepository)
        {
            telegramBotClient = telegramClient.CreateInstance();
            this.questionRepository = questionRepository;
        }

        public async Task ExecuteCommand(Message message,int category = 1)
        {
            var question = questionRepository.GetRandomQuestion(category);

            if(question == null)
            {
                await telegramBotClient.SendTextMessageAsync(message.Chat.Id, Messages.categoryNotFound);

                return;
            }

            await telegramBotClient.SendPollAsync(
                chatId: message.Chat.Id,
                question: question.title,
                options: new[]
                {
                    question.optionA,
                    question.optionB,
                    question.optionC,
                    question.optionD
                },
                type:PollType.Quiz,
                isAnonymous:false,
                correctOptionId: question.answer
            );
        }
    }
}
