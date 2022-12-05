using Core.Entities;

namespace Web.ViewModels.Shop
{
    public class ShopIndexVM
    {
        public List<Product> Products { get; set; }
        public List<ProductCategory> Categories { get; set; }
    }
}
