namespace Personals_App.Migrations
{
    using Bogus;
    using Personals_App.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Personals_App.Models.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Personals_App.Models.EFContext context)
        {
            context.Roles.AddOrUpdate(role => role.Id,

                new Role[]
                {
                        new Role()
                    {
                        Id = 1,
                        Name = "User"
                    },
                    new Role()
                    {
                        Id = 2,
                        Name = "Admin"
                    },
                    new Role()
                    {
                        Id = 3,
                        Name = "Moderator"
                    },
                }
             );

            //context.Users.AddOrUpdate(user => user.Id,

            //    new User[]
            //    {
            //            new User()
            //        {
            //            Id = 1,
            //            FirstName = "Grisha",
            //            LastName="BigMack",
            //            DateOfBirth=DateTime.Parse("12-12-1990"),
            //            Phone="+38(097)100-10-10",
            //            Image="https://demotivatorium.ru/sstorage/3/2016/07/15070713746312/demotivatorium_ru_eto_grisha_6h9_117413.jpg"
            //        },


            //        new User()
            //        {
            //            Id = 2,
            //            FirstName = "Vasja",
            //            LastName = "Oblomov",
            //            DateOfBirth = DateTime.Parse("11-11-1990"),
            //            Phone = "+38(097)111-11-11",
            //            Image = "https://image.karabas.com/w/350/h/496/f/files/import/1731343716_ImageBig637130484358472864.jpeg"
            //        },

            //         new User()
            //        {
            //            Id = 3,
            //            FirstName = "Ivan",
            //            LastName="Ivanov",
            //            DateOfBirth=DateTime.Parse("02-12-1990"),
            //            Phone="+38(097)222-22-22",
            //            Image="https://demotivatorium.ru/sstorage/3/2016/07/15070713746312/demotivatorium_ru_eto_grisha_6h9_117413.jpg"
            //        },


            //        new User()
            //        {
            //            Id = 4,
            //            FirstName = "Vasja",
            //            LastName = "Oblomov",
            //            DateOfBirth = DateTime.Parse("01-11-1990"),
            //            Phone = "+38(097)333-33-33",
            //            Image = "https://images.aif.ru/017/947/2619ba23a00efc0c44354a153bae22b0.jpg"
            //        },

            //         new User()
            //        {
            //            Id = 5,
            //            FirstName = "Oleg",
            //            LastName="Tunew",
            //            DateOfBirth=DateTime.Parse("22-12-1990"),
            //            Phone="+38(097)444-44-44",
            //            Image="https://demotivatorium.ru/sstorage/3/2016/07/15070713746312/demotivatorium_ru_eto_grisha_6h9_117413.jpg"
            //        },


            //        new User()
            //        {
            //            Id = 6,
            //            FirstName = "Evgen",
            //            LastName = "Rudenko",
            //            DateOfBirth = DateTime.Parse("18-01-1990"),
            //            Phone = "+38(097)555-55-55",
            //            Image = "https://image.karabas.com/w/350/h/496/f/files/import/1731343716_ImageBig637130484358472864.jpeg"
            //        },

            //         new User()
            //        {
            //            Id = 7,
            //            FirstName = "Misha",
            //            LastName="Homiak",
            //            DateOfBirth=DateTime.Parse("28-12-1990"),
            //            Phone="+38(097)666-66-66",
            //            Image="https://demotivatorium.ru/sstorage/3/2016/07/15070713746312/demotivatorium_ru_eto_grisha_6h9_117413.jpg"
            //        },


            //        new User()
            //        {
            //            Id = 8,
            //            FirstName = "Volodimir",
            //            LastName = "Varov",
            //            DateOfBirth = DateTime.Parse("19-11-1990"),
            //            Phone = "+38(097)777-77-77",
            //            Image = "https://images.aif.ru/017/947/2619ba23a00efc0c44354a153bae22b0.jpg"
            //        },

            //        new User()
            //        {
            //            Id = 9,
            //            FirstName = "www",
            //            LastName="www",
            //            DateOfBirth=DateTime.Parse("22-12-1990"),
            //            Phone="+38(095)666-66-66",
            //            Image=" "
            //        },


            //        new User()
            //        {
            //            Id = 10,
            //            FirstName = "xxx",
            //            LastName = "xxx",
            //            DateOfBirth = DateTime.Parse("11-11-1990"),
            //            Phone = "+38(096)111-11-11",
            //            Image = " "
            //        },
            //    }
            //    );
            var userIds = 0;
            Faker<User> faker = new Faker<User>("uk")
                .CustomInstantiator(f => new User() { Id = userIds++ })
                .RuleFor(f => f.FirstName, t => t.Person.FirstName)
                .RuleFor(f => f.LastName, t => t.Person.LastName)
                .RuleFor(f => f.Phone, t => t.Phone.PhoneNumber("+38(###)###-##-##"))
                .RuleFor(f => f.Image, t => t.Image.People(1024, 1024))
                .RuleFor(f => f.DateOfBirth, t => t.Date.Between(DateTime.Parse("12/12/2008"), DateTime.Parse("12/12/2020")))
                .RuleFor(f => f.RoleId, context.Roles.FirstOrDefault(t => t.Name == "Admin").Id);

            context.Users.AddRange(faker.Generate(100));
        }
    }
}
