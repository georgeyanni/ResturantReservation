using Microsoft.EntityFrameworkCore;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Helper
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodList>().HasData(
              new FoodList { Id = 1, FoodType = "Pizza" }
              );
            modelBuilder.Entity<FoodList>().HasData(
              new FoodList { Id = 2, FoodType = "Sea Food" }
              );
            modelBuilder.Entity<FoodList>().HasData(
               new FoodList { Id = 3, FoodType = "Fried Chicken" }
               );

            modelBuilder.Entity<User>().HasData(

               new User
               {
                   Id = 1,
                   Name = "george yanni",
                   Username = "georgey",
                   Password = MD5Hashing.CreateMD5("g123")
               });

            modelBuilder.Entity<User>().HasData(

               new User
               {
                   Id = 2,
                   Name = "helmy adam",
                   Username = "helmya",
                   Password = MD5Hashing.CreateMD5("h123")
               });


            modelBuilder.Entity<Models.ReservationTable>().HasData(
                new Models.ReservationTable
                {
                    Id = 1,
                    FoodTypeId=1,
                    TableNo = 12,
                    PepoleNumber = 5,
                    ReservationDate = Convert.ToDateTime("2021-05-08"),
                    UserId = 1

                });


            modelBuilder.Entity<Models.ReservationTable>().HasData(
                new Models.ReservationTable
                {
                    Id = 2,
                    FoodTypeId = 2,
                    TableNo = 15,
                    PepoleNumber = 10,
                    ReservationDate = Convert.ToDateTime("2021-05-08"),
                    UserId = 2

                });







        }
    }

  }

