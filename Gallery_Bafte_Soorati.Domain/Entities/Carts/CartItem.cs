using Gallery_Bafte_Soorati.Domain.Entities.Common;
using Gallery_Bafte_Soorati.Domain.Entities.Products;
using System;

namespace Gallery_Bafte_Soorati.Domain.Entities.Carts
{
    public class CartItem : BaseEntity
    {
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public virtual Cart Cart { get; set; }
        public Guid CartId { get; set; }
    }
}
