namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Process;

	#region Class: CampaignLandingElement

	/// <summary>
	/// Landing page schema element in campaign.
	/// </summary>
	[DesignModeProperty(Name = "LandingId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = LandingPropertyName)]
	public class CampaignLandingElement : CampaignSchemaElement
	{

		#region Constants: Private

		private const string LandingPropertyName = "LandingId";
		private const string AddAudienceExtensionSuffix = "AddAudience";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignLandingElement"/>.
		/// </summary>
		public CampaignLandingElement() {
			ElementType = CampaignSchemaElementType.AsyncTask;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignLandingElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignLandingElement"/>.</param>
		public CampaignLandingElement(CampaignLandingElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignLandingElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignLandingElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignLandingElement(CampaignLandingElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			LandingId = source.LandingId;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action {
			get {
				return CampaignConsts.CampaignLogTypeLanding;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of the landing.
		/// </summary>
		[MetaTypeProperty("{5044E8BE-EC68-4712-9D6F-F10BC3EEB1D7}")]
		public Guid LandingId { get; set; }

		#endregion

		#region Methods: Protected

		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case LandingPropertyName:
					LandingId = reader.GetGuidValue();
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
			writer.WriteValue(LandingPropertyName, LandingId, Guid.Empty);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the CampaignLandingElement.</returns>
		public override object Clone() {
			return new CampaignLandingElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the CampaignLandingElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignLandingElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignLandingFlowElement {
				UserConnection = userConnection,
				LandingId = LandingId
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}
