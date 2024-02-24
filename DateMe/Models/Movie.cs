using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Larson.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId {  get; set; }
        
        [ForeignKey("CategoryID")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Enter a Title")]
        public string Title { get; set; }

        [Range(1888, 2025)]
        [Required(ErrorMessage = "Year Must Be Entered")]
        public int Year { get; set; } = 2020;
        public string? Director { get; set; }
        public string? Rating { get; set; }
        
        [Required(ErrorMessage = "Edited must be specified")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }




    }
}
