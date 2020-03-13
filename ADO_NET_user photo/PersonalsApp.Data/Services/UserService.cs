using PersonalsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PersonalsApp.Data.Services
{
    public class UserService
    {
        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (EFContext context = new EFContext())
            {
                users =  context.Users.Include(t=>t.AccountOf).Include(t=>t.RoleOf).ToList();
            }
            return users;
        }

        public void Add(User user)
        {
            try
            {
                using (EFContext context = new EFContext())
                {
                    context.Users.Add(user);
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
