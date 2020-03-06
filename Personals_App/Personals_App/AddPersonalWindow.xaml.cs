using Microsoft.Win32;
using Personals_App.Models;
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

namespace Personals_App
{
    /// <summary>
    /// Логика взаимодействия для AddPersonalWindow.xaml
    /// </summary>
    public partial class AddPersonalWindow : Window
    {
        public AddPersonalWindow()
        {
            InitializeComponent();
        }
        string PathPhoto;
        private void btnChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "*.jpg|JPEG"
            };
            if (dlg.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(dlg.FileName));
                PathPhoto = dlg.FileName;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PathPhoto))
            {
                MessageBox.Show("Choose photo.");
            }
            string imageName = Guid.NewGuid().ToString() + ".jpg";
            System.Drawing.Image img = System.Drawing.Image.FromFile(PathPhoto);
            img = CompressImage.CreateImage((Bitmap)img, 500, 500);
            img.Save(Environment.CurrentDirectory + "//" + imageName, ImageFormat.Jpeg);
            User user = new User()
            {
                FirstName = tbFirstName.Text
            };

        }

        // LastName=tbLastName.Text;
        private void cbRole_Loaded(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                cbRole.ItemsSource = context.Roles.ToList();
            }
        }
    }
}

