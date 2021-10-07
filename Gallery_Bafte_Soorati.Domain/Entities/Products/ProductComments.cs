using Gallery_Bafte_Soorati.Domain.Entities.Common;
using Gallery_Bafte_Soorati.Domain.Entities.Users;
using System;

namespace Gallery_Bafte_Soorati.Domain.Entities.Products
{
    public class ProductComments : BaseEntity
    {
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public string Comments { get; set; }
        public bool Displayed { get; set; }
        public virtual User User { get; set; }
        public Guid UsertId { get; set; }
    }
}

