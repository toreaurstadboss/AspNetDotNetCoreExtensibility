using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Globomantics.Conventions
{
    public class BindName : Attribute, IParameterModelConvention
    {
        public string Name { get; set; }

        public void Apply(ParameterModel parameter)
        {
            if (parameter.BindingInfo == null)
            {
                parameter.BindingInfo = new BindingInfo();
            }
            parameter.BindingInfo.BinderModelName = Name; 
        }
    }
}
