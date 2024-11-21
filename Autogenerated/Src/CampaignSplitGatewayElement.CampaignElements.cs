namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Process;

	#region Class: CampaignSplitGatewayElement

	/// <summary>
	/// Split gateway schema element in campaign.
	/// </summary>
	[DesignModeProperty(Name = "Distribution",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = DistributionPropertyName)]
	[DesignModeProperty(Name = "UseCustomDistribution",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = UseCustomDistributionPropertyName)]
	public class CampaignSplitGatewayElement : CampaignSchemaElement
	{

		#region Constants: Private

		private const string DistributionPropertyName = "Distribution";
		private const string UseCustomDistributionPropertyName = "UseCustomDistribution";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignSplitGatewayElement"/>.
		/// </summary>
		public CampaignSplitGatewayElement() {
			ElementType = CampaignSchemaElementType.AsyncTask;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignSplitGatewayElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignSplitGatewayElement"/>.</param>
		public CampaignSplitGatewayElement(CampaignSplitGatewayElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignSplitGatewayElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignSplitGatewayElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignSplitGatewayElement(CampaignSplitGatewayElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			_distributionJson = Common.Json.Json.Serialize(source.Distribution, true);
			UseCustomDistribution = source.UseCustomDistribution;
		}

		#endregion

		#region Fields: Private

		private string _distributionJson;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => CampaignConsts.CampaignLogTypeSplitGateway;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Pairs of campaign transition element Id and it's expected percentage of audience to transfer.
		/// </summary>
		[MetaTypeProperty("{030AEF75-CFF3-49E3-BB63-23E06D5F59F4}")]
		public Dictionary<Guid, int> Distribution => !string.IsNullOrWhiteSpace(_distributionJson)
			? Common.Json.Json.Deserialize<Dictionary<Guid, int>>(_distributionJson)
			: new Dictionary<Guid, int>();

		/// <summary>
		/// Flag to indicate that distribution is customized for flows.
		/// </summary>
		[MetaTypeProperty("{62EEC2E6-2EDB-4598-8858-326E44D803DE}")]
		public bool UseCustomDistribution { get; set; }

		#endregion

		#region Methods: Protected

		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case DistributionPropertyName:
					_distributionJson = reader.GetValue<string>();
					break;
				case UseCustomDistributionPropertyName:
					UseCustomDistribution = reader.GetBoolValue();
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
			writer.WriteValue(DistributionPropertyName, _distributionJson, null);
			writer.WriteValue(UseCustomDistributionPropertyName, UseCustomDistribution, false);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the <see cref="CampaignSplitGatewayElement"/>.</returns>
		public override object Clone() {
			return new CampaignSplitGatewayElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the <see cref="CampaignSplitGatewayElement"/>.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignSplitGatewayElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignSplitGatewayFlowElement {
				UserConnection = userConnection,
				Distribution = Distribution,
				UseCustomDistribution = UseCustomDistribution
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}
