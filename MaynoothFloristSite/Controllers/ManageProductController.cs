using MFlorist.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MaynoothFloristSite.Controllers
{
    public class ManageProductController : Controller
    {
        private FlowersdbEntities db = new FlowersdbEntities();
                
        // GET: ManageProduct
        public ActionResult Index()
        {

            return View(db.Products.ToList());

        }

        // GET: ManageProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);

        }

        // GET: ManageProduct/Create new product with dropdownlist of "TypeId".
        [HttpGet]
        public ActionResult Create()
        {
            PopulateTypeIdDropDownList();
            PopulateImageUrlDropDownList();

            return View();
        }

        // POST: ManageProduct/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                PopulateTypeIdDropDownList(product.TypeId);
                PopulateImageUrlDropDownList(product.Image);
                return View(product);
            }
            catch
            {
                return View();
            }
        }


        // GET: ManageProduct/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {


            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            PopulateTypeIdDropDownList(product.TypeId);
            return View(product);
        }

        // POST: ManageProduct/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                //PopulateTypeIdDropDownList(product.TypeId);
                return View(product);
            }
            catch
            {
                return View();
            }
        }
       
        // GET: ManageProduct/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: ManageProduct/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Product prod)
        {

            try
            {
                Product product = new Product();
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    product = db.Products.Find(id);
                    if (product == null)
                        return HttpNotFound();
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddProductType(ProductType productType)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    db.ProductTypes.Add(productType);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(productType);
            }
            catch
            {
                return View();
            }
        }

        private void PopulateTypeIdDropDownList(object selectedId = null)
        {
            var ProductTypesQuery = from d in db.ProductTypes
                                    orderby d.Name
                                    select d;
            ViewBag.TypeId = new SelectList(ProductTypesQuery, "Id", "Name", selectedId);
        }

        private void PopulateImageUrlDropDownList(object selectedId = null)
        {
            var ProductImageQuery = from d in db.Products
                                    orderby d.Image
                                    select d;
            ViewBag.ImageUrl = new SelectList(ProductImageQuery, "Id", "Image", selectedId);
        }
    }
}
