using LoginService.Models.Domain.Entity;
using LoginService.Services;
using LoginService.Services.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;

namespace music_store
{
    public class LoginWindow : Window
    {
        private Grid _windowCanvas;

        private TextBox _loginField;

        private TextBox _passwordField;

        private void InitCanvas()
        {
            const uint COUNT_GRID_COLLS = 12;
            const uint COUNT_GRID_ROWS = 7;

            this._windowCanvas = new Grid();

            for (uint i = 0; i < COUNT_GRID_ROWS; i++)
            {
                this._windowCanvas.RowDefinitions.Add(new RowDefinition());
            }
            for (uint i = 0; i < COUNT_GRID_COLLS; i++)
            {
                this._windowCanvas.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void AddIputFields()
        {
            Label loginFieldLabel = new Label();
            loginFieldLabel.Content = "Login";

            this._loginField = new TextBox();

            Label passwordFieldLabel = new Label();
            passwordFieldLabel.Content = "Password";

            this._passwordField = new TextBox();

            int childrenRow = 1;

            this._windowCanvas.Children.Add(loginFieldLabel);
            Grid.SetRow(loginFieldLabel, childrenRow);
            Grid.SetColumn(loginFieldLabel, 5);
            Grid.SetColumnSpan(loginFieldLabel, 3);
            childrenRow++;

            this._windowCanvas.Children.Add(this._loginField);
            Grid.SetRow(this._loginField, childrenRow);
            Grid.SetColumn(this._loginField, 4);
            Grid.SetColumnSpan(this._loginField, 4);
            childrenRow++;

            this._windowCanvas.Children.Add(passwordFieldLabel);
            Grid.SetRow(passwordFieldLabel, childrenRow);
            Grid.SetColumn(passwordFieldLabel, 5);
            Grid.SetColumnSpan(passwordFieldLabel, 3);
            childrenRow++;

            this._windowCanvas.Children.Add(this._passwordField);
            Grid.SetRow(this._passwordField, childrenRow);
            Grid.SetColumn(this._passwordField, 4);
            Grid.SetColumnSpan(this._passwordField, 4);
        }

        private void AddControlButtons()
        {
            Button registationButton = new Button();
            registationButton.Content = "Зарегистрироваться";

            Button agreeButton = new Button();
            agreeButton.Content = "Ок";
            agreeButton.Click += this.AgreeClick;

            Button cancelButton = new Button();
            cancelButton.Content = "Отмена";
            cancelButton.Click += this.CancelClick;

            this._windowCanvas.Children.Add(registationButton);
            Grid.SetRow(registationButton, 0);
            Grid.SetColumn(registationButton, 4);
            Grid.SetColumnSpan(registationButton, 4);

            this._windowCanvas.Children.Add(agreeButton);
            Grid.SetRow(agreeButton, 6);
            Grid.SetColumn(agreeButton, 2);
            Grid.SetColumnSpan(agreeButton, 3);

            this._windowCanvas.Children.Add(cancelButton);
            Grid.SetRow(cancelButton, 6);
            Grid.SetColumn(cancelButton, 7);
            Grid.SetColumnSpan(cancelButton, 3);
        }

        private void AgreeClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this._loginField.Text) &&
                !String.IsNullOrEmpty(this._passwordField.Text))
            {
                IUserService userService = new UserService();

                User currentUser = new User()
                {
                    Login = this._loginField.Text,
                    Password = userService.CreateHashPassword(this._passwordField.Text)
                };

                if (userService.GetUserExist(currentUser))
                {
                    MessageBox.Show("Вход успешен!");
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            else
            {
                MessageBox.Show("Пустое поле!");
            }
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public LoginWindow(uint width, uint height)
        {
            this._windowCanvas = new Grid();
            this.Width = width;
            this.Height = height;
            this.ResizeMode = ResizeMode.NoResize;

            this.InitCanvas();
            this.Content = this._windowCanvas;
            this.AddIputFields();
            this.AddControlButtons();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Show();
        }
    }
}
