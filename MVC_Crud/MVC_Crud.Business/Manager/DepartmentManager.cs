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
    public class DepartmentManager : IDepartmentManager
    {
        public void Delete(int id)
        {
            using (CrudDbContext db = new CrudDbContext())//Performans açısından yapılmıştır
            {
                var d = db.departments.Find(id);
                db.departments.Remove(d);
                db.SaveChanges();
            }
        }

        public List<Department> Department_List()
        {
            using (CrudDbContext db = new CrudDbContext())//Performans açısından yapılmıştır
            {
                return db.departments.ToList();
            }
        }

        public Department List_By_Id(int id)
        {
            using (CrudDbContext db = new CrudDbContext())//Performans açısından yapılmıştır
            {
                return db.departments.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Save(Department department)
        {
            using (CrudDbContext db = new CrudDbContext())//Performans açısından yapılmıştır
            {
                if (department.Id == 0)//Id=0 ise create yapacak değilse güncelleme yapacak
                    db.departments.Add(department);
                else
                {
                    var d = db.departments.Find(department.Id);
                    if (d == null)
                        return;
                    d.Name = department.Name;
                }
                db.SaveChanges();
            }    
        }
    }
}
