using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class FeedBack:Entity
    {
        [Display(Name ="Konu")]
        [Required(ErrorMessage ="Bu alan zorunludur")]
        public string Subject { get; set; }

        [Display(Name = "İçerik")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Description { get; set; }

        public DateTime CreationTime {  get; set; }=DateTime.Now;
    }
}