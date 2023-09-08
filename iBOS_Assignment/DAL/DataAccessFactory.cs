using DAL.EF;
using DAL.EF.Model;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Employee, int, bool> EmployeeDataAccess()
        {
            return new EmployeeRepo();
        }
        public static IRepo<EmployeeAttendance, int, bool> EmployeeAttendanceDataAccess()
        {
            return new EmployeeAttendanceRepo();
        }
    }
}