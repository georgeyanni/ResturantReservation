using Microsoft.EntityFrameworkCore;
using Reservation.Helper;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Data
{
    public class AuthRepo : IAuthRepo
    {
        private readonly ReservationContext _context;
        public AuthRepo(ReservationContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Username==username && u.Password==MD5Hashing.CreateMD5(password));

            if (user == null) return null;

            return user;

        }
    }
}
