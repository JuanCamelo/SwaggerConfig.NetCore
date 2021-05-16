using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebasDeConexion.Aplicacion.Contracts;
using PruebasDeConexion.DTOs;
using PruebasDeConexion.Model;

namespace PruebasDeConexion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IPerosona _persona;

        
        /// <param name="persona"></param>
        public ProductosController(IPerosona persona)
        {
            _persona = persona;
        }


        /// <summary>
        /// get list personas 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(ProductosController.getlisataProductos))]
        public ActionResult<List<personaDTO>> getlisataProductos()
        => _persona._getPersona();
    }
}
