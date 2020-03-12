using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees;
        static EmployeeController()
        {
            employees = new List<Employee>();
            employees.Add(new Employee { Id = 0, FirstName = "Oleg", LastName = "Petrov", Age = 25 });
        }

        // GET: Employee
        public ActionResult Index() // маршрут /Employee
        {
            return View(employees);
        }

        [HttpGet]

        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit");
        }

        [HttpPost]

        public ActionResult Add(Employee employee)
        {
            employee.Id = employees.Count;
            employees.Add(employee);
            return View("Edit");
        }

        [HttpGet]

        public ActionResult Edit(int? id) // маршрут /Employee/Edit/1
        {
            var employee = employees.FirstOrDefault(p => p.Id == id);
            if(employee != null)
            {
                ViewBag.Action = "Edit";
                return View(employee);
            }

            return RedirectToAction("Index"); // HttpNotFoundResult?
        }

        [HttpPost]

        public ActionResult Edit(Employee employee)
        {
            var oldEmployee = employees.FirstOrDefault(p => p.Id == employee.Id);
            if (oldEmployee != null)
            {
                oldEmployee.FirstName = employee.FirstName;
                oldEmployee.LastName = employee.LastName;
                oldEmployee.Age = employee.Age;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(p => p.Id == id);
            employees.Remove(employee);
            return RedirectToAction("Index");
        }
    }
}