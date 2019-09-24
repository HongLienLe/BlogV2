using System;
using System.Collections.Generic;
using System.Linq;
using BlogV2.Services;
using Microsoft.EntityFrameworkCore;

namespace BlogV2.Models
{
    public class RecipeRepository
    {
        private RecipesContext _recipesContext;

        public RecipeRepository(RecipesContext recipesContext)
        {
            _recipesContext = recipesContext;
        }

        public List<Recipe> GetAllRecipes()
        {
            return _recipesContext.Recipes.ToList();
        }

        public Recipe GetRecipes(int id)
        {
            using (var context = _recipesContext)
            {
                return context.Recipes.Find(id);
            }

        }

        public void AddRecipe(Recipe recipe)
        {
            using (var context = _recipesContext)
            {
                context.Recipes.Add(recipe);
                context.SaveChanges();
            }
        }

        public void UpdateRecipe(Recipe reciepe)
        {
            using (var context = _recipesContext)
            {
                context.Recipes.Attach(reciepe);

                var recipeEntry = context.Entry(reciepe);

                recipeEntry.State = EntityState.Modified;
                // for when there is a property that should 100% not be changed 
                recipeEntry.Property("Title").IsModified = false;

                context.SaveChanges();

            }
        }

        public void DeleteRecipe(int id)
        {
            using (var context = _recipesContext)
            {
                //var reciepeToFind = context.Reciepes.Find(id);
                //context.Reciepes.Remove(reciepeToFind);

                var recipe = new Recipe() { Id = id };
                context.Entry(recipe).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
