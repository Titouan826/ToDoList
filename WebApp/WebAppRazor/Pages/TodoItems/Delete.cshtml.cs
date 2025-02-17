using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApiTest.Entity;

namespace WebAppRazor.Pages.TodoItems
{
    public class DeleteModel : PageModel
    {
        private readonly Service _service;

        public DeleteModel(Service service)
        {
            _service = service;
        }

        [BindProperty]
        public TodoItem TodoItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoitem = await _service.GetTodo(id);

            if (todoitem == null)
            {
                return NotFound();
            }
            else
            {
                TodoItem = todoitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoitem = await _service.GetTodo(id);
            if (todoitem != null)
            {
                TodoItem = todoitem;
                _service.DeleteItemAsync(TodoItem.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
