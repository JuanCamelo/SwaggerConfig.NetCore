using PruebasDeConexion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasDeConexion.Domain.contracts
{
    public interface IPesoronasDomain
    {
        List<Persona> _getlistpersonas();
    }
}
