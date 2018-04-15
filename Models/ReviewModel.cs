using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Review
    {
        public int ReviewId {get;set;}

        [Required]
        [Display(Name = "Review")]
        [MinLength(10)]
        public string Content {get;set;}

        [Required]
        [Display(Name = "Reviewer Name")]
        public string UserName {get;set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Visit")]
        public DateTime Date {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        [Required]
        [Display(Name = "Stars")]
        public int Star {get;set;}
        public int RestaurantId {get;set;}
        public Restaurant Restaurant {get;set;}
    
        public Review()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }
}