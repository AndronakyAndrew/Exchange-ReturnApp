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
using System.Windows.Shapes;

namespace Exchange_ReturnApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        //Функционал для кнопки авторизации и проверка введенных данных от пользователя в базе данных
        private void btn_Auth_Click(object sender, RoutedEventArgs e)
        {
            string name = Namebox.Text.Trim();
            string password = Passwordbox.Password.Trim();

            if (name.Length < 5)
            {
                Namebox.ToolTip = "Неверный логин!";
                Namebox.Background = Brushes.Red;
            }
            else if (password.Length < 8)
            {
                Passwordbox.ToolTip = "Неверный пароль!";
                Passwordbox.Background = Brushes.Red;
            }
            else
            {
                User user = null;
                using (ExchangeReturnContext db = new ExchangeReturnContext())
                {
                    user = db.Users.Where(b => b.Name == name && b.Password == password).FirstOrDefault();
                }
                if (user != null)
                {
                    MessageBox.Show("Вы успешно авторизовались!");
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден!");
                }
            }
        }

        //Функционал для кнопки перехода на окно регистрации
        private void btn_Reg_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Hide();
        }
    }
}