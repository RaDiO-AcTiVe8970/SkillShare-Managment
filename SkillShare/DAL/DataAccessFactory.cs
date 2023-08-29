using DAL.EF.Models;
using DAL.Interface;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Instructor, int, bool> InstructorDataAccess()
        {
            return new InstructorRepo();
        }
        public static IRepo<Course, int, bool> CourseDataAccess()
        {
            return new CourseRepo();
        }
        public static IRepo<Student, int, bool> StudentDataAccess()
        {
                return new StudentRepo();
        }
        public static IRepo<StudentGroup, int, bool> StudentGroupDataAccess()
        {
                return new StudentGroupRepo();
        }
        public static IRepo<CourseSectionAndStudent, int, bool> CourseSectionAndStudentDataAccess()
        {
            return new CourseSectionAndStudentRepo();
        }
        public static IRepo<User, string, bool> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Token, int, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static IAuth<Instructor> AuthDataAccess()
        {
            return new InstructorRepo();
        }
        public static IRepo<CourseFeedback , string, bool> CourseFeedbackDataAccess()
        {
            return new CourseFeedBackRepo();
        }
        public static IRepo<CourseExam, int, bool> CourseExamDataAccess()
        {
            return new CourseExamRepo();
        }
        public static IRepo<CourseExamAndStudent, int, bool> CourseExamAndStudentDataAccess()
        {
            return new CourseExamAndStudentRepo();
        }
        public static I_Image<Instructor, byte[], string, bool> InstructorImageDataAccess()
        {
            return new InstructorRepo();
        }
        public static IRepo<Admin, int, bool> AdminDataAccess()
        {
            return new AdminRepo();
        }
    }
}
