// <copyright file="IDatabase.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaApp.Core.Entities.Settings;

namespace SocialMediaApp.Interfaces
{
    /// <summary>
    /// IDatabase.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Gets app settings.
        /// </summary>
        /// <returns>App Settings.</returns>
        AppSettings GetAppSettings();

        /// <summary>
        /// Save App Settings.
        /// </summary>
        /// <param name="appSettings">App Settings.</param>
        /// <returns>Bool if saved.</returns>
        bool SaveAppSettings(AppSettings appSettings);
    }
}
