using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class WorkController : Controller
    {
        private static PortfolioDBContext _dBContext = new PortfolioDBContext(new DbContextOptions<PortfolioDBContext>());
        private WorkRepository _workRepository;
        public WorkController()
        {
            _workRepository = new WorkRepository(_dBContext);
        }

        public IActionResult Index()
        {
            return View("Index", _workRepository.GetAllWorks());
        }
        public IActionResult GetSingleWork(string Id)
        {
            Work work = _workRepository.GetWorkBySlug(Id);
            if (work == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            else
            {
                return View("SingleWork", work);
            }
        }
    }
}
