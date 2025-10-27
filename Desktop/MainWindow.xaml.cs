
using Desktop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regist Regist1 = new Regist();
            Regist1.Show();
            this.Hide();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ErrorMessageLabel.Content = "Пожалуйста, заполните все поля."; // Или ErrorMessageLabel.Text для Windows Forms
                return;
            }

            if (UserRepository.AuthenticateUser(login, password))
            {
                // Аутентификация успешна
                ErrorMessageLabel.Content = ""; // Скрываем сообщение об ошибке
                MessageBox.Show("Вход успешно выполнен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information); // Или MessageBox.Show для Windows Forms

                // Открываем главное окно (замените MainAppWindow на имя вашего главного окна)
                Main_empty mainWindow = new Main_empty(); // Или для Windows Forms: MainAppWindow mainWindow = new MainAppWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                ErrorMessageLabel.Content = "Неверный логин или пароль."; // Или ErrorMessageLabel.Text для Windows Forms
            }
        }
        
        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
