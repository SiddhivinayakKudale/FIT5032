using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FIT5032_MyJS.Models
{
    public partial class FIT5032_MyJS_Models : DbContext
    {
        public FIT5032_MyJS_Models()
            : base("name=FIT5032_MyJS_Models")
        {
        }

        public virtual DbSet<MOCK_DATA> MOCK_DATA { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<MOCK_DATA>()
                .Property(e => e.ip_address)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<FIT5032_MyJS.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<FIT5032_MyJS.Models.Event> Events { get; set; }
    }
}
