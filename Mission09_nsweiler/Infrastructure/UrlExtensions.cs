using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Infrastructure
{
    public static class UrlExtensions // beautify the path visible to the user
    {
        public static string PathAndQuery(this HttpRequest request ) => 
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
