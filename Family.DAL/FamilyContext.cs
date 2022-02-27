using Family.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.DAL
{
    public class FamilyContext : DbContext
    {
        public FamilyContext() : base("Data Source = localhost; Initial Catalog = FamilyDB; Integrated Security = True;")
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>()
                        .HasRequired(parent => parent.Mother)
                        .WithMany(person => person.Mothers)
                        .HasForeignKey(parent => parent.MotherId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parent>()
                        .HasRequired(parent => parent.Father)
                        .WithMany(person => person.Fathers)
                        .HasForeignKey(parent => parent.FatherId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                        .HasRequired(r => r.Sender)
                        .WithMany(person => person.Requests)
                        .HasForeignKey(r => r.SenderId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                        .HasRequired(r => r.Receiver)
                        .WithMany(person => person.Receivers)
                        .HasForeignKey(r => r.ReceiverId)
                        .WillCascadeOnDelete(false);
        }
    }
}
