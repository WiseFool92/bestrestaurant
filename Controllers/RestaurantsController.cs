using Microsoft.AspNetCore.Mvc;
using TableData.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TableData.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly TableDataContext _db;

    public RestaurantsController(TableDataContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.ToList();
      return View("Index", model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View("Details", thisRestaurant);
    }

    // Use to implement a search field for the user to compare offerings
    // [HttpPost]
    // public ActionResult index(string searchParameter)
    // {
    //   List<Cuisine> matchCuisine = _db.Cuisine.Where(a => a.Type == searchParameter).ToList();
    //   return View("Index", matchCuisine);
    // }


    public ActionResult Update(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(Restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Update(Restaurant restaurant)
    {
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }


    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}