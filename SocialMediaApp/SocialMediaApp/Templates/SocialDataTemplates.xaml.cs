// <copyright file="SocialDataTemplates.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialMediaApp.Templates
{
    /// <summary>
    /// Social App Data Templates.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialDataTemplates : ResourceDictionary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SocialDataTemplates"/> class.
        /// </summary>
        public SocialDataTemplates()
        {
            this.InitializeComponent();
        }
    }
}