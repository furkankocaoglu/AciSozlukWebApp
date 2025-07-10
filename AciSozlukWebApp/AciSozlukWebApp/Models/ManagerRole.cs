using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class ManagerRole : Entity

    {
        // Entity sınıfıntan kalıtım aldım ID otomatik olarak geliyor
        [Display(Name = "Rol Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }

        public virtual ICollection<Manager> Managers { get; set; } // Birden çok yönetici olabilir Virtual(istek anında veri çekme) lazy loading
    }
}