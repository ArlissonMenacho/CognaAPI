using CognaAPI.Domain.Entidades;
using CognaAPI.Service.ViewModels.Todo;

namespace CognaAPI.Service.Interfaces
{
    public interface ITodoService
    {
        Task<List<Todo>> BuscaTodosAsync(CancellationToken cancellationToken);
        Task<Todo> BuscaPorTodoIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Todo> CadastrarTodoAsync(CreateTodoViewModel viewModel, CancellationToken cancellationToken);
        Task<Todo> AtualizarTodoAsync(UpdateTodoViewModel viewModel, CancellationToken cancellationToken);
        Task DeletarTodoAsync(Guid idTodo, CancellationToken cancellationToken);
    }
}
