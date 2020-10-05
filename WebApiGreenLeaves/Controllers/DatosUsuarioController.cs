using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGreenLeaves.Repository.IRepository;
using WebApiGreenLeaves.ViewModel;

namespace WebApiGreenLeaves.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiFormulario")]
    public class DatosUsuarioController : BaseController
    {
        private readonly ICitiesRepository _CitiesRepo;
        private readonly IRegionsRepository _RegionsRepo;
        private readonly ICountriesRepository _CountriesRepo;
        //private readonly IMapper _Mapper;

        public DatosUsuarioController(ICitiesRepository CitiesRepo, IRegionsRepository RegionsRepo, ICountriesRepository CountriesRepo)
        {
            _CitiesRepo = CitiesRepo;
            _RegionsRepo = RegionsRepo;
            _CountriesRepo = CountriesRepo;
            //_Mapper = Mapper;
        }


        /// <summary>
        /// Metodo para obtener la locacion mediante el envio del nombre de la ciudad.
        /// </summary>
        /// <param name="NameCiudad"></param>
        /// <returns></returns>
        [HttpGet("{NameCiudad}")]
        //[Route("ObtenerLocacion")]
        public ActionResult ObtenerLocacion(string NameCiudad)
        {
            NameCiudad = NameCiudad.First().ToString().ToUpper() + NameCiudad.Substring(1).ToLower();

            var ciudades = _CitiesRepo.ObtenerCiudades(NameCiudad);

            var regiones = _RegionsRepo.ObtenerRegiones(ciudades);


            var paises = _CountriesRepo.ObtenerPaises(regiones);

            List<LocacionModel> listaLocacion = new List<LocacionModel>();
            foreach (var item in ciudades)
            {
                LocacionModel nuevaLocacion = new LocacionModel();
                nuevaLocacion.LocacionCompleta = item.Name + "," + item.Region.Name + "," + item.Region.Country.Name;
                nuevaLocacion.IdCiudad = item.Id;
                listaLocacion.Add(nuevaLocacion);
            }

            return Ok(listaLocacion);
        }

        /// <summary>
        /// Enviar datos del usuario por correo
        /// </summary>
        /// <param name="datosUsuario"></param>
        /// <returns></returns>
       [HttpPost]
        public ActionResult EnviarDatosUsuario([FromBody] DatosUsuarioModel datosUsuario)
        {
            try
            {

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }



        
        }
    }
}
