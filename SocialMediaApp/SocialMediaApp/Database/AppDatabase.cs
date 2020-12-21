// <copyright file="AppDatabase.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using SocialMediaApp.Core.Entities.Settings;
using SocialMediaApp.Interfaces;

namespace SocialMediaApp.Database
{
    /// <summary>
    /// App Database.
    /// </summary>
    public class AppDatabase : IDatabase, IDisposable
    {
        private const string OptionsDB = nameof(OptionsDB);
        private readonly IPlatformProperties properties;
        private readonly LiteDatabase db;
        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDatabase"/> class.
        /// </summary>
        /// <param name="properties">Platform Properties.</param>
        public AppDatabase(IPlatformProperties properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            this.properties = properties;
            this.db = new LiteDatabase(properties.DatabasePath + ".litedb");
        }

        /// <inheritdoc/>
        public AppSettings GetAppSettings()
        {
            var collection = this.db.GetCollection<AppSettings>(OptionsDB);
            var appSettings = collection.FindAll().ToList();
            var appSetting = appSettings.FirstOrDefault();
            if (appSetting != null)
            {
                return appSetting;
            }

            appSetting = new AppSettings() { UseDarkMode = this.properties.IsDarkTheme };
            return appSetting;
        }

        /// <inheritdoc/>
        public bool SaveAppSettings(AppSettings appSettings)
        {
            var collection = this.db.GetCollection<AppSettings>(OptionsDB);
            return collection.Upsert(appSettings);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose DB.
        /// </summary>
        /// <param name="disposing">Is Disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            if (disposing)
            {
                this.db.Dispose();
            }

            this.isDisposed = true;
        }
    }
}
