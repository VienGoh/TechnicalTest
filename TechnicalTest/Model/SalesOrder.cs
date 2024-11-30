using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTest.Model
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public string? SalesOrderNo { get; set; }
        public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class SalesOrderCreateModel
    {
        [NotMapped] 
        public SalesOrder? SalesOrder { get; set; }
        [NotMapped]
        public int ExistingSalesOrdersCount { get; set; }
    }

}
