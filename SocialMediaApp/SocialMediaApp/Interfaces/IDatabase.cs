// <copyright file="IDatabase.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaApp.Core.Entities.Settings;
using SocialMediaApp.Core.Entities.Users;

namespace SocialMediaApp.Interfaces
{
    /// <summary>
    /// IDatabase.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Gets a value indicating whether there are logged in users.
        /// </summary>
        /// <returns>Bool.</returns>
        bool IsUserLoggedIn { get; }

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

        /// <summary>
        /// Gets the current logged in user.
        /// </summary>
        /// <returns>UserAuth.</returns>
        UserAuth GetLoggedInUser();

        /// <summary>
        /// Saves the current logged in user.
        /// </summary>
        /// <param name="userAuth">UserAuth.</param>
        /// <returns>Bool if saved.</returns>
        bool SaveLoggedInUser(UserAuth userAuth);
    }
}
