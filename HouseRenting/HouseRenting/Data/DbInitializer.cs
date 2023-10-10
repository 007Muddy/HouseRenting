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
                    Type = "Single Family",
                    Color = "Blue",
                    Area = 2000.5m,
                    Price = 250000.0f,
                    NumberOfRooms = "3",
                    Location = "123 Main St",
                    ConstructionDate = new DateTime(2005, 5, 15),
                    Description = "A beautiful single-family home in a quiet neighborhood."
                },
                new House
                {
                    Type = "Apartment",
                    Color = "Red",
                    Area = 1200.75m,
                    Price = 150000.0f,
                    NumberOfRooms = "2",
                    Location = "456 Elm St",
                    ConstructionDate = new DateTime(2010, 8, 20),
                    Description = "Spacious apartment with a great view of the city."
                },
                new House
                {
                    Type = "Condo",
                    Color = "White",
                    Area = 1000.0m,
                    Price = 180000.0f,
                    NumberOfRooms = "2",
                    Location = "789 Oak St",
                    ConstructionDate = new DateTime(2008, 12, 10),
                    Description = "Modern condo with excellent amenities."
                },
                new House
                {
                    Type = "Townhouse",
                    Color = "Yellow",
                    Area = 1500.25m,
                    Price = 210000.0f,
                    NumberOfRooms = "4",
                    Location = "101 Pine St",
                    ConstructionDate = new DateTime(2012, 6, 5),
                    Description = "Charming townhouse with a small garden."
                },
                new House
                {
                    Type = "Duplex",
                    Color = "Green",
                    Area = 1800.0m,
                    Price = 280000.0f,
                    NumberOfRooms = "4",
                    Location = "222 Oak Ave",
                    ConstructionDate = new DateTime(2015, 4, 18),
                    Description = "Duplex with two separate units for rental income."
                },
                new House
                {
                    Type = "Ranch",
                    Color = "Brown",
                    Area = 2200.75m,
                    Price = 320000.0f,
                    NumberOfRooms = "3",
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
