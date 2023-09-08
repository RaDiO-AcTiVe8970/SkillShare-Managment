using DAL.EF;
using DAL.EF.Model;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EmployeeRepo :  IRepo<Employee, int, bool>
    {
        private readonly IBOS_AssignmentContext db;

        public bool Create(Employee obj)
        {
            db.Employees.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var data= db.Employees.Find(id);
            db.Employees.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public List<Employee> GetALL()
        {
            return db.Employees.ToList();
        }

        public bool Update(Employee obj)
        {
            var data = db.Employees.Find(obj.employeeId);
            data.employeeName = obj.employeeName;
            data.employeeCode = obj.employeeCode;
            data.employeeSalary = obj.employeeSalary;
            data.supervisorId = obj.supervisorId;
            return db.SaveChanges() > 0;
        }
    }
}
