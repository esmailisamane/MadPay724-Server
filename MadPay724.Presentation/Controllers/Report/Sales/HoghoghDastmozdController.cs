using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Data.DatabaseContext;
using MadPay724.Presentation.Models.Seller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportInfrastructure.Sql;

namespace MadPay724.Presentation.Controllers.Report.Sales
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireSellerRole")]
    public class HoghoghDastmozdController : Controller
    {
        private readonly BPMS_NanobotonContext _context;

        public HoghoghDastmozdController(BPMS_NanobotonContext context)
        {
            _context = context;
        }


        #region بیمه - حقوق و دستمزد
        [HttpGet("GetHoghoghDastmozd/{fromDate?}/{toDate?}/{yearid?}")]
        public JsonResult GetHoghoghDastmozd(string fromDate, string toDate, string yearid)
        {

            var fdate = "";
            var tDate = "";
            try
            {
                if (fromDate != "null")
                {

                    fdate = fromDate.Substring(0, 4) + "/" + fromDate.Substring(5, 2) + "/" + fromDate.Substring(8, 2);
                }
                else
                {
                    fdate = null;
                }
                if (toDate != "null")
                {

                    tDate = toDate.Substring(0, 4) + "/" + toDate.Substring(5, 2) + "/" + toDate.Substring(8, 2);
                }
                else
                {
                    tDate = null;
                }
            }
            catch (Exception ex)
            {

            }

            var serviceResult = new ReportInfrastructure.Service.ServiceResult<IEnumerable<HoghoghDastmozd_ViewModel>>();
            //AccountMoeein_FindModel MoeinAccount_FindModel = new AccountMoeein_FindModel ();
            try
            {
                var model = DapperHelper.GetQueryResult<dynamic, HoghoghDastmozd_ViewModel>(new { FromDate = fdate, ToDate = tDate, YearID = yearid }, System.Data.CommandType.StoredProcedure, "[Acc].[Get_Bime_Hoghogh_Dastmozd]");
                serviceResult.SetData(model);
            }
            catch (Exception ex)
            {
                //serviceResult.SetException(new Exception(Alyatim.Localization.Resources.ActionMessages.UnknownError));
            }
            return Json(serviceResult);
        }

        #endregion
    }
}