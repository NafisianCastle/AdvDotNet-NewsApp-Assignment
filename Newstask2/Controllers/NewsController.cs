using Newstask2.Models.Database;
using System.Linq;
using System.Web.Mvc;

namespace Newstask2.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            var db = new news_taskEntities2();
            var data = db.News.ToList();
            return View(data);
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create(News news)
        {
            if (!ModelState.IsValid) return View(news);
            var db = new news_taskEntities2();
            db.News.Add(news);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new news_taskEntities2();
            var news = (from u in db.News where u.Id == id select u).FirstOrDefault();
            return View(news);
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(News newNews)
        {
            var db = new news_taskEntities2();
            var oldNews = (from u in db.News
                           where u.Id == newNews.Id
                           select u
                          ).FirstOrDefault();
            db.Entry(oldNews).CurrentValues.SetValues(newNews);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
            var db = new news_taskEntities2();
            var news = (from u in db.News where u.Id == id select u).FirstOrDefault();
            if (news != null) db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
