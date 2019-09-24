using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlogV2.Models
{
    public class ReadFile : IReadFile
    {

        private List<Recipe> RecipeEntries;

        public ReadFile()
        {
            RecipeEntries = new List<Recipe>();

        }

        public List<Recipe> LoadEntries(string path)
        {        
           var files = GetContentFiles(path);

            if(files == null)
            {
                return null;
            }

            foreach(var file in files)
            {
                var entry = ReadContent(file);
                RecipeEntries.Add(entry);
            }

            return RecipeEntries;
        }

        private string[] GetContentFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
            }catch (Exception e)
            {
                Console.WriteLine($"Exception caught: {e.Message}");
                return null;
            }
        }

        private Recipe ReadContent(string file)
        {
            var lines = File.ReadAllLines(file);
            Recipe recipe = new Recipe();

            if (ValidationCheck(lines)) {

                bool tasteCheck = Int32.TryParse(lines[4], out int tastyLevel);

                bool difficultyCheck = Int32.TryParse(lines[5], out int difficultyLevel);

                bool timeCheck = Int32.TryParse(lines[6], out int time);

                StringBuilder instructions = new StringBuilder();

                for (int i = 7; i < lines.Length; i++)
                {
                    instructions.AppendLine(lines[i]);
                }

                recipe.Title = lines[0];
                recipe.SubTitle = lines[1];
                recipe.Description = lines[2];
                recipe.ImagePath = lines[3];
                recipe.Tasty = (Tasty)tastyLevel;
                recipe.Difficulty = (Difficulty)difficultyLevel;
                recipe.TimeinMin = time;
                recipe.Instructions = instructions.ToString();

            }

            return recipe;

        }

        private bool ValidationCheck(string[] lines)
        {
            bool tasteCheck = Int32.TryParse(lines[4],out int tastyLevel);

            bool difficultyCheck = Int32.TryParse(lines[5], out int difficultyLevel);

            bool timeCheck = Int32.TryParse(lines[6], out int time);

            if(tasteCheck == false || difficultyCheck == false || timeCheck == false)
            {
                return false;
            }

            return true; 
        }
    }
}
