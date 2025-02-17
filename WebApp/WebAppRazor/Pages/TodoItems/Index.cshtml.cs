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
    public class IndexModel : PageModel
    {
        private readonly Service _service;

        public IndexModel(Service service)
        {
            _service = service;
        }

        public IList<TodoItem> TodoItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TodoItem = await _service.GetTodos();
        }
    }
}
