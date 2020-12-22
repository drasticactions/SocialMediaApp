// <copyright file="IAuthenticationManager.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Core.Entities.Users;

namespace SocialMediaApp.Core.Managers
{
    /// <summary>
    /// IAuthenticationManager.
    /// </summary>
    public interface IAuthenticationManager
    {
        /// <summary>
        /// Send Login Information.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>UserAuth.</returns>
        Task<UserAuth> LoginAsync(string username, string password);
    }
}
