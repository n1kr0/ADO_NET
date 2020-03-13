using PersonalsApp.Data.Models;
using PersonalsApp.Data.Services;
using PersonalsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private BackgroundWorker _bgWorker;

        public MainWindow()
        {
            InitializeComponent();

            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += _bgWorker_DoWork;
            _bgWorker.ProgressChanged += _bgWorker_ProgressChanged;
            _bgWorker.WorkerReportsProgress = true;

            _userService = new UserService();
        }

        private void _bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbUsers.Value = e.ProgressPercentage;
            int countOfAdded = (int)(((double)e.ProgressPercentage / 100) * int.Parse(txtCount.Text));
            tbCountOfAdded.Text = countOfAdded.ToString();
        }

        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int countOfUsers = 0;
            if (int.TryParse(e.Argument.ToString(), out countOfUsers)) {
                using (EFContext context = new EFContext())
                {
                    for (int i = 0; i <= countOfUsers; i++)
                    {
                        User user = new User()
                        {
                            DateOfBirth = DateTime.Now,
                            FirstName = "Vlad",
                            Image = "http://google.com.ua",
                            LastName = "Kot",
                            Phone = "+38(098)003-62-82",
                            RoleId = 1
                        };
                        _bgWorker.ReportProgress((i * 100) / countOfUsers);
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }
            }
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
            dgUsers.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPersonalWindow dlg = new AddPersonalWindow();
            dlg.ShowDialog();
        }

        private void btnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            _bgWorker.RunWorkerAsync(txtCount.Text);
        }
    }
}
