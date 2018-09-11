using Infrastructure.Static.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    class Executable
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetShopRepository, PetShopRepository>();
            serviceCollection.AddScoped<IPetShopService, PetShopService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetShopService>();
            FakeDB.DefaultData();
            //new Program(petService);
            

            Console.ReadLine();
        }
    }
}
