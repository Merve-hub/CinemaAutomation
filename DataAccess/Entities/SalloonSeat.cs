using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
 public  class SalloonSeat:BaseEntity
    {
        public int SalloonId { get; set; }
        public int SeatId { get; set; }
        
        public Salloon Salloon { get; set; }
        public Seat Seat { get; set; }

    }
}
