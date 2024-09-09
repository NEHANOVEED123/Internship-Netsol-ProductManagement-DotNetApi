namespace Internship_Netsol_ProductManagement_DotNetApi.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = double.MinValue;
    }
}
