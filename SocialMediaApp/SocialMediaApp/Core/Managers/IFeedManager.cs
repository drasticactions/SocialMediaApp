// <copyright file="IFeedManager.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MapleFedNet.Common;
using MapleFedNet.Model;

namespace SocialMediaApp.Core.Managers
{
    /// <summary>
    /// IFeedManager.
    /// </summary>
    public interface IFeedManager
    {
        /// <summary>
        /// Get Main Feed Posts.
        /// </summary>
        /// <param name="credentials">Mastodon Credentials.</param>
        /// <param name="maxId">Max Post Id.</param>
        /// <param name="sinceId">Since Post Id.</param>
        /// <param name="onlyMedia">Only return media.</param>
        /// <param name="limit">Amount of posts to return.</param>
        /// <returns>List of Posts.</returns>
        Task<MastodonList<Status>> GetMainFeedPostsAsync(IMastodonCredentials credentials, string maxId = "", string sinceId = "", bool onlyMedia = false, int limit = 20);
    }
}
