namespace BPMSoft.Configuration.ServiceDesigner
{

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Text;
	using System.Threading.Tasks;
	using System.Xml.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common;

	#region Class: DownloadXmlSchemaException

	public class DownloadXmlSchemaException : Exception
	{

		#region Constructors: Public

		public DownloadXmlSchemaException(string message)
			: base(message) {
		}

		public DownloadXmlSchemaException(string message, Exception innerException)
			: base(message, innerException) {
		}

		#endregion

	}

	#endregion

	#region Class: XmlSchemaParseException

	public class XmlSchemaParseException : Exception
	{

		#region Constructors: Public

		public XmlSchemaParseException(string message)
			: base(message) {
		}

		public XmlSchemaParseException(string message, Exception innerException)
			: base(message, innerException) {
		}

		#endregion

	}

	#endregion

	#region Class: DownloadWsdlEndpoint

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DownloadWsdlEndpoint : BaseService
	{

		#region Class: XmlSchemaFiles

		private class XmlSchemaFiles
		{

			public XmlSchemaFiles(IEnumerable<string> urls) {
				Stack = new Stack<string>(urls);
			}

			public Stack<string> Stack {
				get;
			}

			private Dictionary<string, int[]> _files;
			public Dictionary<string, int[]> Files => _files ?? (_files = new Dictionary<string, int[]>());

			private List<string> _processedFiles;

			public List<string> ProcessedFiles => _processedFiles ?? (_processedFiles = new List<string>());

		}

		#endregion

		#region Fields: Private

		private static HttpClient _httpClient;
		private static readonly IEnumerable<string> _importNodesNames = new[] { "import", "include" };
		private const string SchemaLocationAttributeName = "schemaLocation";
		private const int MaximumSchemasCount = 100;
		private const int MaximumSchemaSizeBytes = 10000000;

		#endregion

		#region Methods: Private

		private static HttpClient GetHttpClient() {
			if (_httpClient != null) {
				return _httpClient;
			}
			if (!ClassFactory.TryGet("DownloadWsdlEndpointHttpClient", out _httpClient)) {
				_httpClient = new HttpClient();
			}
			return _httpClient;
		}

		private static IEnumerable<string> GetImportedSchemaUrls(string xmlContent) {
			if (xmlContent.IsNullOrWhiteSpace()) {
				return new List<string>();
			}
			XDocument xDocument = XDocument.Parse(xmlContent);
			return xDocument.Descendants()
				.Where(element => _importNodesNames.Contains(element.Name.LocalName.ToLower()))
				.Select(element => element.Attribute(SchemaLocationAttributeName))
				.Where(locationAttribute => locationAttribute != null)
				.Select(locationAttribute => locationAttribute.Value)
				.Where(schemaLocation => schemaLocation.IsNotNullOrEmpty());
		}

		private async Task<string> GetUriContent(string uri) {
			var maximumAllowedSchemaSize = GetLocalizedString("MaximumAllowedSchemaSize");
			var errorDownloadingSchema = GetLocalizedString("ErrorDownloadingSchema");
			try {
				var httpClient = GetHttpClient();
				HttpResponseMessage response = await httpClient.GetAsync(new Uri(uri));
				var schemaSize = response.Content.Headers.ContentLength;
				if (schemaSize > MaximumSchemaSizeBytes) {
					throw new XmlSchemaParseException(
					string.Format(maximumAllowedSchemaSize, MaximumSchemaSizeBytes, schemaSize, uri)
					);
				}
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsStringAsync();
			} catch (XmlSchemaParseException e) {
				throw e;
			}
			catch (Exception e) {
				throw new DownloadXmlSchemaException(string.Format(errorDownloadingSchema, uri), e);
			}
		}

		private string GetLocalizedString(string resourceName) {
			var localizableString = $"LocalizableStrings.{resourceName}.Value";
			string result = new LocalizableString(UserConnection.ResourceStorage,
				GetType().Name, localizableString);
			return result;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetXmlSchemaFilesContent", ResponseFormat = WebMessageFormat.Json)]
		public async Task<GetXmlSchemaFilesContentResponse> GetXmlSchemaFilesContent(string[] urls) {
			var xmlSchemaFiles = new XmlSchemaFiles(urls);
			var response = new GetXmlSchemaFilesContentResponse {
				Success = true,
			};
			try {
				while (xmlSchemaFiles.Stack.Count > 0) {
					string url = xmlSchemaFiles.Stack.Pop();
					if (xmlSchemaFiles.ProcessedFiles.Contains(url)) {
						continue;
					}
					string fileContent = await GetUriContent(url);
					if (xmlSchemaFiles.ProcessedFiles.Count >= MaximumSchemasCount) {
						var wrongFileFormat = GetLocalizedString("MaximumAllowedSchemaCount");
						throw new XmlSchemaParseException(string.Format(wrongFileFormat, MaximumSchemasCount, url));
					}
					IEnumerable<string> schemasUrls;
					try {
						schemasUrls = GetImportedSchemaUrls(fileContent);
					} catch (Exception e) {
						var wrongFileFormat = GetLocalizedString("IncorrectSchemaFileFormat");
						throw new XmlSchemaParseException(string.Format(wrongFileFormat, url), e);
					}
					schemasUrls.Where(schemaUrl => !xmlSchemaFiles.ProcessedFiles.Contains(schemaUrl))
						.ForEach(schemaUrl => {
							xmlSchemaFiles.Stack.Push(schemaUrl);
						});
					xmlSchemaFiles.Files.Add(url, Encoding.ASCII.GetBytes(fileContent)
						.Select(b=> (int)b).ToArray());
					xmlSchemaFiles.ProcessedFiles.Add(url);
				}
				response.Files = xmlSchemaFiles.Files;
			} catch (Exception e) {
				response.Success = false;
				response.ErrorInfo = new ErrorInfo {
					Message = e.Message,
					StackTrace = e.StackTrace,
				};
			}
			return response;
		}

		#endregion

	}

	#endregion

}

