using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.Builder.ConcreteBuilder;
using EmployeePortal.Builder.Director;
using EmployeePortal.Builder.IBuilder;
using EmployeePortal.Factory.AbstractFactory;
using EmployeePortal.Factory.FactoryMethod;
using EmployeePortal.Manager;
using EmployeePortal.Models;

namespace EmployeePortal.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeePortalEntities1 db = new EmployeePortalEntities1();

        [HttpGet]
        public ActionResult BuildSystem(int? employeeID)
        {
            EmployeeDetail employee = db.EmployeeDetails.Find(employeeID);
            if (employee.ComputerDetails.Contains("Laptop"))
                return View("BuildLaptop", employeeID);
            else
                return View("BuildDesktop", employeeID);
        }
        [HttpPost]
        public ActionResult BuildLaptop(FormCollection formCollection)
        {
            EmployeeDetail employee = db.EmployeeDetails.Find(Convert.ToInt32(formCollection["employeeID"]));
            //Concrete Builder
            ISystemBuilder systemBuilder = new LaptopBuilder();
            //Director
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(systemBuilder, formCollection);
            ComputerSystem system = systemBuilder.GetSystem();

            employee.SystemConfigurationDetails = string.Format("RAM : {0}, HDDSize : {1}, TouchScreen: {2}", system.RAM, system.HDDSize, system.TouchScreen);
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult BuildDesktop(FormCollection formCollection)
        {
            //Step 1
            EmployeeDetail employee = db.EmployeeDetails.Find(Convert.ToInt32(formCollection["employeeID"]));
            //Step 2 Concrete Builder
            ISystemBuilder systemBuilder = new DesktopBuilder();
            //Step 3 Director
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(systemBuilder, formCollection);
            //Step 4 return the system
            ComputerSystem system = systemBuilder.GetSystem();
            employee.SystemConfigurationDetails = string.Format("RAM : {0}, HDDSize : {1}, Keyboard: {2}, Mouse : {3}", system.RAM, system.HDDSize, system.KeyBoard, system.Mouse);
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult BuildSystem(int employeeID, string RAM, string Drive)
        //{
        //    EmployeeDetail employee = db.EmployeeDetails.Find(employeeID);
        //    ComputerSystem computerSystem = new ComputerSystem(RAM, Drive);
        //    employee.SystemConfigurationDetails = computerSystem.Build();

        //    db.Entry(employee).State = EntityState.Modified;
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

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
