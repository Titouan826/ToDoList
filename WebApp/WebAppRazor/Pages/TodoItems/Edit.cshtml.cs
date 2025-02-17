using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiTest.Entity;

namespace WebAppRazor.Pages.TodoItems
{
    public class EditModel : PageModel
    {
        private readonly Service _service;

        public EditModel(Service service)
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

            var todoitem =  await _service.GetTodo(id);
            if (todoitem == null)
            {
                return NotFound();
            }
            TodoItem = todoitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

          await _service.PutTodo(TodoItem.Id, TodoItem); 

            return RedirectToPage("./Index");
        }

    }
}
