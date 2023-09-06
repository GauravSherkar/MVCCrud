using Machine_Test_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Machine_Test_1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryProductContext db = new CategoryProductContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            Category category= db.Categories.Find(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Create(Category c)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(c);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "Data Inserted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "Data Not Inserted";
                }
            }
            return View("Index");
        }
        public ActionResult Edit(int? id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "Data Updated Successfully!!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "Data Not Updated !!!";
                }
            }
            return View("Index");
        }
        public ActionResult Delete(int? id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "Delete Data SuccessFully !!!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteMessage"] = "Data Not Deleted Something Wrong!!!";
            }
            return View("Index");
        }
    }
}