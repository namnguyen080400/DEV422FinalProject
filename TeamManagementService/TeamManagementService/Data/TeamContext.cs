﻿using Microsoft.EntityFrameworkCore;
using TeamManagementService.Model;

namespace TeamManagementService.Data
{
    public class TeamContext : DbContext
    {
        // contructor
        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {
            // empty
        }

        public DbSet<Team> Teams {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    TeamName = "Optic"
                },
                new Team
                {
                    TeamId = 2,
                    TeamName = "Cloud9"
                },
                new Team
                {
                    TeamId = 3,
                    TeamName = "Faze"
                }
            );
        }
    }
}
