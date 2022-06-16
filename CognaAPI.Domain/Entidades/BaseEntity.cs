namespace CognaAPI.Domain.Entidades
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime Criado { get; set; }

        public DateTime? UltimaModificacao { get; set; }
    }
}
