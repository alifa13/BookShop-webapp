using BookShop.Shared.Models;

namespace BookShop.Shared
{
    public class ShopFilterStateContainer
    {
        public ShopFilterModel ShopFilter { get; set; }
        public event Action OnStateChange;
        public void SetValue(ShopFilterModel data)
        {
            this.ShopFilter = data;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
