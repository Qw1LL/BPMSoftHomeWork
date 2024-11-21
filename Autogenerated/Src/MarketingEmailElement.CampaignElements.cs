namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Process;

	#region Class: MarketingEmailElement

	/// <summary>
	/// Bulk email schema element in campaign.
	/// </summary>
	[DesignModeProperty(Name = "MarketingEmailId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = BulkEmailPropertyName)]
	[DesignModeProperty(Name = "AudienceSchemaName",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = AudienceSchemaPropertyName)]
	public class MarketingEmailElement : CampaignSchemaElement
	{

		#region Constants: Private

		private const string BulkEmailPropertyName = "MarketingEmailId";
		private const string AudienceSchemaPropertyName = "AudienceSchemaName";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="MarketingEmailElement"/>.
		/// </summary>
		public MarketingEmailElement() {
			ElementType = CampaignSchemaElementType.AsyncTask | CampaignSchemaElementType.Sessioned;
		}

		/// <summary>
		/// Constructor for <see cref="MarketingEmailElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="MarketingEmailElement"/>.</param>
		public MarketingEmailElement(MarketingEmailElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="MarketingEmailElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="MarketingEmailElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public MarketingEmailElement(MarketingEmailElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			MarketingEmailId = source.MarketingEmailId;
			AudienceSchemaName = source.AudienceSchemaName;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action {
			get {
				return CampaignConsts.CampaignLogTypeMailing;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of the bulk email.
		/// </summary>
		[MetaTypeProperty("{0F8BA709-452A-9EED-838C-0A750A84B9C4}")]
		public Guid MarketingEmailId { get; set; }

		/// <summary>
		/// Name of the email audience schema.
		/// </summary>
		[MetaTypeProperty("{627F73A6-0B2A-4A75-AEEB-FF900452224B}")]
		public string AudienceSchemaName { get; set; }

		
		#endregion

		#region Methods: Protected

		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case BulkEmailPropertyName:
					MarketingEmailId = reader.GetGuidValue();
					break;
				case AudienceSchemaPropertyName:
					AudienceSchemaName = reader.GetStringValue();
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
			writer.WriteValue(BulkEmailPropertyName, MarketingEmailId, Guid.Empty);
			writer.WriteValue(AudienceSchemaPropertyName, AudienceSchemaName, string.Empty);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the MarketingEmailElement.</returns>
		public override object Clone() {
			return new MarketingEmailElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the MarketingEmailElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new MarketingEmailElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new BulkEmailCampaignElement {
				UserConnection = userConnection,
				BulkEmailId = MarketingEmailId,
				AudienceSchemaName = AudienceSchemaName
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}
