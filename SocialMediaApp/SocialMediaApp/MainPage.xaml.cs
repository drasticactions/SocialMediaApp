// <copyright file="MainPage.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SocialMediaApp.Pages;
using SocialMediaApp.ViewModels;
using Xamarin.Forms;

namespace SocialMediaApp
{
    /// <summary>
    /// Main entrance page.
    /// </summary>
    public partial class MainPage : FlyoutPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.Detail = new ContentPage();
            var vm = App.Container.Resolve<MainMenuViewModel>();
            vm.SetFlyoutPage(this);
            this.Flyout = new MainMenuPage(vm);
        }
    }
}
