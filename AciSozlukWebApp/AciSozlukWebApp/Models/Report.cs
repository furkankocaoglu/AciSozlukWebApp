using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class Report:Entity

    {
        public int EntryID { get; set; }

        [ForeignKey("EntryID")]
        public virtual Entry Entry { get; set; }

        public int MemberID { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }

        [Display(Name ="Şikayet İçeriği")]
        [Required(ErrorMessage ="Bu alan zorunludur")]
        public string ReportWrite { get; set; }

        public DateTime CreationTime {  get; set; }=DateTime.Now;
    }
}