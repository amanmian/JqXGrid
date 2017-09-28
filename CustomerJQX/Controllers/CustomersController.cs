using CustomerJQX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerJQX.Controllers
{
    public class CustomersController : Controller
    {
        NewContext db = new NewContext();

        // GET: /Customers/
        
        public JsonResult GetCustomers(string sidx, string sort, int page , int rows)
        {
            NewContext db = new NewContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var CustomerList = db.Customers.Select(
                    t => new
                    {
                        t.CustomerId,
                        t.CustomerName,
                        t.Address,
                        t.MobileNo,
                     //   t.PhoneNo,
                        t.City,
                     //   t.District,
                        t.State
                    });
            int totalRecords = CustomerList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                CustomerList = CustomerList.OrderByDescending(t => t.CustomerName);
                CustomerList = CustomerList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                CustomerList = CustomerList.OrderBy(t => t.CustomerName);
                CustomerList = CustomerList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = CustomerList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Create([Bind(Exclude = "CustomerId")] Customer obj)
        {
            
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
           
                    db.Customers.Add(obj);
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfully";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Edit(Customer obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Saved SuccessFully";

                }
                else
                {
                    msg = "Validation not successfull";
                }
            }
            catch(Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;

        }
        //public ActionResult Delete(int id)
        //{
        //    var Cust = db.Customers.Where(c => c.CustomerId == id).First();
        //    return View(Cust);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Customer Cust)
        //{
        //    var Customer = db.Customers.Where(c =>
        //     c.CustomerId == id).First();
        //    if (Customer != null)
        //    {
        //        db.Customers.Remove(Customer);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}