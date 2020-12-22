// <copyright file="INavigationHandler.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialMediaApp.Interfaces
{
    /// <summary>
    /// Navigation Handler.
    /// </summary>
    public interface INavigationHandler
    {
        /// <summary>
        /// Display Alert to User.
        /// </summary>
        /// <param name="title">Title of message.</param>
        /// <param name="message">Message to user.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DisplayAlertAsync(string title, string message);

        /// <summary>
        /// Signout of all accounts.
        /// </summary>
        void Signout();

        /// <summary>
        /// Push Page to current navigation stack.
        /// If on tablet, pushes on top of Master.
        /// </summary>
        /// <param name="page">Page to navigate to.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task PushPageAsync(Page page);

        /// <summary>
        /// Sets the main page of the application.
        /// </summary>
        void SetMainAppPage();
    }
}
