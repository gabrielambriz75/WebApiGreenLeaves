using System;
using System.Collections.Generic;

namespace WebApiGreenLeaves.Data
{
    public partial class Cities
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }

        public virtual Regions Region { get; set; }
    }
}
