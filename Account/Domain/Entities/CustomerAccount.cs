using Account.Models.Domain.Common;

namespace Account.Models.Domain.Entities
{
    public class CustomerAccount : AuditableEntity
    {
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }
        public int AccountNumber { get; set; }
    }
}
