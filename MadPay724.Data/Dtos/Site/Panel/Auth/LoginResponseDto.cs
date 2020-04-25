﻿using MadPay724.Data.Dtos.Site.Panel.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.Dtos.Site.Panel.Auth
{
    public class LoginResponseDto
    {
        public string token { get; set; }
        public string refresh_token { get; set; }
        public UserForDetailedDto user { get; set; }
    }
}