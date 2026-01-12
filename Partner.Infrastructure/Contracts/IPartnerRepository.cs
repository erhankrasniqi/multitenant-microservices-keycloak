 
using Partner.Domain.Aggregates.PartnerAggregates;

namespace Partner.Infrastructure.Contracts
{
    public interface IPartnerRepository : IRepository<Domain.Aggregates.PartnerAggregates.Partner, int>
    {
        Task<IEnumerable<Domain.Aggregates.PartnerAggregates.Partner>> GetPartners(CancellationToken cancellationToken);
    }
}
