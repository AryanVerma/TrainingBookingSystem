namespace Training.Domain.Entities.Base
{
    public interface IAuditEntity
    {
        DateTime CreateDateTime { get; set; }

        DateTime? ModifyDateTime { get; set; }
        int CreatedBy { get; set; }
        int? ModifyBy { get; set; }
    }


}

