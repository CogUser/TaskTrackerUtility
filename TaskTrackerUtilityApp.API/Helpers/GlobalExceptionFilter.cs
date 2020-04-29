using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerUtilityApp.API.Helpers
{
    public class GlobalExceptionFilter: ExceptionFilterAttribute
    {
        public  override void OnException(ExceptionContext context)
        {
            
        }
    }
}
