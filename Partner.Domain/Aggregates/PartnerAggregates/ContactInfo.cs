using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner.Domain.Aggregates.PartnerAggregates
{
    public class ContactInfo : AggregateRoot<int>
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

}
