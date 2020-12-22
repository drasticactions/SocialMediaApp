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
    public class UserAuth
    {
        /// <summary>
        /// Gets or sets the Users Auth.
        /// </summary>
        public MapleFedNet.Model.Auth Auth { get; set; }

        /// <summary>
        /// Gets or sets the currents users account.
        /// </summary>
        public MapleFedNet.Model.Account Account { get; set; }
    }
}
