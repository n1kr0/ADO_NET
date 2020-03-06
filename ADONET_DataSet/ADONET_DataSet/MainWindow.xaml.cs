using System;
using System.Collections.Generic;
using System.Data;
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

namespace ADONET_DataSet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DgProducts_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable("Products");

            DataColumn idColumn = new DataColumn("Id", typeof(int));
            DataColumn nameColumn = new DataColumn("Name", typeof(string));

            DataColumn priceColumn = new DataColumn("Price", typeof(float));

            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 1;
            idColumn.AutoIncrementStep = 1;
            nameColumn.MaxLength = 50;

            //priceColumn.Expression = "Price" > 0;



            dataTable.Columns.Add(idColumn);
            dataTable.Columns.Add(nameColumn);
            dataTable.Columns.Add(priceColumn);

            dataTable.Rows.Add(null,"сметана", 200);
            dataTable.Rows.Add(null, "сметана", 200);

            DataTable dataCategories = new DataTable("Categories");

            dataSet.Tables.Add(dataTable);
            dataSet.Tables.Add(dataCategories);

            dgProducts.ItemsSource = dataSet.Tables[0].DefaultView;

        }

 
    }
}
