using PersonalsApp.Data.Models;
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

namespace PersonalsApp
{
//    Зробити програму на WPF для управління людми бізнесу.
//    Зробити логін і реєстрацію.
//    При реєстрації зробити шифрування пароля.
//    Також є один адмін в системі.
//Він може дивитись інших людей(Виводити Ім'я, Тип персони, пошта, дата редагування емейлу, адреса, телефон).
//Також редагування, видалення може виконувати тільки адмін.
//    Адмін також може добавляти адресу(місто, крайну, провінцію).
//Користувач може побачити свою інформацію(емейл, телефон, адреса)
//    Користувач може змінити пароля також змінити телефон і адресу.
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {

                context.Accounts.FirstOrDefault(t => t.Login == tbLogin.Text && t.Password == pbPassword.Password);
                MainWindow dlg = new MainWindow();
                dlg.ShowDialog();
            }
            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            AddPersonalWindow dlg = new AddPersonalWindow();
            dlg.ShowDialog();

        }
    }
}
