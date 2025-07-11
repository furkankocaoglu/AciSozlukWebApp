using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class Category:Entity
    {
        [Display(Name ="KategoriAdı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string CategoryName { get; set; }

        public DateTime CreationTime { get; set; }=DateTime.Now;

        public virtual ICollection<Title> Titles { get; set; }
        
    }
}