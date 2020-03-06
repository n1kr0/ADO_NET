using ADO.NET_1.Entities;
using System;
using System.Collections.Generic;
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

namespace ADO.NET_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string conString;
        public MainWindow()
        {

            InitConString();
            InitializeComponent();
        }

        private void InitConString()
        {
            conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlowersShop;Integrated Security=True";
            //string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlowersShop;User id=UserName;Password=Secret;";
            //SqlConnectionStringBuilder conBuilder = new SqlConnectionStringBuilder();
            //conBuilder.InitialCatalog = "FlowersShop";
            ////...
            //string conStringBuilder = conBuilder.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            this.dgFlowers.ItemsSource = GetFlowers();
        }

        private IEnumerable<Flower> GetFlowers()
        {
            // Створюємо клас для підключення
            using (SqlConnection con = new SqlConnection(conString))
            {
                //Відкриваємо підключення.
                con.Open();
                //Команда яка буде виконуватись в sql
                string command = "SELECT * FROM tblFlowers";
                //Створюємо клас для команди і прив`язуємо її до нашого підключення
                SqlCommand cmd = new SqlCommand(command, con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Повертає список елементів з квітами
                        yield return
                            new Flower(
                            //зчитування колонки з таблиці в даному випадку перша
                            reader.GetInt32(0),
                            //тут уже по назві колонки
                            reader["Name"].ToString(),
                            float.Parse(reader["Price"].ToString()),
                            int.Parse(reader["SeasonId"].ToString())
                            );
                    }
                }
                //Якщо без using
                con.Close();
            }
        }

        private int AddFlower(Flower flower)
        {
            try
            {
                // Створюємо клас для підключення
                using (SqlConnection con = new SqlConnection(conString))
                {
                    //Відкриваємо підключення.
                    con.Open();
                    //Команда яка буде виконуватись в sql
                    string command = $"INSERT INTO tblFlowers VALUES (N'{flower.Name}',{flower.Price},{flower.SeasonId})";
                    //Створюємо клас для команди і прив`язуємо її до нашого підключення
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
            this.AddFlower(new Flower("Хризантема", 50, 3));
        }
    }
}
