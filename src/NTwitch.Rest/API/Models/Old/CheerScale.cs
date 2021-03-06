﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace NTwitch.Rest.API
{
    internal class CheerScale
    {
        [JsonProperty("animated")]
        public Dictionary<double, string> Animated { get; set; }
        [JsonProperty("static")]
        public Dictionary<double, string> Static { get; set; }
    }
}
