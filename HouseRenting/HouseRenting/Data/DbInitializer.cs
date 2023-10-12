using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HouseRenting.Data;
using HouseRenting.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new HouseDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<HouseDbContext>>()))
        {
            // Check if there's already data in the database
            if (context.House.Any())
            {
                return; // Database has been seeded
            }

            // Add more seed data
            context.House.AddRange(
                new House
                {
                    Type = "Apartment",
                    Color = "Gray",
                    Area = 950.5m,
                    Price = 135000,
                    Rooms = "2",
                    Location = "789 Maple Ave",
                    ConstructionDate = new DateTime(2011, 9, 30),
                    Description = "Modern apartment with great city access."
                },
                new House
                {
                    Type = "Single Family",
                    Color = "Blue",
                    Area = 2000.5m,
                    Price = 250000,
                    Rooms = "3",
                    Location = "123 Main St",
                    ConstructionDate = new DateTime(2005, 5, 15),
                    Description = "A beautiful single-family home in a quiet neighborhood."
                },
                new House
                {
                    Type = "Apartment",
                    Color = "Red",
                    Area = 1200.75m,
                    Price = 150000,
                    Rooms = "2",
                    Location = "456 Elm St",
                    ConstructionDate = new DateTime(2010, 8, 20),
                    Description = "Spacious apartment with a great view of the city."
                },
                new House
                {
                    Type = "Condo",
                    Color = "White",
                    Area = 1000.0m,
                    Price = 180000,
                    Rooms = "2",
                    Location = "789 Oak St",
                    ConstructionDate = new DateTime(2008, 12, 10),
                    Description = "Modern condo with excellent amenities."
                },
                new House
                {
                    Type = "Townhouse",
                    Color = "Yellow",
                    Area = 1500.25m,
                    Price = 210000,
                    Rooms = "4",
                    Location = "101 Pine St",
                    ConstructionDate = new DateTime(2012, 6, 5),
                    Description = "Charming townhouse with a small garden."
                },
                 new House
                 {
                     Type = "Duplex",
                     Color = "Teal",
                     Area = 1600.0m,
                     Price = 245000,
                     Rooms = "4",
                     Location = "456 Maple Ln",
                     ConstructionDate = new DateTime(2016, 11, 20),
                     Description = "Duplex with two spacious units for rental income."
                 },
                new House
                {
                    Type = "Duplex",
                    Color = "Green",
                    Area = 1800.0m,
                    Price = 280000,
                    Rooms = "4",
                    Location = "222 Oak Ave",
                    ConstructionDate = new DateTime(2015, 4, 18),
                    Description = "Duplex with two separate units for rental income."
                },
                  new House
                  {
                      Type = "Condo",
                      Color = "Gold",
                      Area = 1100.5m,
                      Price = 170000,
                      Rooms = "2",
                      Location = "456 Elm St",
                      ConstructionDate = new DateTime(2019, 11, 20),
                      Description = "Modern condo with excellent amenities."
                  },
                 new House
                 {
                     Type = "Condo",
                     Color = "Gold",
                     Area = 1100.5m,
                     Price = 170000,
                     Rooms = "2",
                     Location = "456 Elm St",
                     ConstructionDate = new DateTime(2019, 11, 20),
                     Description = "Modern condo with excellent amenities."
                 },
                  new House
                  {
                      Type = "Townhouse",
                      Color = "Magenta",
                      Area = 1500.0m,
                      Price = 220000,
                      Rooms = "4",
                      Location = "789 Pine Ave",
                      ConstructionDate = new DateTime(2018, 4, 5),
                      Description = "Charming townhouse with a beautiful garden."
                  },
                new House

                {
                    Type = "Ranch",
                    Color = "Brown",
                    Area = 2200.75m,
                    Price = 320000,
                    Rooms = "3",
                    Location = "333 Meadow Ln",
                    ConstructionDate = new DateTime(2009, 10, 25),
                    Description = "Spacious ranch-style home with a large backyard."
                }
                // Add more data as needed
            );

            context.SaveChanges();
        }
    }
}
