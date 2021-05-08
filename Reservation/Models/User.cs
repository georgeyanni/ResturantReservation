using System;
using System.Collections.Generic;

#nullable disable

namespace Reservation.Models
{
    public partial class User
    {
        public User()
        {
            ReservationTables = new HashSet<ReservationTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ReservationTable> ReservationTables { get; set; }
    }
}
