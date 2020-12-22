// <copyright file="MainMenuPage.xaml.cs" company="Drastic Actions">
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
    /// Main Menu Page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuPage"/> class.
        /// </summary>
        public MainMenuPage(MainMenuViewModel vm)
        {
            this.InitializeComponent();
            this.BindingContext = vm;
        }
    }
}