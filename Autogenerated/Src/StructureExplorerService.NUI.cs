namespace BPMSoft.Configuration.StructureExplorerService
{
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Web.Common;

	#region Class: SchemaCaptionConfig

	/// <summary>
	/// Column config for <see cref="StructureExplorerService"/> request methods.
	/// </summary>
	public class SchemaCaptionConfig {

		#region Properties: Public

		/// <summary>
		/// Gets or sets the name of the root schema for column path.
		/// </summary>
		/// <value>
		/// The name of the schema.
		/// </value>
		public string schemaName { get; set;}

		/// <summary>
		/// Gets or sets the column path.
		/// </summary>
		/// <value>
		/// The column path.
		/// </value>
		public string columnPath { get; set; }

		/// <summary>
		/// Gets or sets the column info key, returns in <see cref="SchemaCaptionResponseItem"/>.
		/// </summary>
		/// <value>
		/// The key.
		/// </value>
		public string key { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [need schema caption].
		/// </summary>
		/// <value>
		///   <c>true</c> if [need schema caption]; otherwise, <c>false</c>.
		/// </value>
		public bool needSchemaCaption { get; set; }

		#endregion

	}

	#endregion

	#region Class: SchemaCaptionResponseItem

	/// <summary>
	/// Column config for <see cref="StructureExplorerService"/> method response.
	/// </summary>
	public class SchemaCaptionResponseItem
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the column caption.
		/// </summary>
		/// <value>
		/// The column caption.
		/// </value>
		public string columnCaption { get; set; }

		/// <summary>
		/// Gets or sets the name of the column reference schema (for Lookups).
		/// </summary>
		/// <value>
		/// The name of the reference schema.
		/// </value>
		public string referenceSchemaName { get; set; }

		/// <summary>
		/// Gets or sets the name of the parent schema (for backward columns).
		/// </summary>
		/// <value>
		/// The name of the parent schema.
		/// </value>
		public string parentSchemaName { get; set; }

		/// <summary>
		/// Gets or sets the type of the data value.
		/// </summary>
		/// <value>
		/// The type of the data value.
		/// </value>
		public BPMSoft.Nui.ServiceModel.DataContract.DataValueType dataValueType { get; set; }

		/// <summary>
		/// Gets or sets the key of column info, relates to request key in <see cref="SchemaCaptionConfig"/>.
		/// </summary>
		/// <value>
		/// The key.
		/// </value>
		public string key { get; set; }

		#endregion

	}

	#endregion

	#region Class: StructureExplorerService

	/// <summary>
	/// Service for extracting columns info related to entity schema.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class StructureExplorerService : BaseService, IReadOnlySessionState
	{

		#region Methods: Public

		/// <summary>
		/// Gets the structured columns info (entity schema, caption) by column paths (including linked to the root
		/// entity lookup and backward link columns). 
		/// </summary>
		/// <param name="configJSON">The JSON serialized array of <see cref="SchemaCaptionConfig"/>.</param>
		/// <returns>Array with structured info for each column config.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetColumnPathCaption", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SchemaCaptionResponseItem[] GetColumnPathCaption(string configJSON) {
			SchemaCaptionConfig[] config = (SchemaCaptionConfig[])Common.Json.Json.Deserialize(configJSON,
				typeof(SchemaCaptionConfig[]));
			List<SchemaCaptionResponseItem> response = new List<SchemaCaptionResponseItem>();
			foreach (var configItem in config) {
				if (string.IsNullOrEmpty(configItem.schemaName)) {
					continue;
				}
				var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(configItem.schemaName);
				if (entitySchema == null) {
					continue;
				}
				if (configItem.needSchemaCaption) {
					response.Add(new SchemaCaptionResponseItem() {
						columnCaption = entitySchema.Caption.Value,
						key = configItem.key
					});
				}
				if (!string.IsNullOrEmpty(configItem.columnPath)) {
					var column = entitySchema.GetSchemaColumnByPath(configItem.columnPath);
					response.Add(new SchemaCaptionResponseItem() {
						columnCaption = entitySchema.GetSchemaColumnFullCaptionByPath(configItem.columnPath).Value,
						dataValueType = column.DataValueType.ToEnum(),
						referenceSchemaName = column.ReferenceSchema == null ? "" : column.ReferenceSchema.Name,
						parentSchemaName = column.ParentMetaSchema?.Name ?? "",
						key = configItem.key
					});
				}
			}
			return response.ToArray();
		}

		/// <summary>
		/// Determines whether the specified schema has aggregation columns for specified aggregation type.
		/// </summary>
		/// <param name="schemaName">Name of the schema.</param>
		/// <param name="aggregationType">Type of the aggregation type.</param>
		/// <returns>
		///<c>true</c> if the specified schema has aggregation columns; otherwise, <c>false</c>.
		/// </returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "HasAggregationColumns", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool HasAggregationColumns(string schemaName, string aggregationType) {
			if (string.IsNullOrEmpty(schemaName) || string.IsNullOrWhiteSpace(aggregationType)) {
				return false;
			}
			var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			if (entitySchema == null) {
				return false;
			}
			foreach (var column in entitySchema.Columns) {
				if (GetIsSupportedDataValueType(aggregationType, column)) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Determines whether the column supports the specified aggregation type.
		/// </summary>
		/// <param name="aggregationType">Type of the aggregation.</param>
		/// <param name="column">The column.</param>
		/// <returns>
		/// <c>true</c> if the specified column supports the aggregation type; otherwise, <c>false</c>.
		/// </returns>
		public bool GetIsSupportedDataValueType(string aggregationType, EntitySchemaColumn column) {
			if (column.DataValueType is BinaryDataValueType) {
				return false;
			}
			bool dataValueTypeIsNumeric = column.DataValueType is NumericDataValueType;
			switch (aggregationType) {
				case "Count":
					return true;
				case "Min":
				case "Max":
					return dataValueTypeIsNumeric || (column.DataValueType is DateTimeDataValueType);
				case "Sum":
				case "Avg":
					return dataValueTypeIsNumeric;
				default:
					return false;
			}
		}

		#endregion

	}

	#endregion
}
