using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmployeeDTO
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeCode { get; set; }
        public string employeeSalary { get; set; }
        public string supervisorId { get; set; }
    }
}
