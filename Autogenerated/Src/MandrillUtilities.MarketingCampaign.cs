namespace BPMSoft.Configuration.MandrillService
{
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using System;
	using System.Collections.Generic;
	using System.Drawing.Imaging;
	using System.IO;
	using System.IO.Compression;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Security.Cryptography;
	using global::Common.Logging;
	using BPMSoft.Configuration.CESModels;

	#region Class: MandrillUtilities

	/// <summary>
	/// ######## ######### ###### ### ###### # ######### MandrillApi.
	/// </summary>
	public static class MandrillUtilities
	{

		#region Fields: Private

		private const int DescriptionTypeStringLength = 250;

		private const int SubjectCaptionTypeStringLength = 500;

		private static readonly ILog _log = LogManager.GetLogger("Mandrill");

		private static readonly ILog _webHookLog = LogManager.GetLogger("MandrillWebHooks");

		private static readonly MD5 _md5 = MD5.Create();

		private static readonly Regex HtmlHyperlinksParserRegex = new Regex(@"<a\b[^>]*?\bhref\s*=\s*" + 
			@"(?:""(?<URL>(?:\\""|[^""])*)""|'(?<URL>(?:\\'|[^'])*)')[^>]*>([^<]*(?:(?!</a)<[^<]*)*)</a>");

		private static readonly IStringCrypto _stringCrypto = new SimpleCrypto();

		#endregion

		#region Properties: Public

		/// <summary>
		/// ###### ### ########## # Mandrill.
		/// </summary>
		public static ILog Log {
			get {
				return _log;
			}
		}

		/// <summary>
		/// ###### ### ########## # Mandrill.
		/// </summary>
		public static ILog WebHookLog {
			get {
				return _webHookLog;
			}
		}

		/// <summary>
		/// ############ ######## ##########.
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

		#endregion

		#region Methods: Public

		/// <summary>
		/// ######### ###### ######## #########.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		/// <param name="spName">### ######## #########.</param>
		/// <param name="parameters">######### #######.</param>
		/// <returns>######### ########## ######## #########.</returns>
		public static int ExecuteStoredProcedure(UserConnection userConnection, string spName, 
				params KeyValuePair<string, object>[] parameters) {
			var sp = new StoredProcedure(userConnection, spName);
			foreach (var parameter in parameters) {
				sp.WithParameter(parameter.Key, parameter.Value);
			}
			sp.PackageName = userConnection.DBEngine.SystemPackageName;
			return sp.Execute();
		}

		/// <summary>
		/// ####### ########### ############.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		/// <param name="entity">######, ## ######## ##### ####### ###########.</param>
		/// <param name="description">##### ###########.</param>
		/// <param name="schemaCaption">######### ######### ###### ###########.</param>
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
		/// ####### ########### ############.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		/// <param name="description">##### ###########.</param>
		/// <param name="sysEntitySchemaId">########## ############# #######, ## ######## ##### #######
		/// ###########.</param>
		[Obsolete("7.8.0 | Use BPMSoft.Configuration.RemindingUtilities.CreateReminding")]
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
		/// ########## ###### gzip ###### ####.
		/// </summary>
		/// <param name="str">###### ### ##########.</param>
		/// <returns>###### ####.</returns>
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
		/// ########## ############# ###### ####.
		/// </summary>
		/// <param name="data">###### gzip ###### ####.</param>
		/// <returns>###### ####.</returns>
		public static byte[] Decompress(byte[] data) {
			using (MemoryStream input = new MemoryStream()) {
				input.Write(data, 0, data.Length);
				input.Position = 0;
				return Decompress(input);
			}
		}

		/// <summary>
		/// ########## ############# ###### ####.
		/// </summary>
		/// <param name="data">###### gzip #####.</param>
		/// <returns>###### ####.</returns>
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
		/// ########## ############# ###### ####.
		/// </summary>
		/// <param name="data">###### gzip #####.</param>
		/// <returns>############ ######.</returns>
		public static string DecompressToString(Stream data) {
			byte[] bytes = Decompress(data);
			return BytesToString(bytes);
		}

		/// <summary>
		/// ############ ###### #### # ######.
		/// </summary>
		/// <param name="bytes">###### ####.</param>
		/// <returns>############### ######.</returns>
		public static string BytesToString(byte[] bytes) {
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}

		/// <summary>
		/// ########## ########## ############# ####### # ######### email.
		/// </summary>
		/// <param name="eventType">######### ######### <see cref="WebHookEventType"/>.</param>
		/// <returns>########## ############# ####### # ######### email.</returns>
		public static Guid GetBulkEmailResponse(this WebHookEventType eventType) {
			switch (eventType) {
				case WebHookEventType.Click:
					return MarketingConsts.BulkEmailResponseClickedId;
				case WebHookEventType.Open:
					return MarketingConsts.BulkEmailResponseOpenedId;
				case WebHookEventType.Hard_bounce:
					return MarketingConsts.BulkEmailResponseHardBounceId;
				case WebHookEventType.Soft_bounce:
					return MarketingConsts.BulkEmailResponseSoftBounceId;
				case WebHookEventType.Spam:
					return MarketingConsts.BulkEmailResponseSpamId;
				case WebHookEventType.Send:
					return MarketingConsts.BulkEmailResponseSentId;
				case WebHookEventType.Unsub:
					return MarketingConsts.BulkEmailResponseUnsubId;
				case WebHookEventType.Reject:
					return MarketingConsts.BulkEmailResponseRejectedId;
				case WebHookEventType.Deferral:
					return MarketingConsts.BulkEmailResponseDeferralId;
				default:
					return Guid.Empty;
			}
		}

		/// <summary>
		/// ########## ########## ############# ####### # ######### email.
		/// </summary>
		/// <param name="state">######### ######### <see cref="WebHookMessageState"/>.</param>
		/// <returns>########## ############# ####### # ######### email.</returns>
		public static Guid GetBulkEmailResponse(this WebHookMessageState state) {
			switch (state) {
				case WebHookMessageState.Bounced:
					return MarketingConsts.BulkEmailResponseHardBounceId;
				case WebHookMessageState.Rejected:
					return MarketingConsts.BulkEmailResponseRejectedId;
				case WebHookMessageState.Sent:
					return MarketingConsts.BulkEmailResponseSentId;
				case WebHookMessageState.Soft_bounced:
					return MarketingConsts.BulkEmailResponseSoftBounceId;
				case WebHookMessageState.Spam:
					return MarketingConsts.BulkEmailResponseSpamId;
				case WebHookMessageState.Unsub:
					return MarketingConsts.BulkEmailResponseUnsubId;
				default:
					return Guid.Empty;
			}
		}

		/// <summary>
		/// ########## ########## ############# ####### # ######### email.
		/// </summary>
		/// <param name="status">######### ######### <see cref="EmailResultStatus"/>.</param>
		/// <returns>########## ############# ####### # ######### email.</returns>
		public static Guid GetBulkEmailResponse(this EmailResultStatus status) {
			switch (status) {
				case EmailResultStatus.Invalid:
					return MarketingConsts.BulkEmailResponseInvalidId;
				case EmailResultStatus.Queued:
					return MarketingConsts.BulkEmailResponseQueuedId;
				case EmailResultStatus.Rejected:
					return MarketingConsts.BulkEmailResponseRejectedId;
				case EmailResultStatus.Sent:
					return MarketingConsts.BulkEmailResponseSentId;
				default:
					return Guid.Empty;
			}
		}

		/// <summary>
		/// ########## ###### # email #########.
		/// </summary>
		/// <param name="eventType">######### ######### <see cref="WebHookEventType"/>.</param>
		/// <returns>###### # email #########.</returns>
		[Obsolete]
		public static BulkEmailResponseCode GetBulkEmailResponseCode(this WebHookEventType eventType) {
			switch (eventType) {
				case WebHookEventType.Click:
					return BulkEmailResponseCode.Clicked;
				case WebHookEventType.Open:
					return BulkEmailResponseCode.Opened;
				case WebHookEventType.Hard_bounce:
					return BulkEmailResponseCode.HardBounce;
				case WebHookEventType.Soft_bounce:
					return BulkEmailResponseCode.SoftBounce;
				case WebHookEventType.Spam:
					return BulkEmailResponseCode.Spam;
				case WebHookEventType.Send:
					return BulkEmailResponseCode.Sent;
				case WebHookEventType.Unsub:
					return BulkEmailResponseCode.Unsub;
				case WebHookEventType.Reject:
					return BulkEmailResponseCode.Rejected;
				case WebHookEventType.Deferral:
					return BulkEmailResponseCode.Deferral;
				default:
					throw new InvalidCastException(eventType + 
							"is not a defined value for enum type WebHookEventType.");
			}
		}

		/// <summary>
		/// ########## ###### # email #########.
		/// </summary>
		/// <param name="state">######### ######### <see cref="WebHookMessageState"/>.</param>
		/// <returns>###### # email #########.</returns>
		[Obsolete]
		public static BulkEmailResponseCode GetBulkEmailResponseCode(this WebHookMessageState state) {
			switch (state) {
				case WebHookMessageState.Bounced:
					return BulkEmailResponseCode.HardBounce;
				case WebHookMessageState.Rejected:
					return BulkEmailResponseCode.Rejected;
				case WebHookMessageState.Sent:
					return BulkEmailResponseCode.Sent;
				case WebHookMessageState.Soft_bounced:
					return BulkEmailResponseCode.SoftBounce;
				case WebHookMessageState.Spam:
					return BulkEmailResponseCode.Spam;
				case WebHookMessageState.Unsub:
					return BulkEmailResponseCode.Unsub;
				default:
					throw new InvalidCastException(state + " is not a defined value for enum type WebHookMessageState.");
			}
		}

		/// <summary>
		/// ########## ###### # email #########.
		/// </summary>
		/// <param name="status">######### ######### <see cref="EmailResultStatus"/>.</param>
		/// <returns>####### # email #########.</returns>
		[Obsolete]
		public static BulkEmailResponseCode GetBulkEmailResponseCode(this EmailResultStatus status) {
			switch (status) {
				case EmailResultStatus.Invalid:
					return BulkEmailResponseCode.Invalid;
				case EmailResultStatus.Queued:
					return BulkEmailResponseCode.Queued;
				case EmailResultStatus.Rejected:
					return BulkEmailResponseCode.Rejected;
				case EmailResultStatus.Sent:
					return BulkEmailResponseCode.Sent;
				default:
					throw new InvalidCastException(status + " is not a defined value for enum type EmailResultStatus.");
			}
		}

		/// <summary>
		/// ##### ######### Action ### ####### ######## #########.
		/// </summary>
		public static void BulkEmail<T>(this IEnumerable<T> collection, Action<T> action) {
			foreach (var item in collection) {
				action.Invoke(item);
			}
		}

		/// <summary>
		/// ######### ######## ## ########## URL # ######### ### # ###### Base64.
		/// </summary>
		/// <param name="url">##### ### ######## ###########.</param>
		/// <param name="base64Data">###### Base64 ########## ###########.</param>
		/// <param name="mimeType">MIME ### ############ ###########.</param>
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
			} catch {}
		}

		/// <summary>
		/// ########## ###### ####### # ###### # ###### ######### ########.
		/// </summary>
		/// <param name="messageTemplate">##### #######.</param>
		/// <param name="messageImages">######## # #######.</param>
		/// <returns>###### # ######.</returns>
		public static int GetTemplateSize(string messageTemplate, List<image> messageImages) {
			int result = System.Text.ASCIIEncoding.Unicode.GetByteCount(messageTemplate);
			if (messageImages == null) {
				return result;
			}
			foreach (var image in messageImages) {
				result += System.Text.ASCIIEncoding.Unicode.GetByteCount(image.name);
				result += System.Text.ASCIIEncoding.Unicode.GetByteCount(image.type);
				result += System.Text.ASCIIEncoding.Unicode.GetByteCount(image.content);
			}
			return result;
		}

		/// <summary>
		/// ########## ###-### ## ######### SHA1.
		/// </summary>
		/// <param name="hashContent">###### ##### ### ############ ###-####.</param>
		/// <returns>### ### # ######### #### ### ############.</returns>
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
		/// ######### ######### ###-#### # ###-##### ############### ## ####### #####.
		/// </summary>
		/// <param name="hash">###-### (SHA1) # ######### #### ### ############.</param>
		/// <param name="hashContent">###### ##### ### ############ ###-####.</param>
		/// <returns>######### ###-### # ############### ###-###.</returns>
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
		/// Generates unique identifier from hash-code of <paramref name="source"/> using md5.
		/// </summary>
		/// <param name="source">Source string.</param>
		/// <returns>Unique identifier.</returns>
		public static Guid GetMD5HashGuid(string source) {
			byte[] hash = _md5.ComputeHash(Encoding.Default.GetBytes(source));
			Guid hashUId = new Guid(hash);
			hash = null;
			return hashUId;
		}

		#endregion

	}

	#endregion

	#region Interface: IStringCrypto

	/// <summary>
	/// ######### ########### ###### ########## # ###############.
	/// </summary>
	public interface IStringCrypto {
		string EncryptString(string message, string passphrase);
		string DecryptString(string message, string passphrase);
	}

	#endregion

	#region Class: SimpleCrypto

	/// <summary>
	/// ########## ######### 3DES.
	/// </summary>
	public class SimpleCrypto: IStringCrypto {

		#region Methods: Public

		/// <summary>
		/// ######### ########## ######.
		/// </summary>
		/// <param name="message">######### ######.</param>
		/// <param name="passphrase">####, # ####### ######## ########### ##########.</param>
		/// <returns>############# ######.</returns>
		public string EncryptString(string message, string passphrase) {
			byte[] results;
			UTF8Encoding utf8 = new UTF8Encoding();
			MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
			byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));
			using (var tdesAlgorithm = new TripleDESCryptoServiceProvider()) {
				tdesAlgorithm.Key = tdesKey;
				tdesAlgorithm.Mode = CipherMode.ECB;
				tdesAlgorithm.Padding = PaddingMode.PKCS7;
				byte[] dataToEncrypt = utf8.GetBytes(message);
				using (ICryptoTransform encryptor = tdesAlgorithm.CreateEncryptor()) {
					results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
				}
			}
			return Convert.ToBase64String(results);
		}

		/// <summary>
		/// ######### ############### ######.
		/// </summary>
		/// <param name="message">################ ######.</param>
		/// <param name="passphrase">####, # ####### ######## ########### ###############.</param>
		/// <returns>############## ######.</returns>
		public string DecryptString(string message, string passphrase) {
			byte[] results;
			UTF8Encoding utf8 = new UTF8Encoding();
			MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
			byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));
			using(var tdesAlgorithm = new TripleDESCryptoServiceProvider()) {
				tdesAlgorithm.Key = tdesKey;
				tdesAlgorithm.Mode = CipherMode.ECB;
				tdesAlgorithm.Padding = PaddingMode.PKCS7;
				byte[] dataToDecrypt = Convert.FromBase64String(message);
				using (ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor()) {
					results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
				}
			}
			return utf8.GetString(results);
		}

		#endregion

	}

	#endregion

	public enum WebHookEventType
	{
		Send,
		Hard_bounce,
		Soft_bounce,
		Open,
		Click,
		Spam,
		Unsub,
		Reject,
		Deferral,
		Inbound,
	}


	public enum WebHookMessageState
	{
		Sent,
		Rejected,
		Spam,
		Unsub,
		Bounced,
		[System.Runtime.Serialization.EnumMember(Value = "soft-bounced")] Soft_bounced,
		Deferred,
		Inbound,
	}
	
	public enum EmailResultStatus
	{
		Sent,
		Queued,
		Rejected,
		Invalid,
		Scheduled,
	}
}

