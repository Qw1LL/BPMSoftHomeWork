namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign.StartSignal;
	using BPMSoft.Core.Process;

	#region Class: CampaignStartLandingElement

	/// <summary>
	/// Start Landing schema element.
	/// </summary>
	[DesignModeProperty(Name = "LandingId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = LandingPropertyName)]
	public class CampaignStartLandingElement : CampaignStartSignalElement
	{

		#region Constants: Private

		private const string LandingPropertyName = "LandingId";

		#endregion

		#region Constructors: Public

		public CampaignStartLandingElement() : base() {
		}

		public CampaignStartLandingElement(CampaignStartLandingElement source) : this(source, null, null) {
		}

		public CampaignStartLandingElement(CampaignStartLandingElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			LandingId = source.LandingId;
			SignalEntityId = source.LandingId;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action {
			get {
				return CampaignConsts.CampaignLogTypeAddLandingAudience;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of the landing.
		/// </summary>
		[MetaTypeProperty("{3054E8BE-BC68-2712-1D6F-610BC3EEB1D8}")]
		public Guid LandingId { get; set; }

		#endregion

		#region Methods: Protected

		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case LandingPropertyName:
					LandingId = reader.GetGuidValue();
					SignalEntityId = LandingId;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Produces concrete entity handler for start landing.
		/// </summary>
		/// <returns>Instance of <see cref="ICampaignSignalEntityHandler"/>.</returns>
		protected override ICampaignSignalEntityHandler GetElementEntityHandler(UserConnection userConnection) =>
			new CampaignLandingEntityHandler(userConnection);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Writes meta data values.
		/// </summary>
		/// <param name="writer">Instance of the <see cref="DataWriter"/> type.</param>
		public override void WriteMetaData(DataWriter writer) {
			SignalEntityId = LandingId;
			base.WriteMetaData(writer);
			writer.WriteValue(LandingPropertyName, LandingId, Guid.Empty);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the CampaignStartLandingElement.</returns>
		public override object Clone() {
			return new CampaignStartLandingElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the CampaignStartLandingElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignStartLandingElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates empty ProcessFlowElement instance only to add audience by signal.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignStartLandingFlowElement {
				UserConnection = userConnection
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}
