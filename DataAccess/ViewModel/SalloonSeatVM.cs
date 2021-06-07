using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CinemaAutomation.Models.ViewModels
{
    public class SalloonSeatVM
    {
        public Salloon Salloon { get; set; }
        public List<Seat> Seats { get; set; }

    }
}
