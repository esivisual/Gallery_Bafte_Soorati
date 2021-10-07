using Gallery_Bafte_Soorati.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Gallery_Bafte_Soorati.Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public Guid? ParentCategoryId { get; set; }

        public virtual ICollection<Category> SubCategory { get; set; }

    }
}

