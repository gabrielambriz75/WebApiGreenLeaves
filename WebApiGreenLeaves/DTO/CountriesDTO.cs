using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGreenLeaves.DTO
{
    public class CountriesDTO
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }

        public List<RegionsDTO> Regions { get; set; }
    }
}
