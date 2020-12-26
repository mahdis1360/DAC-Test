using Microsoft.EntityFrameworkCore;
using Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkDataAccessLayer
{
    public class Context : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<MemberShipTypes> memberShipTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DAC;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<MemberShipTypes>
                (entity =>
                {
                    entity.HasMany(m => m.User)
                    .WithOne(i => i.MemberShipTypes);


                }
                );



      
        }
    }
}
