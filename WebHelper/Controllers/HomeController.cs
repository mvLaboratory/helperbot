using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using WebHelper.Models;

namespace WebHelper.Controllers
{
  public class HomeController : Controller
  {
    public HomeController(HelperBotContext helperContext)
    {
      _dbContext = helperContext;
    }

    public IActionResult Index()
    {
      var currency = _dbContext.CurrencyExchangeRate.ToList();
      return View();
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private HelperBotContext _dbContext;
  }
}
