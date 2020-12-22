// <copyright file="LoginPage.xaml.cs" company="Drastic Actions">
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
    /// Login page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
            this.InitializeComponent();
            this.BindingContext = App.Container.Resolve<LoginViewModel>();
        }
    }
}