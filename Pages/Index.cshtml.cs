using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskForge.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Name { get; set; } = "";
    public string Greeting { get; set; } = "";

    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        Greeting = $"Hello, {Name}!";
    }
}
