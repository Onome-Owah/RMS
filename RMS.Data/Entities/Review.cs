using System;
using System.ComponentModel.DataAnnotations;

namespace RMS.Data.Entities;


    public class Review
    {
        public int Id { get; set; }
            
        // suitable review attributes / relationships
        [Required]
        public string Author { get; set;}

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // link Reviews back to the owning Recipe
            public int RecipeId { get; set; }      // foreign key
            public Recipe Recipe { get; set; }    // navigation property
            
    
    }

