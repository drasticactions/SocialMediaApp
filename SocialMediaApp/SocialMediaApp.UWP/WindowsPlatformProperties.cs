// <copyright file="WindowsPlatformProperties.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using SocialMediaApp.Interfaces;

namespace SocialMediaApp.UWP
{
    /// <summary>
    /// Windows Platform Properties.
    /// </summary>
    public class WindowsPlatformProperties : IPlatformProperties
    {
        /// <inheritdoc/>
        public bool IsDarkTheme
        {
            get
            {
                var uiSettings = new Windows.UI.ViewManagement.UISettings();
                var color = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Background).ToString(System.Globalization.CultureInfo.InvariantCulture);
                return color switch
                {
                    "#FF000000" => true,
                    "#FFFFFFFF" => false,
                    _ => false,
                };
            }
        }

        /// <inheritdoc/>
        public string DatabasePath => System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "awful.db");
    }
}
