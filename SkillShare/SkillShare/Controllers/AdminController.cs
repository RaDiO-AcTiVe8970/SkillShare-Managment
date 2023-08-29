using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillShare.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin/alladmin")]
        public HttpResponseMessage GetALLadmin()
        {
            try
            {
                var data = AdminService.GetAllAdmin();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/admin/createadmin")]
        public HttpResponseMessage CreateIns(AdminDTO ad)
        {
            try
            {
                var data = AdminService.CreateAdmin(ad);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
