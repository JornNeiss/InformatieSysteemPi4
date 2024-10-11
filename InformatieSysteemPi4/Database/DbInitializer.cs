using InformatieSysteemPi4.Models;
using System;
using System.Linq;

namespace InformatieSysteemPi4.Database
{
    public static class DbInitializer
    {
        public static void Initialize(FrietzaakDbContext context)
        {
            // Zorg ervoor dat de database bestaat
            context.Database.EnsureCreated();

            // Controleer of er al gegevens zijn
            if (context.Products.Any())
            {
                return; // De database is al gevuld
            }

          
        }
    }
}
