using Microsoft.AspNetCore.Mvc;

namespace TableData.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}