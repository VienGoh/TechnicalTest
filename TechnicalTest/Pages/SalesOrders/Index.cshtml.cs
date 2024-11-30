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
    public class IndexModel : PageModel
    {
        private readonly TechnicalTest.Data.TechnicalTestContext _context;

        public IndexModel(TechnicalTest.Data.TechnicalTestContext context)
        {
            _context = context;
        }

        public IList<SalesOrder> SalesOrder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SalesOrder != null)
            {
                SalesOrder = await _context.SalesOrder.ToListAsync();
            }
        }
    }
}
