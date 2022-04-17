using Account.Models.Domain.Common;

namespace Account.Models.Domain.Entities
{

    public class Customer : AuditableEntity
    {
        public Guid ID { get; set; }
        public string CustomerNumber { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
