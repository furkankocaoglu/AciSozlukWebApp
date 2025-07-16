using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class MemberRole : Entity
    {
        [Display(Name = "Rol Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}