using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Aggregate.MerchantAggregates
{
    public class Address : AggregateRoot<int>
    { 

        public string Street { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string Region { get; private set; } = default!;
        public string Country { get; private set; } = default!;
        public string PostalCode { get; private set; } = default!;

        public static Address Create(string street, string city, string region, string postalCode, string country)
        {
            var address = new Address
            {
                Street = street,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country
            };

            address.AddressValidate();

            return address;
        }

        private void AddressValidate()
        {
            if (string.IsNullOrWhiteSpace(Street))
                ThrowDomainException("Street is required.");

            if (string.IsNullOrWhiteSpace(City))
                ThrowDomainException("City is required.");

            if (string.IsNullOrWhiteSpace(Country))
                ThrowDomainException("Country is required.");
             
        }

        private void ThrowDomainException(string message)
        {
            throw new InvalidOperationException(message);  
        }
    }

}
