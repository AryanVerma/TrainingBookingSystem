using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training.Domain.Entities.Base;

namespace Training.Domain.Entities
{
    public class Course : AuditEntity
    {
        [Column("Title")]
        [MaxLength(50)]
        public string Title { get; set; }

        public int MaxUsers { get; set; }

        public bool IsActive { get; set; }


    }
}
