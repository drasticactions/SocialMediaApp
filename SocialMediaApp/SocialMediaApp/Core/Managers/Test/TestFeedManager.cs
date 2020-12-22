// <copyright file="TestFeedManager.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Core.Entities.Posts;
using SocialMediaApp.Core.Entities.Users;
using Tynamix.ObjectFiller;

namespace SocialMediaApp.Core.Managers.Test
{
    /// <summary>
    /// Test Feed Manager.
    /// </summary>
    public class TestFeedManager : IFeedManager
    {
        /// <inheritdoc/>
        public async Task<List<Post>> GetMainFeedPostsAsync()
        {
            Filler<Post> post = new Filler<Post>();
            post.Setup()
                .OnProperty(n => n.Id).Use(Guid.NewGuid())
                .OnProperty(n => n.Text).Use(new Lipsum(LipsumFlavor.LoremIpsum, 30))
                .OnProperty(n => n.Images).Use(() => GenerateImages(new Random().Next(0, 4)))
                .SetupFor<User>()
                .OnProperty(n => n.AvatarLink).Use("https://picsum.photos/300");

            return post.Create(30).ToList();
        }

        private static List<string> GenerateImages(int number)
        {
            var list = new List<string>();
            for (var i = 0; i < number; i++)
            {
                list.Add("https://picsum.photos/500/500");
            }

            return list;
        }
    }
}
