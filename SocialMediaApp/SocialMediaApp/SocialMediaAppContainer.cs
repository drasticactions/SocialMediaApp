// <copyright file="SocialMediaAppContainer.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Autofac;
using SocialMediaApp.Core.Managers;
using SocialMediaApp.Core.Managers.Test;
using SocialMediaApp.Database;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Tools;
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
            builder.RegisterType<NavigationHandler>().As<INavigationHandler>().SingleInstance();
            builder.RegisterType<ErrorHandler>().As<IErrorHandler>().SingleInstance();
            builder.RegisterType<TestAuthenticationManager>().As<IAuthenticationManager>();
            builder.RegisterType<SettingsViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MainMenuViewModel>();
            builder.RegisterType<MainFeedViewModel>();

            return builder.Build();
        }
    }
}
