using Calculator.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Services
{
    static class AuthUserServiceCollectionExtensions
    {
        public static void AddCalculatorServices(this IServiceCollection services) 
            => services.AddScoped<ICalculatorServices<Tax>, CalculatorServices>();

        public static void AddIRServices(this IServiceCollection services) 
            => services.AddScoped<ITaxServices<IR>, TaxServices>();       

    }
}