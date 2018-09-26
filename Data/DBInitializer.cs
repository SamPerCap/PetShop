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
                Address = "El Greco",
                Email = "owner1@gmail.com",
                FirstName = "Owner",
                LastName = "The First",
                PhoneNumber = 654657575
            }).Entity;
            var pet1 = ctx.Pets.Add(new Pet()
            {
                Birthday = new DateTime(2005, 4, 6),
                Owner = owner1,
                SoldDate = new DateTime(2005, 6, 7),
                Color = "White",
                Race = "Yorkshire",
                Type = "Dog",
                Price = 4450
            }).Entity;

            ctx.SaveChanges();
        }



    }
}
