using Microsoft.EntityFrameworkCore;
using PruebasDeConexion.Domain.contracts;
using PruebasDeConexion.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasDeConexion.Domain
{
    public class pesrnassDomain: System.Data.Entity.DbContext, IPesoronasDomain
    {
        private readonly System.Data.Entity.DbSet<Persona> _personas;

        public pesrnassDomain(System.Data.Entity.DbSet<Persona> personas)
        {
            _personas = personas;
        }

        public List<Persona> _getlistpersonas()
         => _personas.ToList();
    }
}

