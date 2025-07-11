using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class Like:Entity

    {
        [Display(Name ="Oy Sayısı")]
        public int Vote { get; set; }

        public DateTime LikeTime { get; set; }=DateTime.Now;
        public int EntryID { get; set; }
        [ForeignKey("EntryID")]
        public virtual Entry Entry { get; set; }

        public int MemberID { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }
    }
}