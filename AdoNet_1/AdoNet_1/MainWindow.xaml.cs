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
using System.Data.SqlClient;
using AdoNet_1.Entities;

namespace AdoNet_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string conString;
        public MainWindow()
        {
            //1 варіант
            //conString =
            //    @"Data Sourse=10.7.0.7;" +
            //    "Initial Catalog=PizzaShopRomanyuk;" +
            //    "User ID=romanyukM;"+
            //    "Password=241912&&!=Dsnz";

            //conString =
            //    @"Data Sourse=localdb\MSSQLLocalDB;" +
            //    "Initial Catalog=PizzaShopRomanyuk;" +
            //    "Integrated Security=True";
            //2 варіант
            SqlConnectionStringBuilder conBuilder = new SqlConnectionStringBuilder();
            conBuilder.DataSource = ".";
            conBuilder.InitialCatalog = "PizzaShopRomanyuk";
            conBuilder.IntegratedSecurity = true;
            conString = conBuilder.ToString();

            InitializeComponent();
        }

        private void Button_Click(object sender,RoutedEventArgs e)
        {
            dgPizzas.ItemsSource = this.GetPizzas();
        }


        private IEnumerable<Pizza> GetPizzas()
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
                    while(reader.Read())
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

        private int AddPizza(Pizza pizza)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    string command = $"INSERT INTO tblPizzas VALUES(N'{pizza.Name}',{pizza.Price},'{pizza.Type}')";
                    SqlCommand cmd = new SqlCommand(command, con);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.AddPizza(new Pizza("Paperoni", 80, "L"));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.AddPizza(new Pizza(tbName.Text, float.Parse(tbPrice.Text), tbSize.Text));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (dgPizzas.SelectedItems.Count < 1)
            {
                MessageBox.Show("Ви не вибрали піцу");
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    string command = $"UPDATE tblPizzas SET Name=N'{tbName.Text}', Price={tbPrice.Text},Type='{tbSize.Text}' WHERE tblPizzas.Id={(dgPizzas.SelectedItem as Pizza).Id}";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void DgPizzas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbName.Text = (dgPizzas.SelectedItem as Pizza)?.Name;
            tbPrice.Text = (dgPizzas.SelectedItem as Pizza)?.Price.ToString();
            tbSize.Text = (dgPizzas.SelectedItem as Pizza)?.Type;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (dgPizzas.SelectedItems.Count < 1)
            {
                MessageBox.Show("Ви не вибрали піцу");
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    string command = $"DELETE FROM tblPizzas WHERE tblPizzas.Id={(dgPizzas.SelectedItem as Pizza).Id}";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            List<Pizza> res = new List<Pizza>();
            using (SqlConnection sqlCon = new SqlConnection(conString))
            {
                //створюємо обєкт підключення
                sqlCon.Open();
                string command = $"SELECT * FROM tblPizzas WHERE tblPizzas.Name LIKE N'%{tbName.Text}%' AND tblPizzas.Price={tbPrice.Text} AND tblPizzas.Type Like N'%{tbSize.Text}%'";

                SqlCommand cmd = new SqlCommand(command, sqlCon);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(new Pizza(
                                 reader.GetInt32(0),
                                 reader["Name"].ToString(),
                                 float.Parse(reader["Price"].ToString()),
                                 reader["Type"].ToString()
                                 ));

                    }
                }
            }
            dgPizzas.ItemsSource = res;
        }
    }

}
