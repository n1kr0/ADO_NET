using System;
using System.Windows.Media.Imaging;

namespace PersonalsApp.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string ImagePath { get; set; }

        public string Role { get; set; }

        public BitmapImage Image { get; set; }
        public string Login { get; internal set; }
        public string Password { get; internal set; }
    }
}