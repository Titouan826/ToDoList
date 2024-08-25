using ApiTest.Entity;
using ApiTest.Manager;
using ApiTest.ApiKey;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest.Filters;

namespace ApiTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly TodoManager _manager;
    private readonly IApiKeyValidation _apiKeyValidation;

    public TodoItemsController(TodoManager manager, IApiKeyValidation apiKeyValidation)
    {
        _manager = manager;
        _apiKeyValidation = apiKeyValidation;
    }

    //public /*IActionResult*/ bool AuthenticateViaHeader()
    //{
    //    string? apiKey = Request.Headers[Constants.ApiKeyHeaderName];
    //    if (string.IsNullOrWhiteSpace(apiKey))
    //        return false; /*BadRequest();*/
    //    bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);
    //    if (!isValid)
    //        return false;/*Unauthorized();*/
    //    return true;/*Ok();*/
    //}

    //// GET: api/TodoItems
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
    //{
    //    if (AuthenticateViaHeader())
    //    {
    //        var todoItems = _manager.GetTodoItems();

    //        return Ok(todoItems);
    //    }
    //    return Unauthorized();
    //}


    //[HttpGet("header")]
    //public IActionResult AuthenticateViaHeader()
    //{
    //    string? apiKey = Request.Headers[Constants.ApiKeyHeaderName];
    //    if (string.IsNullOrWhiteSpace(apiKey))
    //        return BadRequest();
    //    bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);
    //    if (!isValid)
    //        return Unauthorized();
    //    return Ok();
    //}

    // GET: api/TodoItems
    [HttpGet]
    [ApiKey]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
    {
        var todoItems = _manager.GetTodoItems();

        return Ok(todoItems);
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    [HttpGet("{id}")]
    [ApiKey]
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
    [ApiKey]
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
    [ApiKey]
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
    [ApiKey]
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