
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Reservation.Data;
using Reservation.Dtos;
using Reservation.Helper;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Reservation.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationRepo _repo;

        private readonly IMapper _mapper;
        public ReservationController(IReservationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {

            List<SelectListItem> items;
            var foodList = await _repo.GetFoodList();

            items = new SelectList(foodList.Select(f => new { f.Id, f.FoodType }), "Id", "FoodType").ToList();

            ViewBag.foodList = items;
            ViewBag.CreatedSuccessfully = TempData["ReservationStatus"];
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReservationDto reservationDto)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetId();

                reservationDto.UserId = int.Parse(userId);

                var reservation = _mapper.Map<ReservationTable>(reservationDto);

                _repo.AddReservation(reservation);

                TempData["ReservationStatus"] = true;
            }

            return RedirectToAction("Index");
        }

        public IActionResult ShowAll()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LoadReservationData()
        {

             
           var reservation = await _repo.GetAllReservation();

            var reservationDto = _mapper.Map<IEnumerable<ReservationDto>>(reservation);
            return Json(JsonConvert.SerializeObject(reservationDto));
            //return Json(new {data = reservationDto });
        }
    }
}
