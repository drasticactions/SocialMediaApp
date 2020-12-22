// <copyright file="TestAuthenticationManager.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Core.Entities.Users;

namespace SocialMediaApp.Core.Managers.Test
{
    /// <summary>
    /// Test Authentication Manager.
    /// </summary>
    public class TestAuthenticationManager : IAuthenticationManager
    {
        /// <inheritdoc/>
        public Task<UserAuth> LoginAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<UserAuth>();
            Task.Run(async () =>
            {
                await Task.Delay(1500).ConfigureAwait(false);
                tcs.SetResult(new UserAuth() { Id = Guid.NewGuid(), Followers = 420, Following = 69, Username = username, AvatarLink = "https://picsum.photos/300", OauthToken = string.Empty, RefreshToken = string.Empty });
            }).ConfigureAwait(false);
            return tcs.Task;
        }
    }
}
