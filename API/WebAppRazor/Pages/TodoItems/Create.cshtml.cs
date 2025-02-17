using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppRazor.Pages.TodoItems
{
    public class CreateModel : PageModel
    {
        private readonly TodoContext _context;

        public CreateModel(TodoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TodoItem TodoItem { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TodoItems.Add(TodoItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
