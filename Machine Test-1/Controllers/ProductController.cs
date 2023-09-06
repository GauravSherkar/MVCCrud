using Machine_Test_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Machine_Test_1.Controllers
{
    public class ProductController : Controller
    {
        CategoryProductContext db = new CategoryProductContext();
        // GET: Product
        public ActionResult Index(int ? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var products = db.Products.OrderBy(p => p.ProductId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.pageNumber = pageNumber;
            ViewBag.TotalPages = Math.Ceiling((double)db.Products.Count() / pageSize);
            ViewBag.HasPreviousPage = pageNumber > 1;
            ViewBag.HasNextPage = pageNumber < ViewBag.TotalPages;
            return View(products);           
        }
        public ActionResult Details(int Id)
        {
            Product product = db.Products.Find(Id);
            return View(product);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductId,CategoryId,ProductName")] Product p)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(p);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "Product Inserted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "Product Data Not Inserted";
                }
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", p.CategoryId);
            return View(p);
        }

        public ActionResult Edit(int? Id)
        {
            Product product = db.Products.Find(Id);
            if (product==null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include ="ProductId,CategoryId,ProductName")]Product product)
        {
            db.Entry(product).State= EntityState.Modified;
            int a=db.SaveChanges();
            if(a>0)
            {
                TempData["UpdateMessage"] = "Product Update SuccessFully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UpdateMessage"] = "Product Not Updated";
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);           
        }
        public ActionResult Delete(int? Id)
        {
            Product product = db.Products.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int Id)
        {
            Product product=db.Products.Find(Id);
            db.Products.Remove(product);
            int a= db.SaveChanges();
            if (a>0) 
            {
                TempData["DeleteMessage"] = "Product Deleted SuccessFully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteMessage"] = "Product  Not Deleted Something Wrong";
            }
            return View("Index");
        }
    }
}