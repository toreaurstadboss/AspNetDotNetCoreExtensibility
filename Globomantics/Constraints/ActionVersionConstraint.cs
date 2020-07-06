using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Globomantics.Constraints
{
    public class ActionVersionConstraint : IActionConstraint
    {
        private double requiredVersion;

        public ActionVersionConstraint(double version)
        {
            this.requiredVersion = version;
        }

        public int Order { get; set; }

        public bool Accept(ActionConstraintContext context)
        {
            if (double.TryParse(context.RouteContext.HttpContext.Request
                .Headers["x-version"].ToString(), out var parsedVersion))
            {
                return parsedVersion >= requiredVersion &&
                    parsedVersion < requiredVersion + 1;
            }

            return false;
        }
    }
}
