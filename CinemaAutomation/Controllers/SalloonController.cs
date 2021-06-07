using CinemaAutomation.Models.ViewModels;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;
using Services.SalloonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAutomation.Controllers
{
    public class SalloonController : Controller
    {
        private readonly IRepository<Salloon> salloonRepository;
        private readonly IRepository<Seat> seatRepository;
        private readonly IRepository<SalloonSeat> salloonSeatRepository;
        private readonly ISalloonRepository salloonSeatRepo;

        public SalloonController(IRepository<Salloon> salloonRepository, IRepository<Seat> seatRepository, IRepository<SalloonSeat> salloonSeatRepository, ISalloonRepository salloonSeatRepo)
        {
            this.salloonRepository = salloonRepository;
            this.seatRepository = seatRepository;
            this.salloonSeatRepository = salloonSeatRepository;
            this.salloonSeatRepo = salloonSeatRepo;
        }
        public IActionResult Index()
        {
            return View(salloonSeatRepository.GetAll());
        }
        public IActionResult Details(int id)
        {
            //SalloonSeatVM salloonSeatVM = new SalloonSeatVM();
            //salloonSeatVM.Salloon =salloonRepository.GetById(id);
            //salloonSeatVM.Seats = new List<Seat>();

            //var sallonSeat = salloonSeatRepository.GetAll().Where(x => x.SalloonId == id).ToList();

            //foreach (var salloon in sallonSeat)
            //   salloonSeatVM.Seats.Add(seatRepository.GetById(salloon.SeatId));

            //return View();

            var result = salloonSeatRepo.GetSeats(id);
            return View(result);


        }

    }
}
