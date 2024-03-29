﻿using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class CardsDbContext :DbContext
    {
        public CardsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
    }
}
