using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Data.DatabaseContext;
using MadPay724.Presentation.Models.test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportInfrastructure.Sql;

namespace MadPay724.Presentation.Controllers.Report.Lab
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireAccountantRole")]
    public class TestController : Controller
    {
        private readonly MadpayDbContext _context;

        public TestController(MadpayDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
       
        [HttpPost("Add")]
        public JsonResult Add([FromBody] test_InputModel model)
        {
            var serviceResult = new ReportInfrastructure.Service.ServiceResult<bool>();
            try
            {
                if (!ModelState.IsValid)
                {
                    serviceResult.State = ReportInfrastructure.Service.StateEnum.NotValid;
                    serviceResult.SetException(new Exception("Validation Error"));
                    return Json(serviceResult);
                }
               
                var result = MainDapperHelper.ExecuteQuery_With_DataAndMessage<bool, DBMessageModel>("[dbo].[ins_test]", model, System.Data.CommandType.StoredProcedure, ReturnType.MessageAndData);
                serviceResult.SetData(result?.data?.FirstOrDefault() ?? true);
                serviceResult.Message = result.message?.Value;

            }
            catch (SqlException ex)
            {
                if (ex.Number == ReportInfrastructure.Sql.ErrorNumbers.CustomErrors)
                {
                    serviceResult.State = ReportInfrastructure.Service.StateEnum.Exception;
                    serviceResult.Message = ex.Message;
                }
                else
                {
                    serviceResult.State = ReportInfrastructure.Service.StateEnum.Exception;
                    serviceResult.SetException(new Exception("UnknownError"));
                }
            }
            catch (Exception ex)
            {
                serviceResult.SetException(new Exception("UnknownError"));
            }
            return Json(serviceResult);
        }

    }
}