namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Process;

	#region Class: CampaignDeduplicatorElement

	/// <summary>
	/// Deduplicator schema element in campaign.
	/// </summary>
	[MetaType("{4875409B-DCF4-4246-B107-2536FACC318E}")]
	[DesignModeProperty(Name = "ColumnPath",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = ColumnPathPropertyName)]
	[DesignModeProperty(Name = "EntitySchemaUId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = EntitySchemaUIdPropertyName)]
	[DesignModeProperty(Name = "SuspendParticipantsWithEmptyValues",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = SuspendParticipantsWithEmptyValuesPropertyName)]
	public class CampaignDeduplicatorElement : CampaignSchemaElement
	{

		#region Constants: Private

		private const string ColumnPathPropertyName = "ColumnPath";
		private const string EntitySchemaUIdPropertyName = "EntitySchemaUId";
		private const string SuspendParticipantsWithEmptyValuesPropertyName = "SuspendParticipantsWithEmptyValues";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignDeduplicatorElement"/>.
		/// </summary>
		public CampaignDeduplicatorElement() {
			ElementType = CampaignSchemaElementType.AsyncTask;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignDeduplicatorElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignDeduplicatorElement"/>.</param>
		public CampaignDeduplicatorElement(CampaignDeduplicatorElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignDeduplicatorElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignDeduplicatorElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignDeduplicatorElement(CampaignDeduplicatorElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			EntitySchemaUId = source.EntitySchemaUId;
			ColumnPath = source.ColumnPath;
			SuspendParticipantsWithEmptyValues = source.SuspendParticipantsWithEmptyValues;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action {
			get {
				return CampaignConsts.CampaignLogTypeDeduplicator;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Entity schema identifier.
		/// </summary>
		[MetaTypeProperty("{3DB91DB7-D49B-4C67-9504-E2AEAE680887}")]
		public Guid EntitySchemaUId { get; set; }

		/// <summary>
		/// Path to column duplicates search by.
		/// </summary>
		[MetaTypeProperty("{07980A9E-2C22-4CE2-A469-23E50C1AC186}")]
		public string ColumnPath { get; set; }

		/// <summary>
		/// Defines if participants with empty data will be suspended.
		/// </summary>
		[MetaTypeProperty("{AA20CF16-B23B-4AE5-9DF6-283D897185C4}")]
		public bool SuspendParticipantsWithEmptyValues { get; set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Reads MetaData values to properties.
		/// </summary>
		/// <param name="reader">Instance of the <see cref="DataReader"/> type.</param>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case EntitySchemaUIdPropertyName:
					EntitySchemaUId = reader.GetGuidValue();
					break;
				case ColumnPathPropertyName:
					ColumnPath = reader.GetStringValue();
					break;
				case SuspendParticipantsWithEmptyValuesPropertyName:
					SuspendParticipantsWithEmptyValues = reader.GetBoolValue();
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
			writer.WriteValue(EntitySchemaUIdPropertyName, EntitySchemaUId, Guid.Empty);
			writer.WriteValue(ColumnPathPropertyName, ColumnPath, default(string));
			writer.WriteValue(SuspendParticipantsWithEmptyValuesPropertyName, SuspendParticipantsWithEmptyValues,
				false);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the MarketingEmailElement.</returns>
		public override object Clone() {
			return new CampaignDeduplicatorElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the MarketingEmailElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignDeduplicatorElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignDeduplicatorFlowElement {
				UserConnection = userConnection,
				Rule = new CampaignDeduplicatorRule {
					Name = EntitySchemaUId.ToString() + "_" + ColumnPath,
					EntitySchemaUId = EntitySchemaUId,
					ColumnPath = ColumnPath
				},
				SuspendParticipantsWithEmptyValues = SuspendParticipantsWithEmptyValues
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

