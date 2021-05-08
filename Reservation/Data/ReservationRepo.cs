using Microsoft.EntityFrameworkCore;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Reservation.Data
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly ReservationContext _context;

        public ReservationRepo(ReservationContext context)
        {
            _context = context;

        }
        public async Task AddReservation(ReservationTable reservation)
        {
            await _context.ReservationTables.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<ReservationTable>> GetAllReservation()
        {
            return await _context.ReservationTables
                .Include(u=>u.User)
                .Include(f=>f.FoodType)
                .ToListAsync();
        }

        public async Task<IList<FoodList>> GetFoodList()
        {
          var foodList=  await _context.FoodLists.ToListAsync();

            return foodList;
        }
    }
}
