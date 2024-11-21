namespace BPMSoft.Configuration.Mailing 
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core;
	using SysSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: CESMailingTemplate

	/// <summary>
	/// Represents class to working with CES mailing template.
	/// </summary>
	public class CESMailingTemplate : IMailingTemplateWithHeaders 
	{

		#region Constants: Private

		/// <summary>
		/// Pattern for name of the template.
		/// </summary>
		private const string NamePattern = "{0}({1})";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly BulkEmail _bulkEmail;
		private readonly BulkEmailMacroParser _macroParser;
		private string _checksum;
		private string _templateSubject;
		private string _content;
		private string _senderName;
		private string _fromEmail;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates empty instance of the <see cref="CESMailingTemplate"/>.
		/// </summary>
		/// <param name="userConnection">Instance of the user connection.</param>
		/// <param name="bulkEmail">Instance of the bulk email.</param>
		/// <param name="macroParser">Instance of the macros helper.</param>
		public CESMailingTemplate(UserConnection userConnection, BulkEmail bulkEmail,
			BulkEmailMacroParser macroParser) {
			_userConnection = userConnection;
			_bulkEmail = bulkEmail;
			_macroParser = macroParser;
		}

		#endregion

		#region Properties: Private

		private MacrosHelperV2 _macrosHelperV2 = null;
		private MacrosHelperV2 MacrosHelperV2 {
			get => _macrosHelperV2 ?? (_macrosHelperV2 = new MacrosHelperV2());
			set => _macrosHelperV2 = value;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name of the template.
		/// </summary>
		public string Name {
			get => string.Format(NamePattern, TemplateSubject, _bulkEmail.Id.ToString("N"));
		}

		/// <summary>
		/// Template subject.
		/// </summary>
		public string TemplateSubject {
			get => _templateSubject ?? (_templateSubject = _bulkEmail?.TemplateSubject);
			private set => _templateSubject = value;
		}

		/// <summary>
		/// Content of the template.
		/// </summary>
		public string Content {
			get => _content ?? (_content = _bulkEmail?.TemplateBody);
			set => _content = value;
		}

		/// <summary>
		/// List of message images.
		/// </summary>
		public IEnumerable<Base64Image> InlineImages { get; protected set; }

		/// <summary>
		/// List of macros included in template.
		/// </summary>
		public List<MacrosInfo> MacrosCollection { get; protected set; }

		/// <summary>
		/// Template checksum.
		/// </summary>
		public string Checksum {
			get { return _checksum ?? (_checksum = GetCheckSum()); }
		}

		/// <summary>
		/// Gets or sets the replica identifier.
		/// </summary>
		public Guid ReplicaId { get; set; }

		public string SenderName {
			get => _senderName ?? (_senderName = _bulkEmail.SenderName);
			private set => _senderName = value;
		}

		public string SenderEmail {
			get => _fromEmail ?? (_fromEmail = _bulkEmail.SenderEmail);
			private set => _fromEmail = value;
		}

		private Dictionary<string, string> _trackedAliases = null;
		public Dictionary<string, string> TrackedAliases {
			get => _trackedAliases ?? (_trackedAliases = new Dictionary<string, string>());
			private set => _trackedAliases = value;
		}

		#endregion

		#region Methods: Private

		private void InitInlineImages(IEnumerable<Base64Image> images) {
			InlineImages = images;
		}

		private string GetCheckSum() {
			var subject = TemplateSubject ?? string.Empty;
			var senderName = SenderName ?? string.Empty;
			var senderEmail = SenderEmail ?? string.Empty;
			var checksumValues = subject + senderName + senderEmail + Content;
			byte[] data;
			using (var hash = MD5.Create()) {
				data = hash.ComputeHash(Encoding.UTF8.GetBytes(checksumValues));
			}
			var result = new StringBuilder(data.Length * 2);
			foreach (var b in data) {
				result.Append(b.ToString("x2"));
			}
			return result.ToString();
		}

		private void InitContent() {
			InitMacrosCollectionFromText();
			bool isFeatureEnabled = _userConnection.GetIsFeatureEnabled("FromEmailFromNameMacros");
			if (isFeatureEnabled) {
				SetTrackedMacrosFromHeaders();
			}
			TemplateSubject = ReplaceBpmCrmMacroByAlias(TemplateSubject);
			SetContentValue();
		}

		private void SetContentValue() {
			var bulkEmailId = _bulkEmail.Id;
			var parsers = GetImageParsers();
			var templateSrc = ReplaceBpmCrmMacroByAlias(Content);
			if (_userConnection.GetIsFeatureEnabled("OutboundCampaign")) {
				templateSrc = BulkEmailHyperlinkHelper.ModifyTemplate(templateSrc);
			}
			var images =
				MailingHTMLTemplateParser.ExtractInlineImages(templateSrc, parsers);
			InitInlineImages(images.Values);
			templateSrc = MailingHTMLTemplateParser.ReplaceInlineImagesByContentId(templateSrc, images);
			if (!string.IsNullOrEmpty(templateSrc)) {
				var utmData = BulkEmailUtmHelper.ConvertToUtmData(_bulkEmail, templateSrc);
				var bulkEmailRId = BulkEmailQueryHelper.GetBulkEmailRId(bulkEmailId, _userConnection);
				templateSrc = BulkEmailUtmHelper.GetTemplateCodeWithUtmLabel(utmData, bulkEmailRId);
			}
			Content = templateSrc;
		}

		private void SetTrackedMacrosFromHeaders() {
			AddTrackedAlias(MailingConsts.FromNameMacroKey, SenderName);
			AddTrackedAlias(MailingConsts.FromEmailMacroKey, SenderEmail);
		}

		private void AddTrackedAlias(string macroKey, string macroAlias) {
			var trackedMacros = MacrosHelperV2.ExtractMacrosCollectionFromText(macroAlias);
			var trackedMacroCode = trackedMacros.FirstOrDefault()?.Code;
			if (string.IsNullOrEmpty(trackedMacroCode)) {
				return;
			}
			var macroItem = MacrosCollection.FirstOrDefault(macro => macro.Code == trackedMacroCode);
			if (macroItem != null){
				TrackedAliases[macroKey] = macroItem.Alias;
			}
		}

		private void InitMacrosCollectionFromText() {
			var combinedTextWithMacros = TemplateSubject + " " + Content + " " + SenderName + " " + SenderEmail;
				MacrosCollection = _macroParser.GetMacrosCollection(combinedTextWithMacros).ToList();
		}

		private string ReplaceBpmCrmMacroByAlias(string content) {
			return _macroParser.ReplaceMacros(content, MacrosCollection);
		}

		private void OverrideTemplateHeadersFromReplica(UserConnection userConnection, Guid replicaId) {
			var replicaHeaders = GetBulkEmailReplicaHeaders(userConnection, replicaId);
			if (replicaHeaders == null) {
				return;
			}
			TemplateSubject = replicaHeaders.Subject;
			SenderName = replicaHeaders.SenderName;
			SenderEmail = replicaHeaders.SenderEmail;
		}

		private void OverrideFromEmailHeader() {
			var senderEmailMacros = MacrosHelperV2.ExtractMacrosCollectionFromText(SenderEmail);
			if (senderEmailMacros.Any()) {
				SenderEmail = SysSettings.GetValue(_userConnection, "DefaultESPEmail") as string;
			}
		}

		private BulkEmailReplicaHeaders GetBulkEmailReplicaHeaders(UserConnection userConnection, Guid replicaId) {
			var replicaHeaders = userConnection.EntitySchemaManager.GetInstanceByName(nameof(BulkEmailReplicaHeaders))
				.CreateEntity(userConnection);
			var fetchResult = replicaHeaders.FetchFromDB(nameof(BulkEmailReplicaHeaders.DCReplica), replicaId,
				new[] {
				nameof(BulkEmailReplicaHeaders.SenderName),
				nameof(BulkEmailReplicaHeaders.SenderEmail),
				nameof(BulkEmailReplicaHeaders.Subject)
			});
			return fetchResult ? replicaHeaders as BulkEmailReplicaHeaders : null;
		}

		#endregion

		#region Methods: Protected

		protected virtual IEnumerable<IBase64ImageParser> GetImageParsers() {
			return new IBase64ImageParser[] {
				new Base64ImageParser(),
				new FileServiceBase64ImageParser(_userConnection)
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initializes properties of current instance.
		/// </summary>
		public void Init() {
			OverrideTemplateHeadersFromReplica(_userConnection, ReplicaId);
			InitContent();
			bool isFeatureEnabled = _userConnection.GetIsFeatureEnabled("FromEmailFromNameMacros");
			if (isFeatureEnabled) {
				OverrideFromEmailHeader();
			}
		}

		#endregion

	}

	#endregion
}
