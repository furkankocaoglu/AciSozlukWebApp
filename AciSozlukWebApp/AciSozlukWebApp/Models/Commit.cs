using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class Commit:Entity
    {
        public int EntryID { get; set; }

        [ForeignKey("EntryID")]
        public virtual Entry Entry { get; set; }

        public int MemberID { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }

        [Display(Name ="Yorum İçeriği")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        [StringLength(300,ErrorMessage ="Yorum en fazla 300 karakter olabilir")]
        public string CommitWrite { get; set; }

        public DateTime CreationTime { get; set; }=DateTime.Now;       
        
    }
}