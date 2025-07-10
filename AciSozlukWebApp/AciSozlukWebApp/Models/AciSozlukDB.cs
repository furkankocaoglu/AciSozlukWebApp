using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AciSozlukWebApp.Models
{
    public partial class AciSozlukDB : DbContext
    {
        public AciSozlukDB()
            : base("name=AciSozlukDB1")
        {
        }
        public DbSet <Manager> Managers { get; set; }
        public DbSet<ManagerRole> ManagerRoles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
