// <copyright file="MainFeedPage.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SocialMediaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialMediaApp.Pages
{
    /// <summary>
    /// Main Feed Page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFeedPage : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainFeedPage"/> class.
        /// </summary>
        public MainFeedPage()
        {
            this.InitializeComponent();
            this.BindingContext = App.Container.Resolve<MainFeedViewModel>();
        }
    }
}