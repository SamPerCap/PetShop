using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Static.Data.Repositories
{
   public class FakeDB
    {
        public static IEnumerable<Pet> Pets;
        public static int petID = 1;

        public static IEnumerable<Owner> Owners;
        public static int ownerID = 1;

        public static void DefaultData()
        {
            var owner1 = new Owner()
            {
                ID = ownerID++,
                Address = "El Greco",
                Email = "owner1@gmail.com",
                FirstName = "Owner",
                LastName = "The First",
                PhoneNumber = 654657575,
            };
            var owner2 = new Owner()
            {
                ID = ownerID++,
                Address = "Ana María Matute",
                Email = "2Owner@gmail.com",
                FirstName = "Lucas",
                LastName = "Sorn",
                PhoneNumber = 392541094,
            };
            var pet1 = new Pet()
            {
                ID = petID++,
                Birthday = new DateTime(2005, 4, 6),
                Owner = owner1,
                SoldDate = new DateTime(2006, 4, 6),
                Color = "White",
                Race = "Yorkshire",
                Type = "Dog",
                Price = 4450
            };
            var pet2 = new Pet()
            {
                ID = petID++,
                Birthday = new DateTime(2015, 12, 25),
                Color = "Red",
                Race = "Cobra",
                Owner = owner2,
                SoldDate = new DateTime(2015,12,25),
                Type = "Snake",
                Price = 8507
            };
            var pet3 = new Pet()
            {
                ID = petID++,
                Birthday = new DateTime(0001, 5, 2),
                Color = "White",
                Race = "Silvan Elf",
                Owner = owner1,
                SoldDate = new DateTime(2017, 4, 16),
                Type = "Elf",
                Price = 10
            };
            var pet4 = new Pet()
            {
                ID = petID++,
                Birthday = new DateTime(2018, 8, 25),
                Owner = owner2,
                SoldDate = new DateTime(2018, 8, 26),
                Color = "Black",
                Race = "Pellucid Fly",
                Type = "Fly",
                Price = 75
            };
            var pet5 = new Pet()
            {
                ID = petID++,
                Birthday = new DateTime(1997, 3, 18),
                Owner = owner1,
                SoldDate = new DateTime(2016, 6, 20),
                Color = "White",
                Race = "Programmer",
                Type = "Student",
                Price = -75
            };
            Pets = new List<Pet>
            {
                pet1,pet2,pet3,pet4,pet5
            };
            Owners = new List<Owner>
            {
                owner1,owner2
            };
        }
    }
}
