using MVC_Crud.Business.Interfaces;
using MVC_Crud.Models;
using MVC_Crud.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Crud.Business.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        public void Delete(int id)
        {
            using (CrudDbContext db = new CrudDbContext())//Performans açısından yapılmıştır
            {
                var d = db.employees.Find(id);
                db.employees.Remove(d);
                db.SaveChanges();
            }
        }

        public List<Employee> Employee_List()
        {
            using (CrudDbContext db = new CrudDbContext())//Performans açısından yapılmıştır
            {
                return db.employees.ToList();
            }
        }

        public Employee List_By_Id(int id)
        {
            using (CrudDbContext db = new CrudDbContext())//Performans açısından yapılmıştır
            {
                return db.employees.FirstOrDefault(x => x.Id == id);
            }
        }

        //public void Add(Employee employee)
        //{
        //    using (CrudDbContext db = new CrudDbContext())//Performans açısından yapılmıştır
        //    {
        //        db.employees.Add(employee);
        //        db.SaveChanges();
        //    }
        //}
        //public void Update(Employee employee)
        //{
        //    using (CrudDbContext db = new CrudDbContext())//Performans açısından yapılmıştır
        //    {
        //        db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //}
        public void Save(Employee employee)
        {
            using (CrudDbContext db = new CrudDbContext())
            {
                if (employee.Id == 0)//Id=0 ise create yapacak değilse güncelleme yapacak
                    db.employees.Add(employee);
                else
                {
                    var e = db.employees.Find(employee.Id);
                    if (e == null)
                        return;
                    e.Name = employee.Name;
                    e.Surname = employee.Surname;
                    e.Wage = employee.Wage;
                    e.Department_Id = employee.Department_Id;
                }

                db.SaveChanges();
            }    
        }
    }
}
