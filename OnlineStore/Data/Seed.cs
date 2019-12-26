using System;
using OnlineStore.Models.Database;
using OnlineStore.Services;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Data
{
    public class Seed
    {
        public void SeedData(ModelBuilder builder)
        {
            //CREATE USER ROLES
            var simpleRole = new UserRole() {Id = 1,Name = "SimpleUser"};
            var adminRole = new UserRole() {Id = 2,Name = "Administrator"};
            var moderRole = new UserRole() {Id = 3,Name = "Moderator"};

            //CREATE CATEGORIES
            var smartphones = new Category() { Id = 1, Name = "Smartphone" };
            var notebooks = new Category() { Id = 2, Name = "Notebook" };
            var tvs = new Category() { Id = 3, Name = "TV" };

            //CREATE IMAGES
            var iphonexr = new Image() { Id = 1, Path = "iphonexr.jpg" };
            var samsung10e = new Image() { Id = 2, Path = "samsung10e.jpg" };
            var macbook16 = new Image() { Id = 3, Path = "macbookpro16.jpg" };
            var macbook13 = new Image() { Id = 4, Path = "macbookpro13.jpg" };
            var lgtv  = new Image() { Id = 5, Path = "lgtv.jpg" };

            //CREATE USERS
            //pasword for the user = 12345678
            //role - simple user
            var user1 = new User() {
                Id = 1,
                CreationTime = DateTime.Now,
                Name = "Vasyl",
                Surname = "Vlasiuk",
                Email="vasylvlasiuk@gmail.com",
                PasswordHash = PasswordConverter.Hash("12345678"),
                RoleId=1,
                Adress=""                
            };
            //password = qwerty12
            //role - moderator
            var user2 = new User()
            {
                Id = 2,
                CreationTime = DateTime.Now,
                Name = "John",
                Surname = "Doe",
                Email = "johndoe@gmail.com",
                PasswordHash = PasswordConverter.Hash("qwerty12"),
                RoleId = 2,
                Adress = ""
            };
            //password = 87654321
            //role = administrator
            var user3 = new User()
            {
                Id = 3,
                CreationTime = DateTime.Now,
                Name = "Ostap",
                Surname = "Bondar",
                Email = "ostepbondar@gmail.com",
                PasswordHash = PasswordConverter.Hash("87654321"),
                RoleId = 3,
                Adress = ""
            };

            //CREATE PRODUCTS
            var product1 = new Product()
            {
                Id = 1,
                CreatorUserId=3,
                CategoryId=1,
                Producer="Apple",
                Model="iPhone XR 64GB",
                Price=760.0M,
                Description="Example of description about a smartphone.",
                ImageId=1,
                CreationTime=DateTime.Now,
                CommentsEnabled=true
            };
            var product2 = new Product()
            {
                Id = 2,
                CreatorUserId = 3,
                CategoryId = 1,
                Producer = "Samsung",
                Model = "S10e SM-G970",
                Price = 650.00M,
                Description = "New smartphone Samsung S10e is already in sale.",
                ImageId = 2,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product3 = new Product()
            {
                Id = 3,
                CreatorUserId = 3,
                CategoryId = 2,
                Producer = "Apple",
                Model = "Macbook Pro 16\"",
                Price = 2200.00M,
                Description = "New notebook from Apple is already in our store.",
                ImageId = 3,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product4 = new Product()
            {
                Id = 4,
                CreatorUserId = 3,
                CategoryId = 2,
                Producer = "Apple",
                Model = "MacBook Pro 13\" Space Gray",
                Price = 1400.00M,
                Description = "New notebook from Apple is already in our store.",
                ImageId = 4,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product5 = new Product()
            {
                Id = 5,
                CreatorUserId = 3,
                CategoryId = 3,
                Producer = "LG",
                Model = "43UM7459",
                Price = 450.00M,
                Description = "New TV with high resolution screen.",
                ImageId = 5,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };

            builder.Entity<UserRole>().HasData(adminRole, moderRole, simpleRole);
            builder.Entity<Image>().HasData(iphonexr, samsung10e, macbook16, macbook13, lgtv);
            builder.Entity<Category>().HasData(smartphones, notebooks, tvs);
            builder.Entity<User>().HasData(user1,user2,user3);
            builder.Entity<Product>().HasData(product1, product2, product3, product4, product5);

        }
    }
}
