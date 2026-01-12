using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner.Domain.Aggregates.PartnerAggregates
{
    public class PartnerUser : AggregateRoot<int>
    {
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
