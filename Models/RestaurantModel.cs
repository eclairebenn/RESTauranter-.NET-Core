using System;
using System.Collections.Generic;

namespace RESTauranter.Models
{
    public class Restaurant
    {
        public int RestaurantId {get;set;}
        public string Name {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public List<Review> Reviews {get;set;}
        public Restaurant()
        {
            Reviews = new List<Review>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}