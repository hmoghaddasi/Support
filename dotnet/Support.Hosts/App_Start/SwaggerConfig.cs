using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Support.Hosts;
using Swashbuckle.Application;

namespace Support.Hosts
{
    public static class SwaggerConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Support Api Documentation v1");
                    c.IgnoreObsoleteActions();
                    c.UseFullTypeNameInSchemaIds();
                    c.DescribeAllEnumsAsStrings();
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                    c.OperationFilter<AddRequiredHeaderParameter>();
                })
                .EnableSwaggerUi();
        }
    }
}