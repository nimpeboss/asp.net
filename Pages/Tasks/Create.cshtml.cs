using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskForge.Data;
using TaskForge.Models;

namespace TaskForge.Pages.Tasks;

[Authorize]
public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TaskItem TaskItem { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        TaskItem.UserId = User.Identity.Name!;
        _context.Tasks.Add(TaskItem);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
