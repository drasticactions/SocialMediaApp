﻿// <copyright file="SettingsViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialMediaApp.Core.Entities.Settings;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Tools;

namespace SocialMediaApp.ViewModels
{
    /// <summary>
    /// Settings View Model.
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        private AppSettings appSettings;
        private IPlatformProperties properties;
        private IDatabase database;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
        /// </summary>
        /// <param name="properties">Platform Properties.</param>
        /// <param name="database">Database.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        public SettingsViewModel(IPlatformProperties properties, IDatabase database, IErrorHandler error, INavigationHandler navigation)
            : base(database, error, navigation)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.database = database;
            this.properties = properties;
            this.appSettings = database.GetAppSettings();
            this.Title = "Settings";
        }

        /// <summary>
        /// Gets the theme names.
        /// </summary>
        public List<string> CustomThemeNames
        {
            get
            {
                return Enum.GetNames(typeof(AppCustomTheme)).Select(b => b).ToList();
            }
        }

        /// <summary>
        /// Gets or sets the device color theme.
        /// </summary>
        public AppCustomTheme CustomTheme
        {
            get
            {
                return this.appSettings.CustomTheme;
            }

            set
            {
                this.appSettings.CustomTheme = value;
                this.OnPropertyChanged(nameof(this.CustomTheme));
                this.database.SaveAppSettings(this.appSettings);
                this.SetTheme();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the system settings for themes,
        /// or let the user override them.
        /// </summary>
        public bool UseSystemThemeSettings
        {
            get
            {
                return this.appSettings.UseSystemThemeSettings;
            }

            set
            {
                this.appSettings.UseSystemThemeSettings = value;
                if (value)
                {
                    this.UseDarkMode = this.properties.IsDarkTheme;
                    this.CustomTheme = AppCustomTheme.None;
                }

                this.OnPropertyChanged(nameof(this.UseSystemThemeSettings));
                this.OnPropertyChanged(nameof(this.CanOverrideThemeSettings));
                this.database.SaveAppSettings(this.appSettings);
                this.SetTheme();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the system settings for themes,
        /// or let the user override them.
        /// </summary>
        public bool UseDarkMode
        {
            get
            {
                return this.appSettings.UseDarkMode;
            }

            set
            {
                this.appSettings.UseDarkMode = value;
                this.OnPropertyChanged(nameof(this.UseDarkMode));
                this.database.SaveAppSettings(this.appSettings);
                this.SetTheme();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user can override theme settings.
        /// </summary>
        public bool CanOverrideThemeSettings => !this.UseSystemThemeSettings;

        private void SetTheme()
        {
            var darkMode = this.UseSystemThemeSettings ? this.properties.IsDarkTheme : this.UseDarkMode;
            if (!this.UseSystemThemeSettings && this.appSettings.CustomTheme != AppCustomTheme.None)
            {
                ResourcesHelper.SetCustomTheme(this.appSettings.CustomTheme);
                return;
            }

            if (darkMode)
            {
                ResourcesHelper.SetDarkMode();
            }
            else
            {
                ResourcesHelper.SetLightMode();
            }
        }
    }
}
