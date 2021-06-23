using Redzone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redzone.API.Models
{
    public class OrderPostModel : BaseModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Payment
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }
        public override T MapToEntity<T>()
        {
            OrderEntity order = new OrderEntity();
            order.Guid = this.Id ?? Guid.Empty;
            order.IsActive = this.IsActive;
            order.CreatedbyUserGuid = this.CreatedbyUserGuid ?? Guid.Empty;
            order.CreatedDate = this.CreatedDate ?? DateTime.Now;
            order.LastModifiedByUserGuid = this.LastUpdateByUserGuid;
            order.LastModifiedDate = this.UpdateDate;
            order.UserName = this.UserName;
            order.TotalPrice = this.TotalPrice;
            order.FirstName = this.FirstName;
            order.LastName = this.LastName;
            order.EmailAddress = this.EmailAddress;
            order.AddressLine = this.AddressLine;
            order.Country = this.Country;
            order.State = this.State;
            order.ZipCode = this.ZipCode;
            order.CardName = this.CardName;
            order.CardNumber = this.CardNumber;
            order.Expiration = this.Expiration;
            order.CVV = this.CVV;
            order.PaymentMethod = this.PaymentMethod;
            return order as T;
        }

       
    }
}
