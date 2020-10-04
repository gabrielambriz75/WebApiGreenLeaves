using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGreenLeaves.Data;
using WebApiGreenLeaves.DTO;
using WebApiGreenLeaves.Repository.IRepository;


namespace WebApiGreenLeaves.Repository
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly GreenLeavesContext _contextGreenLeaves;
        public CitiesRepository(GreenLeavesContext contextGreenLeaves)
        {
            _contextGreenLeaves = contextGreenLeaves;
        }

        public List<Cities> ObtenerCiudades(string NameCiudad)
        {
            try
            {
                List<Cities> Ciudades = new List<Cities>();
                Ciudades = _contextGreenLeaves.Cities.Where(x => x.Name.StartsWith(NameCiudad)).Take(50).ToList();

                //Ciudades = Ciudades.Where(x => x.Name.StartsWith(NameCiudad)).ToList();
                return Ciudades;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
            //throw new NotImplementedException();
        }
    }
}
