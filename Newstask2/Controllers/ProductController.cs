using Newstask2.Models.Database;
using System.Linq;
using System.Web.Mvc;

namespace Newstask2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new news_taskEntities2();
            var data = db.Products.ToList();
            return View(data);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var db = new news_taskEntities2();
            var data = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            return View(data);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            var db = new news_taskEntities2();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new news_taskEntities2();
            var product = (from u in db.Products where u.Id == id select u).FirstOrDefault();
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product newProduct)
        {
            try
            {
                // TODO: Add update logic here
                var db = new news_taskEntities2();
                var oldProduct = (from u in db.Products
                                  where u.Id == newProduct.Id
                                  select u
                    ).FirstOrDefault();
                db.Entry(oldProduct).CurrentValues.SetValues(newProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
            var db = new news_taskEntities2();
            var product = (from u in db.Products where u.Id == id select u).FirstOrDefault();
            if (product != null) db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            return View(id);

        }
    }
}
