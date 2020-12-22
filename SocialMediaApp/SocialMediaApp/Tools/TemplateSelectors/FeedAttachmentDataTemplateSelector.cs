// <copyright file="FeedAttachmentDataTemplateSelector.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using MapleFedNet.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SocialMediaApp.Tools.TemplateSelectors
{
    /// <summary>
    /// Renders data attachment in feed.
    /// </summary>
    public class FeedAttachmentDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the debug template.
        /// </summary>
        public DataTemplate DebugTemplate { get; set; }

        /// <summary>
        /// Gets or sets the image template.
        /// </summary>
        public DataTemplate ImageTemplate { get; set; }

        /// <summary>
        /// Gets or sets the gifv template.
        /// </summary>
        public DataTemplate GifvTemplate { get; set; }

        /// <summary>
        /// Gets or sets the audio template.
        /// </summary>
        public DataTemplate AudioTemplate { get; set; }

        /// <summary>
        /// Gets or sets the video template.
        /// </summary>
        public DataTemplate VideoTemplate { get; set; }

        /// <summary>
        /// Gets or sets the unknown template.
        /// </summary>
        public DataTemplate UnknownTemplate { get; set; }

        /// <inheritdoc/>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Attachment attachment)
            {
                switch (attachment.Type)
                {
                    case "image":
                        return this.ImageTemplate;
                    case "gifv":
                        return this.GifvTemplate;
                    case "video":
                        return this.VideoTemplate;
                    case "audio":
                        return this.AudioTemplate;
                    default:
                        return this.UnknownTemplate;
                }
            }

            return this.DebugTemplate;
        }
    }
}
