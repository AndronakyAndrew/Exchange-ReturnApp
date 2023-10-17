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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {

        ExchangeReturnContext db;

        public RegistrationWindow()
        {
            InitializeComponent();

            db = new ExchangeReturnContext();
        }

        //Функционал для кнопки перехода на окно авторизации
        private void btn_Auth_window_click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginwindow= new LoginWindow();
            loginwindow.Show();
            this.Hide();
        }

        //Функционал для кнопки регистрации и проверка введенных данных от пользователя
        private void btn_Reg_Click(object sender, RoutedEventArgs e)
        {
            string name = Namebox.Text.Trim();
            string password = Passwordbox.Password.Trim();
            string password2 = Passwordbox_2.Password.Trim();
            string email = Emailbox.Text.Trim().ToLower();

            if (name.Length < 5)
            {
                Namebox.ToolTip = "Логин должен содержать больше 5 символов!";
                Namebox.Background = Brushes.Red;
            }
            else if (password.Length < 8)
            {
                Passwordbox.ToolTip = "Пароль должен содержать больше 8 символов!";
                Passwordbox.Background = Brushes.Red;
            }
            else if (password != password2)
            {
                Passwordbox_2.ToolTip = "Пароли не совпадают!";
                Passwordbox_2.Background = Brushes.Red;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                Emailbox.ToolTip = "Почта введена неверно!";
                Emailbox.Background = Brushes.Red;
            }
            else
            {
                Namebox.ToolTip = "";
                Namebox.Background = Brushes.Transparent;
                Passwordbox.ToolTip = "";
                Passwordbox.Background = Brushes.Transparent;
                Passwordbox_2.ToolTip = "";
                Passwordbox_2.Background = Brushes.Transparent;
                Emailbox.ToolTip = "";
                Emailbox.Background = Brushes.Transparent;

                MessageBox.Show("Регистрация прошла успешно!");

                //Создание нового пользователя и добавление его в базу данных
                User user = new User(name, password, email);

                db.Users.Add(user);
                db.SaveChanges();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
        }
    }
}
