using BookShop.ApiCaller.Api;
using BookShop.ApiCaller.Client;
using BookShop.Utility;

namespace BookShop.Services
{
    public static class ApiCallService
    {
        private static IBookApi? _bookApi;
        private static IGuaranteeApi? _guaranteeApi;
        private static ICustomerApi? _customerApi;
        private static IOrderApi? _orderApi;
        private static IAuthorApi? _authorApi;
        private static IGroupApi? _groupApi;
        private static IPublisherApi? _publisherApi;
        private static ITranslatorApi? _translatorApi;
        private static IUserApi? _userApi;
        private static string? _baseApiAddress;
        private static IConfiguration? _configuration;
        private static CookieHelper? _cookieHelper;

        public static void Configure(IConfiguration configuration, CookieHelper cookieHelper)
        {
            _configuration = configuration;
            if (_configuration is null)
                return;

            _cookieHelper = cookieHelper;
            if (_cookieHelper is null)
                return;

            _baseApiAddress = _configuration["ApiBaseAddress"];
        }

        public static async Task ConfigureWebToken(this IApiAccessor apiAccessor)
        {
            if (_cookieHelper != null)
            {
                if (apiAccessor.Configuration.ApiKey.ContainsKey("WebToken"))
                    apiAccessor.Configuration.ApiKey.Remove("WebToken");

                var token = await _cookieHelper.GetCookie("WebToken");
                if (!string.IsNullOrWhiteSpace(token))
                    apiAccessor.Configuration.ApiKey.TryAdd("WebToken", token);
            }
        }

        public static IGuaranteeApi GuaranteeApi
        {
            get
            {
                _guaranteeApi ??= new GuaranteeApi(_baseApiAddress);

                return _guaranteeApi;
            }
        }

        public static IBookApi BookApi
        {
            get
            {
                _bookApi ??= new BookApi(_baseApiAddress);

                return _bookApi;
            }
        }
        public static ICustomerApi CustomerApi
        {
            get
            {
                _customerApi ??= new CustomerApi(_baseApiAddress);

                return _customerApi;
            }
        }
        public static IOrderApi OrderApi
        {
            get
            {
                _orderApi ??= new OrderApi(_baseApiAddress);

                return _orderApi;
            }
        }
        public static IAuthorApi AuthorApi
        {
            get
            {
                _authorApi ??= new AuthorApi(_baseApiAddress);

                return _authorApi;
            }
        }
        public static IPublisherApi PublisherApi
        {
            get
            {
                _publisherApi ??= new PublisherApi(_baseApiAddress);

                return _publisherApi;
            }
        }
        public static ITranslatorApi TranslatorApi
        {
            get
            {
                _translatorApi ??= new TranslatorApi(_baseApiAddress);

                return _translatorApi;
            }
        }
        public static IUserApi UserApi
        {
            get
            {
                _userApi ??= new UserApi(_baseApiAddress);

                return _userApi;
            }
        }
        public static IGroupApi GroupApi
        {
            get
            {
                _groupApi ??= new GroupApi(_baseApiAddress);

                return _groupApi;
            }
        }
    }
}
