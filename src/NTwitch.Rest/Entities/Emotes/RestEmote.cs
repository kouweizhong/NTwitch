﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace NTwitch.Rest
{
    public class RestEmote : EmoteBase
    {
        [JsonProperty("")]
        public IEnumerable<RestEmoteImage> Images { get; private set; }
        [JsonProperty("")]
        public string Name { get; private set; }

        public RestEmote(TwitchRestClient client) : base(client) { }

        public static RestEmote Create(BaseRestClient client, string json)
        {
            var emote = new RestEmote(client as TwitchRestClient);
            JsonConvert.PopulateObject(json, emote);
            return emote;
        }
    }
}
