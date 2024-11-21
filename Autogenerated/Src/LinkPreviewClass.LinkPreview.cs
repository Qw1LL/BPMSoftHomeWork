using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using global::Common.Logging;

namespace BPMSoft.Configuration
{
	#region Class: LinkPreviewWebClient

	/// <summary>
	/// Class for extending capabilities of WebClient.
	/// </summary>
	public class LinkPreviewWebClient : WebClient
	{
		/// <summary>
		/// Constructor for initialization of default encoding.
		/// </summary>
		public LinkPreviewWebClient() 
		{
			Encoding = Encoding.UTF8;
		}

		#region Methods: Private

		/// <summary>
		/// Returns encoding from response headers. If nothig has been found, returns default encoding.
		/// </summary>
		/// <param name="responseHeaders">Response headers collection.</param>
		/// <returns>Server or default encoding</returns>
		private Encoding GetEncodingFromResponseHeaders(NameValueCollection responseHeaders)
		{
			if (responseHeaders == null)
			{
				throw new ArgumentNullException("responseHeaders");
			}
			var contentType = responseHeaders["Content-Type"];
			if (contentType == null)
			{
				return Encoding;
			}
			var contentTypeParts = contentType.Split(';');
			if (contentTypeParts.Length <= 1)
			{
				return Encoding;
			}
			var charsetPart = contentTypeParts.Skip(1).
				FirstOrDefault(p => p.TrimStart().StartsWith("charset", StringComparison.InvariantCultureIgnoreCase));
			if (charsetPart == null)
			{
				return Encoding;
			}
			var charsetPartParts = charsetPart.Split('=');
			if (charsetPartParts.Length != 2)
			{
				return Encoding;
			}
			var charsetName = charsetPartParts[1].Trim();
			if (charsetName == string.Empty)
			{
				return Encoding;
			}
			return Encoding.GetEncoding(charsetName);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates the WebRequest with automatic decompression. 
		/// </summary>
		/// <param name="address">Uri.</param>
		/// <returns>WebRequest instance.</returns>
		protected override WebRequest GetWebRequest(Uri address)
		{
			HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			return request;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Downloads a string from the server.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <returns>Page html code.</returns>
		public string DownloadStringUsingServerEncoding(string url)
		{
			var rawData = DownloadData(new Uri(url));
			var encoding = GetEncodingFromResponseHeaders(ResponseHeaders);
			return encoding.GetString(rawData);
		}

		#endregion
	}

	#endregion

	#region Class: LinkPreviewInfo

	/// <summary>
	/// Class of link preview info.
	/// </summary>
	[DataContract]
	public class LinkPreviewInfo
	{
		#region Properties: Public

		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "image")]
		public string Image { get; set; }

		[DataMember(Name = "host")]
		public string Host { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }

		#endregion
	}

	#endregion

	#region Class: LinkPreview

	/// <summary>
	/// Class for generate link preview info.
	/// </summary>
	public class LinkPreview
	{
		
		#region Constants: Private

		/// <summary>
		/// Meta data regular expression.
		/// </summary>
		const string _metaDataRegEx = "<meta[\\s]+[^>]*?content[\\s]?=[\\s\"\']+(.*?)[\"\']+.*?>";

		#endregion

		#region Fields: Private

		private readonly ILog _log = LogManager.GetLogger("LinkPreview");

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns web page html code.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <returns>Page html code.</returns>
		protected virtual string GetWebPageHtmlCode(string url) {
			string result = string.Empty;
			try {
				using (LinkPreviewWebClient client = new LinkPreviewWebClient()) {
					result = client.DownloadStringUsingServerEncoding(url);
				}
			}
			catch (Exception e) {
				_log.ErrorFormat("[LinkPreview.GetWebPageHtmlCode]: Download string {0}: {1}", url, e);
			}
			return result;
		}

		/// <summary>
		/// Returns web page meta data.
		/// </summary>
		/// <param name="s">Html.</param>
		/// <returns>Page meta data.</returns>
		protected IEnumerable<Match> GetWebPageMetaData(string html) {
			Regex m3 = new Regex(_metaDataRegEx);
			MatchCollection mc = m3.Matches(html);
			return mc.Cast<Match>();
		}

		/// <summary>
		/// Searches property value in <paramref name="metadata"/>.
		/// </summary>
		/// <param name="metadata">Metadata.</param>
		/// <param name="propertyName">Property name.</param>
		/// <returns>Meta data property value.</returns>
		protected string GetMetaDataPropertyValue(IEnumerable<Match> metadata, string propertyName) {
			Match match = metadata.FirstOrDefault(m => m.Value.ToLowerInvariant().Contains(propertyName));
			return match?.Groups[1]?.Value;
		}

		/// <summary>
		/// Returns host url.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <returns>Host url.</returns>
		protected string GetHost(string url) {
			Uri uri = new Uri(url);
			return uri.Host;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Generates link preview info by url.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <returns>Link preview info.</returns>
		public LinkPreviewInfo GetWebPageLinkPreview(string url) {
			string htmlCode = GetWebPageHtmlCode(url);
			IEnumerable<Match> metadata = GetWebPageMetaData(htmlCode);
			if (metadata == null) {
				return null;
			}
			string description = GetMetaDataPropertyValue(metadata, "og:description");
			string title = GetMetaDataPropertyValue(metadata, "og:title");
			string image = GetMetaDataPropertyValue(metadata, "og:image");
			if (string.IsNullOrEmpty(description) && string.IsNullOrEmpty(title) && string.IsNullOrEmpty(image)) {
				return null;
			}
			return new LinkPreviewInfo {
				Url = url,
				Host = GetHost(url),
				Description = description,
				Title = title,
				Image = image
			};
		}

		#endregion
	}

	#endregion
}
