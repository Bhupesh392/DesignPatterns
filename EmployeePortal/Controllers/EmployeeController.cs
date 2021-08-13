using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.Factory.AbstractFactory;
using EmployeePortal.Factory.FactoryMethod;
using EmployeePortal.Manager;
using EmployeePortal.Models;

namespace EmployeePortal.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeePortalEntities1 db = new EmployeePortalEntities1();

        // GET: Employee
        public ActionResult Index()
        {
            var employeeDetails = db.EmployeeDetails.Include(e => e.Employee_Type);
            return View(employeeDetails.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_Id,Name,Department,Description,HourlyPay,Bonus,EmployeeTypeID")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                //Bad Design because business logic is tightly coupled here in the EMployee controller.what if we add another employee type??
                //
                //if (employeeDetail.EmployeeTypeID == 1)
                //{
                //    employeeDetail.HourlyPay = 8;
                //    employeeDetail.Bonus = 10;
                //}
                //else if (employeeDetail.EmployeeTypeID == 2)
                //{
                //    employeeDetail.HourlyPay = 12;
                //    employeeDetail.Bonus = 5;
                //}


                //Better with Factory Design Pattern
                //EmployeeManagerFactory empfactory = new EmployeeManagerFactory();
                //IEmployeeManager employeeManager = empfactory.GetEmployeeManager(employeeDetail.EmployeeTypeID);
                //employeeDetail.Bonus = employeeManager.GetBonus();
                //employeeDetail.HourlyPay = employeeManager.GetPay();

                //with Factory Method Design Pattern because now the requirement is more specific on to subclasses whoch is type of employee
                BaseEmployeeFactory empfactory = new EmployeeManagerFactory().CreateFactory(employeeDetail);
                empfactory.ApplySalary();

                IComputerFactory factory = new EmployeeSystemFactory().Create(employeeDetail);
                EmployeeSystemManager manager = new EmployeeSystemManager(factory);
                employeeDetail.ComputerDetails =  manager.GetSystemDetails();

                db.EmployeeDetails.Add(employeeDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employeeDetail.EmployeeTypeID);
            return View(employeeDetail);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employeeDetail.EmployeeTypeID);
            return View(employeeDetail);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_Id,Name,Department,Description,HourlyPay,Bonus,EmployeeTypeID")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employeeDetail.EmployeeTypeID);
            return View(employeeDetail);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            db.EmployeeDetails.Remove(employeeDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
