using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChatCustomDisign.Models.Autho;
using ChatCustomDisign.Models.DTO;
using ChatCustomDisign.Models.Interfaces.Services;
using ChatCustomDisign.Models.Template;
using Newtonsoft.Json;

namespace ChatCustomDisign.Services
{
    public class LoginService : ILoginService
    {
        public bool LoginUser(LoginRequest login)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            var result = string.Empty;

            var body = new Dictionary<string, string>()
            {
                {"client_id", "ro.client"},
                {"client_secret", "secret"},
                {"userName", login.Login},
                {"password", login.Password},
                {"grant_type", "password"}
            };

            var token = MakeRequest<TokenResponce>("POST", "connect/token", body);

            if (token == null)
            {
                return false;
            }

            var ts = Properties.Settings.Default["Token"].ToString();

            Properties.Settings.Default["Token"] = token.Token;
            Properties.Settings.Default.Save();
            var t = Properties.Settings.Default["Token"].ToString();
            return true;
        }

        public UserResponce GetUserInfo()
        {
            var result = string.Empty;

            var body = new Dictionary<string, string>()
            {
                {"Bearer", Properties.Settings.Default["Token"].ToString()}     
            };

            var model = MakeRequest<UserResponce>("GET", "api/User/Info", body);

            if (model == null)
            {
                return null;
            }
            
            return model;
        }

        private static T MakeRequest<T>(string httpMethod, string route, Dictionary<string, string> postParams = null)
        {
            using (var client = new HttpClient()
            {
                DefaultRequestHeaders = { { "Authorization", "Bearer " + Properties.Settings.Default["Token"].ToString()} }
            })
            {
                var requestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), $"{"http://localhost:53261"}/{route}");

                var response = client.SendAsync(requestMessage).Result;

                var apiResponse = response.Content.ReadAsStringAsync().Result;
                try
                {
                    // Attempt to deserialise the reponse to the desired type, otherwise throw an expetion with the response from the api.
                    if (apiResponse != "")
                        return JsonConvert.DeserializeObject<T>(apiResponse);

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
