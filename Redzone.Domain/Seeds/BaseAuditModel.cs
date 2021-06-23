using System;
using System.Collections.Generic;
using System.Text;

namespace Redzone.Domain.Seeds
{
    public abstract class BaseAuditModel
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }

    }
}
