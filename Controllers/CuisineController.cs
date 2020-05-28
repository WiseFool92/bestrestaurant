using Microsoft.AspNetCore.Mvc;
using TableData.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TableData.Controllers
{
  public class CuisineController : Controller
  {
    private readonly TableDataContext _db;

    public CuisineController(TableDataContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisine.ToList();
      return View("Index", model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisine.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View("Details", thisCuisine);
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
      var thisCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Update(Cuisine cuisine)
    {
      _db.Entry(cuisine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }


    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      _db.Cuisine.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}