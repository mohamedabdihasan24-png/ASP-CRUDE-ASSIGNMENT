using Azure; 
using Microsoft.AspNetCore.Mvc.RazorPages; 
 
public class ProductModel(ApplicationDbContext context) : PageModel 
{ 
    // Connect to Database  
    private readonly ApplicationDbContext _context = context;

    public required List<order> Orders {get; set;} 
 
    public void OnGet() 
    { 
        Orders=_context.orders.ToList();


    }
}