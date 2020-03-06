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
    /// <summary>
    /// Логика взаимодействия для Photo_Window.xaml
    /// </summary>
    public partial class Photo_Window : Window
    {
        public Photo_Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Photo_Window photo_win = new Photo_Window();
            photo_win.ShowDialog();
        }
    }
}
