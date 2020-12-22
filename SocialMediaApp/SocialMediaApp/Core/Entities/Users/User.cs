// <copyright file="User.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaApp.Core.Entities.Users
{
    /// <summary>
    /// User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Avatar Link.
        /// </summary>
        public string AvatarLink { get; set; }

        /// <summary>
        /// Gets or sets the followers count.
        /// </summary>
        public int Followers { get; set; }

        /// <summary>
        /// Gets or sets the following count.
        /// </summary>
        public int Following { get; set; }
    }
}
