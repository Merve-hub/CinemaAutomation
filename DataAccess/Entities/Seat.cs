using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
 public class Seat:BaseEntity
    {
        public string SeatNo { get; set; }
        public virtual List<SalloonSeat> SalloonSeats { get; set; }

    }
}
