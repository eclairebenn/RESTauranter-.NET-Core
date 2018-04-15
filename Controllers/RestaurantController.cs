using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;


namespace RESTauranter.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantContext _context;
    
        public RestaurantController(RestaurantContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("new")]
        public IActionResult NewReview(Review review, string Name)
        {
            if(ModelState.IsValid)
            {
                Restaurant Returned = _context.restaurants.SingleOrDefault(restaurant => restaurant.Name == Name);
                if(Returned == null)
                {
                        Restaurant NewRestaurant = new Restaurant
                            {
                                Name = Name
                            };
                        _context.restaurants.Add(NewRestaurant);
                        _context.SaveChanges();
                }
                Restaurant rest = _context.restaurants.SingleOrDefault(restaurant => restaurant.Name == Name);
                review.RestaurantId = rest.RestaurantId;
                _context.Add(review);
                _context.SaveChanges();
                return RedirectToAction("AllReviews");                 
            }

            return View("Index");
        }
  
        [HttpGet]
        [Route("reviews")]
        public IActionResult AllReviews()
        {
            List<Review> AllReviews = _context.reviews.Include(review => review.Restaurant).OrderByDescending(review => review.CreatedAt).ToList();

            ViewBag.Reviews = AllReviews;
            return View("Reviews");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
