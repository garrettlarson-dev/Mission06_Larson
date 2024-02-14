using System.ComponentModel.DataAnnotations;

namespace Mission06_Larson.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieID {  get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string MovieRating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }




    }
}
