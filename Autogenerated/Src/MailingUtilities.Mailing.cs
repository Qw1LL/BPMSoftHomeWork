namespace BPMSoft.Configuration
{
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using System;
	using System.Data;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.IO;
	using System.IO.Compression;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Security.Cryptography;
	using Quartz;
	using global::Common.Logging;

	#region Class: MailingUtilities

	/// <summary>
	/// Utility methods for the mailing service.
	/// </summary>
	public static class MailingUtilities
	{

		#region Fields: Private

		private const int DescriptionTypeStringLength = 250;

		private const int SubjectCaptionTypeStringLength = 500;

		private static readonly ILog _log = LogManager.GetLogger("Mailing");

		private static readonly ILog _webHookLog = LogManager.GetLogger("WebHooks");

		private static readonly MD5 _md5 = MD5.Create();

		private static readonly Regex EmailRegex = new Regex(@"[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?" +
			@":\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9]" +
			"(?:[A-Za-z0-9-]*[A-Za-z0-9])?");

		private static readonly Regex HtmlHyperlinksParserRegex = new Regex(@"<a\b[^>]*?\bhref\s*=\s*" +
			@"(?:""(?<URL>(?:\\""|[^""])*)""|'(?<URL>(?:\\'|[^'])*)')[^>]*>([^<]*(?:(?!</a)<[^<]*)*)</a>");

		private static readonly Regex HrefValueRegex = new Regex(@"<.*href=""(?<href>.*?)"".*?>((.|\n)*)<\/.*>");

		private const string HrefParameterName = "href";

		private static readonly IStringCrypto _stringCrypto = new SimpleCrypto();

		#endregion

		#region Properties: Public

		/// <summary>
		/// Logger.
		/// </summary>
		public static ILog Log {
			get {
				return _log;
			}
		}

		/// <summary>
		/// WebHook Logger.
		/// </summary>
		public static ILog WebHookLog {
			get {
				return _webHookLog;
			}
		}

		/// <summary>
		/// Encryption mechanism.
		/// </summary>
		public static IStringCrypto StringCrypto {
			get {
				return _stringCrypto;
			}
		}

		#endregion

		#region Methods: Private

		private static string GetRemindingHash(Dictionary<string, object> dictionary) {
			var str = new StringBuilder();
			foreach (object value in dictionary.Values) {
				str.Append(value);
			}
			return FileUtilities.GetMD5Hash(Encoding.Unicode.GetBytes(str.ToString()));
		}

		private static string TruncateString(string source, int length) {
			return (source.Length > length)
				? source = source.Substring(0, length)
				: source;
		}

		/// <summary>
		/// Checks whether email contains nonprintable chatachters.
		/// </summary>
		/// <param name="email">Email address.</param>
		/// <returns>True if email contains nonprintable charachters.</returns>
		private static bool CheckEmailContainsNonPrintableCharachters(string email) {
			return Regex.IsMatch(email, @"[^\u0021-\u007F]");
		}

		private static bool CheckEmailIsValid(string email) {
			return EmailRegex.IsMatch(email);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns identifier of the active provider.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		/// <returns>Unique identifier.</returns>
		public static Guid GetActiveProviderId(UserConnection userConnection) {
			return (Guid)BPMSoft.Core.Configuration.SysSettings.GetValue(userConnection, "MailingProvider");
		}

		/// <summary>
		/// Creates user remindings.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="entity">Object on which reminding is created.</param>
		/// <param name="description">Reminding text.</param>
		/// <param name="schemaCaption">Custom reminding header.</param>
		public static void CreateReminding(
				UserConnection userConnection, Entity entity, string description, string schemaCaption = "") {
			Reminding remindingEntity = new Reminding(userConnection);
			string subject = entity.PrimaryDisplayColumnValue;
			DateTime userDateTime = userConnection.CurrentUser.GetCurrentDateTime();
			Guid userContactId = userConnection.CurrentUser.ContactId;
			var condition = new Dictionary<string, object> {
				{
					"Author", userContactId
				}, {
					"Contact", userContactId
				}, {
					"Source", RemindingConsts.RemindingSourceAuthorId
				}, {
					"SubjectCaption", subject
				}, {
					"SysEntitySchema", entity.Schema.UId
				},
			};
			string hash = GetRemindingHash(condition);
			if (!string.IsNullOrEmpty(description)) {
				subject = string.Format("{0} \"{1}\" {2}",
						string.IsNullOrEmpty(schemaCaption) ? entity.Schema.Caption.Value : schemaCaption,
						entity.PrimaryDisplayColumnValue,
						description);
			}
			if (!remindingEntity.FetchFromDB(new Dictionary<string, object> { { "Hash", hash } }, false)) {
				remindingEntity.SetDefColumnValues();
			}
			description = TruncateString(subject, DescriptionTypeStringLength);
			subject = TruncateString(subject, SubjectCaptionTypeStringLength);
			remindingEntity.SetColumnValue("ModifiedOn", userDateTime);
			remindingEntity.SetColumnValue("AuthorId", userContactId);
			remindingEntity.SetColumnValue("ContactId", userContactId);
			remindingEntity.SetColumnValue("SourceId", RemindingConsts.RemindingSourceAuthorId);
			remindingEntity.SetColumnValue("RemindTime", userDateTime);
			remindingEntity.SetColumnValue("Description", description);
			remindingEntity.SetColumnValue("SubjectCaption", subject);
			remindingEntity.SetColumnValue("Hash", hash);
			remindingEntity.SetColumnValue("SysEntitySchemaId", entity.Schema.UId);
			remindingEntity.SetColumnValue("SubjectId", entity.PrimaryColumnValue);
			remindingEntity.Save();
		}

		/// <summary>
		/// Creates user remindings.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="description">Reminding text.</param>
		/// <param name="sysEntitySchemaId">UId of entity schema on which reminding is created.</param>
		public static void CreateReminding(UserConnection userConnection, string description, Guid sysEntitySchemaId) {
			DateTime userDateTime = userConnection.CurrentUser.GetCurrentDateTime();
			Guid userContactId = userConnection.CurrentUser.ContactId;
			Reminding remindingEntity = new Reminding(userConnection);
			remindingEntity.SetDefColumnValues();
			string subject = TruncateString(description, SubjectCaptionTypeStringLength);
			description = TruncateString(description, DescriptionTypeStringLength);
			remindingEntity.SetColumnValue("AuthorId", userContactId);
			remindingEntity.SetColumnValue("ContactId", userContactId);
			remindingEntity.SetColumnValue("SourceId", RemindingConsts.RemindingSourceAuthorId);
			remindingEntity.SetColumnValue("RemindTime", userDateTime);
			remindingEntity.SetColumnValue("Description", description);
			remindingEntity.SetColumnValue("SubjectCaption", subject);
			remindingEntity.SetColumnValue("SysEntitySchemaId", sysEntitySchemaId);
			remindingEntity.SetColumnValue("SubjectId", Guid.Empty);
			remindingEntity.Save();
		}

		/// <summary>
		/// Returns collection of the folder filters.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="BPMSoft.Core.UserConnection"/>.</param>
		/// <param name="recordId">Unique identifier of the folder.</param>
		/// <param name="folderSchemaUId">Unique identifier of the folder schema.</param>
		/// <param name="sourceSchemaUId">Unique identifier of the source filters schema.</param>
		/// <returns><see cref="IEntitySchemaQueryFilterItem"/> Filters collection.</returns>
		[Obsolete("7.8.0 | Use BPMSoft.Configuration.CommonUtilities.GetFolderEsqFilter")]
		public static IEntitySchemaQueryFilterItem GetFolderFilters(
				UserConnection userConnection, Guid recordId, Guid folderSchemaUId, Guid sourceSchemaUId) {
			return CommonUtilities.GetFolderEsqFilters(
				userConnection, recordId, folderSchemaUId, sourceSchemaUId, true);
		}

		/// <summary>
		/// Compresses source string with gzip algorithm.
		/// </summary>
		/// <param name="str">Source string.</param>
		/// <returns>Compressed data.</returns>
		public static byte[] Compress(string str) {
			byte[] data = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, data, 0, data.Length);
			using (MemoryStream output = new MemoryStream()) {
				using (GZipStream gzip = new GZipStream(output, CompressionMode.Compress, true)) {
					gzip.Write(data, 0, data.Length);
					gzip.Close();
					return output.ToArray();
				}
			}
		}

		/// <summary>
		/// Decompresses data.
		/// </summary>
		/// <param name="data">Compressed with gzip the byte array.</param>
		/// <returns>Decompressed data.</returns>
		public static byte[] Decompress(byte[] data) {
			using (MemoryStream input = new MemoryStream()) {
				input.Write(data, 0, data.Length);
				input.Position = 0;
				return Decompress(input);
			}
		}

		/// <summary>
		/// Decompresses stream data.
		/// </summary>
		/// <param name="data">Compressed gzip stream.</param>
		/// <returns>Decompressed data.</returns>
		public static byte[] Decompress(Stream data) {
			using (GZipStream gzip = new GZipStream(data, CompressionMode.Decompress, true)) {
				using (MemoryStream output = new MemoryStream()) {
					byte[] buff = new byte[64];
					int read = -1;
					read = gzip.Read(buff, 0, buff.Length);
					while (read > 0) {
						output.Write(buff, 0, read);
						read = gzip.Read(buff, 0, buff.Length);
					}
					gzip.Close();
					return output.ToArray();
				}
			}
		}

		/// <summary>
		/// Decompresses stream data and converts it to string.
		/// </summary>
		/// <param name="data">Compressed gzip stream.</param>
		/// <returns>Decompressed string.</returns>
		public static string DecompressToString(Stream data) {
			byte[] bytes = Decompress(data);
			return BytesToString(bytes);
		}

		/// <summary>
		/// Converts byte array to string.
		/// </summary>
		/// <param name="bytes">Byte array.</param>
		/// <returns>Converted string.</returns>
		public static string BytesToString(byte[] bytes) {
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}

		/// <summary>
		/// Executes Action for each element in collection.
		/// </summary>
		public static void BulkEmail<T>(this IEnumerable<T> collection, Action<T> action) {
			foreach (var item in collection) {
				action.Invoke(item);
			}
		}

		/// <summary>
		/// Uploads the image at the specified URL and converts it into a Base64 string.
		/// </summary>
		/// <param name="url">Image URL.</param>
		/// <param name="base64Data">Image as base64 string.</param>
		/// <param name="mimeType">MIME type of the image.</param>
		public static void LoadImageAsBase64(string url, out string base64Data, out string mimeType) {
			base64Data = null;
			mimeType = null;
			try {
				var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
				var response = (System.Net.HttpWebResponse)request.GetResponse();
				using (Stream receiveStream = response.GetResponseStream()) {
					MemoryStream stream = new MemoryStream();
					using (System.Drawing.Image image = System.Drawing.Image.FromStream(receiveStream)) {
						image.Save(stream, image.RawFormat);
						base64Data = Convert.ToBase64String(stream.ToArray(), 0, (int)stream.Length);
						ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders()
							.FirstOrDefault(c => c.FormatID == image.RawFormat.Guid);
						mimeType = codec != null ? codec.MimeType : null;
					}
					stream.Close();
					stream.Dispose();
				}
			} catch { }
		}

		/// <summary>
		/// Generates SHA1 hash code.
		/// </summary>
		/// <param name="hashContent">Source data of the hash.</param>
		/// <returns>Hash code (SHA1 without delimeters).</returns>
		public static string GenerateHash(params string[] hashContent) {
			StringBuilder sb = new StringBuilder();
			foreach (string item in hashContent) {
				sb.Append(item);
			}
			byte[] hashBytes = (new SHA1CryptoServiceProvider()).ComputeHash(new System.Text.UTF8Encoding()
				.GetBytes(sb.ToString()));
			sb = null;
			return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
		}

		/// <summary>
		/// Validates hash code and its content.
		/// </summary>
		/// <param name="hash">Hash code (SHA1 without delimeters).</param>
		/// <param name="hashContent">Source data of the hash.</param>
		/// <returns>Validation result.</returns>
		public static bool ValidateHash(string hash, params string[] hashContent) {
			return GenerateHash(hashContent) == hash;
		}

		/// <summary>
		/// Gets all hyperlinks from <paramref name="htmlSource"/>.
		/// </summary>
		/// <param name="htmlSource">Source html text.</param>
		/// <param name="parseToLowerCase">Determines if parse link to lower case.</param>
		/// <returns>Found hyperlinks.</returns>
		public static Dictionary<string, string> ParseHtmlHyperlinks(string htmlSource, bool parseToLowerCase = true) {
			Dictionary<string, string> links = new Dictionary<string, string>();
			foreach (Match match in HtmlHyperlinksParserRegex.Matches(htmlSource)) {
				if (match.Success) {
					string linkUrl = match.Groups[2].Value;
					if (parseToLowerCase) {
						linkUrl = linkUrl.ToLower();
					}
					linkUrl = System.Net.WebUtility.HtmlDecode(linkUrl).Trim();
					if (linkUrl.StartsWith("http://") || linkUrl.StartsWith("https://")) {
						string linkCaption =
							Regex.Replace(match.Groups[1].Value, @"<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
						linkCaption = System.Net.WebUtility.HtmlDecode(linkCaption).Trim();
						links[linkUrl] = linkCaption;
					}
				}
			}
			return links;
		}

		/// <summary>
		/// Returns all anchor elements from <paramref name="htmlSource"/>.
		/// </summary>
		/// <param name="htmlSource">Source html text.</param>
		/// <returns>The anchor element collection.</returns>
		public static List<string> ParseHtmlAnchorElement(string htmlSource) {
			var result = new List<string>();
			foreach (Match match in HtmlHyperlinksParserRegex.Matches(htmlSource)) {
				if (match.Success) {
					if (!result.Any(_ => _.Equals(match.Value, StringComparison.OrdinalIgnoreCase))) {
						result.Add(match.Value);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Returns value of the href parameter of <paramref name="htmlElementSource"/>.
		/// </summary>
		/// <param name="htmlSource">Source html text.</param>
		/// <returns>Value of the href parameter.</returns>
		public static string ParseHtmlHrefValue(string htmlElementSource) {
			string result = string.Empty;
			foreach (Match match in HrefValueRegex.Matches(htmlElementSource)) {
				if (match.Success) {
					result = match.Groups[HrefParameterName].Value;
				}
			}
			return result;
		}
		
		/// <summary>
		/// Returns values of the href parameters of <paramref name="htmlSource"/>.
		/// </summary>
		/// <param name="htmlSource">Source html text.</param>
		/// <returns>Values of the href parameters.</returns>
		public static IEnumerable<string> ParseHtmlHrefValues(string htmlSource) {
			var result = new List<string>();
			var anchorElements = ParseHtmlAnchorElement(htmlSource);
			foreach (string anchorElement in anchorElements) {
				result.Add(ParseHtmlHrefValue(anchorElement));
			}
			return result;
		}

		/// <summary>
		/// Generates unique identifier from hash code usning MD5 algoritm.
		/// </summary>
		/// <param name="source">String for hash code calculation.</param>
		/// <returns>Unique identifier.</returns>
		public static Guid GetMD5HashGuid(string source) {
			byte[] hash = _md5.ComputeHash(Encoding.Default.GetBytes(source));
			Guid hashUId = new Guid(hash);
			hash = null;
			return hashUId;
		}

		/// <summary>
		/// Checks whether email is valid.
		/// </summary>
		/// <param name="email">Email address.</param>
		/// <returns><True if email is valid./returns>
		public static bool ValidateEmail(string email) {
			return !CheckEmailContainsNonPrintableCharachters(email) && CheckEmailIsValid(email);
		}

		#endregion

	}

	#endregion

}

