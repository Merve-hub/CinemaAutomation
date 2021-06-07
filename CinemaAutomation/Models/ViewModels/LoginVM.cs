using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAutomation.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage="Kullanıcı Adı Boş Geçilemez")]
         [Display(Name ="Kullanıcı Adı")]
         public string UserName { get; set; }

        [Required(ErrorMessage ="Parola Boş Geçilemez")]
        [Display(Name ="Parola")]
        public string Password { get; set; }
        public bool IsPersistant { get; set; }


    }
}
