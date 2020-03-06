using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TransactionExample.Entities;

namespace TransactionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Вкажіть кількість користувачів для вставлення=>");
            int count = int.Parse(Console.ReadLine());
            InsertTransactionDataRandomUsers(count);
        }
        static void InsertTransactionDataRandomUsers(int count = 10)
        {
            using (EFContext context=new EFContext())
            {
                using (TransactionScope scope=new TransactionScope())
                {
                    List<User> users = new List<User>();
                    for(int i=0; i < count;i++)
                    {
                        users.Add(new User()
                        {
                            Email = "emailRandom@gmail.com",
                            Password = "Qwerty-1"
                        });
                    }
                    context.Users.AddRange(users);
                    context.SaveChanges();
                    //записує дані в базу даних
                    scope.Complete();
                }
            }
        }
    }
}
