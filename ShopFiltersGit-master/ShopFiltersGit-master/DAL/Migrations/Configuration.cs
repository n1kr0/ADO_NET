namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Entities.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Entities.EFContext context)
        {
            #region Categories
            context.Categories.AddOrUpdate(t => t.Id, new Category() {
                Id=2,
                Name="Сало"
            });
            #endregion

            #region Filters
            context.Filters.AddOrUpdate(t => t.Id, new Filter()
            {
                Id=1,
                Name="Виробник"
            });
            context.Filters.AddOrUpdate(t => t.Id, new Filter()
            {
                Id = 2,
                Name = "Розмір"
            });
            #endregion

            #region FilterValues
            context.FilterValues.AddOrUpdate(t => t.Id, new FilterValue()
            {
                Id = 1,
                FilterId = 1,
                Name = "Китай"
            });
            context.FilterValues.AddOrUpdate(t => t.Id, new FilterValue()
            {
                Id = 2,
                FilterId = 1,
                Name = "Україна"
            });
            context.FilterValues.AddOrUpdate(t => t.Id, new FilterValue()
            {
                Id = 3,
                FilterId = 1,
                Name = "Гуцули"
            });

            context.FilterValues.AddOrUpdate(t => t.Id, new FilterValue()
            {
                Id = 4,
                FilterId = 2,
                Name = "S"
            });
            context.FilterValues.AddOrUpdate(t => t.Id, new FilterValue()
            {
                Id = 5,
                FilterId = 2,
                Name = "M"
            });
            context.FilterValues.AddOrUpdate(t => t.Id, new FilterValue()
            {
                Id = 6,
                FilterId = 2,
                Name = "L"
            });
            #endregion

            #region CategoryFilters
            context.CategoryFilters.AddOrUpdate(t => t.Id, new CategoryFilter()
            {
                Id = 1,
                CategoryId = 1,
                FilterId = 1
            });
            context.CategoryFilters.AddOrUpdate(t => t.Id, new CategoryFilter()
            {
                Id = 2,
                CategoryId = 2,
                FilterId = 2
            });
            #endregion

            #region Products
            for (int i = 0; i < 10; i++)
            {
                Product product = new Product()
                {
                    Id = i + 1,
                    Name = "Салат" + i + 1,
                    DateCreate = DateTime.Now,
                    Price = (i + 1) * 100,
                    Quantity = i + 10,
                    CategoryId = 1,
                };
                context.Products.AddOrUpdate(t => t.Id, product);
            }
            #endregion

            #region ProductFilters
            context.ProductFilters.AddOrUpdate(t => t.Id, new ProductFilter()
            {
                Id = 1,
                FilterId = 1,
                ProductId = 1
            });
            context.ProductFilters.AddOrUpdate(t => t.Id, new ProductFilter()
            {
                Id = 2,
                FilterId = 2,
                ProductId = 2
            });
            context.ProductFilters.AddOrUpdate(t => t.Id, new ProductFilter()
            {
                Id = 3,
                FilterId = 2,
                ProductId = 3
            });
            #endregion 
        }
    }
}
