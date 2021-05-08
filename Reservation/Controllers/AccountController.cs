using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using Reservation.Data;
using Reservation.Dtos;
using Reservation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reservation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthRepo _repo;

        public AccountController(IAuthRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<ActionResult> Login(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userLogin =await _repo.Login(user.Username,user.Password);

            if (userLogin == null) return View();


            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,userLogin.Name),
                new Claim("Username",userLogin.Username),
                new Claim("UserId",userLogin.Id.ToString())

            };


            var claimsIdentity = new ClaimsIdentity(claims, "Claims Identity");
            var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
         
            await HttpContext.SignInAsync(claimsPrinciple);

            return RedirectToAction("Index", "Reservation");
        }

       
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
