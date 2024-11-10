namespace BookShop.Shared.Models
{
	public class ShopCartItemModel
	{
        public int BookID { get; set; }
        public int Count { get; set; }
        public string BookTitle { get; set; }
        public decimal BookPrice { get; set; }
        public decimal BookTotalPrice => Count * BookPrice;
    }
}
