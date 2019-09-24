using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogV2.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Tasty Tasty { get; set; }
        public Difficulty Difficulty { get; set; }
        public int TimeinMin { get; set; }
        public string Instructions { get; set; }
        
    }

    public enum Tasty
    {
        er = 1,
        okayish = 2,
        decent = 3,
        good = 4,
        amazinggg = 5
    }
    public enum Difficulty
    {
        Easy = 1,
        okayish = 2,
        decent = 3,
        Effort = 4,
        Harddd = 5
    }

}
