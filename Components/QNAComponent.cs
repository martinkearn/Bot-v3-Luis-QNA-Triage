using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LuisBot.Components
{
    public static class QNAComponent
    {
        public static async Task<string> MakeQNARequest(string userInput)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var qnaAPIKey = ConfigurationManager.AppSettings["QnaAPIKey"];
            var qnaKbId = ConfigurationManager.AppSettings["QnaKbId"];
            var qnaHostName = ConfigurationManager.AppSettings["QnaHostName"];

            HttpContent body = new StringContent("{\"question\": \"" + userInput + "\"}");

            body.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            client.DefaultRequestHeaders.Add("Authorization", "EndpointKey " + qnaAPIKey);

            var uri = $"https://{qnaHostName}/qnamaker/knowledgebases/{qnaKbId}/generateAnswer";

            var response = await client.PostAsync(uri, body);

            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent.ToString();
        }
    }
}