// <copyright file="UserAuth.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaApp.Core.Entities.Users
{
    /// <summary>
    /// User Auth.
    /// </summary>
    public class UserAuth : User
    {
        /// <summary>
        /// Gets or sets the Oauth Token.
        /// </summary>
        public string OauthToken { get; set; }

        /// <summary>
        /// Gets or sets the Refresh Token.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
