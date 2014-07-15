using FluentValidation;
using FluentValidation.WebApi;
using Newtonsoft.Json;
using FVTest.Filters;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace FVTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            FluentValidationModelValidatorProvider.Configure(config);
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            config.Filters.Add(new ValidateModelFilterAttribute());
            config.Filters.Add(new CheckModelForNullAttribute());

            // Clear all formatters
            config.Formatters.Clear();

            var JsonMTF = new JsonMediaTypeFormatter
            {
                SerializerSettings = { MissingMemberHandling = MissingMemberHandling.Error }
            };

            // Add the JSON formatter
            config.Formatters.Add(JsonMTF);

            // Implement custom content negotiator that only accepts JSON
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(JsonMTF));
        }
    }
}
