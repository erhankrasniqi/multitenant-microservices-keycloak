using SharedKernel;

namespace UserManagement.Domain.Aggregates.UsersAggregates
{
    public class Users : AggregateRoot<int>
    {
        public Guid KeycloakId { get; set; }
        public string TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<UserRole> UserRoles { get; set; }

        public static Users Create(Guid? keycloakId, string firstName, string lastName, string postalCode, string street, string city, string region, string country)
        {
            var user = new Users
            {
                KeycloakId = keycloakId ?? Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
            };

            var address = new Address
            {
                Street = street,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                User = user
            };

            user.Addresses.Add(address);

            user.ValidateUser();

            return user;
        }

        public void ChangePersonalInfo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            ValidateUser();
        }

        public void ToggleUserActive(ref bool isActive)
        {
            isActive = !isActive;

            ValidateUser();
        }

        private void ValidateUser()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
                ThrowDomainException("First name and last name are required.");

            if (Addresses == null || !Addresses.Any())
                ThrowDomainException("At least one address is required.");

            var primaryAddress = Addresses.First();

            if (string.IsNullOrWhiteSpace(primaryAddress.PostalCode))
                ThrowDomainException("Postal code is required. Order cannot be submitted without postal code.");

            if (string.IsNullOrWhiteSpace(primaryAddress.Street))
                ThrowDomainException("Street is required. Order cannot be submitted without address.");
        }
    }
}
