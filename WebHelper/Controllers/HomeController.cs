﻿using System.Diagnostics;
using Core.Jobs;
using DAL;
using Microsoft.AspNetCore.Mvc;
using WebHelper.Models;

namespace WebHelper.Controllers
{
  public class HomeController : Controller
  {
    public HomeController(SendCurrencyExchangeRateNotificationJob sendCurrencyExchangeRateNotificationJob)
    {
      _sendCurrencyExchangeRateNotificationJob = sendCurrencyExchangeRateNotificationJob;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet][Route("home/exchangeRate")][ActionName("GetExchangeRate")]
    public IActionResult GetExchangeRate()
    {
      _sendCurrencyExchangeRateNotificationJob.Execute();
      return View("~/Views/Home/Index.cshtml");
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

    private SendCurrencyExchangeRateNotificationJob _sendCurrencyExchangeRateNotificationJob;
  }
}
