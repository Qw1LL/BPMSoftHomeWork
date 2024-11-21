namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common;
	using System.Collections.Generic;
	using BPMSoft.Core.Factories;
	using System.Text;

	#region Class: DeduplicationActionHelper

	public class DeduplicationActionHelper
	{

		#region Constants: Private

		private const string FindDuplicateProcedurePattern = "tsp_Find{0}Duplicate";

		private const string MergeProcedurePattern = "Merge{0}";

		private const int CommonSqlExceptionCode = -1;

		private const int DescriptionTypeStringLength = 250;

		private const int SubjectCaptionTypeStringLength = 500;

		private const string InitialResultsTableSuffix = "DuplicateSearchResult";

		private const string RecordIdColumnNamePattern = "{0}Id";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private readonly string _schemaName;

		private IActionLocker _locker;

		private IConversationProvider _conversationProvider;

		#endregion

		#region Properties: Protected

		protected IActionLocker Locker {
			get {
				return _locker ?? (_locker = new DeduplicationActionLocker(_userConnection));
			}
			set {
				_locker = value;
			}
		}

		protected IConversationProvider ConversationProvider {
			get {
				return _conversationProvider ?? (_conversationProvider = new ConversationProvider(_userConnection));
			}
			set {
				_conversationProvider = value;
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public DeduplicationActionHelper(string schemaName, UserConnection userConnection) {
			_schemaName = schemaName;
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private string GetRecordIdColumnName(string schemaName) {
			return string.Format(RecordIdColumnNamePattern, schemaName);
		}

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

		#region Methods: Protected

		/// <summary>
		/// Creates reminding in case of successfull search.
		/// </summary>
		/// <param name="duplicateRecordIds">Collection of duplicate entity id.</param>
		protected virtual void CreateSuccessReminding() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, _schemaName);
			var duplicatesCountColumn = esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Count, "Id"));
			esq.UseAdminRights = false;
			Select esqSelect = esq.GetSelectQuery(_userConnection);
			string initialResultsTableName =
				string.Format("{0}{1}", _schemaName, InitialResultsTableSuffix);
			string recordIdColumnName = GetRecordIdColumnName(_schemaName);
			Select initialSelect = new Select(_userConnection)
					.Column(recordIdColumnName)
				.From(initialResultsTableName).As(initialResultsTableName) as Select;
			initialSelect.Where(initialSelect.SourceExpression.Alias, recordIdColumnName)
				.IsEqual(esqSelect.SourceExpression.Alias, "Id");
			esqSelect.Where().Exists(initialSelect);
			var countEntity = esq.GetEntityCollection(_userConnection)[0];
			int duplicatesCount = countEntity.GetTypedColumnValue<int>(duplicatesCountColumn.Name);
			string message = string.Empty;
			if (duplicatesCount > 0) {
				message = string.Format(_userConnection.GetLocalizableString("DeduplicationActionHelper",
					"SuccessfullDuplicatesSearchMessage"), duplicatesCount);
			} else {
				message = _userConnection.GetLocalizableString("DeduplicationActionHelper",
					"NoDuplicatesFoundMessage");
			}
			CreateReminding(message);
		}

		
		/// <summary>
		/// Creates reminding whith custom text.
		/// </summary>
		/// <param name="remindingText">Text to be shown in reminding</param>
		protected virtual void CreateReminding(string remindingText) {
			Reminding remindingEntity = new Reminding(_userConnection);
			var manager = _userConnection.GetSchemaManager("EntitySchemaManager");
			var targetSchema = manager.FindItemByName(_schemaName);
			manager = _userConnection.GetSchemaManager("ClientUnitSchemaManager");
			var loaderSchema = manager.FindItemByName("DuplicatesSearchNotificationTargetLoader");
			string subject = _schemaName;
			DateTime userDateTime = _userConnection.CurrentUser.GetCurrentDateTime();
			Guid userContactId = _userConnection.CurrentUser.ContactId;
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
					"SysEntitySchema", targetSchema.UId
				},
			};
			string description = GetRemindingDescription(_userConnection);
			string hash = GetRemindingHash(condition);
			if (!string.IsNullOrEmpty(remindingText)) {
				subject = GetRemindingSubject(_userConnection, _schemaName, remindingText);
			}
			if (!remindingEntity.FetchFromDB(new Dictionary<string, object> { { "Hash", hash } }, false)) {
				remindingEntity.SetDefColumnValues();
			}
			remindingText = TruncateString(remindingText, DescriptionTypeStringLength);
			subject = TruncateString(subject, SubjectCaptionTypeStringLength);
			remindingEntity.SetColumnValue("ModifiedOn", userDateTime);
			remindingEntity.SetColumnValue("AuthorId", userContactId);
			remindingEntity.SetColumnValue("ContactId", userContactId);
			remindingEntity.SetColumnValue("SourceId", RemindingConsts.RemindingSourceAuthorId);
			remindingEntity.SetColumnValue("RemindTime", userDateTime);
			remindingEntity.SetColumnValue("Description", description);
			remindingEntity.SetColumnValue("SubjectCaption", subject);
			remindingEntity.SetColumnValue("NotificationTypeId", RemindingConsts.NotificationTypeNotificationId);
			remindingEntity.SetColumnValue("Hash", hash);
			remindingEntity.SetColumnValue("SysEntitySchemaId", targetSchema.UId);
			remindingEntity.SetColumnValue("LoaderId", loaderSchema.UId);
			remindingEntity.SetColumnValue("IsRead", false);
			remindingEntity.Save();
		}

		protected virtual string GetRemindingDescription(UserConnection userConnection) {
			return userConnection.GetLocalizableString("DeduplicationActionHelper",
				"RemindingDescription");
		}

		protected virtual string GetRemindingSubject(UserConnection userConnection, string schemaName, string remindingText) {
			string caption = userConnection.GetLocalizableString("DeduplicationActionHelper",
				  schemaName + "DuplicatesSearchCaption");
			return string.Format("{0}: {1}", caption, remindingText);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Begin search process.
		/// </summary>
		public void BeginSearch() {
			Guid operationId = DeduplicationConsts.SearchOperationId;
			bool isFeatureEnable = _userConnection.GetIsFeatureEnabled("FindDuplicatesOnSave");
			string tspFindDuplicateName = string.Format(FindDuplicateProcedurePattern, _schemaName);
			if (isFeatureEnable) {
				tspFindDuplicateName = string.Format(FindDuplicateProcedurePattern, String.Empty);
			}
			if (!Locker.CanExecute(operationId, _schemaName)) {
				return;
			}
			Guid conversationId = ConversationProvider.BeginConversation(tspFindDuplicateName);
			try {
				Locker.SetLockState(conversationId, _schemaName, operationId, true);
				var storedProcedure = new StoredProcedure(_userConnection, tspFindDuplicateName);
				if (isFeatureEnable) {
					storedProcedure.WithParameter("schemaName", _schemaName);
					storedProcedure.WithParameter("xmlRows", String.Empty);
					storedProcedure.WithParameter("sysAdminUnit", _userConnection.CurrentUser.Id);
				}
				storedProcedure.Execute();
				ConversationProvider.EndConversation(conversationId);
				CreateSuccessReminding();
			} catch (Exception e) {
				ConversationProvider.EndConversationWithError(conversationId, CommonSqlExceptionCode, e.Message);
				CreateReminding(_userConnection.GetLocalizableString("DeduplicationActionHelper", "FaildDuplicatesSearchMessage"));
			} finally {
				Locker.SetLockState(conversationId, _schemaName, operationId, false);
			}
		}

		/// <summary>
		/// Begin merge process.
		/// </summary>
		/// <param name="groupId">Identifier of the group of search results.</param>
		/// <param name="duplicateRecordIds">Collection of duplicate entity id.</param>
		/// <param name="resolvedConflicts">Config for resolving conflicts.</param>
		public void BeginMerge(int groupId, List<Guid> duplicateRecordIds, Dictionary<string, string> resolvedConflicts) {
			string mergeProcedure = string.Format(MergeProcedurePattern, _schemaName);
			if (!Locker.CanExecute(DeduplicationConsts.SearchOperationId, _schemaName)) {
				return;
			}
			var handler = ClassFactory.Get<DeduplicationMergeHandler>(
				new ConstructorArgument("userConnection", _userConnection));
			handler.MergeEntityDublicates(_schemaName, groupId, duplicateRecordIds, resolvedConflicts);
		}

		#endregion


	}

	#endregion
}
