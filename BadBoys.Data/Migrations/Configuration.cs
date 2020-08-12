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
                new Crime { CrimeId = 5, CrimeType = (CrimeTypes)5, CrimeDescription = "Attempt to overthrow and destroy the Galactic Federation", Penalty = "Eternity in Galactic Federation Prison" },
                new Crime { CrimeId = 6, CrimeType = (CrimeTypes)5, CrimeDescription = "Meddling with a foreign nation in an attempt to rig an election", Penalty = "30 years in Galactic Federation Prison & $5,000,000 fine" },
                new Crime { CrimeId = 7, CrimeType = (CrimeTypes)2, CrimeDescription = "Possession of concentrated Dark Matter", Penalty = "15 years in Galactic Federation Prison" },
                new Crime { CrimeId = 8, CrimeType = (CrimeTypes)1, CrimeDescription = "Stolen Microverse battery", Penalty = "3 years in Galactic Federation Prison" },
                new Crime { CrimeId = 9, CrimeType = (CrimeTypes)2, CrimeDescription = "Possession of Death Crystals", Penalty = "10 years in Galactic Federation Prison" },
                new Crime { CrimeId = 10, CrimeType = (CrimeTypes)4, CrimeDescription = "Destroying an entire civilized planet (C-137)", Penalty = "65 years in Galactic Federation Prison" }
                );

            context.Suspects.AddOrUpdate(x => x.SuspectId,
                new Suspect { SuspectId = 1, Name = "Sleepy Gary", Height = "5'11\"", Weight = 185, PriorConviction = false, DateBooked = new DateTime(2013, 05, 23, 14, 58, 00) },
                new Suspect { SuspectId = 2, Name = "Pencilvester", Height = "2'6\"", Weight = 15, PriorConviction = true, DateBooked = new DateTime(2015, 03, 06, 11, 23, 00) },
                new Suspect { SuspectId = 3, Name = "Reverse Giraffe", Height = "8'2\"", Weight = 215, PriorConviction = true, DateBooked = new DateTime(2016, 01, 16, 04, 20, 00) },
                new Suspect { SuspectId = 4, Name = "Cousin Nicky", Height = "5'8\"", Weight = 165, PriorConviction = false, DateBooked = new DateTime(2015, 02, 14, 17, 30, 00) },
                new Suspect { SuspectId = 5, Name = "Amish Cyborg", Height = "6'5\"", Weight = 240, PriorConviction = true, DateBooked = new DateTime(1998, 10, 25, 09, 17, 00) },
                new Suspect { SuspectId = 6, Name = "Scary Terry", Height = "5'7\"", Weight = 155, PriorConviction = true, DateBooked = new DateTime(1984, 10, 31, 21, 47, 00) },
                new Suspect { SuspectId = 7, Name = "Tammy Guterman", Height = "5'4\"", Weight = 130, PriorConviction = true, DateBooked = new DateTime(2015, 05, 20, 11, 32, 00) },
                new Suspect { SuspectId = 8, Name = "Taddy Mason", Height = "6'1\"", Weight = 200, PriorConviction = false, DateBooked = new DateTime(2018, 11, 08, 13, 13, 00) },
                new Suspect { SuspectId = 9, Name = "Mr. Meeseeks", Height = "4'8\"", Weight = 180, PriorConviction = true, DateBooked = new DateTime(2013, 06, 14, 05, 51, 00) },
                new Suspect { SuspectId = 10, Name = "Hamurai", Height = "5'2\"", Weight = 290, PriorConviction = false, DateBooked = new DateTime(2014, 07, 20, 12, 21, 00) },
                new Suspect { SuspectId = 11, Name = "Mr. Poopybutthole", Height = "3'3\"", Weight = 45, PriorConviction = false, DateBooked = new DateTime(2019, 04, 08, 07, 34, 00) },
                new Suspect { SuspectId = 12, Name = "Ants in my Eyes Johnson", Height = "5'10\"", Weight = 230, PriorConviction = false, DateBooked = new DateTime(2020, 02, 29, 13, 17, 00) },
                new Suspect { SuspectId = 13, Name = "Gazorpazorpfield", Height = "4'3\"", Weight = 170, PriorConviction = true, DateBooked = new DateTime(2015, 11, 11, 17, 24, 00) },
                new Suspect { SuspectId = 14, Name = "Mrs. Pancakes", Height = "5'6\"", Weight = 155, PriorConviction = false, DateBooked = new DateTime(2019, 12, 31, 23, 45, 00) },
                new Suspect { SuspectId = 15, Name = "Jan-Michael Vincent", Height = "6'4\"", Weight = 235, PriorConviction = true, DateBooked = new DateTime(2011, 03, 17, 22, 05, 00) },
                new Suspect { SuspectId = 16, Name = "Photography Raptor", Height = "7'1\"", Weight = 315, PriorConviction = false, DateBooked = new DateTime(2020, 05, 29, 21, 18, 00) },
                new Suspect { SuspectId = 17, Name = "Krombopulous Michael", Height = "6'2\"", Weight = 170, PriorConviction = true, DateBooked = new DateTime(2004, 01, 20, 12, 03, 00) },
                new Suspect { SuspectId = 18, Name = "Revolio Clockberg Jr.", Height = "6'6\"", Weight = 260, PriorConviction = true, DateBooked = new DateTime(2008, 07, 04, 20, 41, 00) },
                new Suspect { SuspectId = 19, Name = "Lucius Needful", Height = "6'0\"", Weight = 165, PriorConviction = true, DateBooked = new DateTime(1999, 09, 18, 06, 06, 00) },
                new Suspect { SuspectId = 20, Name = "Scroopy Noopers", Height = "4'8\"", Weight = 150, PriorConviction = false, DateBooked = new DateTime(2016, 10, 07, 10, 15, 00) }
            );
        }
    }
}
