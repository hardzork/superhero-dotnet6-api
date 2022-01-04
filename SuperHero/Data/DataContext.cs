﻿using System;
using Microsoft.EntityFrameworkCore;

namespace SuperHero.Data
{
	public class DataContext : DbContext
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DataContext(DbContextOptions<DataContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

		}

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}

