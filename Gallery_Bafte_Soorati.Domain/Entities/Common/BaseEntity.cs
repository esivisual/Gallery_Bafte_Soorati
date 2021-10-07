using System;
using System.ComponentModel.DataAnnotations;

namespace Gallery_Bafte_Soorati.Domain.Entities.Common
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemovedTime { get; set; }
    }
    public class BaseEntity : BaseEntity<Guid>
    {

    }
}
