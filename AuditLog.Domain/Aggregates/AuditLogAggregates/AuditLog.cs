

using SharedKernel;

namespace AuditLog.Domain.Aggregates.AuditLogAggregates
{
    public class AuditLog : AggregateRoot<int>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; } = null!;  

        public string ServiceName { get; set; } = null!;  

        public string Action { get; set; } = null!;  

        public string EntityName { get; set; } = null!;  

        public string EntityId { get; set; } = null!;  

        public string? Metadata { get; set; }  

        public string? CorrelationId { get; set; }  
    }
}
