using Internship_Netsol_ProductManagement_DotNetApi.Enums;

namespace Internship_Netsol_ProductManagement_DotNetApi.Models
{
    public class CustomizeOrder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int FrontendPages { get;set; }
        public PaymentStatusType PaymentStatus { get; set; }
        public PaymentMethodType PaymentType { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Note { get; set; }
    }
}
