using CinemaAutomation.Models.ViewModels;
using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.SalloonService
{
    public class SalloonRepository : ISalloonRepository
    {
        private readonly ApplicationDbContext context;

        public SalloonRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public SalloonSeatVM GetSeats(int salloonId)
        {
            SalloonSeatVM salloonSeatVM = new SalloonSeatVM();
            salloonSeatVM.Salloon = context.Salloons.Find(salloonId);
            salloonSeatVM.Seats = new List<Seat>();

            var sallonSeat = context.SalloonSeats.Where(x => x.SalloonId == salloonId).ToList();

            foreach (var salloon in sallonSeat)
            {
                salloonSeatVM.Seats.Add(context.Seats.FirstOrDefault(x => x.Id == salloon.SeatId));

            }
            return salloonSeatVM;
        }
    }
}
