using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CompanyController : Controller
    {
        static List<Company> companies;
        static CompanyController()
        {
            companies = new List<Company>();
            companies.Add(new Company { Id = 0, Name = "BelCo"});
        }

        // GET: Company
        public ActionResult Index() // маршрут /Company
        {
            return View(companies);
        }

        [HttpGet]

        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit");
        }

        [HttpPost]

        public ActionResult Add(Company company)
        {
            company.Id = companies.Count;
            companies.Add(company);
            return View("Edit");
        }

        [HttpGet]

        public ActionResult Edit(int? id) // маршрут /Company/Edit/1
        {
            var company = companies.FirstOrDefault(p => p.Id == id);
            if (company != null)
            {
                ViewBag.Action = "Edit";
                return View(company);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]

        public ActionResult Edit(Company company)
        {
            var oldCompany = companies.FirstOrDefault(p => p.Id == company.Id);
            if (oldCompany != null)
            {
                oldCompany.Name = company.Name;
                //oldCompany.Age = company.Age;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Delete(int companyId)
        {
            var company = companies.FirstOrDefault(p => p.Id == companyId);
            companies.Remove(company);
            return RedirectToAction("Index");
        }
    }
}