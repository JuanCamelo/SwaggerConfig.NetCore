using Microsoft.Extensions.DependencyInjection;
using PruebasDeConexion.Aplicacion;
using PruebasDeConexion.Aplicacion.Contracts;
using PruebasDeConexion.Domain;
using PruebasDeConexion.Domain.contracts;
using PruebasDeConexion.Model;
using System;

namespace PruebasDeConexion.DI
{
    public class DependencyInjectionProfile
    {
        public static void RegisterProfile(IServiceCollection services)
        {
           // #region Context

           //// services.AddTransient<Microsoft.EntityFrameworkCore.DbContext, AdminAgroSuiteContext>();


           // #endregion

           // #region Loggers

           // #endregion

           // #region Aplicacion
           // services.AddTransient<IPerosona, PersonaService>();
           // #endregion

           // #region Domain
           // services.AddTransient<IPesoronasDomain, pesrnassDomain>();
           // #endregion
        }
    }
}
