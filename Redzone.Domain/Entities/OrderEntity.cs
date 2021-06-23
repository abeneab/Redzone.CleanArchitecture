using Redzone.Domain.Models;
using Redzone.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redzone.Domain.Entities
{
    public class OrderEntity : BaseEntity<Order>
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
        public OrderEntity()
        {

        }
        public OrderEntity(Order order)
        {
            this.Guid = order.Id;
            this.IsActive = order.IsActive;
            this.CreatedbyUserGuid = order.CreatedBy;
            this.CreatedDate = order.CreatedDate;
            this.LastModifiedByUserGuid = order.LastModifiedBy;
            this.LastModifiedDate = order.LastModifiedDate;
            this.UserName = order.UserName;
            this.TotalPrice = order.TotalPrice;
            this.FirstName = order.FirstName;
            this.LastName = order.LastName;
            this.EmailAddress = order.EmailAddress;
            this.AddressLine = order.AddressLine;
            this.Country = order.Country;
            this.State = order.State;
            this.ZipCode = order.ZipCode;
            this.CardName = order.CardName;
            this.CardName = order.CardNumber;
            this.Expiration = order.Expiration;
            this.CVV = order.CVV;
            this.PaymentMethod = order.PaymentMethod;
        }

        public override Order MapToModel()
        {
            Order order = new Order();
            order.Id = this.Guid;
            order.IsActive = this.IsActive;
            order.CreatedBy = this.CreatedbyUserGuid;
            order.CreatedDate = this.CreatedDate;
            order.LastModifiedBy = this.LastModifiedByUserGuid;
            order.LastModifiedDate = this.LastModifiedDate;
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
            return order;
        }

        public override Order MapToModel(Order t)
        {
            Order order = t;
            order.Id = this.Guid;
            order.IsActive = this.IsActive;
            order.CreatedBy = this.CreatedbyUserGuid;
            order.CreatedDate = this.CreatedDate;
            order.LastModifiedBy = this.LastModifiedByUserGuid;
            order.LastModifiedDate = this.LastModifiedDate;
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
            return order;
        }
    }
}
