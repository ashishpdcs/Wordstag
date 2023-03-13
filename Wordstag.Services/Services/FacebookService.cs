using Wordstag.Services.Entities.User;
using Wordstag.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Services
{
    public class FacebookService : IFacebookService
    {
        private const string TokenValidationUrl="https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}&grant_type=client_credentials";
        private const string UserInfoUrl = "https://graph.facebook.com/me?fields=first_name,last_name,picture,email&access_token={0}";
        private readonly FacebookAuthSettings _facebookAuthSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        public FacebookService(FacebookAuthSettings facebookAuthSettings, IHttpClientFactory httpClientFactory)
        {
            _facebookAuthSettings = facebookAuthSettings;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
        {
            var formattedUrl = string.Format(TokenValidationUrl, accessToken, _facebookAuthSettings.AppId,
             _facebookAuthSettings.AppSecret);
            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            result.EnsureSuccessStatusCode();
            var responseAsString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FacebookTokenValidationResult>(responseAsString);
        }
        //public async Task<FaceBookUserInfoResult> GetUserInfoAsync(string accessToken)
        //{
        //    var formattedUrls = string.Format(UserInfoUrl, accessToken, _facebookAuthSettings.AppId,
        //     _facebookAuthSettings.AppSecret);
        //    var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrls);
        //    result.EnsureSuccessStatusCode();
        //    var responseAsString = await result.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<FaceBookUserInfoResult>(responseAsString);


        //}
    }
}
