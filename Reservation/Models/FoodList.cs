using System;
using System.Collections.Generic;

#nullable disable

namespace Reservation.Models
{
    public partial class FoodList
    {
        public FoodList()
        {
            ReservationTables = new HashSet<ReservationTable>();
        }

        public int Id { get; set; }
        public string FoodType { get; set; }

        public virtual ICollection<ReservationTable> ReservationTables { get; set; }
    }
}
