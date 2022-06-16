using CognaAPI.Domain.Entidades;
using CognaAPI.Infra.Context;
using CognaAPI.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CognaAPI.Infra.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly CognaDbContext _dbContext;
        public TodoRepository(CognaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Todo>> BuscaTodosAsync(CancellationToken cancellationToken)
        {
            var todos = await _dbContext.Todos.ToListAsync(cancellationToken);
            return todos;
        }

        public async Task<Todo> BuscaPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var todo = await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (todo == null)
                throw new Exception("Nenhum atividade a fazer encontrada com o ID informado!");

            return todo;
        }

        public async Task<Todo> CadastrarTodoAsync(Todo todo, CancellationToken cancellationToken)
        {

            await _dbContext.AddAsync(todo, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return todo;
        }

        public async Task<Todo> AtualizarTodoAsync(Todo todo, CancellationToken cancellationToken)
        {
            _dbContext.Todos.Update(todo);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return todo;
        }

        public async Task DeletarTodoAsync(Guid idTodo, CancellationToken cancellationToken)
        {
            var todo = await BuscaPorIdAsync(idTodo, cancellationToken);
            _dbContext.Todos.Remove(todo);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
