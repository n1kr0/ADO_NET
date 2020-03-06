using Microsoft.Win32;
using PersonalsApp.Data.Models;
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
    /// Interaction logic for AddPersonalWindow.xaml
    /// </summary>
    public partial class AddPersonalWindow : Window
    {
        public AddPersonalWindow()
        {
            InitializeComponent();
        }

        string PathPhoto;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PathPhoto))
            {
                MessageBox.Show("Choose photo.");
            }

            string imageName = Guid.NewGuid().ToString() + ".jpg"; //08f71055-72b0-4075-bbc9-8472782e3b7f.jpg
            System.Drawing.Image img = System.Drawing.Image.FromFile(PathPhoto);
            img = CompressImage.CreateImage((Bitmap)img, 500, 500);
            img.Save(Environment.CurrentDirectory + "//" + imageName, ImageFormat.Jpeg);


            User user = new User()
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.Now,
                Phone = tbPhone.Text,
                Image = imageName,
                RoleId = ((Role)cbRole.SelectedItem).Id
            };

            Account account = new Account()
            {
                Id = user.Id,
                Login = tbLoginReg.Text,
                Password = tbPassReg.Text
            };

            using(EFContext context=new EFContext())
            {
                context.Users.Add(user);
                context.Accounts.Add(account);
                context.SaveChanges();
            }
            this.Close();
        }

        private void btnChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "JPEG | *.jpg"
            };
            if(dlg.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(dlg.FileName));
                PathPhoto = dlg.FileName;
            }
        }

        private void cbRole_Loaded(object sender, RoutedEventArgs e)
        {
            using(EFContext context=new EFContext())
            {
                cbRole.ItemsSource = context.Roles.ToList();
            }
        }
    }
}
