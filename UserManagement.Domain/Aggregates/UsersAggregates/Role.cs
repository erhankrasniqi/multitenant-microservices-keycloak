using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Aggregates.UsersAggregates
{
    public class Role : AggregateRoot<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public static Role Create(string name, string description)
        {
            return new Role
            {
                Name = name,
                Description = description,
            };
        }
    }
}