using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MovieReviewSPA.web.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string MovieName { get; set; }

        [Required]
        [StringLength(255)]
        public string DirectorName { get; set; }

        [Required]
        [StringLength(10)]
        public string ReleaseYear { get; set; }
        public virtual ICollection<MovieReview> Reviews { get; set; }
    }
}