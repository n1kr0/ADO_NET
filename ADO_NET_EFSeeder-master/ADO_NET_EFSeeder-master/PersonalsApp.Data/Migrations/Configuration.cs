namespace PersonalsApp.Data.Migrations
{
    using Bogus;
    using PersonalsApp.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonalsApp.Data.Models.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonalsApp.Data.Models.EFContext context)
        {
            context.Roles.AddOrUpdate(role => role.Id, 
                new Role[] {
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
                });
            context.SaveChanges();
            var userIds = 1;
            Faker<User> faker = new Faker<User>()
                .CustomInstantiator(f => new User() { Id = userIds++ })
                .RuleFor(f => f.FirstName, t => t.Person.FirstName)
                .RuleFor(f => f.LastName, t => t.Person.LastName)
                .RuleFor(f => f.Phone, t => t.Phone.PhoneNumber("+38(###)###-##-##"))
                .RuleFor(f => f.Image, t => t.Image.People(1024, 1024))
                .RuleFor(f => f.DateOfBirth, t=>t.Date.Between(DateTime.Parse("15/02/2000"),DateTime.Parse("17/02/2020")))
                .RuleFor(f => f.RoleId, context.Roles.FirstOrDefault(t => t.Name == "Admin").Id);

            context.Users.AddOrUpdate(f => f.Id, faker.Generate(100).ToArray());
        }
    }
}
