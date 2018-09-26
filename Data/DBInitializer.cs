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
            var owner1 = ctx.Owners.Add(new Owner()
            {
            FirstName = "Susana",
            LastName = "Caparros",
            Address = "MyHeart<3",
            PhoneNumber = 060606060,
            Email = "fuckMySon@gmail.com"
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



    }
}
