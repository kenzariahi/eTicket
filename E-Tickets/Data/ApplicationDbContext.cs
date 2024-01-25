using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace eTickets.Data
    {
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<ActorMovie>().HasKey(am => new
                {
                    am.ActorId,
                    am.MovieId
                });

                modelBuilder.Entity<ActorMovie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
                modelBuilder.Entity<ActorMovie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);


                base.OnModelCreating(modelBuilder);
            }

            public DbSet<Actor> Actors { get; set; }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<ActorMovie> Actors_Movies { get; set; }
            public DbSet<Cinema> Cinemas { get; set; }
            public DbSet<Producer> Producers { get; set; }


            //Orders related tables
            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderItem> OrderItems { get; set; }
            public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        }
    }

