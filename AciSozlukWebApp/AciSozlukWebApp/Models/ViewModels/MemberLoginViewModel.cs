using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models.ViewModels
{
    public class MemberLoginViewModel
    {
        [Display(Name = "KullanıcıAdı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string NickName { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Password { get; set; }

    }
}