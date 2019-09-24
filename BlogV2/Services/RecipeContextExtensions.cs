using System;
using System.Collections.Generic;
using System.Linq;
using BlogV2.Models;

namespace BlogV2.Services
{
    public static class RecipeContextExtensions
    {
        public static void CreateSeedData
             (this RecipesContext context)
        {
            if (context.Recipes.Any())
                return;
            var recipes = new ReadFile().LoadEntries("/Users/hongle/Projects/BlogV2/BlogV2/Data");
            context.AddRange(recipes);
            context.SaveChanges();

        }
    }
}
