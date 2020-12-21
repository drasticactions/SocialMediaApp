// <copyright file="SocialMediaAppContainer.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Autofac;
using SocialMediaApp.Database;
using SocialMediaApp.Interfaces;
using SocialMediaApp.ViewModels;

namespace SocialMediaApp
{
    /// <summary>
    /// Social Media App Container.
    /// </summary>
    public static class SocialMediaAppContainer
    {
        /// <summary>
        /// Builds SocialMediaApp Container.
        /// </summary>
        /// <param name="builder">Platform Specific Container.</param>
        /// <returns>IContainer.</returns>
        public static IContainer BuildContainer(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.RegisterType<AppDatabase>().As<IDatabase>().SingleInstance();
            builder.RegisterType<SettingsViewModel>();

            return builder.Build();
        }
    }
}
