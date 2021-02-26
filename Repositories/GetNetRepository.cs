using PocGetNet.DTOs;
using System;
using System.Net.Http;
using System.Text;
using PocGetNet.Configurations;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PocGetNet.Repositories
{
    public class GetNetRepository
    {
        private readonly HttpClient httpClient;
        private readonly AppConfigurations configs;
        public GetNetRepository(AppConfigurations configs)
        {
            this.configs = configs;
            httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(5),
            };
        }

        public async Task<AuthenticationResultDto> Authentication() 
        {

            var accessTokenRequest = CreateAuthRequest();

            try
            {
                var result = await httpClient.SendAsync(accessTokenRequest);
                result.EnsureSuccessStatusCode();
                var contentToString = await result.Content.ReadAsStringAsync();
                var authResult = JsonConvert.DeserializeObject<AuthenticationResultDto>(contentToString);
                return authResult;
            }
            catch
            {
                Console.WriteLine("Error!!!");
                throw new ApplicationException();
            }

        }

        public async Task<CardTokenizationResultDto> CardTokenization(AuthenticationResultDto auth, CardTokenizationRequest tokenizationRequest)
        {
            var request = CreateTokenizationRequest(auth.AccessToken, tokenizationRequest);

            try
            {
                var result = await httpClient.SendAsync(request);
                result.EnsureSuccessStatusCode();
                var contentToString = await result.Content.ReadAsStringAsync();
                var cardTokenResult = JsonConvert.DeserializeObject<CardTokenizationResultDto>(contentToString);
                return cardTokenResult;
            }
            catch
            {
                throw new ApplicationException();
            }
        }
        
        public Task<PaymentResultDto> Payment(CardTokenizationResultDto cardTokenized)
        {
            return Task.FromResult(new PaymentResultDto());
        }

        #region privateMethods
        private HttpRequestMessage CreateAuthRequest() 
        {
            var authorizationBase64 = CreateAuthorizationBase64();
            var accessTokenRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri(configs.GetNetAuthEnpoint),
                Method = HttpMethod.Post,
                Headers =
                {
                    Authorization = new AuthenticationHeaderValue("Basic", authorizationBase64),
                }
            };
            accessTokenRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            accessTokenRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            accessTokenRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            accessTokenRequest.Content = new StringContent("scope=oob&grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            return accessTokenRequest;
        }
        private string CreateAuthorizationBase64() 
        {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{configs.GetNetClientId}:{configs.GetNetClientSecrete}");
            var authorizationBase64 = Convert.ToBase64String(plainTextBytes);
            return authorizationBase64;
        }
        private HttpRequestMessage CreateTokenizationRequest(string accessToken, CardTokenizationRequest tokenizationRequest)
        {
            var json = JsonConvert.SerializeObject(tokenizationRequest);
            var httpBody = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(json.ToString());
            var accessTokenRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri(configs.GetNetCardTokenizationEntpoint),
                Method = HttpMethod.Post,
                Headers =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", accessToken),
                },
                Content = httpBody,
            };
            accessTokenRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            accessTokenRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            accessTokenRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            return accessTokenRequest;
        }
        #endregion
    }
}
