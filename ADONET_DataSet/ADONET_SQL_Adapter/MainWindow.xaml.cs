using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace ADONET_SQL_Adapter
{
//    Зробити кнопку добавлення і редагування.
//   При виборі рядка у поля показуються значення із таблиці Докторів.
//   При нажатті кнопки оновити бд база даних тоді оновляється.
//Також є кнопка відмінити - вона повертає стан DataSet в початкове положення.
//   Вирішити баг з не оновлюючою id.
    public partial class MainWindow : Window
    {
        SqlDataAdapter sqlData;
        DataSet ds;
        SqlConnection conn;

        public MainWindow()
        {

            InitializeComponent();
        }


        private void DgDoctors_Loaded(object sender, RoutedEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                sqlData = new SqlDataAdapter("SELECT * FROM Doctors", conn);


                SqlCommandBuilder builder = new SqlCommandBuilder(sqlData);
                sqlData.DeleteCommand = builder.GetDeleteCommand();
                sqlData.UpdateCommand = builder.GetUpdateCommand();

                ds = new DataSet();
                sqlData.Fill(ds);
                conn.Close();

                ds.Tables[0].Columns[0].ReadOnly = true;
                ds.Tables[0].Columns[0].AutoIncrement = true;
                ds.Tables[0].Columns[0].AutoIncrementStep = 1;
                ds.Tables[0].Columns[0].AutoIncrementSeed = ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1].Field<int>("Id") + 1;

                dgDoctors.ItemsSource = ds.Tables[0].DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            conn.ConnectionString = connString;

            conn.Open();
            sqlData.Update(ds);
            conn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = (dgDoctors.SelectedItem as DataRowView).Row.Field<int>("Id");
            int index = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                index = i;
            }
            ds.Tables[0].Rows[index].Delete();
            //ds.Tables[0].Rows[index].SetField<string>("Name", tbName.Text);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataRow dr = ds.Tables[0].NewRow();
            dr.SetField<string>("Name", tbName.Text);
            dr.SetField<string>("SurName", tbSurName.Text);
            dr.SetField<string>("Phone", tbPhone.Text);
            dr.SetField<decimal>("Salary", decimal.Parse(tbSalary.Text));
            dr.SetField<decimal>("Premium", decimal.Parse(tbPremium.Text));
            ds.Tables[0].Rows.Add(dr);
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            var selectedItem = (dgDoctors.SelectedItem as DataRowView).Row.Field<int>("Id");
            int index = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                index = i;
            }

            var selInd = ds.Tables[0].Rows[index];
            selInd.SetField<string>("Name", tbName.Text);
            selInd.SetField<string>("SurName", tbSurName.Text);
            selInd.SetField<string>("Phone", tbPhone.Text);
            selInd.SetField<decimal>("Salary", decimal.Parse(tbSalary.Text));
            selInd.SetField<decimal>("Premium", decimal.Parse(tbPremium.Text));
        }

        private void dgDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var slectedItem = (dgDoctors.SelectedItem as DataRowView);
            var Id = slectedItem.Row.Field<int>("Id");
            var Name = slectedItem.Row.Field<string>("Name");
            var SurName = slectedItem.Row.Field<string>("SurName");
            var Phone= slectedItem.Row.Field<string>("Phone");
            var Salary = slectedItem.Row.Field<decimal>("Salary");
            var Premium = slectedItem.Row.Field<decimal>("Premium");

            tbName.Text = Name;
            tbSurName.Text = SurName;
            tbPhone.Text = Phone;
            tbSalary.Text = Salary.ToString();
            tbPremium.Text = Premium.ToString();
        }
    }
}
