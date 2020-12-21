// <copyright file="AppSettings.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaApp.Core.Entities.Settings
{
    /// <summary>
    /// App Custom Themes.
    /// </summary>
    public enum AppCustomTheme
    {
        /// <summary>
        /// No Theme.
        /// </summary>
        None,

        /// <summary>
        /// OLED Theme.
        /// </summary>
        OLED,
    }

    /// <summary>
    /// App Settings.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the AppSettings Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the system theme settings.
        /// </summary>
        public bool UseSystemThemeSettings { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to use Dark Mode.
        /// Ignored if <see cref="UseSystemThemeSettings"/> is set to true.
        /// </summary>
        public bool UseDarkMode { get; set; }

        /// <summary>
        /// Gets or sets the apps custom theme.
        /// Defaults to None.
        /// </summary>
        public AppCustomTheme CustomTheme { get; set; } = AppCustomTheme.None;
    }
}
