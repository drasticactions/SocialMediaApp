// <copyright file="UWPButton.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.UWP.Renderers;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(UWPButton))]

namespace SocialMediaApp.UWP.Renderers
{
    /// <summary>
    /// UWP Button.
    /// </summary>
    public class UWPButton : ButtonRenderer
    {
        /// <inheritdoc/>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                var style = SocialMediaApp.UWP.App.Current.Resources["ButtonStyle"] as Windows.UI.Xaml.Style;
                this.Control.Style = style;
            }
        }
    }
}
