using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskForge.Data;
using TaskForge.Models;

namespace TaskForge.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TasksApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
    {
        var userId = User.Identity!.Name!;
        return await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTask(int id)
    {
        var userId = User.Identity!.Name!;
        var task = await _context
            .Tasks.Where(t => t.Id == id && t.UserId == userId)
            .FirstOrDefaultAsync();

        if (task == null)
            return NotFound();

        return task;
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> PostTask(TaskItem task)
    {
        task.UserId = User.Identity!.Name!;
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTask(int id, TaskItem task)
    {
        if (id != task.Id)
            return BadRequest();

        var userId = User.Identity!.Name!;
        var existing = await _context
            .Tasks.Where(t => t.Id == id && t.UserId == userId)
            .FirstOrDefaultAsync();

        if (existing == null)
            return NotFound();

        existing.Title = task.Title;
        existing.IsCompleted = task.IsCompleted;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var userId = User.Identity!.Name!;
        var task = await _context
            .Tasks.Where(t => t.Id == id && t.UserId == userId)
            .FirstOrDefaultAsync();

        if (task == null)
            return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
