namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Process;

	#region Class: AddCampaignParticipantElement

	/// <summary>
	/// Element that appends participants to campaign.
	/// </summary>
	[DesignModeProperty(Name = "IsRecurring",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = IsRecurringPropertyName)]
	[DesignModeProperty(Name = "RecurringFrequencyInDays",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = DaysNumberPropertyName)]
	[DesignModeProperty(Name = "Priority",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = PriorityPropertyName)]
	public class AddCampaignParticipantElement : BaseCampaignAudienceElement, IElementPriority
	{

		#region Constants: Private

		private const string IsRecurringPropertyName = "IsRecurring";
		private const string DaysNumberPropertyName = "RecurringFrequencyInDays";

		#endregion

		#region Constants: Protected

		protected const string PriorityPropertyName = "Priority";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="AddCampaignParticipantElement"/>.
		/// </summary>
		public AddCampaignParticipantElement() {
			ElementType = CampaignSchemaElementType.AddAudience;
		}

		/// <summary>
		/// Constructor for <see cref="AddCampaignParticipantElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="AddCampaignParticipantElement"/>.</param>
		public AddCampaignParticipantElement(AddCampaignParticipantElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="AddCampaignParticipantElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="AddCampaignParticipantElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public AddCampaignParticipantElement(AddCampaignParticipantElement source,
				Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema)
					: base(source, dictToRebind, parentSchema) {
			IsRecurring = source.IsRecurring;
			RecurringFrequencyInDays = source.RecurringFrequencyInDays;
			Priority = source.Priority;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => CampaignConsts.CampaignLogTypeAddAudience;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Flag which indicates that element can do recurring add from folder.
		/// </summary>
		[MetaTypeProperty("{7A5933A9-FFCE-418D-B9B1-71411F3229FA}")]
		public bool IsRecurring { get; set; }

		/// <summary>
		/// Number of days before participant will be added next time.
		/// </summary>
		[MetaTypeProperty("{DC69A425-409F-4F9B-9362-EDCEA5DEA2CE}")]
		public int RecurringFrequencyInDays { get; set; }

		/// <summary>
		/// Priority of add audience element execution.
		/// </summary>
		[MetaTypeProperty("{06E4E9F8-F195-4616-9AA0-19305BCE6C17}")]
		public int Priority { get; set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Reads MetaData values to properties.
		/// </summary>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case IsRecurringPropertyName:
					IsRecurring = reader.GetBoolValue();
					break;
				case DaysNumberPropertyName:
					RecurringFrequencyInDays = reader.GetValue<int>();
					break;
				case PriorityPropertyName:
					Priority = reader.GetIntValue();
					break;
				default:
					break;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Writes meta data values.
		/// </summary>
		/// <param name="writer">Instance of the <see cref="DataWriter"/> type.</param>
		public override void WriteMetaData(DataWriter writer) {
			base.WriteMetaData(writer);
			writer.WriteValue(IsRecurringPropertyName, IsRecurring, false);
			writer.WriteValue(DaysNumberPropertyName, typeof(int), RecurringFrequencyInDays, 0);
			writer.WriteValue(PriorityPropertyName, Priority, 0);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the AddCampaignParticipantElement.</returns>
		public override object Clone() {
			return new AddCampaignParticipantElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the AddCampaignParticipantElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new AddCampaignParticipantElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var audienceEntitySchemaInfo = GetAudienceEntitySchemaInfo(userConnection);
			var executableElement = new AddCampaignAudienceElement {
				IsRecurring = IsRecurring,
				RecurringFrequencyInDays = RecurringFrequencyInDays,
				FolderRecordId = FolderId,
				UserConnection = userConnection,
				Filter = Filter,
				HasFilter = HasFilter,
				AudienceEntityId = AudienceSchemaId,
				AudienceSchemaUId = audienceEntitySchemaInfo.schemaUId,
				AudienceEntitySchemaName = audienceEntitySchemaInfo.schemaName,
				AudienceEntityContactPath = audienceEntitySchemaInfo.contactColumnPath
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

