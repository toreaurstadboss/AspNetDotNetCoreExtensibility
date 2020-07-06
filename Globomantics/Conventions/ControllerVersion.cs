using Globomantics.Constraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace Globomantics.Conventions
{
    public class ControllerVersion : Attribute, IControllerModelConvention
    {
        public double Version { get; set; }

        public void Apply(ControllerModel controller)
        {
            foreach(var selector in controller.Selectors)
            {
                selector.ActionConstraints.Add(new ActionVersionConstraint(Version));
            }
        }
    }
}
