using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ÖvningAPI.Models
{
    public class ÖvningAPIDbContext : DbContext
    {
        public ÖvningAPIDbContext(DbContextOptions<ÖvningAPIDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                FirstName = "Lucas",
                LastName = "Narfgren",
                Password = "hemlis123",
                ConfirmPassword = "hemlis123",
                AdressId = 1,
                SkillId = 1

            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                FirstName = "Johnny",
                LastName = "Karlsson",
                Password = "hemlis123",
                ConfirmPassword = "hemlis123",
                AdressId = 2,
                SkillId = 2

            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                FirstName = "Mimmi",
                LastName = "Narfgren",
                Password = "hemlis123",
                ConfirmPassword = "hemlis123",
                AdressId = 1,
                SkillId = 3
               

            });
            modelBuilder.Entity<Adress>().HasData(new Adress
            {
                AdressId = 1,
                Kommun = "Falkenberg",
                GatuNamn = "Hertings Alle 5A",
                PostCode = "311 45"
            });
            modelBuilder.Entity<Adress>().HasData(new Adress
            {
                AdressId = 2,
                Kommun = "Varberg",
                GatuNamn = "Varbergs Gatan 17",
                PostCode = "432 00"
            });


            modelBuilder.Entity<Skill>().HasData(new Skill
            {
                SkillId = 1,
                SkillName = "Trolla"
            });
            modelBuilder.Entity<Skill>().HasData(new Skill
            {
                SkillId = 2,
                SkillName = "Dansa"
            });
            modelBuilder.Entity<Skill>().HasData(new Skill
            {
                SkillId = 3,
                SkillName = "Klösa"
            });
        }
    }
}
