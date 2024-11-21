namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;

	#region Class: CampaignBaseCrudObjectElement

	/// <summary>
	/// Campaign schema element to provide base CRUD operations on objects
	/// for selected entity schema unique name with specified column values.
	/// </summary>
	[DesignModeProperty(Name = "EntityName",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = EntityNamePropertyName)]
	[DesignModeProperty(Name = "ColumnValues",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = ColumnValuesPropertyName)]
	public abstract class CampaignBaseCrudObjectElement : CampaignSchemaElement, IFragmentSynchronizable
	{

		#region Constants: Private
		
		private const string EntityNamePropertyName = "EntityName";
		private const string ColumnValuesPropertyName = "ColumnValues";

		#endregion

		#region Constrsuctors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignBaseCrudObjectElement"/>.
		/// </summary>
		public CampaignBaseCrudObjectElement() {
			ElementType = CampaignSchemaElementType.AsyncTask | CampaignSchemaElementType.Sessioned;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignBaseCrudObjectElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignBaseCrudObjectElement"/>.</param>
		public CampaignBaseCrudObjectElement(CampaignBaseCrudObjectElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignBaseCrudObjectElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignBaseCrudObjectElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignBaseCrudObjectElement(CampaignBaseCrudObjectElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			EntityName = source.EntityName;
			_columnValuesJson = JsonConvert.SerializeObject(source.ColumnValues, new JsonSerializerSettings {
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});
		}

		#endregion

		#region Fields: Private

		/// <summary>
		/// String representation of selected column values.
		/// </summary>
		private string _columnValuesJson;

		#endregion

		/// <summary>
		/// Selected entity schema name for CRUD operations.
		/// </summary>
		[MetaTypeProperty("{982BE24F-5FE0-455A-92B8-D7B1FA789026}")]
		public string EntityName { get; set; }

		/// <summary>
		/// Selected entity column values for CRUD operations.
		/// </summary>
		[MetaTypeProperty("{6748092B-C03E-4810-91C6-8FC59F9557B7}")]
		public IEnumerable<CampaignCrudObjectColumnValue> ColumnValues {
			get => !string.IsNullOrWhiteSpace(_columnValuesJson)
				? JsonConvert.DeserializeObject<IEnumerable<CampaignCrudObjectColumnValue>>(_columnValuesJson)
				: Enumerable.Empty<CampaignCrudObjectColumnValue>();
			set => _columnValuesJson = JsonConvert.SerializeObject(value, new JsonSerializerSettings {
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});
		}

		#region Methods: Protected

		/// <summary>
		/// Reads MetaData values to properties.
		/// </summary>
		/// <param name="reader">Instance of the <see cref="DataReader"/> type.</param>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case EntityNamePropertyName:
					EntityName = reader.GetStringValue();
					break;
				case ColumnValuesPropertyName:
					_columnValuesJson = reader.GetStringValue();
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
			writer.WriteValue(EntityNamePropertyName, EntityName, default(string));
			writer.WriteValue(ColumnValuesPropertyName, _columnValuesJson, default(string));
		}

		/// <summary>
		/// Returns instance of specific for campaign signal element sync manager
		/// that contains logic to synchronize campaign participants.
		/// </summary>
		/// <returns>Instance of <see cref="ICampaignFragmentSyncManager"/>.</returns>
		public ICampaignFragmentSyncManager GetSyncManager() {
			return new CampaignCrudObjectFragmentSyncManager(ParentSchema.EntityId, UId);
		}

		#endregion

	}

	#endregion

}
