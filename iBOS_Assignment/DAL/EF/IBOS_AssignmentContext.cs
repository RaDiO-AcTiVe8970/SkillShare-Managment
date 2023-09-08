using DAL.EF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class IBOS_AssignmentContext: DbContext
    {
        public IBOS_AssignmentContext(DbContextOptions<IBOS_AssignmentContext> options): base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
    }
}
