using System;
using System.Collections.Generic;

namespace WebApiGreenLeaves.Data
{
    public partial class Countries
    {
        public Countries()
        {
            Regions = new HashSet<Regions>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }

        public virtual ICollection<Regions> Regions { get; set; }
    }
}
