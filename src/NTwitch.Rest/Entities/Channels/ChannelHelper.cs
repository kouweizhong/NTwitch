﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTwitch.Rest
{
    internal static class ChannelHelper
    {
        public static async Task<IEnumerable<RestPost>> GetPostsAsync(ChannelBase channel, int comments, PageOptions options)
        {
            var request = new RequestOptions();
            request.Parameters.Add("comments", comments);
            request.Parameters.Add("limit", options?.Limit);
            request.Parameters.Add("offset", options?.Offset);

            string json = await channel.Client.ApiClient.SendAsync("GET", "feed/" + channel.Id + "/posts", request).ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<IEnumerable<string>>(json, new TwitchConverter("posts"));
            return items.Select(x => RestPost.Create(channel.Client, x));
        }

        public static async Task<RestClip> GetClipAsync(ChannelBase channel, string id)
        {
            var json = await channel.Client.ApiClient.SendAsync("GET", "clips/" + channel.Name + "/" + id).ConfigureAwait(false);
            return RestClip.Create(channel.Client, json);
        }

        public static async Task<IEnumerable<RestClip>> GetTopClipsAsync(ChannelBase channel, string game, VideoPeriod period, bool istrending, PageOptions options)
        {
            var request = new RequestOptions();
            request.Parameters.Add("channel", channel.Name);
            request.Parameters.Add("game", game);
            request.Parameters.Add("period", Enum.GetName(typeof(VideoPeriod), period).ToLower());
            request.Parameters.Add("trending", istrending);
            request.Parameters.Add("limit", options?.Limit);
            request.Parameters.Add("offset", options?.Offset);

            string json = await channel.Client.ApiClient.SendAsync("GET", "clips/top", request).ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<IEnumerable<string>>(json, new TwitchConverter("clips"));
            return items.Select(x => RestClip.Create(channel.Client, x));
        }

        public static async Task<IEnumerable<RestClip>> GetFollowedClipsAsync(ChannelBase channel, bool istrending = false, int limit = 10)
        {
            var request = new RequestOptions();
            request.Parameters.Add("trending", istrending);
            request.Parameters.Add("limit", limit);

            string json = await channel.Client.ApiClient.SendAsync("GET", "clips/followed", request).ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<IEnumerable<string>>(json, new TwitchConverter("clips"));
            return items.Select(x => RestClip.Create(channel.Client, x));
        }

        public static Task UnfollowAsync(ChannelBase channel)
        {
            throw new NotImplementedException();
        }

        public static Task FollowAsync(ChannelBase channel, bool notify)
        {
            throw new NotImplementedException();
        }

        public static async Task<RestPost> GetPostAsync(ChannelBase channel, ulong id, int comments)
        {
            var request = new RequestOptions();
            request.Parameters.Add("comments", comments);

            string json = await channel.Client.ApiClient.SendAsync("GET", "feed/" + channel.Id + "/posts/" + id, request).ConfigureAwait(false);
            return RestPost.Create(channel.Client, json);
        }
        
        public static async Task<IEnumerable<RestUserFollow>> GetFollowersAsync(ChannelBase channel, SortDirection direction, PageOptions options)
        {
            var request = new RequestOptions();
            request.Parameters.Add("direction", Enum.GetName(typeof(SortDirection), direction).ToLower());
            request.Parameters.Add("limit", options?.Limit);
            request.Parameters.Add("offset", options?.Offset);

            string json = await channel.Client.ApiClient.SendAsync("GET", "channels/" + channel.Id + "/followers", request).ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<IEnumerable<string>>(json, new TwitchConverter("follows"));
            return items.Select(x => RestUserFollow.Create(channel.Client, x));
        }

        public static Task<IEnumerable<RestEmote>> GetEmotesAsync(ChannelBase channel)
        {
            throw new NotImplementedException();
        }

        public static Task<IEnumerable<RestTeam>> GetTeamsAsync(ChannelBase channel)
        {
            throw new NotImplementedException();
        }

        public static Task<RestEmoteSet> GetEmoteSetAsync(ChannelBase channel, ulong setid)
        {
            throw new NotImplementedException();
        }

        public static Task<IEnumerable<RestVideo>> GetVideosAsync(ChannelBase channel, string language, SortMode sort, BroadcastType type, PageOptions options)
        {
            throw new NotImplementedException();
        }

        public static Task<IEnumerable<RestEmoteSet>> GetEmoteSetAsync(ChannelBase channel)
        {
            throw new NotImplementedException();
        }

        public static Task<IEnumerable<RestBadges>> GetBadgesAsync(ChannelBase channel)
        {
            throw new NotImplementedException();
        }
        
        //
        // SelfChannel
        //

        public static Task<RestPost> CreatePostAsync(RestSelfChannel channel, Action<CreatePostParams> args)
        {
            throw new NotImplementedException();
        }

        public static Task<RestPost> DeletePostAsync(RestSelfChannel channel, ulong postid)
        {
            throw new NotImplementedException();
        }

        public static Task<IEnumerable<RestUser>> GetEditorsAsynC(RestSelfChannel channel)
        {
            throw new NotImplementedException();
        }

        public static async Task<IEnumerable<RestUserSubscription>> GetSubscribersAsync(RestSelfChannel channel, SortDirection direction, PageOptions options)
        {
            var request = new RequestOptions();
            request.Parameters.Add("direction", Enum.GetName(typeof(SortDirection), direction).ToLower());
            request.Parameters.Add("limit", options?.Limit);
            request.Parameters.Add("offset", options?.Offset);

            string json = await channel.Client.ApiClient.SendAsync("GET", "channels/" + channel.Id + "/subscriptions", request).ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<IEnumerable<string>>(json, new TwitchConverter("subscriptions"));
            return items.Select(x => RestUserSubscription.Create(channel.Client, x));
        }

        public static async Task<RestUserSubscription> GetSubscriberAsync(RestSelfChannel channel, ulong userid)
        {
            string json = await channel.Client.ApiClient.SendAsync("GET", "channels/" + channel.Id + "/subscriptions/" + userid).ConfigureAwait(false);
            return RestUserSubscription.Create(channel.Client, json);
        }

        public static Task StartCommercialAsync(RestSelfChannel restSelfChannel, int duration)
        {
            throw new NotImplementedException();
        }

        public static Task<RestSelfChannel> ResetStreamKeyAsync(RestSelfChannel channel)
        {
            throw new NotImplementedException();
        }

        public static Task<RestSelfChannel> ModifyAsync(RestSelfChannel channel, Action<ModifyChannelParams> args)
        {
            throw new NotImplementedException();
        }
    }
}
