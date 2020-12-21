// <copyright file="Main.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using UIKit;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace SocialMediaApp.iOS
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    /// <summary>
    /// iOS Application.
    /// </summary>
#pragma warning disable SA1649 // File name should match first type name
    public class Application
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// This is the main entry point of the application.
        /// </summary>
        /// <param name="args">App Arguments.</param>
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
