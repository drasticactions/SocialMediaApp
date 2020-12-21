// <copyright file="AppDelegate.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Foundation;
using SocialMediaApp.Interfaces;
using UIKit;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace SocialMediaApp.iOS
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    /// <summary>
    /// The UIApplicationDelegate for the application. This class is responsible for launching the
    /// User Interface of the application, as well as listening (and optionally responding) to
    /// application events from iOS.
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        /// <summary>
        ///
        /// This method is invoked when the application has loaded and is ready to run. In this
        /// method you should instantiate the window, load the UI into it and then make the window
        /// visible.
        ///
        /// You have 17 seconds to return from this method, or iOS will terminate your application.
        ///
        /// </summary>
        /// <param name="app">UIApplication.</param>
        /// <param name="options">Dictionary.</param>
        /// <returns>Bool.</returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            var builder = new ContainerBuilder();
            builder.RegisterType<iOSPlatformProperties>().As<IPlatformProperties>();
            this.LoadApplication(new App(builder));

            return base.FinishedLaunching(app, options);
        }
    }
}
