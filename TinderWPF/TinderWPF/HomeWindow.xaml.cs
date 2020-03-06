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

namespace TinderWPF
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private IEnumerable<Users> GetPizzas()
        {
            //створюємо
            using (SqlConnection sqlCon = new SqlConnection(conString))
            {
                //створюємо обєкт підключення
                sqlCon.Open();
                string command = "SELECT * FROM tblPizzas";
                SqlCommand cmd = new SqlCommand(command, sqlCon);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return
                            new Pizza(
                                reader.GetInt32(0),
                                reader["Name"].ToString(),
                                float.Parse(reader["Price"].ToString()),
                                reader["Type"].ToString()
                                );

                    }
                }
            }
        }

        private void dgShowList_Loaded(object sender, RoutedEventArgs e)
        {
            dgShowList.ItemsSource=this
        }
    }
}
