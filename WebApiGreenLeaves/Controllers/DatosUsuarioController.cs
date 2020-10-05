using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        //private readonly IMapper _Mapper;

        public DatosUsuarioController(ICitiesRepository CitiesRepo, 
            IRegionsRepository RegionsRepo, 
            ICountriesRepository CountriesRepo,
             IConfiguration config)
        {
            _CitiesRepo = CitiesRepo;
            _RegionsRepo = RegionsRepo;
            _CountriesRepo = CountriesRepo;
            _config = config;
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
                var mail = new MailMessage();
                mail.To.Add(new MailAddress(datosUsuario.Mail, datosUsuario.Nombre));
                var smtp = _config.GetSection("Smtp");

                mail.From = new MailAddress("correo@hotmail.com", "Nombre");

                mail.Body = "Nombre: "+ datosUsuario.Nombre + 
                    " Telefono: " + datosUsuario.Telefono + 
                    " Fecha: " + datosUsuario.Fecha.ToString() +
                    " Localizacion: " + datosUsuario.CiudadEstado;

           
                using (SmtpClient client = new SmtpClient())
                {
                   

                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtp.GetSection("Mail").Value, smtp.GetSection("Password").Value);
                    client.Host = smtp.GetSection("Host").Value;
                    client.Port =Convert.ToInt32(smtp.GetSection("Port").Value);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;


                    client.Send(mail);
                }
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }



        
        }
    }
}
