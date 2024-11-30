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
    public class DetailsModel : PageModel
    {
        private readonly TechnicalTest.Data.TechnicalTestContext _context;

        public DetailsModel(TechnicalTest.Data.TechnicalTestContext context)
        {
            _context = context;
        }

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
    }
}
