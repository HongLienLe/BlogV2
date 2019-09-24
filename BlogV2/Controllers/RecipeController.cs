using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogV2.Models;
using BlogV2.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogV2.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeRepository _recipeRepository;

        public RecipeController(RecipesContext recipesContext)
        {
            _recipeRepository = new RecipeRepository(recipesContext);
        }
        public IActionResult Recipe()
        {
            return View(_recipeRepository.GetAllRecipes());
        }

        public IActionResult Add()
        {
            var recipe = new Recipe();
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Add(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _recipeRepository.AddRecipe(recipe);
                TempData["Message"] = "Your entry was successfully added!";
                return RedirectToAction("Recipe");
            }

            return View(recipe);
        }

        public IActionResult Edit(int? id)
        {
            var recipe = _recipeRepository.GetRecipes((int)id);

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            _recipeRepository.UpdateRecipe(recipe);
            TempData["Message"] = "Your entry was successfully updated!";

            return RedirectToAction("Recipe");
        }

        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Recipe");
            }

            var recipe = _recipeRepository.GetRecipes((int)id);
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _recipeRepository.DeleteRecipe(id);
            TempData["Message"] = "Your entry was successfully deleted!";

            return RedirectToAction("Reciepe");
        }
    }
}
