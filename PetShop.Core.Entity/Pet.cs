using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Race { get; set; }
        public string Color { get; set; }
        public DateTime Birthday { get; set; }
        public int Price { get; set; }
        public DateTime SoldDate { get; set; }
        public Owner Owner { get; set; }
    }
}
