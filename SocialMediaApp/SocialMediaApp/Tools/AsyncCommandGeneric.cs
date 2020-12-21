// <copyright file="AsyncCommandGeneric.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SocialMediaApp.Interfaces;

namespace SocialMediaApp.Tools
{
    /// <summary>
    /// Async Command.
    /// </summary>
    /// <typeparam name="T">Generic Parameter.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public class AsyncCommand<T> : IAsyncCommand<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly Func<T, Task> execute;
        private readonly Func<T, bool> canExecute;
        private readonly IErrorHandler errorHandler;
        private bool isExecuting;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncCommand{T}"/> class.
        /// </summary>
        /// <param name="execute">Command to Execute.</param>
        /// <param name="canExecute">Can Execute parameters.</param>
        /// <param name="errorHandler">Error Handler.</param>
        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
            this.errorHandler = errorHandler;
        }

        /// <summary>
        /// Can Execute Changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Can execute command.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Bool.</returns>
        public bool CanExecute(T parameter)
        {
            return !this.isExecuting && (this.canExecute?.Invoke(parameter) ?? true);
        }

        /// <summary>
        /// Execute Command Async.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Task.</returns>
        public async Task ExecuteAsync(T parameter)
        {
            if (this.CanExecute(parameter))
            {
                try
                {
                    this.isExecuting = true;
                    await this.execute(parameter).ConfigureAwait(false);
                }
                finally
                {
                    this.isExecuting = false;
                }
            }

            this.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Raise Can Execute Changed.
        /// </summary>
#pragma warning disable CA1030 // Use events where appropriate
        public void RaiseCanExecuteChanged()
#pragma warning restore CA1030 // Use events where appropriate
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc/>
        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute((T)parameter);
        }

        /// <inheritdoc/>
        void ICommand.Execute(object parameter)
        {
            this.ExecuteAsync((T)parameter).FireAndForgetSafeAsync(this.errorHandler);
        }
    }
}
