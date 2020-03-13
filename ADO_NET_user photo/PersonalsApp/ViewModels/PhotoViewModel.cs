using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PersonalsApp.ViewModels
{
    public class PhotoViewModel
    {
        public string ImagePath { get; set; }

        public BitmapImage Image { get; set; }
    }
}
