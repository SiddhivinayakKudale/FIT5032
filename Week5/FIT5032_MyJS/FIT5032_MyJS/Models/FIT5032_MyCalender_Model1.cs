using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FIT5032_MyJS.Models
{
    public partial class FIT5032_MyCalender_Model1 : DbContext
    {
        public FIT5032_MyCalender_Model1()
            : base("name=FIT5032_MyCalender_Model1")
        {
        }

        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(e => e.Title)
                .IsUnicode(false);
        }
    }
}
