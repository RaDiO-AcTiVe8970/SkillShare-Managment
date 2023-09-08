using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }
        [Required]
        public string employeeName { get; set; }
        [Required]
        public string employeeCode { get; set; }
        [Required]
        public string employeeSalary { get; set; }
        [Required]
        public string supervisorId { get; set; }
        public ICollection<EmployeeAttendance> employeeAttendances { get; set; }
        public Employee()
        {
            employeeAttendances = new List<EmployeeAttendance>();
        }

    }
}
