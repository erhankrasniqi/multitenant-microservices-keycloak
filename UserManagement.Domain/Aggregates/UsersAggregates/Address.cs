using SharedKernel; 

namespace UserManagement.Domain.Aggregates.UsersAggregates
{
    public class Address : AggregateRoot<int>
    { 
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public int UserId { get; set; } 
        public Users User { get; set; }

        public static Address Create(int userId, string street, string city, string region, string postalCode, string country)
        {
            return new Address
            {
                UserId = userId,
                Street = street,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country
            };
        }
    }
}