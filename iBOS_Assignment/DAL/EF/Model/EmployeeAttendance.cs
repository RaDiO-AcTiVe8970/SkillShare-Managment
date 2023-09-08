using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class EmployeeAttendance
    {
        [Key]
        public int attendanceId { get; set; }
        [ForeignKey("employee")]
        public int employeeId { get; set; }
        [Required]
        public string attendanceDate { get; set; }
        [Required]
        public int isPresent { get; set; }
        [Required]
        public int isAbsent { get; set; }
        [Required]
        public int isOffday { get; set; }

        public virtual Employee employee { get; set; }
    }
}
