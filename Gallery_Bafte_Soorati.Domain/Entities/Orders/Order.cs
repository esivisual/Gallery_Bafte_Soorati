using Gallery_Bafte_Soorati.Domain.Entities.Common;
using Gallery_Bafte_Soorati.Domain.Entities.Finance;
using Gallery_Bafte_Soorati.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual RequestPay  RequestPay { get; set; }
        public Guid RequsetPayId { get; set; }
        public OrderState OrderState { get; set; }
        public string Address { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
    public enum OrderState
    {
        [Display(Name ="در حال پردازش")]
        Processing = 0,
        [Display(Name ="لغوشده")]
        Canceled = 1,
        [Display(Name ="تحویل شده")]
        Deliverd =2,
    }
}
