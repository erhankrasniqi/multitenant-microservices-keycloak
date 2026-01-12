using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Aggregate.MerchantAggregates
{
    public class Merchant : AggregateRoot<int>
    { 

        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;

        public Guid AddressId { get; private set; }
        public Guid StatusId { get; private set; }

        public string CreatedBy { get; private set; } = default!; // KeycloakId
        public bool OnboardingCompleted { get; private set; }  

       

        public static Merchant Create(string name, string email, string phoneNumber, 
                        string createdBy, bool onboardingCompleted)
        {
            var user = new Merchant
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                CreatedBy = createdBy,
                OnboardingCompleted = onboardingCompleted,
                
            };

            user.MerchantValidate();

            return user;
        } 

        private void MerchantValidate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                ThrowDomainException("Name is required.");

            if (string.IsNullOrWhiteSpace(Email))
                ThrowDomainException("Email is required.");

            if (string.IsNullOrWhiteSpace(PhoneNumber))
                ThrowDomainException("Phone number is required.");

            if (AddressId == Guid.Empty)
                ThrowDomainException("AddressId is required.");

            if (Status == null)
                ThrowDomainException("Status is required.");

            if (StatusId == Guid.Empty)
                ThrowDomainException("StatusId is required.");

            if (string.IsNullOrWhiteSpace(CreatedBy))
                ThrowDomainException("CreatedBy (KeycloakId) is required.");
        }

        private void ThrowDomainException(string message)
        {
            throw new InvalidOperationException(message);
        } 
    }


}
