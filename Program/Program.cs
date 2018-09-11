//using PetShop.Core.ApplicationService;
//using PetShop.Core.Entity;
//using System;

//namespace Program
//{
//    class Program
//    {
//        readonly IPetShopService _petShopService;
//        public Program(IPetShopService petShopService)
//        {
//            _petShopService = petShopService;
//            //ShowPets(); //Amazing unit test
//            MenuFunction();
//        }

//        public void MenuFunction()
//        {
//            var selection = 0;
//            Console.WriteLine("\nMenu: \n\n" +
//                "1: Add a pet.\n" +
//                "2: List of pets.\n" +
//                "3: Update a pet.\n" +
//                "4: Delete a pet.\n" +
//                "5: Search pet by type.\n" +
//                "6: Order pets by price.\n" +
//                "7: Top 5 cheapest pets.");
//            Console.WriteLine();

//            selection = int.Parse(Console.ReadLine());

//            var petList = _petShopService.GetAllPets();
//            switch (selection)
//            {
//                case 1:
//                    Console.WriteLine("Adding a new pet to our reserve...\n");
//                    var petType = AskQuestion("Type: ");
//                    var petRace = AskQuestion("Race: ");
//                    var petColor = AskQuestion("Color: ");
//                    var petBirthD = AskADate("Birthday: ");
//                    var petPrice = AskANumber("Price: ");
//                    var petoldOwner = AskQuestion("Last owner: ");
//                    var petsoldDate = AskADate("Date: ");
//                    var pet = _petShopService.NewPet(petType, petRace, petColor, petBirthD, petPrice, petsoldDate, petoldOwner);
//                    _petShopService.CreatePet(pet);
//                    break;
//                case 2:
//                    Console.WriteLine("Loading pets...\n ===========");
//                    ShowPets();
//                    break;
//                case 3:
//                    ShowPets();
//                    Console.WriteLine("Which pet do you want to update?");
//                    var petID = AskANumber("Pet ID: ");
//                    var oldOwner = AskQuestion("Last owner: ");
//                    var newPrice = AskANumber("New price: ");
//                    var soldDate = AskADate("Date: ");
//                    var petByID = _petShopService.FindPetByID(petID);
//                    _petShopService.UpdatePet(new Pet()
//                    {
//                        ID = petID,
//                        Owner = owner,
//                        Price = newPrice,
//                        SoldDate = soldDate
//                    });
//                    break;
//                case 4:
//                    Console.WriteLine("Removing process.\n -Press 0 to come back\n -Type pet's id to remove.");
//                    ShowPets();
//                    var idSelection = int.Parse(Console.ReadLine());
//                    _petShopService.RemovePet(idSelection);
//                    break;
//                case 5:
//                    var Type = AskQuestion("Which type do you wish?\n Do not forget to write the first letter as a capital.");
//                    ShowPetsByType(Type);
//                    break;
//                case 6:
//                    Console.WriteLine("Looking for most expensive pet and making an order...");
//                    ShowPetsByPrice();
//                    break;
//                case 7:
//                    Console.WriteLine("Printing the most 5 cheapest pets availables...");
//                    ShowCheapestPets();
//                    break;
//            }
//            MenuFunction();
//        }

//        private void ShowCheapestPets()
//        {
//            var petList = _petShopService.GetCheapestPets();
//            foreach (var pet in petList)
//            {
//                Console.WriteLine(
//                                    "ID: " + pet.ID +
//                                    "\nType: " + pet.Type +
//                                    "\nRace: " + pet.Race +
//                                    "\nBirthday " + pet.Birthday.ToShortDateString() +
//                                    "\nColor: " + pet.Color +
//                                    "\nSold date: " + pet.SoldDate.ToShortDateString() +
//                                    "\nOld owner: " + pet.OldOwner +
//                                    "\nDKK: " + pet.Price + "\n ======="
//                                    );
//            }
//        }

//        private void ShowPetsByPrice()
//        {
//            var petList = _petShopService.GetAllPetsByPrice();
//            foreach (var pet in petList)
//            {
//                Console.WriteLine(
//                    "ID: " + pet.ID +
//                    "\nType: " + pet.Type +
//                    "\nRace: " + pet.Race +
//                    "\nBirthday " + pet.Birthday.ToShortDateString() +
//                    "\nColor: " + pet.Color +
//                    "\nSold date: " + pet.SoldDate.ToShortDateString() +
//                    "\nOld owner: " + pet.OldOwner +
//                    "\nDKK: " + pet.Price + "\n ======="
//                    );
//            }
//        }
//        void ShowPetsByType(string type)
//        {
//            Console.WriteLine("Looking into our reserve...");
//            var petsList = _petShopService.GetAllPetsByType(type);
//            if (petsList.Count == 0)
//            {
//                Console.WriteLine("We dont have any pet of your desiree type. We are so sorry :(");
//            }
//            else
//            {
//                foreach (var typeWish in petsList)
//                {
//                    Console.WriteLine("\nID: " + typeWish.ID +
//                        "\nType: " + typeWish.Type +
//                        "\nRace: " + typeWish.Race +
//                        "\nBirthday " + typeWish.Birthday.ToShortDateString() +
//                        "\nColor: " + typeWish.Color +
//                        "\nSold date: " + typeWish.SoldDate.ToShortDateString() +
//                        "\nOld owner: " + typeWish.OldOwner +
//                        "\nDKK: " + typeWish.Price + "\n =======");
//                }
//            }
//        }
//        void ShowPets()
//        {
//            var petsList = _petShopService.GetAllPets();
//            foreach (var pet in petsList)
//            {
//                Console.WriteLine(
//                    "ID: " + pet.ID +
//                    "\nType: " + pet.Type +
//                    "\nRace: " + pet.Race +
//                    "\nBirthday " + pet.Birthday.ToShortDateString() +
//                    "\nColor: " + pet.Color +
//                    "\nSold date: " + pet.SoldDate.ToShortDateString() +
//                    "\nOld owner: " + pet.OldOwner +
//                    "\nDKK: " + pet.Price + "\n ======="
//                    );
//            }
//        }
//        private string AskQuestion(string q)
//        {
//            Console.WriteLine(q);
//            return Console.ReadLine();

//        }
//        private int AskANumber(string q)
//        {
//            Console.WriteLine(q);
//            try
//            {
//                return Int32.Parse(Console.ReadLine());
//            }
//            catch (Exception)
//            {
//                Console.WriteLine("Type invalid, try again.\nThe input must be a number or a group of numbers.");
//                MenuFunction();
//                throw;
//            }
//        }
//        private DateTime AskADate(string q)
//        {
//            Console.WriteLine(q);
//            try
//            {
//                return DateTime.Parse(Console.ReadLine());
//            }
//            catch (Exception)
//            {
//                Console.WriteLine("Type invalid, try again.\nThe input must be: xx/xx/xxxx where x = number.");
//                MenuFunction();
//                throw;
//            }
//        }
//    }
//}
