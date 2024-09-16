using Internship_Netsol_ProductManagement_DotNetApi.Enums;

namespace Internship_Netsol_ProductManagement_DotNetApi.FilterQuery
{
    public class CustomizeOrderQueryObject
    {
    
        public string? Title { get; set; }=null;
        public string? Description { get; set; }=string.Empty;
        public decimal? Price { get; set; }=decimal.Zero;
        public int? FrontendPages { get; set; }=int.MinValue;
        public PaymentStatusType PaymentStatus { get; set; }
        public PaymentMethodType PaymentType { get; set; }
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public DateTime? DeliveryDate { get; set; }=DateTime.Now;
        public string? Note { get; set; }=null ;

        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}
