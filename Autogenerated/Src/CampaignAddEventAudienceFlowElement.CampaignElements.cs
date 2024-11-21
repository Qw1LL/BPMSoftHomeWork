namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.DB;

	#region Class: CampaignAddEventAudienceFlowElement

	/// <summary>
	/// Executable add event audience element in campaign.
	/// </summary>
	public class CampaignAddEventAudienceFlowElement : BaseCampaignAudienceFlowElement
	{

		#region Constants: Private

		private const string EventTargetTableName = "EventTarget";

		#endregion

		#region Properties: Protected

		/// <summary>
		/// ContactId column name alias in origin select for add audience in campaign.
		/// </summary>
		protected override string SourceSelectContactIdColumnName { get; set; } = "ContactId";

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of event.
		/// </summary>
		public Guid EventId { get; set; }

		#endregion

		#region Methods: Private

		private Select GetEventAudienceSelect() {
			var select = new Select(UserConnection)
				.Column(EventTargetTableName, "Id").As("LinkedEntityId")
				.Column(EventTargetTableName, SourceSelectContactIdColumnName).As("ContactId")
				.From(EventTargetTableName)
				.Where(EventTargetTableName, "EventId").IsEqual(Column.Parameter(EventId)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Defines <see cref="AudienceQuery"/> for add new participants in campaign.
		/// </summary>
		/// <returns><see cref="Select"/> query which returns contacts for add in campaign.</returns>
		protected override Select GetContactsSelect() => GetEventAudienceSelect();

		#endregion

	}

	#endregion

}

