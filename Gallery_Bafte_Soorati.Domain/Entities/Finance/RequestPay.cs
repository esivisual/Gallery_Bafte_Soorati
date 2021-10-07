using Gallery_Bafte_Soorati.Domain.Entities.Common;
using Gallery_Bafte_Soorati.Domain.Entities.Orders;
using Gallery_Bafte_Soorati.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Domain.Entities.Finance
{
    public class RequestPay : BaseEntity
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        

        public long Amount { get; set; }
        public bool? IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;


    }
}
