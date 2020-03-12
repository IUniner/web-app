using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Views;

namespace WebApplication3.Controllers
{
    public class CompanyController : Controller
    {
        CompaniesContext db = new CompaniesContext(); // объект контекста базы данных

        public ActionResult Index()
        {
            var companies = db.Companies.ToList();
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
            company.Id = db.Companies.Count() + 1;
            db.Companies.Add(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {/*
            var company = companies.FirstOrDefault(p => p.Id == id);
            if (company != null)
            {
                ViewBag.Action = "Edit";
                return View(company);
            }*/

            return HttpNotFound();
        }
    }
}