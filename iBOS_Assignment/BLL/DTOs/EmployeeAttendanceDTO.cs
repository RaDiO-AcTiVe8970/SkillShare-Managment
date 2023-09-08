using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmployeeAttendanceDTO
    {
        public int attendanceId { get; set; }
        public int employeeId { get; set; }
        public string attendanceDate { get; set; }
        public int isPresent { get; set; }
        public int isAbsent { get; set; }
        public int isOffday { get; set; }
    }
}
