using CinemaAutomation.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.SalloonService
{
  public interface ISalloonRepository
    {

        SalloonSeatVM GetSeats(int salloonId);
            
    }
}
