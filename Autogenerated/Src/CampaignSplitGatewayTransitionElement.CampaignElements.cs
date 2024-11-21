namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Process;

	#region Class: CampaignSplitGatewayTransitionElement

	[DesignModeProperty(Name = "TransitionId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = TransitionIdPropertyName)]
	public class CampaignSplitGatewayTransitionElement : SequenceFlowElement
	{

		#region Constants: Private

		private const string TransitionIdPropertyName = "TransitionId";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default ctor
		/// </summary>
		public CampaignSplitGatewayTransitionElement() {}

		/// <summary>
		/// Constructor of the clone.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignSplitGatewayTransitionElement"/>.</param>
		public CampaignSplitGatewayTransitionElement(CampaignSplitGatewayTransitionElement source)
			: this(source, null, null) {
		}

		/// <summary>
		/// Constructor of the copy.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignSplitGatewayTransitionElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignSplitGatewayTransitionElement(CampaignSplitGatewayTransitionElement source,
				Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema)
					: base(source, dictToRebind, parentSchema) {
			TransitionId = source.TransitionId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of transition per campaign schema, that is used for split distribution definition.
		/// </summary>
		[MetaTypeProperty("{ACAE8719-12A8-4D78-82E5-B0E77A6BF381}")]
		public virtual Guid TransitionId { get; set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// The overriden metadata reader.
		/// </summary>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case TransitionIdPropertyName:
					TransitionId = reader.GetGuidValue();
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
			writer.WriteValue(TransitionIdPropertyName, TransitionId, Guid.Empty);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the <see cref="CampaignSplitGatewayTransitionElement"/>.</returns>
		public override object Clone() {
			return new CampaignSplitGatewayTransitionElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the <see cref="CampaignSplitGatewayTransitionElement"/>.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignSplitGatewayTransitionElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates executable instance of conditional transition.
		/// </summary>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignSplitGatewayTransitionFlowElement {
				UserConnection = userConnection,
				TransitionId = TransitionId
			};
			InitializeCampaignProcessFlowElement(executableElement);
			InitializeCampaignTransitionFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

