// <copyright file="NavigationHandler.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SocialMediaApp.Tools
{
    /// <summary>
    /// Navigation Handler.
    /// </summary>
    public class NavigationHandler : INavigationHandler
    {
        /// <inheritdoc/>
        public Task DisplayAlertAsync(string title, string message)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert(title, message, "Close").ConfigureAwait(false));
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task PushPageAsync(Page page)
        {
            // If the main page of the app is null,
            // Set whatever we're pushing to be the main.
            if (App.Current.MainPage == null)
            {
                MainThread.BeginInvokeOnMainThread(() => App.Current.MainPage = page);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public void SetMainAppPage()
        {
            MainThread.BeginInvokeOnMainThread(() => App.Current.MainPage = new MainPage());
        }

        /// <inheritdoc/>
        public void Signout()
        {
            // TODO: Handle Database Removal.
            this.PushPageAsync(new LoginPage());
        }
    }
}
