namespace BadBoys.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BadBoys.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BadBoys.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Crimes.AddOrUpdate(x => x.CrimeId,
                new Crime { CrimeId = 1, CrimeType = (CrimeTypes)1, CrimeDescription = "Stolen Meeseeks box", Penalty = "10 years in Galactic Federation Prison" },
                new Crime { CrimeId = 2, CrimeType = (CrimeTypes)2, CrimeDescription = "Possession of Kalaxian Crystals with intent to distribute", Penalty = "20 years in Galactic Federation Prison & $250,000 fine" },
                new Crime { CrimeId = 3, CrimeType = (CrimeTypes)3, CrimeDescription = "Pedestrian crosswalk was not utilized when crossing the street", Penalty = "12 hours community service" },
                new Crime { CrimeId = 4, CrimeType = (CrimeTypes)4, CrimeDescription = "Illegally purging citizens outside of the designated Purge time", Penalty = "40 years in Galactic Federation Prison" },
                new Crime { CrimeId = 5, CrimeType = (CrimeTypes)5, CrimeDescription = "Attempt to overthrow and destroy the Galactic Federation", Penalty = "Eternity in Galactic Federation Prison" }
                );

            context.Suspects.AddOrUpdate(x => x.SuspectId,
                new Suspect { SuspectId = 1, Name = "Sleepy Gary", Height = "5'11\"", Weight = 185, PriorConviction = false, DateBooked = new DateTime(2013, 5, 23, 14, 58, 00) },
                new Suspect { SuspectId = 2, Name = "Pencilvester", Height = "2'6\"", Weight = 15, PriorConviction = true, DateBooked = new DateTime(2015, 3, 6, 11, 23, 00) },
                new Suspect { SuspectId = 3, Name = "Reverse Giraffe", Height = "8'2\"", Weight = 215, PriorConviction = true, DateBooked = new DateTime(2016, 1, 16, 4, 20, 00) },
                new Suspect { SuspectId = 4, Name = "Cousin Nicky", Height = "5'8\"", Weight = 165, PriorConviction = false, DateBooked = new DateTime(2015, 2, 14, 17, 30, 00) },
                new Suspect { SuspectId = 5, Name = "Amish Cyborg", Height = "6'5\"", Weight = 240, PriorConviction = true, DateBooked = new DateTime(1998, 10, 25, 9, 17, 00) },
                new Suspect { SuspectId = 6, Name = "Scary Terry", Height = "5'7\"", Weight = 155, PriorConviction = true, DateBooked = new DateTime(1984, 10, 31, 21, 47, 00) },
                new Suspect { SuspectId = 7, Name = "Tammy Guterman", Height = "5'4\"", Weight = 130, PriorConviction = true, DateBooked = new DateTime(2015, 5, 20, 11, 32, 00) },
                new Suspect { SuspectId = 8, Name = "Taddy Mason", Height = "6'1\"", Weight = 200, PriorConviction = false, DateBooked = new DateTime(2018, 11, 8, 13, 13, 00) },
                new Suspect { SuspectId = 9, Name = "Mr. Meeseeks", Height = "4'8\"", Weight = 180, PriorConviction = true, DateBooked = new DateTime(2013, 6, 14, 5, 51, 00) },
                new Suspect { SuspectId = 10, Name = "Hamurai", Height = "5'2\"", Weight = 290, PriorConviction = false, DateBooked = new DateTime(2014, 7, 20, 12, 21, 00) }
            );
        }
    }
}
