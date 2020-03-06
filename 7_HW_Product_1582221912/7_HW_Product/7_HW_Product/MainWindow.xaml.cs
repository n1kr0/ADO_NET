using Data.Models;
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

namespace _7_HW_Product
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
            using (EFContext context = new EFContext())
            {
                result.ItemsSource = context.Products.Where(t => t.Name == tbox.Text);
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                result.ItemsSource = null;
            }
        }
    }
}
