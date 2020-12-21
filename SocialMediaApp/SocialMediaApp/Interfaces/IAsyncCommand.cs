// <copyright file="IAsyncCommand.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SocialMediaApp.Interfaces
{
    /// <summary>
    /// IAsyncCommand.
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// Execute Async.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        Task ExecuteAsync();

        /// <summary>
        /// Can execute Command.
        /// </summary>
        /// <returns>Boolean.</returns>
        bool CanExecute();
    }

    /// <summary>
    /// IAsyncCommand.
    /// </summary>
    /// <typeparam name="T">Type of Command.</typeparam>
    public interface IAsyncCommand<T> : ICommand
    {
        /// <summary>
        /// Execute Async.
        /// </summary>
        /// <param name="parameter">parameter.</param>
        /// <returns><see cref="Task"/>.</returns>
        Task ExecuteAsync(T parameter);

        /// <summary>
        /// Can Execute.
        /// </summary>
        /// <param name="parameter">parameter.</param>
        /// <returns>Bool.</returns>
        bool CanExecute(T parameter);
    }
}
