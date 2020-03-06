using Personals_App.Models;
using Personals_App.Services;
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

namespace Personals_App
{

    public partial class MainWindow : Window
    {
        private UserServices _userServices;
        public MainWindow()
        {
            InitializeComponent();
            _userServices = new UserServices();
        }

        private void dgUsers_Loaded(object sender, RoutedEventArgs e)
        {
            List<UserViewModel> users = new List<UserViewModel>();

            foreach(var item in _userServices.GetAll())
            {
                UserViewModel model = new UserViewModel()
                {
                    Id = item.Id,
                    DateOfBirth = item.DateOfBirth,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone = item.Phone,
                    ImagePath = item.Image,
                    Image = new BitmapImage(new System.Uri(item.Image.Contains("http") ? item.Image : Environment.CurrentDirectory + "//" + item.Image, UriKind.Absolute))
                };
                users.Add(model);
            }

            dgUsers.ItemsSource = users;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddPersonalWindow dlg = new AddPersonalWindow();
            dlg.ShowDialog();
        }
    }
}
