using Gallery_Bafte_Soorati.Domain.Entities.Carts;
using Gallery_Bafte_Soorati.Domain.Entities.Common;
using Gallery_Bafte_Soorati.Domain.Entities.Orders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gallery_Bafte_Soorati.Domain.Entities.Users
{
    public  class User : BaseEntity
    {
        [MaxLength(20)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage ="لطفا کد ملی را وارد نمایید")]
        [MaxLength(10)]
        [MinLength(10)]
        public string NationalCode { get; set; }
        
        [Required(ErrorMessage = "لطفا ایمیل را وارد نمایید")]
        [MaxLength(50)]
        [MinLength(10)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "لطفا رمز ورود را وارد نمایید")]
        [MaxLength(20)]
        [MinLength(3)]
        [StringLength(100)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "لطفا شماره همراه را وارد نمایید")]
        [MaxLength(11)]
        [MinLength(11)]
        public string Mobile { get; set; }
        
        [MaxLength(150)]
        public string Address { get; set; }
        
        [MaxLength(11)]
        public string PostalCode { get; set; }
        
        public virtual List<UserInRole> UserInRoles { get; set; }
        public virtual ICollection<Order>  Orders   { get; set; }
        public bool IsActive { get; set; }
    }
}
