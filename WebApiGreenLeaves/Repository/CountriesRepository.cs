using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGreenLeaves.Data;
using WebApiGreenLeaves.DTO;
using WebApiGreenLeaves.Repository.IRepository;

namespace WebApiGreenLeaves.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly GreenLeavesContext _contextGreenLeaves;
        public CountriesRepository(GreenLeavesContext contextGreenLeaves)
        {
            _contextGreenLeaves = contextGreenLeaves;
        }
        public List<Countries> ObtenerPaises(List<Regions> Regiones)
        {

            var Paises = (from p in _contextGreenLeaves.Countries
                          where Regiones.Select(x => x.CountryId).Contains(p.Id)
                          select p).ToList();


            return Paises;
        }
    }
}
