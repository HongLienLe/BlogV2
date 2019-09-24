using System;
using BlogV2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogV2.Services
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
