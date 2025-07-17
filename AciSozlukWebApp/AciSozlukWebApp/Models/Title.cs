using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class Title:Entity
    {
        public Title()
        {
            Deleted = true;
            IsActive = false;
        }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 20, ErrorMessage = "Bu alan en fazla 20 karakter olabilir")]

        public string TitleName { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;

        public virtual ICollection<Entry> Entries { get; set; }

    }
}