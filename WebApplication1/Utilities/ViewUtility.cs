using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Utilities
{
    public class ViewUtility
    {
        public static string GetFunctionName(ControllerContext _context)
        {
            return _context.GetType().FullName + "." + _context.RouteData.Values["action"];
        }

    }
}