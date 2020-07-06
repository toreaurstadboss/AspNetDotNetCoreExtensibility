using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Globomantics.Conventions
{
    public class ApiConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ControllerName = controller.ControllerName.Replace("Api", "");

        }
    }
}
