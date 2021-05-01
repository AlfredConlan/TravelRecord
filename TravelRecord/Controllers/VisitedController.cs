using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelRecord.Helpers;
using TravelRecord.Model;
using TravelRecord.Repository.IRepsitory;

namespace TravelRecord.Controllers
{
    public class VisitedController : Controller
    {
        private readonly IVisitedRepository _visitedRepository;

        public VisitedController(IVisitedRepository visitedRepository)
        {
            _visitedRepository = visitedRepository;
        }
        public IActionResult Index()
        {
            return View(new Visited() { });
        }

        public async Task<IActionResult> GetAllVisited()
        {
            return Json(new { data = await _visitedRepository.GetAllAsync(Constants.VISITED_GET) });
        }
    }
}
