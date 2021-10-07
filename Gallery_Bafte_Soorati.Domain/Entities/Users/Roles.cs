using Gallery_Bafte_Soorati.Domain.Entities.Common;
using System.Collections.Generic;

namespace Gallery_Bafte_Soorati.Domain.Entities.Users
{
    public class Roles  
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserInRole> UserInRole { get; set; }
        public bool IsRemoved { get; set; }

    }
}
