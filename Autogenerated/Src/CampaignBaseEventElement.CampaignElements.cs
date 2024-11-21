namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Process;

	#region Interface: ICampaignEventElement

	/// <summary>
	/// Describes functionality for event schema element in campaign.
	/// </summary>
	public interface ICampaignEventElement
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier of the event.
		/// </summary>
		Guid EventId { get; set; }

		#endregion

	}

	#endregion

	#region Class: CampaignBaseEventElement

	/// <summary>
	/// Base event schema element in campaign.
	/// </summary>
	[DesignModeProperty(Name = "EventId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = EventPropertyName)]
	public class CampaignBaseEventElement : CampaignSchemaElement, ICampaignEventElement
	{

		#region Constants: Private

		private const string EventPropertyName = "EventId";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignBaseEventElement"/>.
		/// </summary>
		public CampaignBaseEventElement() {
			ElementType = CampaignSchemaElementType.AsyncTask;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignBaseEventElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignBaseEventElement"/>.</param>
		public CampaignBaseEventElement(CampaignBaseEventElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignBaseEventElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignBaseEventElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignBaseEventElement(CampaignBaseEventElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			EventId = source.EventId;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => CampaignConsts.CampaignLogTypeEvent;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of the event.
		/// </summary>
		[MetaTypeProperty("{4E0452E5-2B1E-4A95-98CA-858CEEE6F8C9}")]
		public Guid EventId { get; set; }

		#endregion

		#region Methods: Protected

		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case EventPropertyName:
					EventId = reader.GetGuidValue();
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
			writer.WriteValue(EventPropertyName, EventId, Guid.Empty);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the <see cref="CampaignBaseEventElement"/>.</returns>
		public override object Clone() {
			return new CampaignBaseEventElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the <see cref="CampaignBaseEventElement"/>.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignBaseEventElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignEventFlowElement() {
				UserConnection = userConnection,
				EventId = EventId
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

