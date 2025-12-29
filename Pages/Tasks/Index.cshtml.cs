using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskForge.Data;
using TaskForge.Models;

namespace TaskForge.Pages.Tasks;

[Authorize]
public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<TaskItem> Tasks { get; set; } = [];

    public async Task OnGetAsync()
    {
        var userId = User.Identity.Name!;
        Tasks = await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
    }
}
