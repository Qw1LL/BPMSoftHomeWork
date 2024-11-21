namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Configuration.DynamicContent;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: BulkEmailSplitValidator

	/// <summary>
	/// Class that incapsulates logic for split test validation.
	/// </summary>
	public sealed class BulkEmailSplitValidator
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor to create instance of <see cref="BulkEmailSplitValidator"/>.
		/// </summary>
		/// <param name="userConnection">Current user connection instance.</param>
		public BulkEmailSplitValidator(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Public

		private DCTemplateRepository<DCTemplateModel> _templateRepository;

		/// <summary>
		/// Instance of <see cref="DCTemplateRepository<DCTemplateModel>">.
		/// </summary>
		public DCTemplateRepository<DCTemplateModel> TemplateRepository {
			get {
				return _templateRepository
					?? (_templateRepository = new DCTemplateRepository<DCTemplateModel>(_userConnection));
			}
			set {
				_templateRepository = value;
			}
		}

		/// <summary>
		/// An instance of the <see cref="MailingService"/> class.
		/// </summary>
		private MailingService _mailingService;
		public MailingService MailingService {
			get {
				return _mailingService ?? (_mailingService = GetMailingService());
			}
			set {
				_mailingService = value;
			}
		}

		#endregion

		#region Methods: Private

		private MailingService GetMailingService() {
			return ClassFactory.Get<MailingService>(new ConstructorArgument("userConnection", _userConnection));
		}

		private IEnumerable<Guid> GetBulkEmailIdentifiers(Guid splitTestId) {
			var resultCollection = new List<Guid>();
			var bulkEmailSelect = new Select(_userConnection)
				.Column("Id")
				.From(nameof(BulkEmail))
				.Where("SplitTestId")
					.IsEqual(Column.Parameter(splitTestId)) as Select;
			bulkEmailSelect.SpecifyNoLockHints();
			bulkEmailSelect.ExecuteReader(reader => {
				resultCollection.Add(reader.GetColumnValue<Guid>("Id"));
			});
			return resultCollection;
		}

		private string GetLczStringValue(string lczName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(
				_userConnection.Workspace.ResourceStorage, nameof(BulkEmailSplitValidator), localizableStringName);
			string value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		private bool IsEmptyTemplateExist(Guid splitTestId) {
			var isDCFeatureEnabled = _userConnection.GetIsFeatureEnabled("BulkEmailDynamicContentBuilder");
			var emptyHtmlBulkEmailIds = GetBulkEmailIdsWithEmptyHtml(splitTestId);
			if (emptyHtmlBulkEmailIds.Any() && isDCFeatureEnabled) {
				return CheckEmptyTemplates(emptyHtmlBulkEmailIds);
			}
			return emptyHtmlBulkEmailIds.Any();
		}

		private IEnumerable<Guid> GetBulkEmailIdsWithEmptyHtml(Guid splitTestId) {
			var emailIdsWithEmptyHtml = new List<Guid>();
			var selectCount = new Select(_userConnection)
				.Column("Id")
				.From("BulkEmail")
				.Where("SplitTestId").IsEqual(Column.Parameter(splitTestId))
				.And(Func.Len("TemplateBody")).IsEqual(Column.Parameter(0))
				as Select;
			selectCount.SpecifyNoLockHints();
			selectCount.ExecuteReader(reader => {
				emailIdsWithEmptyHtml.Add(reader.GetColumnValue<Guid>("Id"));
			});
			return emailIdsWithEmptyHtml;
		}

		private bool CheckEmptyTemplates(IEnumerable<Guid> bulkEmailIds) {
			var repositoryReadOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
				TemplateReadOptions = DCTemplateReadOption.ExcludeAttributes
					| DCTemplateReadOption.ExcludeReplicaHtmlContent
			};
			foreach (var bulkEmailId in bulkEmailIds) {
				var existingTemplate = TemplateRepository.ReadByRecordId(bulkEmailId, repositoryReadOptions);
				if (existingTemplate == null || existingTemplate.Id.IsEmpty()) {
					return true;
				}
			}
			return false;
		}

		private bool HasBulkEmailsWithIncorrectStatus(Guid splitTestId) {
			var selectCount = new Select(_userConnection)
				.Column(Func.Count("Id"))
				.From("BulkEmail")
				.Where("SplitTestId").IsEqual(Column.Parameter(splitTestId)).And()
				.OpenBlock("StatusId").IsNotEqual(Column.Parameter(MarketingConsts.BulkEmailStatusPlannedId))
					.And("StatusId").IsNotEqual(Column.Parameter(MarketingConsts.BulkEmailStatusStartPlanedId))
				.CloseBlock() as Select;
			selectCount.SpecifyNoLockHints();
			var count = selectCount.ExecuteScalar<int>();
			return count > 0;
		}

		private IEnumerable<string> GetBulkEmailsNamesInDraftStatus(Guid splitTestId) {
			var selectCount = new Select(_userConnection)
				.Column ("Name")
				.From("BulkEmail")
				.Where("SplitTestId").IsEqual(Column.Parameter(splitTestId))
				.And("StatusId").IsEqual(Column.Parameter(MarketingConsts.BulkEmailStatusDraftId))
				as Select;
			selectCount.SpecifyNoLockHints();
			var result = new List<string>();
			using(var dbExecutor = _userConnection.EnsureDBConnection()) {
				using(var reader = selectCount.ExecuteReader(dbExecutor)) {
					var uidColumnIndex = reader.GetOrdinal("Name");
					while(reader.Read()) {
						var name = reader.GetString(uidColumnIndex);
						result.Add(name);
					}
				}
			}
			return result;
		}

		private BulkEmailSplitValidationResult PingMailingProvider() {
			if (!MailingService.PingProvider()) {
				var pingFailedMessage = GetLczStringValue("PingFailedMessage");
				return new BulkEmailSplitValidationResult(pingFailedMessage);
			}
			return new BulkEmailSplitValidationResult();
		}

		private BulkEmailSplitValidationResult ValidateMessages(Guid splitTestId) {
			var identifiers = GetBulkEmailIdentifiers(splitTestId);
			var response = MailingService.ValidateMessages(identifiers.ToArray());
			if (!response.Success) {
				return new BulkEmailSplitValidationResult(response.ErrorInfo.Message);
			}
			return new BulkEmailSplitValidationResult();
		}

		private BulkEmailSplitValidationResult ValidateBulkEmailStatuses(Guid splitTestId) {
			var draftEmailNames = GetBulkEmailsNamesInDraftStatus(splitTestId);
			if (draftEmailNames.Any()) {
				var statusErrorMessage = GetLczStringValue("StartTestEmailDraftMessage");
				var formattedNames = GetFormattedNamesForMessage(draftEmailNames);
				return new BulkEmailSplitValidationResult(string.Format(statusErrorMessage, formattedNames));
			}
			if (HasBulkEmailsWithIncorrectStatus(splitTestId)) {
				var statusErrorMessage = GetLczStringValue("StartTestEmailAlreadyRunMessage");
				return new BulkEmailSplitValidationResult(statusErrorMessage);
			}
			return new BulkEmailSplitValidationResult();
		}

		private string GetFormattedNamesForMessage(IEnumerable<string> draftEmailNames) {
			var formattedNames = new StringBuilder();
			var nameSplitter = ", ";
			foreach (var draftEmailName in draftEmailNames) {
				formattedNames.Append($"\"{draftEmailName}\"{nameSplitter}");
			}
			formattedNames.Remove(formattedNames.Length - nameSplitter.Length, nameSplitter.Length);
			return formattedNames.ToString();
		}

		private BulkEmailSplitValidationResult ValidateTemplates(Guid splitTestId) {
			if (IsEmptyTemplateExist(splitTestId)) {
				var emptyTemplateMessage = GetLczStringValue("EmptyTemplateExistMessage");
				return new BulkEmailSplitValidationResult(emptyTemplateMessage);
			}
			return new BulkEmailSplitValidationResult();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates current split test to be sent.
		/// </summary>
		/// <param name="splitTestId">Unique identifier of split test to validate.</param>
		/// <returns>Returns success result if all parameters are valid. Otherwise returns error result.</returns>
		public BulkEmailSplitValidationResult Validate(Guid splitTestId) {
			var pingMailingProviderResult = PingMailingProvider();
			if (!pingMailingProviderResult.Success) {
				return pingMailingProviderResult;
			}
			var validateMessagesResult = ValidateMessages(splitTestId);
			if (!validateMessagesResult.Success) {
				return validateMessagesResult;
			}
			var validateStatusesResult = ValidateBulkEmailStatuses(splitTestId);
			if (!validateStatusesResult.Success) {
				return validateStatusesResult;
			}
			var validateTemplatesResult = ValidateTemplates(splitTestId);
			if (!validateTemplatesResult.Success) {
				return validateTemplatesResult;
			}
			return new BulkEmailSplitValidationResult();
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSplitValidationResult

	/// <summary>
	/// Class to describe split test validation result.
	/// </summary>
	public class BulkEmailSplitValidationResult
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="BulkEmailSplitValidationResult"/> with success result.
		/// </summary>
		public BulkEmailSplitValidationResult() {
			Success = true;
		}

		/// <summary>
		/// Constructor for <see cref="BulkEmailSplitValidationResult"/> with error result.
		/// </summary>
		/// <param name="message">Validation result message.</param>
		public BulkEmailSplitValidationResult(string message) {
			Success = false;
			Message = message;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Validation result.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Validation result message.
		/// </summary>
		public string Message { get; set; }

		#endregion

	}

	#endregion

}

