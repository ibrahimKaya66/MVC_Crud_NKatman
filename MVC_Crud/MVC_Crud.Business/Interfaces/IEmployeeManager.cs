using MVC_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Crud.Business.Interfaces
{
    public interface IEmployeeManager
    {
        List<Employee> Employee_List();
        Employee List_By_Id(int id);
        //void Add(Employee employee);
        //void Update(Employee employee);
        void Save(Employee employee);
        void Delete(int id);
    }
}
