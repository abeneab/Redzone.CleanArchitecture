using Redzone.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redzone.API.Models
{
    public abstract class BaseModel 
    {
        public BaseModel()
        {
        }
        public Guid? Id { get; set; }
        public bool? IsActive { get; set; }
        public Guid? CreatedbyUserGuid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? LastUpdateByUserGuid { get; set; }
        public DateTime? UpdateDate { get; set; }
        public abstract T MapToEntity<T>() where T: class;
    }
}
