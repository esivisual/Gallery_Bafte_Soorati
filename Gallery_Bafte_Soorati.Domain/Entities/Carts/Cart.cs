using Gallery_Bafte_Soorati.Domain.Entities.Common;
using Gallery_Bafte_Soorati.Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace Gallery_Bafte_Soorati.Domain.Entities.Carts
{
    public class Cart : BaseEntity
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public Guid BrowserId { get; set; }
        public bool Finished { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
