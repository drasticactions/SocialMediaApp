// <copyright file="TaskUtilities.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using SocialMediaApp.Interfaces;

namespace SocialMediaApp.Tools
{
    /// <summary>
    /// Task Utilities.
    /// </summary>
    public static class TaskUtilities
    {
        /// <summary>
        /// Fire and Forget Async Command.
        /// </summary>
        /// <param name="task">Task to fire async.</param>
        /// <param name="handler">Error Handler.</param>
#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
#pragma warning disable CA1030 // Use events where appropriate
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
#pragma warning restore CA1030 // Use events where appropriate
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
        {
            try
            {
                if (task == null)
                {
                    throw new ArgumentNullException(nameof(task));
                }

                await task.ConfigureAwait(false);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                handler?.HandleError(ex);
            }
        }
    }
}
