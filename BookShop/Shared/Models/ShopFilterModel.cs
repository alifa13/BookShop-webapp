namespace BookShop.Shared.Models
{
    public class ShopFilterModel
    {
        public double FromPrice { get; set; }
        public double ToPrice { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> PublisherId { get; set; }

    }
}
