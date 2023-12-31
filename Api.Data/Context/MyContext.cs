﻿using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UserEntity>().HasData(

                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Maro",
                    Email = "maro@gmail.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

        }

        
    }
}
