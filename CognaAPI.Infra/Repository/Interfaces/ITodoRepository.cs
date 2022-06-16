using CognaAPI.Domain.Entidades;

namespace CognaAPI.Infra.Repository.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> BuscaTodosAsync(CancellationToken cancellationToken);
        Task<Todo> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Todo> CadastrarTodoAsync(Todo todo, CancellationToken cancellationToken);
        Task<Todo> AtualizarTodoAsync(Todo todo, CancellationToken cancellationToken);
        Task DeletarTodoAsync(Guid idTodo, CancellationToken cancellationToken);
    }
}
