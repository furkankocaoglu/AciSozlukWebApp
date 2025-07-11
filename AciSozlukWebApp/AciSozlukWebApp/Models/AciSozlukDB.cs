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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Commit>()
                .HasRequired(c => c.Member)
                .WithMany()
                .HasForeignKey(c => c.MemberID)
                .WillCascadeOnDelete(false);

            
            modelBuilder.Entity<Commit>()
                .HasRequired(c => c.Entry)
                .WithMany()
                .HasForeignKey(c => c.EntryID)
                .WillCascadeOnDelete(false);

           
            modelBuilder.Entity<Like>()
                .HasRequired(l => l.Member)
                .WithMany()
                .HasForeignKey(l => l.MemberID)
                .WillCascadeOnDelete(false);

            
            modelBuilder.Entity<Like>()
                .HasRequired(l => l.Entry)
                .WithMany()
                .HasForeignKey(l => l.EntryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Report>()
                .HasRequired(r => r.Member)
                .WithMany()
                .HasForeignKey(r => r.MemberID)
                .WillCascadeOnDelete(false);

            
            modelBuilder.Entity<Report>()
                .HasRequired(r => r.Entry)
                .WithMany()
                .HasForeignKey(r => r.EntryID)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);

        }
    }
}
