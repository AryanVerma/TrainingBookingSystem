namespace Training.Domain.Entities.Base
{
    public abstract class DeleteEntity : BaseEntity, IDeleteEntity
    {
        public bool IsDeleted { get; set; }
    }
}

