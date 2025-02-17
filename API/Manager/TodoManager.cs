using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApiTest.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Manager;
public class TodoManager
{
    private readonly TodoContext _context;

    public TodoManager(TodoContext context)
    {
        _context = context;
    }

    //// GET: api/TodoItems
    //public async Task<IEnumerable<TodoItem>> GetTodoItems()
    //{
    //    await _context.TodoItems.ForEachAsync(item =>
    //    {
    //        items.Add(item);
    //    });


    //}

    public IEnumerable<TodoItem> GetTodoItems()
    {
        return _context.TodoItems.AsEnumerable();
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    public async Task<TodoItem?> GetTodoItem(long id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        return todoItem;
    }
    // </snippet_GetByID>

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    public async Task<TodoItem?> PutTodoItem(long id, TodoItem todo)
    {
        if (todo == null)
            throw new ArgumentNullException("todo");

        if (todo.Id == 0)
            // création
            _context.TodoItems.Add(todo);
        else
        {
            // Mise à jour
            //_context.TodoItems.Attach(todo);


            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return null;
            }

            todoItem.Name = todo.Name;
            todoItem.IsComplete = todo.IsComplete;
            todoItem.Secret = todo.Secret;
        }

            try
            {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
        {
            return null;
        }

        return todo;
    }
    // </snippet_Update>

    // POST: api/TodoItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    public async Task<TodoItem> PostTodoItem(TodoItem todo)
    {
        //var todoItem = new TodoItem
        //{
        //    IsComplete = todo.IsComplete,
        //    Name = todo.Name
        //};
        _context.TodoItems.Add(todo);
        //_context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return todo;
    }
    // </snippet_Create>

    // DELETE: api/TodoItems/5
    public async Task<bool> DeleteTodoItem(long id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return false;
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return true;
    }

    private bool TodoItemExists(long id)
    {
        return _context.TodoItems.Any(e => e.Id == id);
    }
}