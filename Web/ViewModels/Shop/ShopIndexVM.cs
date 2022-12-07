using Core.Entities;

namespace Web.ViewModels.Shop
{
    public class ShopIndexVM
    {
        public List<Product> Products { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public int Page { get; set; } = 1;
        public int Take { get; set; } = 5;
        public int PageCount { get; set; }
    }
}
