namespace Internship_Netsol_ProductManagement_DotNetApi.FilterQuery
{
    public class ProductQueryObject
    {
     
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
        public double? Price { get; set; } = null;

        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}
