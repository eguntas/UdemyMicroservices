using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeCourse.Shared3._1.Service
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private IHttpContextAccessor _contextAccessor;
        public SharedIdentityService(IHttpContextAccessor httpContext)
        {
            _contextAccessor = httpContext;            
        }
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
