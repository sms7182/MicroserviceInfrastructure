using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.SocialNetwork.SocialConfiguration.Telegram
{
    public class ChatBotRequest
    {
        [JsonIgnore]
        public string AccessToken { get; set; }

        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
