using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using Globomantics.Services;
using Microsoft.AspNetCore.Http.Features;

namespace Globomantics.Filters
{
    public class FeatureAuthFilter : IAuthorizationFilter
    {
        private readonly IFeatureService _featureService;
        private string _featureName { get; set; }

        public FeatureAuthFilter(IFeatureService featureService, string featureName)
        {
            _featureService = featureService;
            _featureName = featureName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_featureService.IsFeatureActive(_featureName))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
