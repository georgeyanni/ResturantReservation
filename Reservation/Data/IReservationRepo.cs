using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Data
{
    public interface IReservationRepo
    {
        Task AddReservation(ReservationTable reservation);
        Task<IList<FoodList>> GetFoodList();

        Task<IList<ReservationTable>>GetAllReservation();
    }
}
