using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Data.DatabaseContext;
using MadPay724.Presentation.Models.Moeen;
using MadPay724.Presentation.Models.Seller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportInfrastructure.Sql;

namespace MadPay724.Presentation.Controllers.Report.Sales
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireSellerRole")]
    public class AmalkardTolidController :Controller
    {
        private readonly BPMS_NanobotonContext _context;

        public AmalkardTolidController(BPMS_NanobotonContext context)
        {
            _context = context;
        }

        #region عملکرد تولید
        [HttpGet("GetAmalkardTolid/{yearid?}")]
        public JsonResult GetAmalkardTolid(string yearid)
        {


            var serviceResult = new ReportInfrastructure.Service.ServiceResult<IEnumerable<AmalkardTolid_ViewModel>>();
            //AccountMoeein_FindModel MoeinAccount_FindModel = new AccountMoeein_FindModel ();
            try
            {
                var model = DapperHelper.GetQueryResult<dynamic, AmalkardTolid_ViewModel>(new { YearID = yearid }, System.Data.CommandType.StoredProcedure, "[Acc].[Get_Amalkard_Tolid]");
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