using DAL.EF;
using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EmployeeAttendanceRepo :  IRepo<EmployeeAttendance, int, bool>
    {
        private readonly IBOS_AssignmentContext db;
        public bool Create(EmployeeAttendance obj)
        {
            db.EmployeeAttendances.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.EmployeeAttendances.Find(id);
            db.EmployeeAttendances.Remove(data);
            return db.SaveChanges() > 0;
        }

        public EmployeeAttendance Get(int id)
        {
            return db.EmployeeAttendances.Find(id);
        }

        public List<EmployeeAttendance> GetALL()
        {
            return db.EmployeeAttendances.ToList();
        }

        public bool Update(EmployeeAttendance obj)
        {
            var data = db.EmployeeAttendances.Find(obj.attendanceId);
            data.employeeId = obj.employeeId;
            data.attendanceDate = obj.attendanceDate;
            data.isPresent = obj.isPresent;
            data.isAbsent = obj.isAbsent;
            data.isOffday = obj.isOffday;
            return db.SaveChanges() > 0;
        }
    }
}
