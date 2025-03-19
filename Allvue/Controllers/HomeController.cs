using Allvue.Data.DAO.Interfaces;
using Allvue.Models;
using Allvue.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Allvue.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStockBatchService _stockBatchService;

        public HomeController(IStockBatchService stockBatchService)
        {
            _stockBatchService = stockBatchService;
        }
        
        public ActionResult Index()
        {
            var result = _stockBatchService.GetAllStockBatches();
            return View(result);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult SalesCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SalesCalculator(CalculateSaleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int totalAvailableStocks = _stockBatchService.GetTotalAvailableStocks();

            if (model.Quantity > totalAvailableStocks)
            {
                ModelState.AddModelError("", $"Error: You cannot sell more stocks than you own. Available: {totalAvailableStocks}");
                return View(model);
            }

            var calculatedResult = _stockBatchService.CalculateSale(model.Strategy.Value, model.Quantity, model.Price);
            return View("CalculatedSale", calculatedResult);
        }

        public IActionResult ResetMockData()
        {
            _stockBatchService.ResetData(); 
            return RedirectToAction("Index");
        }
    }
}
