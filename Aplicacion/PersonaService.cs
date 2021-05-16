using Microsoft.EntityFrameworkCore;
using PruebasDeConexion.Aplicacion.Contracts;
using PruebasDeConexion.Domain.contracts;
using PruebasDeConexion.DTOs;
using PruebasDeConexion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasDeConexion.Aplicacion
{
    public class PersonaService : DbContext , IPerosona
    {

        private readonly IPesoronasDomain _personasDomain;
        public PersonaService( DbContextOptions options) : base(options)
        {
            _personasDomain = _personasDomain;
        }

        public  List<personaDTO> _getPersona()
        {
            try
            {
                //var responses = _personasDomain._getlistpersonas();

                return new List<personaDTO>();
            }
            catch (Exception ex)
            {

                return new List<personaDTO>();
            }
        }
    }
}
