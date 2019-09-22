using System.Collections.Generic;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace Support.Hosts
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "Type Bearer before token",
                type = "apiKey",
                required = false
            });
        }
    }
}