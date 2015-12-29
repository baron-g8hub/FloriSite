using AngularWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularWebMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexVM()
        {
            using (ProductsDbEntities dataContext = new ProductsDbEntities())
            {
                var employeeList = dataContext.Products.ToList();
                return Json(employeeList, JsonRequestBehavior.AllowGet);
            }
        }
        
        public JsonResult getAll()
        {
            using (ProductsDbEntities dataContext = new ProductsDbEntities())
            {
                var productList = dataContext.Products.ToList();
                return Json(productList, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getProductByNo(string ProdNo)
        {
            using (ProductsDbEntities dataContext = new ProductsDbEntities())
            {
                int no = Convert.ToInt32(ProdNo);
                var productList = dataContext.Products.Find(no);
                return Json(productList, JsonRequestBehavior.AllowGet);
            }
        }
        public string UpdateEmployee(Product Prod)
        {
            if (Prod != null)
            {
                using (ProductsDbEntities dataContext = new ProductsDbEntities())
                {
                    int no = Convert.ToInt32(Prod.Id);
                    var productList = dataContext.Products.Where(x => x.Id == no).FirstOrDefault();
                    productList.Name = Prod.Name;
                    productList.Price = Prod.Price;
                    productList.Description = Prod.Description;
                    productList.Image = Prod.Image;

                    dataContext.SaveChanges();
                    return "Employee Updated";
                }
            }
            else
            {
                return "Invalid Employee";
            }
        }
        public string AddEmployee(Product Emp)
        {
            if (Emp != null)
            {
                using (ProductsDbEntities dataContext = new ProductsDbEntities())
                {
                    dataContext.Products.Add(Emp);
                    dataContext.SaveChanges();
                    return "Employee Updated";
                }
            }
            else
            {
                return "Invalid Employee";
            }
        }


        public string DeleteEmployee(Product Emp)
        {
            if (Emp != null)
            {
                using (ProductsDbEntities dataContext = new ProductsDbEntities())
                {
                    int no = Convert.ToInt32(Emp.Id);
                    var employeeList = dataContext.Products.Where(x => x.Id == no).FirstOrDefault();
                    dataContext.Products.Remove(employeeList);
                    dataContext.SaveChanges();
                    return "Employee Deleted";
                }
            }
            else
            {
                return "Invalid Employee";
            }
        }
    }
}