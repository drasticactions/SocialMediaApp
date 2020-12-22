// <copyright file="MainFeedViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaApp.Interfaces;

namespace SocialMediaApp.ViewModels
{
    /// <summary>
    /// Main Feed View Model.
    /// </summary>
    public class MainFeedViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainFeedViewModel"/> class.
        /// </summary>
        /// <param name="database">Database.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        public MainFeedViewModel(IDatabase database, IErrorHandler error, INavigationHandler navigation)
            : base(database, error, navigation)
        {
            this.Title = "Main Feed";
        }
    }
}
