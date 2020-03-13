using Microsoft.Win32;
using PersonalsApp.Data.Models;
using PersonalsApp.Data.Services;
using PersonalsApp.Helpers;
using PersonalsApp.ViewModels;
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

            Data.Models.User_Photo user_Photo = new User_Photo();
            {
                user_Photo.Name = imageName;
                user_Photo.User_Id = StartWindow.selectID;
            }

            PhotoService photoService = new PhotoService();
            photoService.Add(user_Photo);



        }

        private void lvPhoto_Loaded(object sender, RoutedEventArgs e)
        {
            List<PhotoViewModel> users = new List<PhotoViewModel>();
            foreach (var item in _photoService.GetPhoto(StartWindow.selectID))
            {
                PhotoViewModel model = new PhotoViewModel()
                {                 
                    ImagePath = item.Name,
                    Image = new BitmapImage(new System.Uri(Environment.CurrentDirectory + "//" + item.Name, UriKind.Absolute))
                };
                users.Add(model);
            }
            lvPhoto.ItemsSource = users;

        }
    }
}
