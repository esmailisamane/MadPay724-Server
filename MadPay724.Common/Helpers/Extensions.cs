﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Common.Helpers
{
  public static class Extensions
    {
        public static void AddAppError(this HttpResponse response, string message)
        {
            response.Headers.Add("App-Error", message);
            response.Headers.Add("Access-Control_Expose-Header", "App-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
           
        }
    }
}
