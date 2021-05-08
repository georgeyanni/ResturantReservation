using Reservation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Dtos
{
    public class ReservationDto
    {
        [Display(Name ="ReservationNo")]
        public int Id { get; set; }


        [Display(Name = "ReservationDate")]
        [Required]
        public DateTime ReservationDate { get; set; }


        [Display(Name = "TableNo")]
        [Required]
        public int TableNo { get; set; }

        [Display(Name = "PepoleNumber")]
        [Required]
        public int PepoleNumber { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
       
        [Display(Name = "FoodType")]
        [Required]
        public int FoodTypeId { get; set; }
        public int UserId { get; set; }

        [Display(Name = "UserFullName")]
        public string Name { get; set; }

        [Display(Name = "FoodType")]
        public string FoodType { get; set; }
    }
}
