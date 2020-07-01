using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Data.DatabaseContext;
using MadPay724.Presentation.Models.BahayeTamamShode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportInfrastructure.Sql;

namespace MadPay724.Presentation.Controllers.Report.Mali
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireAccountantRole")]
    public class BahayeTamashodeKalaController : Controller
    {
        private readonly BPMS_NanobotonContext _context;

        public BahayeTamashodeKalaController(BPMS_NanobotonContext context)
        {
            _context = context;
        }

        #region بهای تمام شده کالای فروش رفته
        [HttpGet("GetbahayeTamamshodeKala/{fromDate?}/{toDate?}/{yearid?}")]
        public JsonResult GetbahayeTamamshodeKala(string fromDate, string toDate, string yearid)
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



            var serviceResult = new ReportInfrastructure.Service.ServiceResult<IEnumerable<BahayeTamamShode_ViewModel>>();
            //AccountMoeein_FindModel MoeinAccount_FindModel = new AccountMoeein_FindModel ();
            try
            {
                var model = DapperHelper.GetQueryResult<dynamic, BahayeTamamShode_ViewModel>(new { FromDate = fdate, ToDate = tDate, YearID = yearid }, System.Data.CommandType.StoredProcedure, "[Acc].[Get_BahayTamashode_KalayeForoshRafte]");
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