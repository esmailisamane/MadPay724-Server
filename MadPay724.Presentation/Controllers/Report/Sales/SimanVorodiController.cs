﻿using System;
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
    public class SimanVorodiController : Controller
    {
        private readonly BPMS_NanobotonContext _context;

        public SimanVorodiController(BPMS_NanobotonContext context)
        {
            _context = context;
        }

        #region سیمان ورودی
        [HttpGet("GetSimanVorodi/{fromDate?}/{toDate?}/{yearid?}")]
        public JsonResult GetSimanVorodi(string fromDate, string toDate, string yearid)
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

            var serviceResult = new ReportInfrastructure.Service.ServiceResult<IEnumerable<SimanVorodi_ViewModel>>();
            //AccountMoeein_FindModel MoeinAccount_FindModel = new AccountMoeein_FindModel ();
            try
            {
                var model = DapperHelper.GetQueryResult<dynamic, SimanVorodi_ViewModel>(new { FromDate = fdate, ToDate = tDate, YearID = yearid }, System.Data.CommandType.StoredProcedure, "[Acc].[Get_B_SimaneVorodi]");
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