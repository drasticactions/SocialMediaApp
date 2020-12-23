// <copyright file="App.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Autofac;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialMediaApp
{
    /// <summary>
    /// Application.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Autofac Container.
        /// </summary>
#pragma warning disable CA2211 // Non-constant fields should not be visible
#pragma warning disable SA1401 // Fields should be private
        public static IContainer Container;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="builder">Container Builder.</param>
        public App(ContainerBuilder builder)
        {
            Device.SetFlags(new string[] { "MediaElement_Experimental", "Shell_UWP_Experimental", "AppTheme_Experimental", "CollectionView_Experimental", "Shapes_Experimental" });
            this.InitializeComponent();
            Container = SocialMediaAppContainer.BuildContainer(builder);
            var database = Container.Resolve<IDatabase>();
            var platform = Container.Resolve<IPlatformProperties>();
            var navigation = Container.Resolve<INavigationHandler>();
            var settings = database.GetAppSettings();

            // If we're using the default system settings.
            if (settings.UseSystemThemeSettings)
            {
                if (platform.IsDarkTheme)
                {
                    ResourcesHelper.SetDarkMode();
                }
                else
                {
                    ResourcesHelper.SetLightMode();
                }
            }
            else
            {
                if (settings.CustomTheme != Core.Entities.Settings.AppCustomTheme.None)
                {
                    ResourcesHelper.SetCustomTheme(settings.CustomTheme);
                }
                else
                {
                    if (settings.UseDarkMode)
                    {
                        ResourcesHelper.SetDarkMode();
                    }
                    else
                    {
                        ResourcesHelper.SetLightMode();
                    }
                }
            }

            if (database.IsUserLoggedIn)
            {
                navigation.SetMainAppPage();
            }
            else
            {
                navigation.PushPageAsync(new LoginPage());
            }
        }

        /// <inheritdoc/>
        protected override void OnStart()
        {
        }

        /// <inheritdoc/>
        protected override void OnSleep()
        {
        }

        /// <inheritdoc/>
        protected override void OnResume()
        {
        }
    }
}
