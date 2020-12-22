// <copyright file="MainFeedViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapleFedNet.Model;
using SocialMediaApp.Core.Managers;
using SocialMediaApp.Interfaces;

namespace SocialMediaApp.ViewModels
{
    /// <summary>
    /// Main Feed View Model.
    /// </summary>
    public class MainFeedViewModel : BaseViewModel
    {
        IFeedManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainFeedViewModel"/> class.
        /// </summary>
        /// <param name="manager">Feed Manager.</param>
        /// <param name="database">Database.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        public MainFeedViewModel(IFeedManager manager, IDatabase database, IErrorHandler error, INavigationHandler navigation)
            : base(database, error, navigation)
        {
            this.manager = manager;
            this.Posts = new ObservableCollection<Status>();
            this.Title = "Main Feed";
        }

        /// <summary>
        /// Gets the posts on the page.
        /// </summary>
        public ObservableCollection<Status> Posts { get; internal set; }

        /// <summary>
        /// Get Main Feed Posts.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task GetMainFeedPostsAsync()
        {
            this.IsBusy = true;
            var posts = await this.manager.GetMainFeedPostsAsync(null).ConfigureAwait(false);
            foreach (var post in posts)
            {
                this.Posts.Add(post);
            }

            this.IsBusy = false;
        }

        /// <inheritdoc/>
        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync().ConfigureAwait(false);
            if (!this.Posts.Any())
            {
                await this.GetMainFeedPostsAsync().ConfigureAwait(false);
            }
        }
    }
}
