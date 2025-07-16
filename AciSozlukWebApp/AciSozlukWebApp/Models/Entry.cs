using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class Entry: Entity
    {
        public int MemberID { get; set; }
        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }
        public int TitleID { get; set; }
        [ForeignKey("TitleID")]
        public virtual Title Title { get; set; }

        [Display(Name ="Yazı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        [StringLength(500,ErrorMessage ="Bu alan en fazla 500 karakter olabilir")]
        public string EntryWrite { get; set; }

        public DateTime CreationTime { get; set; }= DateTime.Now;
    }
}