using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class InstructorRepo : Repo, IRepo<Instructor, int, bool>, IAuth<Instructor>, I_Image<Instructor, byte[], string, bool>
    {
        public Instructor Auth(int id, string password)
        {
            var data = from u in db.Instructors
                       where u.InstructorId.Equals(id) && u.InstructorPassword.Equals(password) && u.InstructorAccountStatus == "Active"
                       select u;
            
            return data.SingleOrDefault();
        }

        public bool Create(Instructor obj)
        {
            db.Instructors.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ins=Get(id);
            ins.InstructorAccountStatus = "Deleted";
            return db.SaveChanges() > 0;

        }

        public Instructor Get(int id)
        {
            var data = db.Instructors.Where(s => s.InstructorId == id && s.InstructorStatus != "Deleted");
            return data.SingleOrDefault();
        }

        public List<Instructor> GetALL()
        {
            return db.Instructors.Where(s => s.InstructorStatus != "Deleted").ToList();
        }

        public byte[] Get_Image(string imageName)
        {
            try
            {
                string projectRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "./DAL");
                string folderPath = Path.Combine(projectRoot, "Uploads", "Instructor", "Profile_Image");
                // Remove or replace invalid characters from the imageName
                string sanitizedImageName = SanitizeFileName(imageName);
                string imagePath = Path.Combine(folderPath, sanitizedImageName);

                if (File.Exists(imagePath))
                {
                    return File.ReadAllBytes(imagePath);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Instructor obj)
        {
            var ins= Get(obj.InstructorId);
            ins.InstructorName = obj.InstructorName;
            ins.InstructorEmail = obj.InstructorEmail;
            ins.InstructorPassword = obj.InstructorPassword;
            ins.InstructorPhoneNumber = obj.InstructorPhoneNumber;
            ins.InstructorStatus = obj.InstructorStatus;
            ins.InstructorAccountStatus = obj.InstructorAccountStatus;
            ins.RegistrationDate = obj.RegistrationDate;
            ins.Image= obj.Image;
            return db.SaveChanges() > 0;
        }

        private string SanitizeFileName(string fileName)
        {
            // Replace invalid characters with an underscore
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(invalidChar, '_');
            }
            return fileName;
        }

        public bool Upload_Image(byte[] image, string imageName)
        {
            try
            {
                string projectRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "./DAL");
                string folderPath = Path.Combine(projectRoot, "Uploads", "Instructor", "Profile_Image");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Remove or replace invalid characters from the imageName
                string sanitizedImageName = SanitizeFileName(imageName);
                string imagePath = Path.Combine(folderPath, sanitizedImageName);

                using (FileStream fileStream = new FileStream(imagePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fileStream.Write(image, 0, image.Length);
                }

                return true;
            }
            catch (Exception ex)
            {
                Print_in_Red(ex.Message);
                return false;
            }
        }
        public static void Print_in_Red(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
