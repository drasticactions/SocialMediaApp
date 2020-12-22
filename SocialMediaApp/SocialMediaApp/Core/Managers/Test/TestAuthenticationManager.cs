// <copyright file="TestAuthenticationManager.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MapleFedNet.Model;
using SocialMediaApp.Core.Entities.Users;
using Tynamix.ObjectFiller;

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
                Filler<UserAuth> post = new Filler<UserAuth>();
                post.Setup()
                .SetupFor<Account>()
                .OnProperty(u => u.AvatarUrl).Use("https://picsum.photos/300");
                await Task.Delay(1500).ConfigureAwait(false);
                tcs.SetResult(post.Create());
            }).ConfigureAwait(false);
            return tcs.Task;
        }
    }
}
