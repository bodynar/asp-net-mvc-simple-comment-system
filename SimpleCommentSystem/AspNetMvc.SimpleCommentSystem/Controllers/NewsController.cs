namespace AspNetMvc.SimpleCommentSystem.Controllers
{
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using AspNetMvc.SimpleCommentSystem.EF;
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Models;
    #endregion


    public class NewsController : Controller
    {

        private AppDbContext _db;

        public AppDbContext db
            => _db ?? (_db = AppDbContext.Create());

        public ApplicationUserManager UserManager
            => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();


        [HttpGet]
        public ActionResult Index()
        {
            var news = db.News.ToList(); // replace with other DAL imp

            var vms = new List<NewsDetailsViewModel>();

            foreach (var news_ in news)
            {
                var newsVM = Mapper.Map<News, NewsDetailsViewModel>(news_);

                vms.Add(newsVM);
            }

            return View(vms);
        }

        [HttpGet]
        public ActionResult ShowNews(Guid? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var news = db.News.FirstOrDefault(n => n.Id == id.Value);

            if (news == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(news);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
            => View();

        [HttpPost]
        [Authorize]
        public ActionResult Create(NewsAddViewModel vm)
        {
            var news = Mapper.Map<NewsAddViewModel, News>(vm);

            news.UserId = User.Identity.GetUserId();

            db.News.Add(news);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult AddComment(Guid? newsId)
        {
            if (!newsId.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var news = db.News.FirstOrDefault(n => n.Id == newsId.Value);

            if (news == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            ViewBag.NewsId = newsId;

            return PartialView("_AddComment");
        }


        [HttpPost]
        [Authorize]
        public ActionResult AddComment(CommentAddViewModel vm)
        {
            var comment = Mapper.Map<CommentAddViewModel, Comment>(vm);

            comment.UserId = User.Identity.GetUserId();

            db.Comments.Add(comment);

            db.SaveChanges();

            return Json(new { Success = true });
        }
    }
}
