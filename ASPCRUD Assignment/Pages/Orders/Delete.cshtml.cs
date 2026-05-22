using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public order Order { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await _context.orders.FirstOrDefaultAsync(m => m.Id == id);

        if (order == null)
        {
            return NotFound();
        }
        else
        {
            Order = order;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await _context.orders.FindAsync(id);
        if (order != null)
        {
            Order = order;
            _context.orders.Remove(Order);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Product");
    }
}