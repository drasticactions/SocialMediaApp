﻿// <copyright file="SettingsPage.xaml.cs" company="Drastic Actions">
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
    /// Settings Page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPage"/> class.
        /// </summary>
        public SettingsPage()
        {
            this.InitializeComponent();
            this.BindingContext = App.Container.Resolve<SettingsViewModel>();
        }
    }
}