using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGreenLeaves.Data;
using WebApiGreenLeaves.DTO;

namespace WebApiGreenLeaves.Repository.IRepository
{
    public interface ICountriesRepository
    {
        List<Countries> ObtenerPaises(List<Regions> Regiones);
    }
}
