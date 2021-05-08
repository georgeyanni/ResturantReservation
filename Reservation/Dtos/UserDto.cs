using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Dtos
{
    public class UserDto
    {
       
        public int Id { get; set; }
       
        public string Name { get; set; }

        [Display(Name = "Username")]
        [Required]
        public string Username { get; set; }
       
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
    }
}
