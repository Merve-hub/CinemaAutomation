using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAutomation.Models.ViewModels
{
    public class RegisterVM
    {   [Required(ErrorMessage="Kullanıcı adı boş geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Email adı boş geçilemez")]
        [EmailAddress(ErrorMessage= "Lütfen Email Formatında Giriş Yapın")]

        public string Email { get; set; }



        
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [Display(Name = "Şifre")]

        public string Password { get; set; }
        
        
        [Required(ErrorMessage = "Şifre(Tekrar) boş geçilemez")]
        [Display(Name = "Şifre Tekrar")]

        [Compare("Password" ,ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

    }
}
