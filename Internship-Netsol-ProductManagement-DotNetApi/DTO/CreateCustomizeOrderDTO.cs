using Internship_Netsol_ProductManagement_DotNetApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace Internship_Netsol_ProductManagement_DotNetApi.DTO
{
    public class CreateCustomizeOrderDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Minimum length for title is 5 characters.")]
        [MaxLength(50, ErrorMessage = "Maximum length for title is 50 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Minimum length for description is 5 characters.")]
        [MaxLength(300, ErrorMessage = "Maximum length for description is 300 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(1, 100)]
        public int FrontendPages { get; set; } = 1;

        [Required]
        public PaymentStatusType PaymentStatus { get; set; } = PaymentStatusType.Pending;

        [Required]
        public PaymentMethodType PaymentType { get; set; } = PaymentMethodType.CashOnDelivery;

        [Required]
        public DateTime? OrderDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime? DeliveryDate { get; set; } = DateTime.Now;

        [Required]
        [MinLength(5, ErrorMessage = "Minimum length for note is 5 characters.")]
        [MaxLength(300, ErrorMessage = "Maximum length for note is 300 characters.")]
        public string Note { get; set; } = string.Empty;
    }
}
