
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class SkillShareContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAndStudentGroup> StudentAndStudentGroups { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseChapter> CourseChapters { get; set; }
        public DbSet<CourseChapterAndStudent> CourseChapterAndStudents { get; set; }
        public DbSet<CourseExam> CourseExams { get; set; }
        public DbSet<CourseExamAndStudent> CourseExamsAndStudents { get; set; }
        public DbSet<CourseFeedback> CourseFeedbacks { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<CourseSectionAndStudent> CourseSectionAndStudents { get; set; }
        public DbSet<CourseSectionAssignment> CourseSectionAssignments { get; set; }
        public DbSet<CourseSectionAssignmentAndStudent> CourseSectionAssignmentAndStudents { get; set; }
        public DbSet<CourseSectionAndStudentGroup> CourseSectionAndStudentGroups { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
