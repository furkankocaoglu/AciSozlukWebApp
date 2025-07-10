using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace AciSozlukWebApp.Models.ViewModels
{
    public class ManagerLoginViewModel
    {

        [Display(Name ="KullanıcıAdı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Bu alan en fazla 5-20 karakter olabilir")]
        public string UserName { get; set; }

        [Display(Name ="Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Bu alan en fazla 5-20 karakter olabilir")]

        public string Password { get; set; }    



    }
}