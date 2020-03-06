using PersonalsApp.Data.Services;
using PersonalsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PersonalsApp
{

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
                    Age = Convert.ToInt32((DateTime.Now-item.DateOfBirth).TotalDays/365.25),
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone = item.Phone,
                    ImagePath = item.Image,
                    Login=item.AccountOf?.Login ?? "",
                    Role=item.RoleOf.Name,
                    Image = new BitmapImage(new System.Uri(item.Image.Contains("http") ? item.Image : Environment.CurrentDirectory + "//" + item.Image,UriKind.Absolute))
                };
                users.Add(model);
            }
            dgUsers.ItemsSource = users ;
           //List<Account> accounts = new List<Account>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPersonalWindow dlg = new AddPersonalWindow();
            dlg.ShowDialog();
        }

        private void btnAddUser_Copy_Click(object sender, RoutedEventArgs e)
        {
           // Photo_Window
        }
    }
}
