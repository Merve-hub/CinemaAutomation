using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Salloon:BaseEntity
    {
        public string SalloonName { get; set; }
        public string Capacity { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
        public virtual List<SalloonSeat> SalloonSeats { get; set; }

    }
}
