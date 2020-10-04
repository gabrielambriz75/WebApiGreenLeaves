using System;
using System.Collections.Generic;

namespace WebApiGreenLeaves.Data
{
    public partial class Regions
    {
        public Regions()
        {
            Cities = new HashSet<Cities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public short CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Cities> Cities { get; set; }
    }
}
