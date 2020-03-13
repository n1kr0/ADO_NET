using Microsoft.Win32;
using PersonalsApp.Data.Services;
using PersonalsApp.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        private PhotoService _photoService;
        public Photo_Window()
        {
            InitializeComponent();
            _photoService = new PhotoService();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();

            string imageName = Guid.NewGuid().ToString() + ".jpg"; //08f71055-72b0-4075-bbc9-8472782e3b7f.jpg
            System.Drawing.Image img = System.Drawing.Image.FromFile(dlg.FileName);
            img = CompressImage.CreateImage((Bitmap)img, 500, 500);
            img.Save(Environment.CurrentDirectory + "//" + imageName, ImageFormat.Jpeg);

        }
    }
}
