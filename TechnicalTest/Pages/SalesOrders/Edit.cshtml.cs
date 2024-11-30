using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Data;
using TechnicalTest.Model;

namespace TechnicalTest.Pages.SalesOrders
{
    public class EditModel : PageModel
    {
        private readonly TechnicalTest.Data.TechnicalTestContext _context;

        public EditModel(TechnicalTest.Data.TechnicalTestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesOrder SalesOrder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalesOrder == null)
            {
                return NotFound();
            }

            var salesorder = await _context.SalesOrder.FirstOrDefaultAsync(m => m.Id == id);

            if (salesorder == null)
            {
                return NotFound();
            }
            else
            {
                SalesOrder = salesorder;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SalesOrder == null)
            {
                return NotFound();
            }
            var salesorder = await _context.SalesOrder.FindAsync(id);

            if (salesorder == null)
            {
                return NotFound();             }

            salesorder.CustomerName = SalesOrder.CustomerName;
            salesorder.OrderDate = SalesOrder.OrderDate;
            salesorder.TotalAmount = SalesOrder.TotalAmount;
            _context.SalesOrder.Update(salesorder);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
