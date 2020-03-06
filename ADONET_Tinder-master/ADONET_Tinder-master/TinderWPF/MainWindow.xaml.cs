using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace TinderWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using(SqlConnection con=new SqlConnection(conString))
            {
                con.Open();
                string command = $"SELECT Id FROM tblUsers " +
                    $"WHERE Login LIKE @login AND Password LIKE @password";

                SqlParameter pLogin = new SqlParameter("@login", txtLogin.Text);
                SqlParameter pPassword = new SqlParameter("@password", pbPassword.Password);

                using (SqlCommand com=new SqlCommand(command,con))
                {
                    com.Parameters.Add(pLogin);
                    com.Parameters.Add(pPassword);

                    string id = Convert.ToString(com.ExecuteScalar());
                    if(!string.IsNullOrEmpty(id))
                    {
                        MessageBox.Show(id);
                    } 
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterWindow regWindow = new RegisterWindow();
            regWindow.ShowDialog();
        }
    }
}
