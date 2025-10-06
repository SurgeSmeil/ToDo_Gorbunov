﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Regist.xaml
    /// </summary>
    public partial class Regist : Window
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            mainW.Show();
            this.Hide();
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

                Regist glavForm = new Regist();
                glavForm.Show();
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
