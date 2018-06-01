using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LuisBot.Components
{
    public static class LuisComponent
    {
        public static async Task<string> MakeLuisRequest(string userInput)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var luisAppId = ConfigurationManager.AppSettings["LuisAppId"];
            var luisAPIKey = ConfigurationManager.AppSettings["LuisAPIKey"];
            var luisAPIHostName = ConfigurationManager.AppSettings["LuisAPIHostName"];

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", luisAPIKey);

            queryString["q"] = userInput;
            queryString["timezoneOffset"] = "0";
            queryString["verbose"] = "true";
            queryString["spellCheck"] = "false";
            queryString["staging"] = "false";

            var uri = $"https://{luisAPIHostName}/luis/v2.0/apps/{luisAppId}?{queryString}";

            var response = await client.GetAsync(uri);

            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent.ToString();
        }
    }
}