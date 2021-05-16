
using PruebasDeConexion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasDeConexion.Aplicacion.Contracts
{
    public interface IPerosona
    {
        List<personaDTO> _getPersona();
    }
}
