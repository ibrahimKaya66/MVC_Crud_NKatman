using MVC_Crud.Business.Manager;
using MVC_Crud.Models;
using MVC_Crud.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Crud.Controllers
{
    public class EmployeeController : Controller
    {
        CrudDbContext db = new CrudDbContext();
        // GET: Employee
        EmployeeManager employeeManager = new EmployeeManager();
        public ActionResult Index()
        {
            List<Employee> employees = employeeManager.Employee_List();
            return View(employees);
        }
        [HttpGet]
        public ActionResult Save()//Create di
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Employee employee)//Create
        {
            employeeManager.Save(employee);
            return RedirectToAction("Index", "Employee");
        }

        public ActionResult Update(int id)
        {
            var model = db.employees.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("Save", model);
        }
        public ActionResult Delete(int id)
        {
            employeeManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}