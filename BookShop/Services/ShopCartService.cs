using BookShop.Shared.Models;
using Newtonsoft.Json;

namespace BookShop.Services
{
    public class ShopCartService
    {
        private Dictionary<int,int> cartItems = new();
        readonly LocalStorageService _LocalStorageService;

        public event Action? OnCartChange;

        public ShopCartService(LocalStorageService localStorageService)
        {
            _LocalStorageService = localStorageService;
        }

        public async void AddToCart(int bookId)
        {
            cartItems = await GetCartItems();
            var getResult = cartItems.ContainsKey(bookId);
            if(getResult)
                cartItems[bookId]++;
            else
                cartItems.Add(bookId, 1);

            await _LocalStorageService.AddItem("Cart", JsonConvert.SerializeObject(cartItems));
            NotifyCartChanged();
        }

        public async void RemoveFromCart(int bookId)
        {
			cartItems = await GetCartItems();
			var getResult = cartItems.ContainsKey(bookId);
			if (getResult)
				cartItems[bookId]--;

			await _LocalStorageService.AddItem("Cart", JsonConvert.SerializeObject(cartItems));
			NotifyCartChanged();
		}

        public async void SetCartItems(Dictionary<int, int> items)
        {
            var cartItems = JsonConvert.SerializeObject(items);
            if (cartItems is null)
                return;

            await _LocalStorageService.AddItem("Cart", cartItems);
        }

        public async Task<Dictionary<int, int>> GetCartItems()
        {
            var cart = await _LocalStorageService.GetItem("Cart");
            if (string.IsNullOrWhiteSpace(cart))
                return new Dictionary<int, int>();

            var result = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart);
            return result ?? new Dictionary<int, int>();
        }

        public async Task DeleteCartItems()
        {
            await _LocalStorageService.RemoveItem("Cart");
            NotifyCartChanged();
        }

        private void NotifyCartChanged() => OnCartChange?.Invoke();

    }
}
