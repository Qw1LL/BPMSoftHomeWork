namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign.StartSignal;
	using BPMSoft.Core.Process;

	#region Class: CampaignStartEventElement

	/// <summary>
	/// Start Event schema element.
	/// </summary>
	[DesignModeProperty(Name = "EventId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = EventPropertyName)]
	public class CampaignStartEventElement : CampaignStartSignalElement, ICampaignEventElement
	{

		#region Constants: Private

		private const string EventPropertyName = "EventId";

		#endregion

		#region Constructors: Public

		public CampaignStartEventElement() : base() {
		}

		public CampaignStartEventElement(CampaignStartEventElement source) : this(source, null, null) {
		}

		public CampaignStartEventElement(CampaignStartEventElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			EventId = source.EventId;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => CampaignConsts.CampaignLogTypeAddEventAudience;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of the event.
		/// </summary>
		[MetaTypeProperty("{7FB94535-9775-4F01-AB72-D355E06C8E8F}")]
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

		/// <summary>
		/// Produces concrete entity handler for start event.
		/// </summary>
		/// <returns>Instance of <see cref="ICampaignSignalEntityHandler"/>.</returns>
		protected override ICampaignSignalEntityHandler GetElementEntityHandler(UserConnection userConnection) =>
			new CampaignEventEntityHandler(userConnection);

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
		/// <returns>Cloned instance of the CampaignStartEventElement.</returns>
		public override object Clone() {
			return new CampaignStartEventElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the CampaignStartEventElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignStartEventElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates empty ProcessFlowElement instance only to add audience by signal.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignStartEventFlowElement {
				UserConnection = userConnection
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}
