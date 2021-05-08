using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Data
{
    public interface IAuthRepo
    {
        Task<User> Login(string username, string password);
    }
}
