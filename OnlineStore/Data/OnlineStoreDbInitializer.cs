using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Database;

namespace OnlineStore.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<UserRole>().HasData(
                new UserRole() { Name = "Administrator", Id=1 },
                new UserRole() { Name = "SimpleUser", Id=2}
                );

            /*
            builder.Entity<Category>().HasData(
                new Category() { Name="Smartphones"},
                new Category() { Name="Notebooks"}
                );

            builder.Entity<Product>().HasData(
                new Product() { Producer = "Nokia", Model = "105", Price = 250.55M, CategoryId=1 },
                new Product() { Producer = "Xiaomi", Model = "Redmi 5", Price = 2000.55M, CategoryId =1 },
                new Product() { Producer = "Xiaomi", Model = "Mi9t", Price = 8000.00M, CategoryId =1 },
                new Product() { Producer = "Iphone", Model = "7", Price = 7500.00M, CategoryId =1 },
                new Product() { Producer = "Dell", Model = "E5440", Price = 15000.00M, CategoryId = 1, Description="Cool notebook"},
                new Product() { Producer = "Dell", Model = "E7440", Price = 19000.00M, CategoryId = 1, Description="Very big screen 17\""}
                );
            builder.Entity<User>().HasData(
                new User() { Name="Alex", Surname="Johnson", Adress="Some adress1", Email="alex@gmail.com", PasswordHash="abrakadabra", RoleId=1 },
                new User() { Name="Ilya", Surname="Varlamov", Adress="Some adress2", Email="varlamov@gmail.com", PasswordHash="varlamovbest", RoleId=1 }
                );
                */
        }
    }
}
