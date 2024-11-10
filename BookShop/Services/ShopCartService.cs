using BookShop.Shared.Models;
using Newtonsoft.Json;

namespace BookShop.Services
{
    public class ShopCartService
    {
        private Dictionary<int,int> cartItems = new Dictionary<int, int>();
        readonly LocalStorageService _LocalStorageService;

        public event Action OnCartChange;

        public ShopCartService(LocalStorageService localStorageService)
        {
            _LocalStorageService = localStorageService;
            Task.Run(async () => cartItems = await GetCartItems());
        }

        public async void AddToCart(int bookId)
        {
            var getResult = cartItems.ContainsKey(bookId);
            if(getResult)
                cartItems[bookId]++;
            else
                cartItems.Add(bookId, 1);

            await _LocalStorageService.AddItem("Cart", JsonConvert.SerializeObject(cartItems));
            NotifyCartChanged();
        }

        public async Task<Dictionary<int, int>> GetCartItems()
        {
            var cart = await _LocalStorageService.GetItem("Cart");
            if (string.IsNullOrWhiteSpace(cart))
                return null;

            return JsonConvert.DeserializeObject<Dictionary<int, int>>(cart);
        }

        private void NotifyCartChanged() => OnCartChange?.Invoke();

    }
}
