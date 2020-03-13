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
                this.Hide();
                var mainWindow = dlg.ShowDialog();
                if (mainWindow.HasValue && mainWindow.Value)
                {
                    this.Show();
                }
                //this.Close();
            }
            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            AddPersonalWindow dlg = new AddPersonalWindow();
            dlg.ShowDialog();
            
        }
    }
}
