// <copyright file="HasAttachmentsConverter.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MapleFedNet.Model;
using Xamarin.Forms;

namespace SocialMediaApp.Tools.Converters
{
    /// <summary>
    /// Has Attachments Converter.
    /// </summary>
    public class HasAttachmentsConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<Attachment> amts)
            {
                return amts.Any();
            }

            return false;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
