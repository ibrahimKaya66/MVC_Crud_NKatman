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
    public class DepartmentController : Controller
    {
        CrudDbContext db = new CrudDbContext();
        // GET: Department

        DepartmentManager departmentManager = new DepartmentManager();
        public ActionResult Index()
        {
            List<Department> departments = departmentManager.Department_List();
            return View(departments);
        }

        [HttpGet]
        public ActionResult Save()//Create di
        {
            return View("CreateAndUpdate");
        }

        [HttpPost]
        public ActionResult Save(Department department)//Create
        {
            departmentManager.Save(department);
            return RedirectToAction("Index","Department");
        }

        public ActionResult Update(int id)
        {
            var model = db.departments.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("CreateAndUpdate",model);
        }
        public ActionResult Delete(int id)
        {
            departmentManager.Delete(id);
            return RedirectToAction("Index", "Department");
        }
    }
}