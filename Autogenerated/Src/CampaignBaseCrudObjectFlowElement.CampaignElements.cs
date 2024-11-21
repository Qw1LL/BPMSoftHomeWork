namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Campaigns;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: CampaignBaseCrudObjectFlowElement

	/// <summary>
	/// Executable base crud object element at campaign.
	/// </summary>
	public abstract class CampaignBaseCrudObjectFlowElement : CampaignBaseEnqueuesFlowElement
	{

		#region Properties: Protected

		/// <summary>
		/// Wrapper for <see cref="BaseCampaignAudience.CampaignParticipantTableName"/>.
		/// </summary>
		protected string CampaignParticipantTableName =>
			(CampaignAudience as BaseCampaignAudience).CampaignParticipantTableName;

		/// <summary>
		/// Message for entity settings not found exception.
		/// </summary>
		protected virtual string EntitySettingsNotFoundExceptionMessage
			=> UserConnection.GetLocalizableString(GetType().Name, "EntitySettingsNotFound");
		
		#endregion

		#region Properties: Public

		/// <summary>
		/// The name of entity schema that is used by campaign CRUD object elements.
		/// </summary>
		public string EntityName { get; set; }

		/// <summary>
		/// Current campaign time zone.
		/// </summary>
		public TimeZoneInfo TimeZoneOffset { get; set; }

		/// <summary>
		/// Instance of <see cref="MacrosInterpreter"/>.
		/// </summary>
		private MacrosInterpreter _macrosInterpreter;
		public MacrosInterpreter MacrosInterpreter {
			get => _macrosInterpreter ??
				(_macrosInterpreter = GetMacrosInterpreter());
			set => _macrosInterpreter = value;
		}

		/// <summary>
		/// List of column value models that are used by campaign CRUD object elements.
		/// </summary>
		public IEnumerable<CampaignCrudObjectColumnValue> ColumnValues { get; set; }

		#endregion

		#region Methods: Private

		private MacrosInterpreter GetMacrosInterpreter() {
			var interpreter = ClassFactory.Get<MacrosInterpreter>(
				new ConstructorArgument("userConnection", UserConnection));
			interpreter.TimeZoneOffset = TimeZoneOffset;
			return interpreter;
		}

		private ColumnValue CreateColumnValue(CampaignCrudObjectColumnValue columnValue, Entity entity) {
			var entityColumn = entity.Schema.Columns.FindByUId(columnValue.ColumnUId);
			return new ColumnValue {
				ColumnUId = columnValue.ColumnUId,
				DataValueType = entityColumn.DataValueType,
				Value = columnValue.Value,
				HasMacrosValue = columnValue.HasMacrosValue
			};
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Checks if column is allowed to be used by this element.
		/// </summary>
		/// <param name="allowedColumns">Allowed columns from lookup.</param>
		/// <param name="restrictedColumns">Restricted columns from lookup.</param>
		/// <param name="columnToCheck">Column name to check.</param>
		/// <returns>
		/// <c>true</c> if <paramref name="allowedColumns"/> contains <paramref name="columnToCheck"/> or '*'.
		/// And <paramref name="restrictedColumns"/> does not contain <paramref name="columnToCheck"/>.
		/// </returns>
		protected bool GetIsColumnAllowed(string allowedColumns, string restrictedColumns, Guid columnUId,
				Entity entity) {
			var asterisk = "*";
			var entityColumn = entity.Schema.Columns.FindByUId(columnUId);
			var columnToCheck = entityColumn?.Name;
			if (string.IsNullOrWhiteSpace(allowedColumns) || string.IsNullOrWhiteSpace(columnToCheck)) {
				return false;
			}
			var columnsList = allowedColumns.Split(',').Select(x => x.Trim());
			var exceptList = new List<string>();
			if (!string.IsNullOrWhiteSpace(restrictedColumns)) {
				exceptList = restrictedColumns.Split(',').Select(x => x.Trim()).ToList();
			}
			return (columnsList.Contains(asterisk) || columnsList.Contains(columnToCheck))
				&& !exceptList.Contains(columnToCheck);
		}

		/// <summary>
		/// Updates status for a single campaign participant.
		/// </summary>
		/// <param name="participantId">Identifier of campaignparticipant.</param>
		/// <param name="statusId">Identifier of campaign participant status.</param>
		protected void UpdateParicipantStatus(Guid participantId, Guid statusId) =>
			new Update(UserConnection, CampaignParticipantTable)
				.Set("StatusId", Column.Parameter(statusId))
				.Where("Id").IsEqual(Column.Parameter(participantId)).Execute();

		/// <summary>
		/// Returns pairs of campaign participants and related contacts.
		/// </summary>
		/// <returns>Collection of type <see cref="Dictionary{CampaignParticipantId, ContactId}"/>.</returns>
		protected Dictionary<Guid, Guid> GetAudienceContacts() {
			var audienceSelect = GetAudienceQuery() as Select;
			audienceSelect.Column(CampaignParticipantTableName, "ContactId");
			var audienceByContact = new Dictionary<Guid, Guid>();
			audienceSelect.ExecuteReader(x => {
				audienceByContact.Add(x.GetColumnValue<Guid>("Id"), x.GetColumnValue<Guid>("ContactId"));
			});
			return audienceByContact;
		}

		/// <summary>
		/// Fills columns with values using <see cref="ColumnValues"/> collection with applied macros values.
		/// </summary>
		/// <param name="entity">Reference to entity object.</param>
		/// <param name="contactId">Unique identifier of campaign participant contact.</param>
		/// <param name="allowedColumns">List of allowed columns from lookup.</param>
		/// <param name="restrictedColumns">List of restricted columns from lookup.</param>
		protected virtual void FillEntityColumns(Entity entity, Guid contactId, string allowedColumns,
				string restrictedColumns) {
			if (ColumnValues == null || string.IsNullOrWhiteSpace(allowedColumns)) {
				return;
			}
			var context = new ColumnValuesIteratorContext {
				TimeZoneOffset = TimeZoneOffset
			};
			var columnValues = ColumnValues
				.Select(x => CreateColumnValue(x, entity))
				.Where(x => GetIsColumnAllowed(allowedColumns, restrictedColumns, x.ColumnUId, entity))
				.ToList();
			context.MacrosValues.AddRange(MacrosInterpreter.GetMacrosValues(columnValues, contactId));
			context.ColumnValues.AddRange(columnValues);
			var iterator = new ColumnValuesIterator();
			iterator.Process(context);
			foreach (var column in context.Results) {
				var columnValue = column.Value;
				var entityColumn = entity.Schema.Columns.FindByUId(columnValue.ColumnUId);
				entity.SetColumnValue(entityColumn, columnValue.Value);
			}
		}

		#endregion

	}

	#endregion

}

