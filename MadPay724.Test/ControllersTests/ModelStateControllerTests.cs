﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;


namespace MadPay724.Test.ControllersTests
{
    public class ModelStateControllerTests : Controller
    {
        public ModelStateControllerTests()
        {
            ControllerContext = (new Mock<ControllerContext>()).Object;
        }
    }
}
