// <copyright file="MainMenuViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Pages;
using SocialMediaApp.Tools;
using Xamarin.Forms;

namespace SocialMediaApp.ViewModels
{
    /// <summary>
    /// Main Page View Model.
    /// </summary>
    public class MainMenuViewModel : BaseViewModel
    {
        private FlyoutPage flyoutPage;
        private MainMenuItem selectedItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuViewModel"/> class.
        /// </summary>
        /// <param name="database">Database.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        public MainMenuViewModel(IDatabase database, IErrorHandler error, INavigationHandler navigation)
            : base(database, error, navigation)
        {
            this.MainMenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem()
                {
                    Title = "Main Feed",
                    IconSource = string.Empty,
                    Page = new NavigationPage(new MainFeedPage()),
                },
                new MainMenuItem()
                {
                    Title = "Settings",
                    IconSource = string.Empty,
                    Page = new NavigationPage(new SettingsPage()),
                },
            };

            this.SelectedItem = this.MainMenuItems.First();
        }

        /// <summary>
        /// Gets the main menu items.
        /// </summary>
        public List<MainMenuItem> MainMenuItems { get; private set; }

        /// <summary>
        /// Gets or sets the selected main menu item.
        /// </summary>
        public MainMenuItem SelectedItem
        {
            get
            {
                return this.selectedItem;
            }

            set
            {
                if (this.selectedItem != value && value != null)
                {
                    this.selectedItem = value;
                    if (this.flyoutPage != null)
                    {
                        this.flyoutPage.Detail = this.selectedItem.Page;
                        this.flyoutPage.IsPresented = false;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the detail page to be navigated to.
        /// </summary>
        /// <param name="page">Page.</param>
        public void SetFlyoutPage(FlyoutPage page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            this.flyoutPage = page;
            if (this.SelectedItem != null)
            {
                this.flyoutPage.Detail = this.SelectedItem.Page;
            }
        }
    }
}
