namespace Unimar.ProjetoAcademico.Domain.Entities.Base
{
    public abstract class EntityBase<TId>
    { 
        public TId Id { get; set; }
    }
}
