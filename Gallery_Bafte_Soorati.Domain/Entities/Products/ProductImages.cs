using Gallery_Bafte_Soorati.Domain.Entities.Common;
using System;

namespace Gallery_Bafte_Soorati.Domain.Entities.Products
{
    public class ProductImages: BaseEntity 
    {
        public string ImagesAddress { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }

    }
}

