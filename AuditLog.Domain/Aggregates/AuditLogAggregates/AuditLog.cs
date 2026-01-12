

using SharedKernel;

namespace AuditLog.Domain.Aggregates.AuditLogAggregates
{
    public class AuditLog : AggregateRoot<int>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; } = null!; // ID e përdoruesit që bëri veprimin

        public string ServiceName { get; set; } = null!; // Emri i mikroshërbimit

        public string Action { get; set; } = null!; // Përshkrimi i veprimit (p.sh., "Login", "CreatePayment")

        public string EntityName { get; set; } = null!; // Entiteti i prekur (p.sh., "User", "Payment")

        public string EntityId { get; set; } = null!; // ID e entitetit të prekur

        public string? Metadata { get; set; } // Informacion shtesë në JSON, p.sh. IP, device info, ndryshimet etj.

        public string? CorrelationId { get; set; } // ID për ndjekje të kërkesës/transaction-it (opsionale)
    }
}
