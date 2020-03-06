using PersonalsApp.Data.Services;
using PersonalsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PersonalsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserService _userService;

        public MainWindow()
        {
            InitializeComponent();

            _userService = new UserService();
        }

        private void dgUsers_Loaded(object sender, RoutedEventArgs e)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (var item in _userService.GetAll())
            {
                UserViewModel model = new UserViewModel()
                {
                    Id = item.Id,
                    DateOfBirth = item.DateOfBirth,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone = item.Phone,
                    ImagePath = item.Image,
                    Image = new BitmapImage(new System.Uri(item.Image.Contains("http") ? item.Image : Environment.CurrentDirectory + "//" + item.Image,UriKind.Absolute))
                };
                users.Add(model);
            }
            dgUsers.ItemsSource = users ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPersonalWindow dlg = new AddPersonalWindow();
            dlg.ShowDialog();
        }
    }
}
