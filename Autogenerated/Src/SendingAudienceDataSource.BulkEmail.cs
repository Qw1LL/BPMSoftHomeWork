namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: SendingAudienceDataSource

	public class SendingAudienceDataSource
	{

		#region Constants: Private

		private const int QueryBatchSize = 3000;

		#endregion

		#region Fields: Private

		private readonly Lazy<Dictionary<Guid, int>> _duplicatingRecipients;

		private readonly BulkEmail _email;

		private readonly UserConnection _userConnection;

		private readonly string _betAlias = "BET";

		private Lazy<Dictionary<Guid, int>> _limitedRecipients;

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
		public SendingAudienceDataSource(UserConnection userConnection, BulkEmail email) {
			_userConnection = userConnection;
			_email = email;
			_duplicatingRecipients = new Lazy<Dictionary<Guid, int>>(GetAudienceDuplicateResponses);
			InitCommunicationRestrictions(userConnection, _email.Id);
		}

		#endregion

		#region Methods: Private

		private Dictionary<string, string> DeserializeMacrosFromReader(string macrosString) {
			var macros = string.IsNullOrEmpty(macrosString) ? new Dictionary<string, string>() : JsonConvert
				.DeserializeObject<IEnumerable<BulkEmailMacroInfo>>(macrosString)
				.ToDictionary(x => x.Alias, x => x.Value);
			return macros;
		}

		private Dictionary<Guid, int> GetAudienceDuplicateResponses() {
			var result = new Dictionary<Guid, int>();
			var checkDuplicates =
				(bool)Core.Configuration.SysSettings.GetValue(_userConnection, "PreventDuplicatesSending");
			if (!checkDuplicates) {
				return result;
			}
			var rootSelect = new Select(_userConnection)
				.Column("BulkEmailTarget", "MandrillId").As("RecipientUId")
				.Column(new WindowQueryFunction(new RowNumberQueryFunction(), new QueryColumnExpression("EmailAddress"),
					new QueryColumnExpression("BulkEmailTarget", "Id"))).As("RowNum")
				.From("BulkEmailTarget")
				.Where("BulkEmailTarget", "BulkEmailId")
				.IsEqual(Column.Parameter(_email.Id))
				.And("BulkEmailTarget", "BulkEmailResponseId")
				.IsEqual(Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId));
			var responseSelect = new Select(_userConnection).Column("RecipientUId")
				.From(rootSelect).As("SourceRecords")
				.Where("RowNum").IsGreater(Column.Parameter(1)) as Select;
			responseSelect.SpecifyNoLockHints();
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var reader = responseSelect.ExecuteReader(dbExecutor)) {
					var uidColumnIndex = reader.GetOrdinal("RecipientUId");
					while (reader.Read()) {
						var id = reader.GetGuid(uidColumnIndex);
						result[id] = (int)MailingResponseCode.Duplicated;
					}
				}
			}
			return result;
		}

		private QueryCase GetDefaultResponseCase(bool isSystemEmail) {
			var responseCase = new QueryCase();
			MailingDbUtilities.AddWhenCondition(responseCase, "Contact", "Email", QueryConditionType.Equal,
				string.Empty, (int)MailingResponseCode.CanceledBlankEmail);
			MailingDbUtilities.AddWhenCondition(responseCase, "Contact", "Email", QueryConditionType.IsNull, null,
				(int)MailingResponseCode.CanceledBlankEmail);
			MailingDbUtilities.AddWhenCondition(responseCase, "Contact", "IsNonActualEmail", QueryConditionType.Equal,
				true, (int)MailingResponseCode.CanceledInvalidEmail);
			if (!isSystemEmail) {
				MailingDbUtilities.AddWhenCondition(responseCase, "Contact", "DoNotUseEmail", QueryConditionType.Equal,
					true, (int)MailingResponseCode.CanceledDoNotUseEmail);
				MailingDbUtilities.AddWhenCondition(responseCase, "BulkEmailSubscription", "BulkEmailSubsStatusId",
					QueryConditionType.Equal, MailingConsts.BulkEmailContactUnsubscribed,
					(int)MailingResponseCode.CanceledUnsubscribedByType);
			}
			responseCase.ElseExpression =
				new QueryColumnExpression(Column.Parameter((int)MailingResponseCode.PostedProvider));
			return responseCase;
		}

		private int ValidateInitialResponseCode(BulkEmailRecipientInfo recipientInfo) {
			var initialResponseCode = recipientInfo.InitialResponseCode;
			if (initialResponseCode != (int)MailingResponseCode.PostedProvider) {
				return initialResponseCode;
			}
			if (!MailingUtilities.ValidateEmail(recipientInfo.EmailAddress)) {
				initialResponseCode = (int)MailingResponseCode.CanceledIncorrectEmail;
			} else if (_limitedRecipients.Value.ContainsKey(recipientInfo.ContactId)) {
				initialResponseCode = _limitedRecipients.Value[recipientInfo.ContactId];
			} else if (_duplicatingRecipients.Value.ContainsKey(recipientInfo.Id)) {
				initialResponseCode = _duplicatingRecipients.Value[recipientInfo.Id];
			} else if (recipientInfo.ReplicaId == Guid.Empty) {
				initialResponseCode = (int)MailingResponseCode.CanceledTemplateNotFound;
			}
			return initialResponseCode;
		}

		private Select GetInnerSelectFromBet(DateTime? addedBefore, int? recipientBatchSize) {
			var batchSize = recipientBatchSize ?? QueryBatchSize;
			var betSelect = new Select(_userConnection).Top(batchSize)
				.Column("BulkEmailTarget", "EmailAddress").As("EmailAddress")
				.Column("BulkEmailTarget", "ContactId").As("ContactId")
				.Column("BulkEmailTarget", "MandrillId").As("MandrillId")
				.Column("BulkEmailTarget", "LinkedEntityId").As("LinkedEntityId")
				.From("BulkEmailTarget")
				.Where("BulkEmailTarget", "BulkEmailId")
				.IsEqual(Column.Parameter(_email.Id))
				.And("BulkEmailTarget", "BulkEmailResponseId")
				.IsEqual(Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId)) as Select;
			if (addedBefore.HasValue) {
				betSelect.And("BulkEmailTarget", "CreatedOn").IsLessOrEqual(Column.Parameter(addedBefore.Value));
			}
			return betSelect;
		}

		private Select GetRecipientsBatchSelect(DateTime? addedBefore, int? recipientBatchSize) {
			var innerSelectFromBet = GetInnerSelectFromBet(addedBefore, recipientBatchSize);
			var responseCase = GetDefaultResponseCase(_email.IsSystemEmail);
			var recipientSelect = new Select(_userConnection)
				.Column(_betAlias, "EmailAddress").As("EmailAddress")
				.Column(_betAlias, "ContactId").As("ContactId")
				.Column(_betAlias, "MandrillId").As("MandrillId")
				.Column(_betAlias, "LinkedEntityId").As("LinkedEntityId")
				.Column("BulkEmailRecipientReplica", "DCReplicaId").As("DCReplicaId")
				.Column("BulkEmailRecipientMacro", "Macros").As("Macros")
				.Column(responseCase).As("InitialResponseCode")
				.From(innerSelectFromBet).As(_betAlias)
				.LeftOuterJoin("BulkEmailRecipientReplica")
				.On("BulkEmailRecipientReplica", "RecipientId")
				.IsEqual(_betAlias, "MandrillId")
				.LeftOuterJoin("BulkEmailRecipientMacro")
				.On("BulkEmailRecipientMacro", "RecipientUId").IsEqual(_betAlias, "MandrillId")
				.LeftOuterJoin("BulkEmailSubscription")
				.On("BulkEmailSubscription", "ContactId").IsEqual(_betAlias, "ContactId")
				.And("BulkEmailSubscription", "BulkEmailTypeId").IsEqual(Column.Parameter(_email.TypeId))
				.InnerJoin("Contact")
				.On("Contact", "Id").IsEqual(_betAlias, "ContactId") as Select;
			recipientSelect.SpecifyNoLockHints();
			return recipientSelect;
		}
		private void InitCommunicationRestrictions(UserConnection userConnection, Guid bulkEmailId) {
			_limitedRecipients = new Lazy<Dictionary<Guid, int>>(() => {
				var isFeatureEnabled = userConnection.GetIsFeatureEnabled("EmailCommunicationRestriction");
				if (!isFeatureEnabled || _email.IsSystemEmail) {
					return new Dictionary<Guid, int>();
				}
				var args = new[] {
					new ConstructorArgument("userConnection", userConnection),
					new ConstructorArgument("bulkEmailId", bulkEmailId),
					new ConstructorArgument("sessionId", Guid.Empty)
				};
				var communicationRestrictionRepository =
					ClassFactory.Get<EmailCommunicationRestrictionRepository>(args);
				return communicationRestrictionRepository.GetAudienceLimitResponses();
			});
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the audience of the bulk email to send.
		/// </summary>
		/// <returns>List of <see cref="IMessageRecipientInfo"/>.</returns>
		public IEnumerable<BulkEmailRecipientInfo> GetAudience(DateTime? addedBefore = null, int? recipientBatchSize = null) {
			var recipientsSelect = GetRecipientsBatchSelect(addedBefore, recipientBatchSize);
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var reader = recipientsSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var macrosString = reader.GetColumnValue<string>("Macros");
						var macros = DeserializeMacrosFromReader(macrosString);
						var recipientInfo = new BulkEmailRecipientInfo {
							Id = reader.GetColumnValue<Guid>("MandrillId"),
							ContactId = reader.GetColumnValue<Guid>("ContactId"), 
							LinkedEntityId = reader.GetColumnValue<Guid>("LinkedEntityId"),
							EmailAddress = reader.GetColumnValue<string>("EmailAddress")?.Trim(),
							Macros = macros,
							ReplicaId = reader.GetColumnValue<Guid>("DCReplicaId"),
							InitialResponseCode = reader.GetColumnValue<int>("InitialResponseCode")
						};
						recipientInfo.InitialResponseCode = ValidateInitialResponseCode(recipientInfo);
						yield return recipientInfo;
					}
				}
			}
		}

		#endregion

	}

	#endregion

}

