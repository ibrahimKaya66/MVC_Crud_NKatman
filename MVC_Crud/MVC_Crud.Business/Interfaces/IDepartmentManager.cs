using MVC_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Crud.Business.Interfaces
{
    public interface IDepartmentManager
    {
        List<Department> Department_List();
        Department List_By_Id(int id);
        void Save(Department department);
        void Delete(int id);
    }
}
