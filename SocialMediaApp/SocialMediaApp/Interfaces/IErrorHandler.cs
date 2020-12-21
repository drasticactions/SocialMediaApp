// <copyright file="IErrorHandler.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;

namespace SocialMediaApp.Interfaces
{
    /// <summary>
    /// Error Handler.
    /// </summary>
    public interface IErrorHandler
    {
        /// <summary>
        /// Handle error in UI.
        /// </summary>
        /// <param name="ex">Exception being thrown.</param>
        void HandleError(Exception ex);
    }
}
