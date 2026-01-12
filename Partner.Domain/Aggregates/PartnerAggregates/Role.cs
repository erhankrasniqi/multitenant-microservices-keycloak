using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner.Domain.Aggregates.PartnerAggregates
{
    public class Role : AggregateRoot<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }  

        public ICollection<PartnerUser> Users { get; set; }
    }

}
