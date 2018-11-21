using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoApi.Data;

namespace Infrastructure.Data
{
    public class DBInitializer
    {

        public static void SeedDB(PetAppContext ctx)
        {

            //ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem { IsComplete=true, Name="Make homework"},
                new TodoItem { IsComplete=false, Name="Sleep"}
};
            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashSusi, passwordSaltSusi, passwordHashSam, passwordSaltSam;
            CreatePasswordHash(password, out passwordHashSusi, out passwordSaltSusi);
            CreatePasswordHash(password, out passwordHashSam, out passwordSaltSam);


            var owner1 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Susana",
                LastName = "Caparros",
                Address = "MyHeart<3",
                PhoneNumber = 060606060,
                Email = "l@gmail.com",
            }).Entity;
            var owner2 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Samuel",
                LastName = "Caparros",
                Address = "Doom",
                PhoneNumber = 123456789,
                Email = "daaaaamn@gmail.com",
            }).Entity;

            var pet1 = ctx.Pets.Add(new Pet()
            {
                Birthday = new DateTime(1997, 3, 18),
                Owner = owner1,
                SoldDate = new DateTime(2016, 8, 26),
                Color = "White",
                Race = "Programmer",
                Type = "Student",
                Price = -4450
            }).Entity;

            var customer1 = ctx.Customers.Add(new Customer()
            {
               // ID = 1,
                FirstName = "SamuelLDB",
                LastName = "CaparrosLDB",
                Address = "1234LDB",
                PasswordHash = passwordHashSam,
                PasswordSalt = passwordSaltSam,
                IsAdmin = true
            }).Entity;

            ctx.TodoItems.AddRange(items);
            ctx.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }


    }
}
