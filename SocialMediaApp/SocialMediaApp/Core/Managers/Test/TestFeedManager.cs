// <copyright file="TestFeedManager.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapleFedNet.Common;
using MapleFedNet.Model;
using SocialMediaApp.Core.Entities.Users;
using Tynamix.ObjectFiller;

namespace SocialMediaApp.Core.Managers.Test
{
    /// <summary>
    /// Test Feed Manager.
    /// </summary>
    public class TestFeedManager : IFeedManager
    {
        private Filler<Status> post;
        private Filler<Attachment> attachment;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestFeedManager"/> class.
        /// </summary>
        public TestFeedManager()
        {
            this.attachment = new Filler<Attachment>();
            this.attachment.Setup()
                .OnProperty(n => n.Type).Use(new RandomListItem<string>("image", "gifv", "video", "audio"));
            this.post = new Filler<Status>();
            this.post.Setup()
                .OnProperty(n => n.Content).Use(new Lipsum(LipsumFlavor.LoremIpsum, 10, 20, 1, 3))
                .OnProperty(n => n.MediaAttachments).Use(() => this.GenerateAttachments(new Random().Next(0, 4)))
                .SetupFor<Account>()
                .OnProperty(n => n.StaticAvatarUrl).Use("https://picsum.photos/300");
        }

        /// <inheritdoc/>
        public async Task<MastodonList<Status>> GetMainFeedPostsAsync(IMastodonCredentials credentials, string maxId = "", string sinceId = "", bool onlyMedia = false, int limit = 20)
        {
            var list = this.post.Create(limit).ToList();
            var mastodonList = new MastodonList<Status>();
            mastodonList.AddRange(list);
            return mastodonList;
        }

        private List<Attachment> GenerateAttachments(int number)
        {
            var list = new List<Attachment>();
            list.AddRange(this.attachment.Create(number));
            foreach (var item in list)
            {
                switch (item.Type)
                {
                    case "audio":
                        item.Url = "https://files.mastodon.social/media_attachments/files/021/165/404/original/a31a4a46cd713cd2.mp3";
                        item.PreviewUrl = "https://files.mastodon.social/media_attachments/files/021/165/404/small/a31a4a46cd713cd2.mp3";
                        break;
                    case "video":
                        item.Url = "https://files.mastodon.social/media_attachments/files/022/546/306/original/dab9a597f68b9745.mp4";
                        item.PreviewUrl = "https://files.mastodon.social/media_attachments/files/022/546/306/small/dab9a597f68b9745.png";
                        break;
                    case "gifv":
                        item.Url = "https://files.mastodon.social/media_attachments/files/021/130/559/original/bc84838f77991326.mp4";
                        item.PreviewUrl = "https://files.mastodon.social/media_attachments/files/021/130/559/small/bc84838f77991326.png";
                        break;
                    case "image":
                        item.Url = "https://picsum.photos/450/450";
                        item.PreviewUrl = "https://picsum.photos/450/450";
                        break;
                }
            }

            return list;
        }
    }
}
