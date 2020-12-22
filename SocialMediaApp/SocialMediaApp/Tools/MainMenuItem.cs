// <copyright file="MainMenuItem.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SocialMediaApp.Tools
{
    /// <summary>
    /// Main Menu Item.
    /// </summary>
    public class MainMenuItem
    {
        /// <summary>
        /// Gets or sets the title for the main menu.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the icon source.
        /// </summary>
        public string IconSource { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public Page Page { get; set; }
    }
}
