using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTraining.HttpClientFactory
{
    public class ClientFactory : IClientFactory
    {
        public IHttpClientFactory clientFactory;

        public ClientFactory(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public string RequestTest()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.tutorialspoint.com/csharp/csharp_question_bank/62.htm?QN=2");

            var client = clientFactory.CreateClient();

            try
            {
                var response = client.SendAsync(request).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                return responseString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return default;
        }
    }
}
