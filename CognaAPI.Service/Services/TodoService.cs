using CognaAPI.Domain.Entidades;
using CognaAPI.Infra.Repository.Interfaces;
using CognaAPI.Service.Interfaces;
using CognaAPI.Service.ViewModels.Todo;

namespace CognaAPI.Service.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<List<Todo>> BuscaTodosAsync(CancellationToken cancellationToken)
        {
            var todos = await _todoRepository.BuscaTodosAsync(cancellationToken);
            return todos;
        }

        public async Task<Todo> BuscaPorTodoIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.BuscaPorIdAsync(id, cancellationToken);
            return todo;
        }

        public async Task<Todo> CadastrarTodoAsync(CreateTodoViewModel viewModel, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(viewModel.Descricao) && !string.IsNullOrEmpty(viewModel.DataLembrete))
            {
                if (DateTime.TryParse(viewModel.DataLembrete, out var date))
                {
                    var todo = new Todo(viewModel.Descricao, DateTime.Parse(viewModel.DataLembrete));
                    return await _todoRepository.CadastrarTodoAsync(todo, cancellationToken);
                }
                else
                {
                    throw new Exception("Não foi possível cadastrar a data de lembrete informada, verifique e tente novamente.");
                }

            }
            else
            {
                throw new Exception("Não foi possível cadastrar a atividade a ser feita verifique os dados informados e tente novamente.");
            }
        }

        public async Task<Todo> AtualizarTodoAsync(UpdateTodoViewModel viewModel, CancellationToken cancellationToken)
        {
            if (viewModel.Id != Guid.Empty)
            {
                var todo = await BuscaPorTodoIdAsync(viewModel.Id, cancellationToken);
                if (!string.IsNullOrEmpty(viewModel.Descricao))
                {
                    todo.Descricao = viewModel.Descricao;
                }
                if (!string.IsNullOrEmpty(viewModel.DataLembrete))
                {
                    if (DateTime.TryParse(viewModel.DataLembrete, out var date))
                    {
                        todo.DataLembrete = DateTime.Parse(viewModel.DataLembrete);
                    }
                    else
                    {
                        throw new Exception("Não é possível atualizar para a data de lembrete informada, verifique e tente novamente");
                    }
                }
                if (viewModel.Concluido != null)
                {
                    todo.Concluido = (bool)viewModel.Concluido;
                }
                return await _todoRepository.AtualizarTodoAsync(todo, cancellationToken);
            }
            else
            {
                throw new Exception("Não é possível atualizar uma atividade a fazer sem ID");
            }
        }

        public async Task DeletarTodoAsync(Guid idTodo, CancellationToken cancellationToken)
        {
            await _todoRepository.DeletarTodoAsync(idTodo, cancellationToken);
        }
    }
}
