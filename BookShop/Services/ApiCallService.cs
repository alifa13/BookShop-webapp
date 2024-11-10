using BookShop.ApiCaller.Api;

namespace BookShop.Services
{
	public class ApiCallService
	{
        private static IBookApi? _bookApi;
		private static ICustomerApi? _customerApi;
		private static IOrderApi? _orderApi;
		private static IAuthorApi? _authorApi;
		private static IPublisherApi? _publisherApi;
		private static ITranslatorApi? _translatorApi;
		private static IUserApi? _userApi;
		private static string? _baseApiAddress;
		private readonly IConfiguration? _configuration;

        public ApiCallService(IConfiguration configuration)
        {
			_configuration = configuration;
			if (_configuration is null)
				return;

			_baseApiAddress = _configuration["ApiBaseAddress"];
		}

		public static IBookApi BookApi => _bookApi ??= new BookApi(_baseApiAddress);
		public static ICustomerApi CustomerApi => _customerApi ??= new CustomerApi(_baseApiAddress);
		public static IOrderApi OrderApi => _orderApi ??= new OrderApi(_baseApiAddress);
		public static IAuthorApi AuthorApi => _authorApi ??= new AuthorApi(_baseApiAddress);
		public static IPublisherApi PublisherApi => _publisherApi ??= new PublisherApi(_baseApiAddress);
		public static ITranslatorApi TranslatorApi => _translatorApi ??= new TranslatorApi(_baseApiAddress);
		public static IUserApi UserApi => _userApi ??= new UserApi(_baseApiAddress);
	}
}
