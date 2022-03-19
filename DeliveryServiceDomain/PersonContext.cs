﻿using DeliveryServiceDomain.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class PersonContext : IdentityDbContext<Person, IdentityRole<int>, int>
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Deliverer> Deliverers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = DeliveryServiceDB;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new DelivererConfiguration());

            SeedData(builder);
            SeedRoles(builder);

            base.OnModelCreating(builder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            PasswordHasher<Person> passwordHasher = new PasswordHasher<Person>();
            List<Customer> users = new List<Customer>();
            List<Deliverer> deliverers = new List<Deliverer>();

            Customer c1 = new Customer { Id = 1, FirstName = "Pera", LastName = "Peric", UserName = "perica", PhoneNumber = "065/111-222-33", Email = "perap@gmail.com", Address="Mije Kovacevica 7b", PostalCode="11000" };
            c1.PasswordHash = passwordHasher.HashPassword(c1, "P3r1c4!!");
            users.Add(c1);

            Customer c2 = new Customer { Id = 2, FirstName = "Zika", LastName = "Zikic", UserName = "zikica", PhoneNumber = "064/444-555-66", Email = "zikazikic222@gmail.com", Address = "Mije Kovacevica 7b", PostalCode = "11000" };
            c2.PasswordHash = passwordHasher.HashPassword(c2, "Z1k1c4!!");
            users.Add(c2);

            modelBuilder.Entity<Customer>().HasData(users);

            Deliverer d1 = new Deliverer { Id = 3, FirstName = "Nastasja", LastName = "Bakovic", UserName = "nastasja", DateOfEmployment=new DateTime(1999, 11, 01) };
            d1.PasswordHash = passwordHasher.HashPassword(d1, "N4st4sj4!!");
            deliverers.Add(d1);

            Deliverer d2 = new Deliverer { Id = 4, FirstName = "Stefan", LastName = "Antic", UserName = "stefan", DateOfEmployment=new DateTime(1999, 11, 04) };
            d2.PasswordHash = passwordHasher.HashPassword(d2, "Ant1c4!!");
            deliverers.Add(d2);

            modelBuilder.Entity<Deliverer>().HasData(deliverers);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = "User", ConcurrencyStamp = "1", NormalizedName = "USER" },
                new IdentityRole() { Id = "2", Name = "Deliverer", ConcurrencyStamp = "2", NormalizedName = "DELIVERER" }
                );
        }
    }

}
