using Globomantics.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace Globomantics.Controllers
{
    public class SurveyController : Controller
    {

        public IActionResult Submission(List<Submission> submissions)
        {
            return new JsonResult(submissions, new JsonSerializerOptions{ WriteIndented = true });
        }
    }
}
