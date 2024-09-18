using GenReport.Infrastructure.Interfaces;
using Rystem.OpenAi;
using Rystem.OpenAi.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GenReport.Infrastructure.SharedServices.AI
{
    public class OpenAIService : IOpenAIService
    {
        private readonly IOpenAiFactory openAiFactory;
        private IOpenAiChat? openAi = null;
        public OpenAIService(IOpenAiFactory openAiFactory)
        {
            this.openAiFactory = openAiFactory;
            openAi = openAiFactory.CreateChat();
        }
        public async Task<string[]> GetTableNamesFromQueryAsync(string requestText ,Dictionary<string,List<string>> schema)
        {
            openAi?.RequestWithUserMessage($"the user has input the message \"{requestText}\" i have the tables with columns {1} in my db please return the list of tables and columns in key value format where the key is table and values are its correspoding columns that you think the user wants to perform operation on.");
            return [];
        }
    }
}
