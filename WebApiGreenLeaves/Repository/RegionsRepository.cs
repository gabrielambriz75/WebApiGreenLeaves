using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGreenLeaves.Data;
using WebApiGreenLeaves.DTO;
using WebApiGreenLeaves.Repository.IRepository;

namespace WebApiGreenLeaves.Repository
{
    public class RegionsRepository : IRegionsRepository
    {
        private readonly GreenLeavesContext _contextGreenLeaves;
        public RegionsRepository(GreenLeavesContext contextGreenLeaves)
        {
            _contextGreenLeaves = contextGreenLeaves;
        }


        public List<Regions>ObtenerRegiones(List<Cities> cities)
        {


            var Regiones = (from r in _contextGreenLeaves.Regions
                            where cities.Select(x => x.RegionId).Contains(r.Id)
                            select r).ToList();

            return Regiones;

        }
    }
}
