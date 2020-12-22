// <copyright file="IFeedManager.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Core.Entities.Posts;

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
        /// <returns>List of Posts.</returns>
        Task<List<Post>> GetMainFeedPostsAsync();
    }
}
