using BLL.DTOs;
using BLL.Services;
using SkillShare.AuthFilters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SkillShare.Controllers
{
    [EnableCors("*", "*", "*")]
    public class InstructorController : ApiController
    {
        [HttpPost]
        [Route("api/Instructor/CreateIns")]
        public HttpResponseMessage CreateIns(InstructorDTO ins)
        {
            try
            {
                var data= InstructorService.CreateIns(ins);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Instructor/GetIns/{id}")]
        //[Logged]
        public HttpResponseMessage GetIns(int id)
        {
            try
            {
                //var current_u = "";
                //var authhead= Request.Headers.Authorization?.ToString();
                var data = InstructorService.GetIns(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Instructor/GetALLIns")]
        public HttpResponseMessage GetALLIns()
        {
            try
            {
                var data = InstructorService.GetALLIns();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("api/Instructor/UpdateIns")]
        public HttpResponseMessage UpdateIns(InstructorDTO ins)
        {
            try
            {
                var data = InstructorService.UpdateIns(ins);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/Instructor/DeleteIns/{id}")]
        public HttpResponseMessage DeleteIns(int id)
        {
            try
            {
                var data = InstructorService.DeleteIns(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //Feature API

        //F1
        [HttpGet]
        [Route("api/Instructor/GetInsByCourse/{id}")]
        public HttpResponseMessage GetInsByCourse(int id)
        {
            try
            {
                var data = InstructorService.GetALLInsByCourse(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //F2
        [HttpGet]
        [Route("api/Instructor/GetStudentbyIns/{id}")]
        public HttpResponseMessage GetStudentbyIns(int id)
        {
            try
            {
                var data = InstructorService.GetNumberOfSudentInCourse(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Instructor/login")]
        public HttpResponseMessage login(BLL.LoginModel lm)
        {
            try
            {
                var token = AuthService.Login(lm.id, lm.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Username or password invalid" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //F3
        [HttpGet]
        [Route("api/Instructor/GetCourseFeedback/{id}")]
        public HttpResponseMessage GetCourseFeedback(int id)
        {
            try
            {
                var data = InstructorService.GetCourseFeedback(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        //F4
        [HttpGet]
        [Route("api/Instructor/GetCourseFeedbackByIns/{id}")]
        public HttpResponseMessage GetCourseFeedbackByIns(int id)
        {
            try
            {
                var data = InstructorService.GetCourseFeedbackByIns(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        //F5
        [HttpGet]
        [Route("api/Instructor/GetAverageGradeByIns/{id}")]
        public HttpResponseMessage GetAverageGradeByIns(int id)
        {
            try
            {
                var data = InstructorService.AverageGradeByIns(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        //F6
        [HttpPost]
        [Route("api/Instructor/image/upload/{id}")]
        public HttpResponseMessage UploadInsImg(int id)
        {
            try
            {
                var current_user_ID = 0;
                var authorizationHeader = Request.Headers.Authorization?.ToString();
                current_user_ID = InstructorService.GetInsID(id);
                var ins_info = InstructorService.GetIns(current_user_ID);
                if (current_user_ID > 0)
                {
                    var file = HttpContext.Current.Request.Files[0];

                    if (file == null || file.ContentLength == 0)
                    {
                        var responseMessage = new
                        {
                            Message = "No Image Uploaded"
                        };
                        return Request.CreateResponse(HttpStatusCode.BadRequest, responseMessage);
                    }
                    else
                    {
                        byte[] imageData;
                        using (var memoryStream = new MemoryStream())
                        {
                            file.InputStream.CopyTo(memoryStream);
                            imageData = memoryStream.ToArray();
                        }
                        var final_decision = InstructorService.UploadImg(imageData, file.FileName, ins_info.InstructorId);
                        if (final_decision)
                        {
                            var responseMessage = new
                            {
                                Message = "Image Updated Successsfully"
                            };
                            return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
                        }
                        else
                        {
                            var responseMessage = new
                            {
                                Message = "Failed to update the Image"
                            };
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, responseMessage);
                        }
                    }
                }
                else
                {
                    var responseMessage = new
                    {
                        Message = "Please Login First"
                    };
                    return Request.CreateResponse(HttpStatusCode.Forbidden, responseMessage);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        //F7
        [HttpGet]
        [Route("api/Instructor/image/get/{id}")]
        public HttpResponseMessage getInsImage(int id)
        {
            try
            {

                var current_user_ID = 0;
                current_user_ID = InstructorService.GetInsID(id);

                if (current_user_ID > 0)
                {
                    var current_INS = InstructorService.GetIns(current_user_ID);
                    var image = InstructorService.Get_Image(current_INS.InstructorId);

                    if (image != null)
                    {
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                        var copy_Byte_image = image;
                        response.Content = new ByteArrayContent(image);
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue(GetImageContentType(copy_Byte_image)); // Set the appropriate content type
                        return response;
                    }
                    else
                    {
                        var responseMessage = new
                        {
                            Message = "Image Not Found"
                        };
                        return Request.CreateResponse(HttpStatusCode.NotFound, responseMessage);
                    }
                }
                else
                {
                    var responseMessage = new
                    {
                        Message = "Invalid Instructor ID"
                    };
                    return Request.CreateResponse(HttpStatusCode.Forbidden, responseMessage);
                }



            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private string GetImageContentType(byte[] image)
        {
            if (image.Length >= 2)
            {
                if (image[0] == 0xFF && image[1] == 0xD8) // JPEG magic number
                {
                    return "image/jpeg";
                }
                else if (image[0] == 0x89 && image[1] == 0x50 && image[2] == 0x4E && image[3] == 0x47) // PNG magic number
                {
                    return "image/png";
                }
                else if (image[0] == 0x47 && image[1] == 0x49 && image[2] == 0x46 && image[3] == 0x38) // GIF8 magic number
                {
                    return "image/gif";
                }
                else if (image[0] == 0x3C && image[1] == 0x73 && image[2] == 0x76 && image[3] == 0x67) // SVG magic number (XML declaration)
                {
                    return "image/svg+xml";
                }
            }

            return "application/octet-stream";
        }

    }
}
