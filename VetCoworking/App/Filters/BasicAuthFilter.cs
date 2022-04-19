using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AQ.Projects.App.Filters
{
    [PrimaryConstructor]
    public partial class BasicAuthFilter : IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
        }
    }
}
