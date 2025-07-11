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
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string TitleName { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;

        public virtual ICollection<Entry> Entries { get; set; }

    }
}