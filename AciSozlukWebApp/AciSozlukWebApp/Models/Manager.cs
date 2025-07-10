using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class Manager : Entity
    {
        public int ManagerRole_ID { get; set; }

        [ForeignKey("ManagerRole_ID")]

        public virtual ManagerRole ManagerRole { get; set; }

        [Display(Name = "Isim")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 50, ErrorMessage = "Bu alan en fazla 50 karakter olabilir")]
        public string Name { get; set; }

        [Display(Name = "Soyisim")]
        [StringLength(maximumLength: 50, ErrorMessage = "Bu alan en fazla 50 karakter olabilir")]
        public string Surname { get; set; }

        [Display(Name = "KullanıcıAdı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Bu alan en fazla 5-20 karakter olabilir")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Bu alan en fazla 5-20 karakter olabilir")]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool Deleted { get; set; }
    }
}