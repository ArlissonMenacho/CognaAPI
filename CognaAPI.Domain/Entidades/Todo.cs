namespace CognaAPI.Domain.Entidades
{
    public class Todo : BaseEntity
    {
        public Todo()
        {

        }
        public Todo(Guid id, string descricao, DateTime dataLembrete)
        {
            Id = id;
            Descricao = descricao;
            Criado = DateTime.Now;
            DataLembrete = dataLembrete;
            Concluido = false;
        }
        public Todo(string descricao, DateTime dataLembrete)
        {
            Descricao = descricao;
            DataLembrete = dataLembrete;
            Concluido = false;
        }
        public DateTime DataLembrete { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
    }
}
