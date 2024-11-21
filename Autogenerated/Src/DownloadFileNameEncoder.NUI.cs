namespace BPMSoft.Configuration {
	using System;
	using System.Text.RegularExpressions;
	using BPMSoft.Web.Http.Abstractions;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: DownloadFileNameEncoder

	public class DownloadFileNameEncoder {

		#region Fields: Protected

		protected HttpContext CurrentContext;

		#endregion

		#region Constructor: Public

		public DownloadFileNameEncoder(HttpContext httpContext) {
			CurrentContext = httpContext;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Remove special characters from fileName.
		/// </summary>
		/// <param name="fileName">File name.</param>
		/// <returns>File name without special characters.</returns>
		protected string RemoveSpecialCharacters(string fileName) {
			return Regex.Replace(fileName, @"[^a-zA-Z\p{IsCyrillic}0-9_.,^&@£$€!½§~'=()\[\]{} «»<>~#*%+-]+",
				"_", RegexOptions.Compiled);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets response content disposition header value.
		/// </summary>
		/// <param name="fileName">File name.</param>
		/// <param name="useUrlPathEncode"> Use UrlPathEncode for encode file name</param>
		/// <returns>Content disposition header value.</returns>
		public virtual string GenerateName(string fileName, bool useUrlPathEncode = false) {
			HttpRequest request = CurrentContext.Request;
			string userAgent = (request.UserAgent ?? string.Empty).ToLowerInvariant();
			if (userAgent.Contains("android"))
			{
				fileName = RemoveSpecialCharacters(fileName);
			}

			string encodedFileName = useUrlPathEncode ? Uri.EscapeDataString(fileName) : HttpUtility.UrlEncode(fileName);
			return $"attachment; filename*=UTF-8''{encodedFileName}";
		}

		#endregion

	}

	#endregion
}

