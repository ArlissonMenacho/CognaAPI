using CognaAPI.Service.Interfaces;
using CognaAPI.Service.ViewModels.Todo;
using Microsoft.AspNetCore.Mvc;

namespace CognaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost("CadastrarTodo")]
        public async Task<IActionResult> CadastrarTodo(CreateTodoViewModel viewModel, CancellationToken cancellationToken)
        {
            var todo =await _todoService.CadastrarTodoAsync(viewModel, cancellationToken);
            return Ok(todo);
        }

        [HttpPut("AtualizarTodo")]
        public async Task<IActionResult> AtualizarTodo(UpdateTodoViewModel viewModel, CancellationToken cancellationToken)
        {
            await _todoService.AtualizarTodoAsync(viewModel, cancellationToken);
            return Ok("Atualizado com sucesso!");
        }

        [HttpDelete("DeletarTodo/{Id}")]
        public async Task<IActionResult> DeletarTodo(Guid Id, CancellationToken cancellationToken)
        {
            await _todoService.DeletarTodoAsync(Id, cancellationToken);
            return Ok("Deletado com sucesso!");
        }

        [HttpGet("BuscaTodoPorId/{Id}")]
        public async Task<IActionResult> BuscarTodoPorId(Guid Id, CancellationToken cancellationToken)
        {
            var todo = await _todoService.BuscaPorTodoIdAsync(Id, cancellationToken);
            if (todo == null)
                return NotFound("Nenhum registro encontrado");
            else
                return Ok(todo);

        }

        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
        {
            var todos = await _todoService.BuscaTodosAsync(cancellationToken);
            if (todos is null || todos.Count == 0)
                return NotFound("Nenhum registro gravado!");
            else
                return Ok(todos);
        }

    }
}
