using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TravelAgency.Core.DTOs.Response;

namespace TravelAngecy.Infraestructure.Helpers
{
    public static class ValidationFilterAttribute
    {
        /// <summary>
        /// Servicio para validar requeridos en los request
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddResponseParametersValidation(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    ResponseQuery<bool> response = new ResponseQuery<bool>();
                    var errors = actionContext.ModelState.Keys
                    .SelectMany(key => actionContext.ModelState[key].Errors.Select(x => new string(x.ErrorMessage)))
                    .ToList();
                    
                    response.RequirementErrorMessage(errors);

                    return new BadRequestObjectResult(response);
                };
            });

            return services;
        }
    }
}
