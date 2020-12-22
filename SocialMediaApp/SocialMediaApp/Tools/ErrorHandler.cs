// <copyright file="ErrorHandler.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaApp.Interfaces;
using Xamarin.Essentials;

namespace SocialMediaApp.Tools
{
    /// <summary>
    /// Error Handler.
    /// </summary>
    public class ErrorHandler : IErrorHandler
    {
        private INavigationHandler navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHandler"/> class.
        /// </summary>
        /// <param name="navigation">Awful Navigation.</param>
        public ErrorHandler(INavigationHandler navigation)
        {
            this.navigation = navigation;
        }

        /// <inheritdoc/>
        public void HandleError(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            string errorMessage = $"An {exception.GetType().FullName} was thrown: {exception.Message} @ {exception.StackTrace}";
            this.navigation.DisplayAlertAsync("Error", errorMessage);
        }
    }
}
