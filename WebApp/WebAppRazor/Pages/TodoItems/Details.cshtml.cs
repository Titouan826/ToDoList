using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApiTest.Entity;

// CHANGE WebAppRazor.Entity TO ApiTest.Entity w CTR + H

namespace WebAppRazor.Pages.TodoItems
{
    public class DetailsModel : PageModel
    {
        private readonly Service _service;

        public DetailsModel(Service service)
        {
            _service = service;
        }

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
    }
}
