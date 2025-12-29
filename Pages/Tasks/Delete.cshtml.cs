using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskForge.Data;
using TaskForge.Models;

namespace TaskForge.Pages.Tasks;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TaskItem TaskItem { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var userId = User.Identity.Name!;
        TaskItem = await _context.Tasks.Where(t => t.Id == id && t.UserId == userId).FirstOrDefaultAsync();

        if (TaskItem == null || TaskItem.UserId != User.Identity!.Name)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var userId = User.Identity!.Name!;
        var task = await _context
            .Tasks.Where(t => t.Id == id && t.UserId == userId)
            .FirstOrDefaultAsync();

        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("Index");
    }
}
