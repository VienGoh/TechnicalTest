using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechnicalTest.Model;
using TechnicalTest.Data;

namespace TechnicalTest.Pages.SalesOrders
{
    public class CreateModel : PageModel
    {
        private readonly TechnicalTestContext _context;

        public CreateModel(TechnicalTestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesOrder SalesOrder { get; set; } = new SalesOrder();

        public int ExistingSalesOrdersCount { get; set; }

        public void OnGet()
        {
            ExistingSalesOrdersCount = _context.SalesOrder.Count();
            GenerateSalesOrderNo();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.SalesOrder == null || SalesOrder == null)
            {
                return Page();
            }

            ExistingSalesOrdersCount = _context.SalesOrder.Count();
            GenerateSalesOrderNo();
            _context.SalesOrder.Add(SalesOrder);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private void GenerateSalesOrderNo()
        {
            if (SalesOrder == null) return;

            var date = DateTime.Now;
            string day = date.Day.ToString("D2");  
            string month = date.Month.ToString("D2");  
            string year = date.Year.ToString().Substring(2, 2);  
            string number = (ExistingSalesOrdersCount + 1).ToString("D3");  

            SalesOrder.SalesOrderNo = $"SO-{day}{month}{year}{number}";
            SalesOrder.OrderDate = date;
        }
    }
}