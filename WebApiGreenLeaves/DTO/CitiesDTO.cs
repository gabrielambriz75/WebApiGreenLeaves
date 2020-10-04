using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGreenLeaves.DTO
{
    public class CitiesDTO
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }

        public RegionsDTO Regions { get; set; }
    }
}
