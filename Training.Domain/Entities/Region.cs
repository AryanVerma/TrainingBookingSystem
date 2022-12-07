using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training.Domain.Entities.Base;

namespace Training.Domain.Entities
{
    public class Region : AuditEntity
    {
        [Column("RegionName")]
        [MaxLength(50)]
        public string RegionName { get; set; }
    }
}
