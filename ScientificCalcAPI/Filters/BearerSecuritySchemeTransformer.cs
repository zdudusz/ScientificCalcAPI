using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace ScientificCalcAPI.Filters
{
    public class BearerSecuritySchemeTransformer : IOpenApiDocumentTransformer
    {
        public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {// Adiciona o esquema de segurança Bearer ao documento OpenAPI
            document.Components ??= new OpenApiComponents();
            if (document.Components.SecuritySchemes == null)
                document.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>();
            document.Components.SecuritySchemes.Add("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Insira o token de acesso:"
            });
            return Task.CompletedTask;
        }
    }
}
