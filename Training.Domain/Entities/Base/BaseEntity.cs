using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Domain.Entities.Base
{
    public abstract class BaseEntity : IEntityBase
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

    }
    public abstract class AuditEntity : DeleteEntity, IAuditEntity
    {
        public DateTime CreateDateTime { get; set; }
        public DateTime? ModifyDateTime { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifyBy { get; set; }
    }
}

