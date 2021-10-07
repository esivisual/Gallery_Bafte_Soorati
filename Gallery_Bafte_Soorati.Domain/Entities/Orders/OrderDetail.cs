using Gallery_Bafte_Soorati.Domain.Entities.Common;
using Gallery_Bafte_Soorati.Domain.Entities.Products;
using System;

namespace Gallery_Bafte_Soorati.Domain.Entities.Orders
{
    public class OrderDetail : BaseEntity
    {
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
        public int Count { get; set; }
    }
}
