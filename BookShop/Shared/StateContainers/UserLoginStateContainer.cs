using BookShop.Shared.Models;

namespace BookShop.Shared
{
    public class UserLoginStateContainer
    {
        public bool IsLogin { get; set; }
        public string Token { get; set; }
        public string Session { get; set; }
        public int UserId { get; set; }

        public event Action OnStateChange;

        public void SetValue(bool isLogin, string token = "", string session = "", int userId = 0, bool notify = true)
        {
            this.IsLogin = isLogin;
            this.Token = token;
            this.Session = session;
            this.UserId = userId;

            if(notify)
                NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
