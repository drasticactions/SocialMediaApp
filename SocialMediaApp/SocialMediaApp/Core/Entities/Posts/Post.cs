// <copyright file="Post.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaApp.Core.Entities.Users;

namespace SocialMediaApp.Core.Entities.Posts
{
    /// <summary>
    /// Social Media Post.
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user who made the post.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the text of the post.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the images attached to the post.
        /// </summary>
        public List<string> Images { get; set; }

        /// <summary>
        /// Gets a value indicating whether there are images attached to the post.
        /// </summary>
        public bool HasImages => this.Images != null && this.Images.Count > 0;

        /// <summary>
        /// Gets or sets the total number of reposts.
        /// </summary>
        public int Reposts { get; set; }

        /// <summary>
        /// Gets or sets the total number of replies.
        /// </summary>
        public int Replies { get; set; }

        /// <summary>
        /// Gets or sets the time the post was created.
        /// </summary>
        public DateTime PostedOn { get; set; }
    }
}
