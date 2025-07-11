using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class Entity
    {
        public int ID { get; set; }

        public bool IsActive { get; set; } = true;

        public bool Deleted { get; set; }=false;
    }
}