using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChatCustomDisign.Models.Autho;
using ChatCustomDisign.Models.Interfaces.Services;
using Newtonsoft.Json;

namespace ChatCustomDisign.Services
{
    public class LoginService : ILoginService
    {
        public async Task LoginUser(string login, string password)
        {
            var loginModel = new
            {
                login = login,
                password = password
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");

            var result = string.Empty;

            var body = new Dictionary<string, string>()
            {
                {"client_id", "ro.client"},
                {"client_secret", "secret"},
                {"userName", "string"},
                {"password", "171198"},
                {"grant_type", "password"}
            };

            var token = MakeRequest<TokenResponce>("POST", "connect/token", body);
            
        }
        
        private static T MakeRequest<T>(string httpMethod, string route, Dictionary<string, string> postParams = null)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), $"{"http://localhost:53261"}/{route}");

                if (postParams != null)
                    requestMessage.Content = new FormUrlEncodedContent(postParams);   // This is where your content gets added to the request body


                HttpResponseMessage response = client.SendAsync(requestMessage).Result;

                string apiResponse = response.Content.ReadAsStringAsync().Result;
                try
                {
                    // Attempt to deserialise the reponse to the desired type, otherwise throw an expetion with the response from the api.
                    if (apiResponse != "")
                        return JsonConvert.DeserializeObject<T>(apiResponse);
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error ocurred while calling the API. It responded with the following message: {response.StatusCode} {response.ReasonPhrase}");
                }
            }
        }
    }
}
