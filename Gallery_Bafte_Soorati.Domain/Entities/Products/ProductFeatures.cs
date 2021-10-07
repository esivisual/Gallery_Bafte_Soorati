using Gallery_Bafte_Soorati.Domain.Entities.Common;
using System;

namespace Gallery_Bafte_Soorati.Domain.Entities.Products
{
    public class ProductFeatures : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }

    }
}

