using Gallery_Bafte_Soorati.Domain.Entities.Common;
using System.Collections.Generic;

namespace Gallery_Bafte_Soorati.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public double DisCount { get; set; }
        public double Price { get; set; }
        public double FinalPrice { get; set; }
        public int ViewCount { get; set; }
        public long Point { get; set; }
        public string Description { get; set; }
        public bool Displayed { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryLinkId { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }
        public virtual ICollection<ProductComments> ProductComments { get; set; }
    }
}

