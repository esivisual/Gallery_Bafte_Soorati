using Gallery_Bafte_Soorati.Domain.Entities.Common;
using System;

namespace Gallery_Bafte_Soorati.Domain.Entities.Users
{
    public class UserInRole : BaseEntity
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        public virtual Roles Roles { get; set; }
        public int RolesId { get; set; }
    }
}
