using System;
using ChatApplicatie.Model;
using ChatApplicatie.Resources;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ChatApplicatie.Settings;

namespace ChatApplicatie
{
    public class ChatMessageApi
    {

        private readonly HttpClient _httpClient;

        public ChatMessageApi(AppSettings appSettings)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(appSettings.ApiBaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        //Channels
        //Get Channels
        public async Task<IList<string>> FindAsyncChannels()
        {
            
            var response = await _httpClient.GetAsync(ChatApplicatieHttp.BaseChannelHttp);
            
                return await response.Content.ReadAsAsync<IList<string>>();
            
           
        }
        //Post Channel
        public async Task<string> CreateChannel(string channel)
        {
            var path = ChatApplicatieHttp.BaseChannelHttp + $"?channel={channel}";
            var response = await _httpClient.PostAsJsonAsync(path, typeof(ChatMessageRequest));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<string>();
            }

            return null;
        }

    }
}
