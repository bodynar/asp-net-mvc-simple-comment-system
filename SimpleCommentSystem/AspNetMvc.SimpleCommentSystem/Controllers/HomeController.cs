using System.Web.Mvc;

namespace AspNetMvc.SimpleCommentSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
            => View();

        public ActionResult About()
        => View();

        public ActionResult Contact()
            => View();
    }
}