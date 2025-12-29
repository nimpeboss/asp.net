using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskForge.Data;
using TaskForge.Models;

namespace TaskForge.Pages.Tasks;

[Authorize]
public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TaskItem TaskItem { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null || task.UserId != User.Identity!.Name)
            return NotFound();

        TaskItem = task;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Attach(TaskItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
