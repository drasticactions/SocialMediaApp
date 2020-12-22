// <copyright file="LoginViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Core.Managers;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Tools;

namespace SocialMediaApp.ViewModels
{
    /// <summary>
    /// Login View Model.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        private IAuthenticationManager manager;
        private string password = string.Empty;
        private string username = string.Empty;
        private AsyncCommand loginCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        /// <param name="manager">Auth Manager.</param>
        /// <param name="database">Database.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        public LoginViewModel(IAuthenticationManager manager, IDatabase database, IErrorHandler error, INavigationHandler navigation)
            : base(database, error, navigation)
        {
            this.manager = manager;
            this.RaiseCanExecuteChanged += this.LoginViewModel_RaiseCanExecuteChanged;
        }

        /// <summary>
        /// Gets a value indicating whether login is enabled.
        /// </summary>
        public bool IsLoginEnabled => !string.IsNullOrEmpty(this.Password) && !string.IsNullOrEmpty(this.Username) && !this.IsBusy;

        /// <summary>
        /// Gets the login command.
        /// </summary>
        public AsyncCommand LoginCommand
        {
            get
            {
                return this.loginCommand ??= new AsyncCommand(this.LoginUserWithPassword, () => this.IsLoginEnabled, this.Error);
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.SetProperty(ref this.password, value);
                this.LoginCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.SetProperty(ref this.username, value);
                this.LoginCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Login User With Password.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task LoginUserWithPassword()
        {
            this.IsBusy = true;
            var user = await this.manager.LoginAsync(this.Username, this.Password).ConfigureAwait(false);
            if (user != null)
            {
                if (this.Database.SaveLoggedInUser(user))
                {
                    this.Navigation.SetMainAppPage();
                }
            }

            this.IsBusy = false;
        }

        private void LoginViewModel_RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            this.LoginCommand.RaiseCanExecuteChanged();
        }
    }
}
