using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class CommentController : Controller
    {
        private static PortfolioDBContext _dBContext = new PortfolioDBContext(new DbContextOptions<PortfolioDBContext>());
        private CommentsRepository commentsRepository = new CommentsRepository(_dBContext);

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult GetAllComments([FromBody] int postId)
        {
            Console.WriteLine(postId);
            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            var comments = commentsRepository.GetCommentsThree(postId);
            return Json(comments, jso);
        }
    }
}
