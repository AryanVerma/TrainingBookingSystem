using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Domain.Entities.Base;

namespace Training.Domain.Entities
{
    /// <summary>
    /// Training
    /// </summary>
    public class Training : AuditEntity
    {
        [Column("Title")]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(50)]
        [Column("Description")]
        public string? Description { get; set; }

        [Column("StartDateTime")]
        public DateTime StartDateTime { get; set; }

        [Column("EndDateTime")]
        public DateTime EndDateTime { get; set; }

        [MaxLength(250)]
        [Column("Location")]
        public int Location { get; set; }

        public bool Status { get; set; }

        public int MaxAttend { get; set; }

        public int CourseId { get; set; }

        public int RegionId { get; set; }

        public bool IsExpired { get; set; }


    }
}
