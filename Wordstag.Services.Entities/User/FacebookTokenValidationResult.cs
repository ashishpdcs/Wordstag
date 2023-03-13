using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Entities.User
{
    public class FacebookTokenValidationResult
    {
        
        [JsonProperty("data")]
        public FacebookData? Data { get; set; }
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }
        [JsonProperty("last_name")]
        public string? LastName { get; set; }
        [JsonProperty("picture")]
        public Picture? Picture { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
    public class FacebookData
    {
        [JsonProperty("app_id")]
        public string? AppId { get; set; }
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("application")]
        public string? Application { get; set; }

        [JsonProperty("data_access_expires_at")]

        public long DataAccessExpiresAt { get; set; }

        [JsonProperty("expires_at")]
        public long ExpiresAt { get; set; }
        [JsonProperty("is_valid")]
        public bool Isvalid { get; set; }
        [JsonProperty("scopes")]
        public string[]? Scopes { get; set; }
        [JsonProperty("user_id")]
        public string? UserId { get; set; }
    }
    public class FaceBookUserInfoResult
    {
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }
        [JsonProperty("last_name")]
        public string? LastName { get; set; }
        [JsonProperty("picture")]
        public Picture? Picture { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
    public class Picture
    {
        [JsonProperty("data")]
        public Data? Data { get; set; }
    }


    public class Data
    {
        [JsonProperty("height")]
        public long Height { get; set; }
        [JsonProperty("is_silhouette")]
        public bool Issilhouette { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("width")]
        public long Width { get; set; }
    }
}

