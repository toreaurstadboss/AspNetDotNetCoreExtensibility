using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;

namespace Globomantics.Theme
{
    public class ThemeExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var activeTheme = context.Values["ACTIVE_THEME"];

            var viewLocationsList = viewLocations.ToList();
            var expandedLocations = viewLocationsList;
            int maxViewLocations = viewLocationsList.Count();

            for (int i = 0; i < maxViewLocations; i++)
            {
                expandedLocations.Insert(i, viewLocationsList.ElementAt(i).Replace("/Views", string.Format("/Views/Themes/{0}", activeTheme)));
            }

            return expandedLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var appSettings =
                (IConfiguration) context.ActionContext.HttpContext.RequestServices.GetService(typeof(IConfiguration));
            context.Values["ACTIVE_THEME"] = appSettings["AppSettings:ActiveTheme"];

            // throw new NotImplementedException();
        }
    }
}
