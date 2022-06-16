namespace CognaAPI.Service.ViewModels.Todo
{
    public class UpdateTodoViewModel
    {
        public UpdateTodoViewModel()
        {

        }
        public UpdateTodoViewModel(Guid id, string descricao, string dataLembrete, bool concluido)
        {
            Id = id;
            Descricao = descricao;
            DataLembrete = dataLembrete;
            Concluido = concluido;
        }
        public Guid Id { get; set; }
        public string DataLembrete { get; set; }
        public string Descricao { get; set; }
        public bool? Concluido { get; set; }
    }
}
