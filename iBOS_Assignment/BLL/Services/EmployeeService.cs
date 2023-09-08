using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> GetEmployees()
        {
            var data = DataAccessFactory.EmployeeDataAccess().GetALL();
            var result = new List<EmployeeDTO>();
            foreach (var item in data)
            {
                result.Add(new EmployeeDTO
                {
                    employeeId = item.employeeId,
                    employeeName = item.employeeName,
                    employeeCode = item.employeeCode,
                    employeeSalary = item.employeeSalary,
                    supervisorId = item.supervisorId
                });
            }

            return result;
        }
    }
}
