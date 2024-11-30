using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Data;
using TechnicalTest.Model;

namespace TechnicalTest.Pages.SalesOrders
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalTest.Data.TechnicalTestContext _context;

        public DeleteModel(TechnicalTest.Data.TechnicalTestContext context)
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

            if (salesorder != null)
            {
                SalesOrder = salesorder;
                _context.SalesOrder.Remove(SalesOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
