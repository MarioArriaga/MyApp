using System.Web.Mvc;
//using DAL;
//using DAL.Infrastructure;

namespace API.Controllers
{
    public class RecordController : Controller
    {
        //private readonly PersonContext _context;

        // GET: Recorded Info
        public ActionResult Index()
        {
            ViewBag.Title = "Recorded Info";
            return View();
        }

        [HttpPost]
        public string RecordData()
        {

            return $"Post executed..";
        }
    }
}