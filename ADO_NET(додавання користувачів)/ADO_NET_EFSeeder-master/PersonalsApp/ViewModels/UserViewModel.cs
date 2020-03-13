using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PersonalsApp.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string ImagePath { get; set; }

        public int RoleId { get; set; }

        public BitmapImage Image { get; set; }
    }
}
