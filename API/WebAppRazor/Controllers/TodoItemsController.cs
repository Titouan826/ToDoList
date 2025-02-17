
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest.Manager;
using ApiTest.Entity;

namespace WebAppRazor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly TodoManager _manager;

    public TodoItemsController(TodoManager manager)
    {
        _manager = manager;
    }


    // GET: api/TodoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
    {
        var todoItems = _manager.GetTodoItems();

        return Ok(todoItems);
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
    {
        var todoItem = await _manager.GetTodoItem(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return Ok(todoItem);
    }
    // </snippet_GetByID>

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id}")]
    public async Task<ActionResult> PutTodoItem(long id, TodoItem todo)
    {
        var todoItem = await _manager.PutTodoItem(id, todo);
        if (todoItem == null) return NotFound();

        return Ok(todoItem);
    }
    // </snippet_Update>

    // POST: api/TodoItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost]
    public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todo)
    {
       

        var todoItem = await _manager.PostTodoItem(todo);

        return CreatedAtAction(
            nameof(GetTodoItem),
            new { id = todoItem.Id },
            todoItem);
    }
    // </snippet_Create>

    // DELETE: api/TodoItems/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTodoItem(long id)
    {
        var result = await _manager.DeleteTodoItem(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}