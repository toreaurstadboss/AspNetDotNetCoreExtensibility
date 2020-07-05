﻿using System;
using Globomantics.Filters;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    [Route("api/[controller]")]
    [RateExceptionFilter]
    public class RatesController : Controller
    {
        private IRateService rateService;

        public RatesController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        [HttpGet]
        [Route("mortgage")]
        public IActionResult GetMortgageRates()
        {
            return Ok(rateService.GetMortgageRates());
        }

        [HttpGet]
        [Route("credit")]
        public IActionResult GetCreditCardRates()
        {
            return Ok(rateService.GetCreditCardRates());
        }

        [HttpGet]
        [Route("autoloan")]
        public IActionResult GetAutoLoanRates()
        {
            throw new TimeoutException();
        }


        [HttpGet]
        [Route("cd")]
        public IActionResult GetCDRates()
        {
            return Ok(rateService.GetCDRates());
        }
    }
}
