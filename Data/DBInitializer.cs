using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class DBInitializer
    {

        public static void SeedDB(PetAppContext ctx)
        {

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

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
            PasswordHash = passwordHashSusi,
            PasswordSalt = passwordSaltSusi,
            IsAdmin = true
            }).Entity;
            var owner2 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Samuel",
                LastName = "Caparros",
                Address = "Doom",
                PhoneNumber = 123456789,
                Email = "daaaaamn@gmail.com",
                PasswordHash = passwordHashSam,
                PasswordSalt = passwordSaltSam,
                IsAdmin = true
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

            ctx.SaveChanges();
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


    }
}
