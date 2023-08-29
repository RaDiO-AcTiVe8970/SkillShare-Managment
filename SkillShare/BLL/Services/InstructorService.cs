using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class InstructorService
    {
        public static bool CreateIns(InstructorDTO ins)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InstructorDTO, Instructor>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<Instructor>(ins);
            var data = DataAccessFactory.InstructorDataAccess().Create(insDTO);
            return data;
        }
        public static bool DeleteIns(int id)
        {
            var data = DataAccessFactory.InstructorDataAccess().Delete(id);
            return data;
        }
        public static bool UpdateIns(InstructorDTO ins)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InstructorDTO, Instructor>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<Instructor>(ins);
            var data = DataAccessFactory.InstructorDataAccess().Update(insDTO);
            return data;
        }
        public static InstructorDTO GetIns(int id)
        {
            var data = DataAccessFactory.InstructorDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Instructor, InstructorDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<InstructorDTO>(data);
            return insDTO;
        }

        public static int GetInsID(int id)
        {
            var data = DataAccessFactory.InstructorDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Instructor, InstructorDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<InstructorDTO>(data);
            var insID= insDTO.InstructorId;
            return insID;
        }
        public static List<InstructorDTO> GetALLIns()
        {
            var data = DataAccessFactory.InstructorDataAccess().GetALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Instructor, InstructorDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<List<InstructorDTO>>(data);
            return insDTO;
        }

        //Feature API
        public static List<InstructorDTO> GetALLInsByCourse(int id)
        {
            var data = (from ins in DataAccessFactory.InstructorDataAccess().GetALL()
                        join c in DataAccessFactory.CourseDataAccess().GetALL() on ins.InstructorId equals c.InstructorId
                        where c.CourseId == id
                        select ins).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Instructor, InstructorDTO>();
            });
            var mapper = new Mapper(config);
            var insDTO = mapper.Map<List<InstructorDTO>>(data);
            return insDTO;
        }
        public static int GetNumberOfSudentInCourse(int id)
        {
            var data= DataAccessFactory.CourseSectionAndStudentDataAccess().GetALL().Where(item=> item.CourseSection.Course.InstructorId==id).ToList();
            var dump = data.Count();
            return dump;
        }
        public static List<CourseFeedbackDTO> GetCourseFeedback(int id)
        {
            var data = (from ins in DataAccessFactory.InstructorDataAccess().GetALL()
                        join c in DataAccessFactory.CourseDataAccess().GetALL() on ins.InstructorId equals c.InstructorId
                        join cs in DataAccessFactory.CourseFeedbackDataAccess().GetALL() on c.CourseId equals cs.CourseId
                        where c.CourseId == id
                        select cs).ToList();
            var ret = ConvertingClass<CourseFeedback, CourseFeedbackDTO>.Convert(data).ToList();
            return ret;
        }
        public static List<CourseFeedbackDTO> GetCourseFeedbackByIns(int id)
        {
            var data = (from ins in DataAccessFactory.InstructorDataAccess().GetALL()
                        join c in DataAccessFactory.CourseDataAccess().GetALL() on ins.InstructorId equals c.InstructorId
                        join cs in DataAccessFactory.CourseFeedbackDataAccess().GetALL() on c.CourseId equals cs.CourseId
                        where ins.InstructorId == id
                        select cs).ToList();
            var ret = ConvertingClass<CourseFeedback, CourseFeedbackDTO>.Convert(data).ToList();
            return ret;
        }
        public static double? AverageGradeByIns(int id)
        {
            var data = (from ins in DataAccessFactory.InstructorDataAccess().GetALL()
                        join c in DataAccessFactory.CourseExamDataAccess().GetALL() on ins.InstructorId equals c.InstructorId
                        join cs in DataAccessFactory.CourseExamAndStudentDataAccess().GetALL() on c.CourseExamId equals cs.CourseExamId
                        where ins.InstructorId == id
                        select cs.Grade).ToList();
            var ret = data.Average();
            return ret;
        }

        public static bool UploadImg(byte[] image, string imageName, int ID)
        {
            try
            {
                var data= DataAccessFactory.InstructorDataAccess().Get(ID);
                if (data != null)
                {
                    var ct= DateTime.Now;
                    var F_imgname=(ct.ToString()) + imageName;
                    data.Image = F_imgname;
                    var des=DataAccessFactory.InstructorDataAccess().Update(data);
                    if(des)
                    {
                        var up_des = DataAccessFactory.InstructorImageDataAccess().Upload_Image(image, F_imgname);
                        if (up_des)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }  
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static byte[] Get_Image(int InsID)
        {
            var data = DataAccessFactory.InstructorDataAccess().Get(InsID);
            var imageName = data.Image.ToString();
            if (data != null)
            {
                return DataAccessFactory.InstructorImageDataAccess().Get_Image(imageName);
            }
            else
            {
                return null;
            }
        }
    }
}
