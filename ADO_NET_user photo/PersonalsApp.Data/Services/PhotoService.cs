using PersonalsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalsApp.Data.Services
{
    
    public class PhotoService
    {
        public IEnumerable<User_Photo> GetPhoto(int UserId)
        {
            List<User_Photo> photos = new List<User_Photo>();
            using (EFContext context = new EFContext())
            {
                photos = context.Photos.Where(t => t.User_Id == UserId).ToList();
            }
            return photos;
        }
        public void Add(User_Photo photo)
        {
            try
            {
                using (EFContext context = new EFContext())
                {
                    context.Photos.Add(photo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
    }
}
