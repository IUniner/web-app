using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Views;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        CompaniesContext db = new CompaniesContext();

        static EmployeeController()
        {

        }

        public ActionResult Index(int companyId)
        {
            IQueryable<Employee> employees = db.Employees;
            employees = employees.Where(p => p.CompanyId == companyId);
            ViewBag.CompanyId = companyId;
            return View(employees.ToList());
        }

        [HttpGet]
        public ActionResult Add(int companyId)
        {
            Employee employee = new Employee { CompanyId = companyId };
            ViewBag.Action = "Add";
            return View("Edit", employee);
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            employee.Id = db.Employees.Count() + 1;
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index", new { companyId=employee.CompanyId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = db.Employees.FirstOrDefault(p => p.Id == id);
            if (employee != null)
            {
                ViewBag.Action = "Edit";
                return View(employee);
            }
            db.SaveChanges();

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var oldEmployee = db.Employees.FirstOrDefault(p => p.Id == employee.Id);
            if (oldEmployee != null)
            {
                oldEmployee.FirstName = employee.FirstName;
                oldEmployee.LastName = employee.LastName;
                oldEmployee.Age = employee.Age;
            }
            db.Entry(oldEmployee).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", new { companyId = employee.CompanyId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = db.Employees.FirstOrDefault(p => p.Id == id);
            db.Employees.Remove(employee);
            db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}