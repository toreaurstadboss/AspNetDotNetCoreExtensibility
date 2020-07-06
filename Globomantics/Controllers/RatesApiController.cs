﻿using Globomantics.Conventions;
using Globomantics.Filters;
using Globomantics.Middleware;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    [ControllerVersion(Version = 1)]
    [RateExceptionFilter]
    [Route("api/rates")]
    [MiddlewareFilter(typeof(BasicAuthConfig))]
    public class RatesApiController : Controller
    {
        private IRateService rateService;

        public RatesApiController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        [HttpGet]
        [Route("mortgage")]
        public IActionResult GetMortgageRates()
        {
            return Ok(rateService.GetMortgageRates());
        }

        //[HttpGet]
        //[Route("autoloan")]
        //public IActionResult GetAutoLoanRates()
        //{
        //    return Ok(rateService.GetAutoLoanRates());
        //}

        [HttpGet]
        [Route("creditcard")]
        public IActionResult GetCreditCardRates()
        {
            return Ok(rateService.GetCreditCardRates());
        }


        [HttpGet]
        [Route("cd")]
        public IActionResult GetCDRates()
        {
            return Ok(rateService.GetCDRates());
        }
    }
}
