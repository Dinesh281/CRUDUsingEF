using CRUDUsingEF.Data;
using CRUDUsingEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingEF.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        CategoryDAL categoryDAL;
        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
            categoryDAL = new CategoryDAL(db);
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var list = categoryDAL.GetAllCategory();
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var cat=categoryDAL.GetCategoryById(id);
            return View(cat);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cat)
        {
            try
            {
                int result = categoryDAL.AddCategory(cat);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = categoryDAL.GetCategoryById(id);
            return View(cat);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            try
            {
                int result = categoryDAL.UpdateCategory(cat);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = categoryDAL.GetCategoryById(id);
            return View(cat);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = categoryDAL.DeleteCategory(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
