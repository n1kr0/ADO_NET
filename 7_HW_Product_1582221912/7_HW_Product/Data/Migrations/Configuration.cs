namespace Data.Migrations
{
    using Bogus;
    using Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Models.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Models.EFContext context)
        {
            context.Categories.AddOrUpdate(cat => cat.Id,
                new Category[]
                {
                    new Category()
                    {
                        Id = 1,
                        Name = "1"
                    },
                    new Category()
                    {
                        Id = 2,
                        Name = "2"
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "3"
                    }
                });
            context.SaveChanges();
            context.Products.AddOrUpdate(user => user.Id,
                 new Product[]
                 {
                    new Product()
                    {
                        Id = 1,
                        Name = "First",
                        Category = Finder(context,"1"),
                        Price = "2433",
                        Image = "https://i.ytimg.com/vi/szFHSxlLBx0/maxresdefault.jpg",
                        Description = "asdasdsd"
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "2",
                        Category = Finder(context,"2"),
                        Price = "433",
                        Image = "https://i.ytimg.com/vi/szFHSxlLBx0/maxresdefault.jpg",
                        Description = "asdasdsd"
                    },
                    new Product()
                    {
                        Id = 3,
                        Name = "3",
                        Category = Finder(context,"3"),
                        Price = "43",
                        Image = "https://i.ytimg.com/vi/szFHSxlLBx0/maxresdefault.jpg",
                        Description = "asdasdsd"
                    }
                 });

            var userIds = 5;
            Faker<Product> faker = new Faker<Product>()
                .CustomInstantiator(f => new Product() { Id = userIds++ })
                .RuleFor(f => f.Name, t => t.Person.FirstName)
                .RuleFor(f => f.Category, context.Categories.FirstOrDefault(t => t.Name == "3").Id)
                .RuleFor(f => f.Price, t => t.Random.Int(0, 5000).ToString())
                .RuleFor(f => f.Image, t => t.Image.People(50, 50, true, true))
                .RuleFor(f => f.Description, t => t.Lorem.Text());
            Checker(context);

            context.Products.AddRange(faker.Generate(100000));
        }
        public int Finder(Data.Models.EFContext context, string str)
        {
            foreach (var item in context.Categories)
                if (item.Name == str)
                    return item.Id;
            return 0;
        }
        public void Checker(Data.Models.EFContext context)
        {
            foreach (var item in context.Products)
                if (item.Image == null || item.Image == "")
                    item.Image = "https://i.ytimg.com/vi/szFHSxlLBx0/maxresdefault.jpg";
        }
    }
}
