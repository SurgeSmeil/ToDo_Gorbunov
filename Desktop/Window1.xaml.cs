using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Desktop
{

    public partial class Window1 : Regist
    {
        public Window1()
        {
            InitializeComponent();
            CloseButton_Click.MainWindowInstance = this;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox1.Text;
            string password1 = PasswordBox2.Text;
            string name = NameTextBox.Text;

            if (ValidateEmail(email) && ValidatePassword(password) && ValidateName(name) && password == password1)
            {
                MessageBox.Show("Регистрация успешно проведена!");

                Regist nextWindow = new Regist();
                nextWindow.Show();
                this.Close();
            }
            else
            {
               
                string errorMessage = "";

                if (!ValidateEmail(email))
                {
                    errorMessage += "Неверный формат почты\n";
                }

                if (!ValidatePassword(password))
                {
                    errorMessage += "Пароль меньше 6 симв.\n";
                }

                if (!ValidateName(name))
                {
                    errorMessage += "Имя короче 3 симв.\n";
                }

                MessageBox.Show(errorMessage, "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static MainWindow? MainWindowInstance { get; set; } // Допустимо значение NULL.

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowInstance == null)
            {
                MainWindowInstance = new MainWindow();
            }

            MainWindowInstance.Show(); // Или MainWindowInstance.ShowDialog() если это диалог
            MainWindowInstance.Activate(); // Вывести на передний план

            this.Close(); // Закрываем текущее окно
        }


        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }

        private bool ValidatePassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 6;
        }

        private bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 3;
        }
    }
}
