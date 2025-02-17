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
    public class IndexModel : PageModel
    {
        private readonly TodoContext _context;

        public IndexModel(TodoContext context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TodoItem = await _context.TodoItems.ToListAsync();
        }
    }
}
