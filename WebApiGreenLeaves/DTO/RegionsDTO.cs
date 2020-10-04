using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGreenLeaves.DTO
{
    public class RegionsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short CountryId { get; set; }
        public CountriesDTO Countries { get; set; }
        public List<CitiesDTO> Cities { get; set; }
    }
}
