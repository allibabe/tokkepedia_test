using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Tools
{
    public class AmpViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            if(context.ActionContext.HttpContext.Request.QueryString.HasValue)
            {
                var contains = context.ActionContext.HttpContext.Request.QueryString.Value.Contains("type=amp");
                context.Values.Add("AmpKey", contains.ToString());
            }

            var containsStem = context.ActionContext.HttpContext.Request.Path.StartsWithSegments("/amp");
            context.Values.Add("AmpStem", containsStem.ToString());
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (!(context.ActionContext.ActionDescriptor is ControllerActionDescriptor descriptor)) { return viewLocations; }

            if ((context.ActionContext.HttpContext.Request.QueryString.HasValue ? context.ActionContext.HttpContext.Request.QueryString.Value.Contains("type=amp") : false)
                || context.ActionContext.HttpContext.Request.Path.StartsWithSegments("/amp")
            )
            {
                return viewLocations.Select(x => x.Replace("{0}", "{0}.amp"));
            }

            return viewLocations;
        }
    }
}
