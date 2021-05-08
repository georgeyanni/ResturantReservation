using System;
using System.Collections.Generic;

#nullable disable

namespace Reservation.Models
{
    public partial class ReservationTable
    {
        public int Id { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int? TableNo { get; set; }
        public int? PepoleNumber { get; set; }
        public string Notes { get; set; }
        public int? FoodTypeId { get; set; }
        public int? UserId { get; set; }

        public virtual FoodList FoodType { get; set; }
        public virtual User User { get; set; }
    }
}
