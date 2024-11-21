namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: BaseCampaignAudienceElement

	/// <summary>
	/// Element that appends participants to campaign.
	/// </summary>
	[DesignModeProperty(Name = "FolderId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = FolderPropertyName)]
	[DesignModeProperty(Name = "AudienceSchemaId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = AudienceSchemaIdPropertyName)]
	[DesignModeProperty(Name = "HasFilter",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = HasFilterPropertyName)]
	[DesignModeProperty(Name = "Filter",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = FilterPropertyName)]
	public class BaseCampaignAudienceElement : CampaignSchemaElement
	{

		#region Constants: Protected

		/// <summary>
		/// Folder identifier property name.
		/// </summary>
		protected const string FolderPropertyName = "FolderId";
		protected const string AudienceSchemaIdPropertyName = "AudienceSchemaId";
		protected readonly Guid ContactSchemaUId = new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3");
		private const string HasFilterPropertyName = "HasFilter";
		private const string FilterPropertyName = "Filter";

		#endregion

		#region Constructors: Protected

		/// <summary>
		/// Default constructor for <see cref="BaseCampaignAudienceElement"/>.
		/// </summary>
		protected BaseCampaignAudienceElement() {
		}

		/// <summary>
		/// Constructor for <see cref="BaseCampaignAudienceElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="BaseCampaignAudienceElement"/>.</param>
		protected BaseCampaignAudienceElement(BaseCampaignAudienceElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="BaseCampaignAudienceElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="BaseCampaignAudienceElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		protected BaseCampaignAudienceElement(BaseCampaignAudienceElement source,
				Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema)
					: base(source, dictToRebind, parentSchema) {
			FolderId = source.FolderId;
			AudienceSchemaId = source.AudienceSchemaId;
			HasFilter = source.HasFilter;
			Filter = source.Filter;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of binded contact folder.
		/// </summary>
		[MetaTypeProperty("{7A6D4FAC-C43A-4036-AC1F-520A1D39DDBE}")]
		public Guid FolderId { get; set; }

		/// <summary>
		/// Audience schema identifier. Is one of the <see cref="CampaignSignalEntity"/>.
		/// </summary>
		[MetaTypeProperty("{66DC1950-6FBF-4DC6-A888-DECCC26601D2}")]
		public Guid AudienceSchemaId { get; set; }

		/// <summary>
		/// Flag to indicate that processing is by filter.
		/// </summary>
		[MetaTypeProperty("{B75B55BE-6EEC-4625-B197-A5628381BE53}")]
		public bool HasFilter { get; set; }

		/// <summary>
		/// Filter to process audience.
		/// </summary>
		[MetaTypeProperty("{959BFC4B-94AB-4C11-95D3-1281729F0843}")]
		public string Filter { get; set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Reads MetaData values to properties.
		/// </summary>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case FolderPropertyName:
					FolderId = reader.GetGuidValue();
					break;
				case AudienceSchemaIdPropertyName:
					AudienceSchemaId = reader.GetGuidValue();
					break;
				case HasFilterPropertyName:
					HasFilter = reader.GetBoolValue();
					break;
				case FilterPropertyName:
					Filter = reader.GetStringValue();
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
			writer.WriteValue(FolderPropertyName, FolderId, Guid.Empty);
			writer.WriteValue(AudienceSchemaIdPropertyName, AudienceSchemaId, Guid.Empty);
			writer.WriteValue(HasFilterPropertyName, HasFilter, false);
			writer.WriteValue(FilterPropertyName, Filter, string.Empty);
		}

		/// <summary>
		/// Returns entity schema name and contact column path due to selected audience schema.
		/// </summary>
		public virtual (string schemaName, string contactColumnPath, Guid schemaUId) GetAudienceEntitySchemaInfo(
				UserConnection userConnection) {
			if (AudienceSchemaId.IsEmpty()) {
				return ("Contact", "Id", ContactSchemaUId);
			}
			var select = new Select(userConnection)
				.Column("ss", "Name")
				.Column("cse", "EntityObjectId")
				.Column("cse", "ContactColumn")
				.From("CampaignSignalEntity").As("cse")
				.InnerJoin("SysSchema").As("ss").On("cse", "EntityObjectId").IsEqual("ss", "UId")
				.Where("cse", "Id").IsEqual(Column.Parameter(AudienceSchemaId)) as Select;
			select.ExecuteSingleRecord(reader => (reader.GetColumnValue<string>("Name"),
				reader.GetColumnValue<string>("ContactColumn"), reader.GetColumnValue<Guid>("EntityObjectId")),
				out (string, string, Guid) audienceSchemaInfo);
			return audienceSchemaInfo;
		}

		#endregion

	}

	#endregion

}

