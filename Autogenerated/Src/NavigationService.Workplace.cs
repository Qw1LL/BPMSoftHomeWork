namespace BPMSoft.Configuration.Url
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;

	/// <summary>
	/// Represents navigation service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class NavigationService : BaseService
	{

		/// <summary>
		/// Returns <see cref="HttpRequest"/> instance.
		/// </summary>
		public HttpRequest Request { get; set; } = HttpContext.Current.Request;

		#region Methods: Private

		/// <summary>
		/// Creates <see cref="IUrlGenerator"/> implementation instance.
		/// </summary>
		/// <returns><see cref="IUrlGenerator"/> implementation instance.</returns>
		private IUrlGenerator GetUrlGenerator() {
			return ClassFactory.Get<IUrlGenerator>(new ConstructorArgument("uc", UserConnection));
		}

		/// <summary>
		/// Returns <see cref="HttpResponse"/> instance.
		/// </summary>
		/// <returns><see cref="HttpResponse"/> instance.</returns>
		private HttpResponse GetResponse() {
			return HttpContext.Current.Response;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Gets navigation url.
		/// <param name="schemaName">Object schema name.</param>
		/// <param name="recordId">Object identifier.</param>
		/// </summary>
		/// <returns>Navigation url.</returns>
		protected string GetUrl(string schemaName, string recordId) {
			IUrlGenerator urlGenerator = GetUrlGenerator();
			string url = Guid.TryParse(recordId, out Guid id)
				? urlGenerator.GetUrl(schemaName, id)
				: urlGenerator.GetDefaultUrl();
			return url;
		}

		#endregion

		#region Constructors: Public

		public NavigationService(UserConnection userConnection) : base(userConnection) {
		}

		public NavigationService() : base() {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Redirects browser page to new url .
		/// </summary>
		/// <param name="schemaName">Object schema name.</param>
		/// <param name="recordId">Object identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Redirect?schemaName={schemaName}&recordId={recordId}",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public void Redirect(string schemaName, string recordId) {
			Request.Headers["Redirect-BPMSoft"] = "true";
			HttpResponse response = GetResponse();
			response.AddHeader("Connection", "close");
			string url = GetUrl(schemaName, recordId);
			response.Redirect(url, false);
		}

		#endregion

	}
}

