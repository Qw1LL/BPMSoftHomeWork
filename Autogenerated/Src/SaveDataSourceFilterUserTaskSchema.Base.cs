namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.IO;
	using System.Text;

	#region Class: SaveDataSourceFilterUserTask

	[DesignModeProperty(Name = "DataSource", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15dcd24fb49b4c289c88bbb615bcef56", CaptionResourceItem = "Parameters.DataSource.Caption", DescriptionResourceItem = "Parameters.DataSource.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FilterName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15dcd24fb49b4c289c88bbb615bcef56", CaptionResourceItem = "Parameters.FilterName.Caption", DescriptionResourceItem = "Parameters.FilterName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StoringEntitySchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15dcd24fb49b4c289c88bbb615bcef56", CaptionResourceItem = "Parameters.StoringEntitySchemaId.Caption", DescriptionResourceItem = "Parameters.StoringEntitySchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StoringColumnUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15dcd24fb49b4c289c88bbb615bcef56", CaptionResourceItem = "Parameters.StoringColumnUId.Caption", DescriptionResourceItem = "Parameters.StoringColumnUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "StoringPrimaryColumnValue", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "15dcd24fb49b4c289c88bbb615bcef56", CaptionResourceItem = "Parameters.StoringPrimaryColumnValue.Caption", DescriptionResourceItem = "Parameters.StoringPrimaryColumnValue.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SaveDataSourceFilterUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public SaveDataSourceFilterUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("15dcd24f-b49b-4c28-9c88-bbb615bcef56");
		}

		#endregion

		#region Properties: Public

		public virtual Object DataSource {
			get;
			set;
		}

		public virtual string FilterName {
			get;
			set;
		}

		public virtual Guid StoringEntitySchemaId {
			get;
			set;
		}

		public virtual Guid StoringColumnUId {
			get;
			set;
		}

		public virtual Guid StoringPrimaryColumnValue {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var dataSource = DataSource as BPMSoft.UI.WebControls.Controls.DataSource;
			if (dataSource == null	|| StoringEntitySchemaId == Guid.Empty || StoringColumnUId == Guid.Empty
					|| StoringPrimaryColumnValue == Guid.Empty) {
				return true;
			}
			var serializedString = GetSerializedFilter(dataSource);
			UpdateData(serializedString);
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual string GetSerializedFilter(BPMSoft.UI.WebControls.Controls.DataSource dataSource) {
			if (string.IsNullOrEmpty(FilterName)) {
				FilterName = "FilterEdit";
			}
			var filter = dataSource.CurrentStructure.Filters.FindByName(FilterName);
			var jsonConverter = new DataSourceFiltersJsonConverter(UserConnection, dataSource);
			return Json.Serialize(filter, jsonConverter);
		}

		public virtual void UpdateData(string serializedString) {
			Stream stream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(serializedString));
			stream.Position = 0;
			var manager = UserConnection.GetSchemaManager("EntitySchemaManager") as BPMSoft.Core.Entities.EntitySchemaManager;
			var entitySchema = manager.GetInstanceByUId(StoringEntitySchemaId);
			Entity entity = entitySchema.CreateEntity(UserConnection);
			var valueColumn = entitySchema.Columns.GetByUId(StoringColumnUId);
			if (entity.FetchFromDB(entitySchema.GetPrimaryColumnName(), StoringPrimaryColumnValue)){
				entity.SetStreamValue(valueColumn.ColumnValueName, stream);
				entity.Save();
			}
		}

		public virtual void UpdateFiltersRightExprMetaDataByParameterValue(Process process, DataSourceFilterCollection filters) {
			foreach (var filter in filters) {
				if (filter is DataSourceFilterCollection) {
					UpdateFiltersRightExprMetaDataByParameterValue(process, (DataSourceFilterCollection)filter);
					continue;
				}	
				var dataSourcefilter = (DataSourceFilter)filter;
				if (dataSourcefilter.RightExpression == null) {
					continue;
				}
				if (dataSourcefilter.RightExpression.Type == DataSourceFilterExpressionType.Custom) {
					dataSourcefilter.RightExpression.Type = DataSourceFilterExpressionType.Parameter;
					if (dataSourcefilter.RightExpression.Parameters.Count == 2) {
						var parameters = dataSourcefilter.RightExpression.Parameters;
						var metaPath = parameters[1].Value;
						parameters[1].Value = process.GetParameterValueByMetaPath((string)metaPath);
						parameters.RemoveAt(0);
					}
					if (dataSourcefilter.SubFilters != null && dataSourcefilter.SubFilters.Count > 0) {
						UpdateFiltersRightExprMetaDataByParameterValue(process, dataSourcefilter.SubFilters);
					}
				}
			}
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (UseFlowEngineMode) {
				if (DataSource != null) {
					if (DataSource.GetType().IsSerializable || DataSource.GetType().GetInterface("ISerializable") != null) {
						writer.WriteSerializableObjectValue("DataSource", DataSource, null);
					}
				}
			}
			if (!HasMapping("FilterName")) {
				writer.WriteValue("FilterName", FilterName, null);
			}
			if (!HasMapping("StoringEntitySchemaId")) {
				writer.WriteValue("StoringEntitySchemaId", StoringEntitySchemaId, Guid.Empty);
			}
			if (!HasMapping("StoringColumnUId")) {
				writer.WriteValue("StoringColumnUId", StoringColumnUId, Guid.Empty);
			}
			if (!HasMapping("StoringPrimaryColumnValue")) {
				writer.WriteValue("StoringPrimaryColumnValue", StoringPrimaryColumnValue, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "DataSource":
					if (!UseFlowEngineMode) {
						break;
					}
					DataSource = reader.GetSerializableObjectValue();
				break;
				case "FilterName":
					FilterName = reader.GetStringValue();
				break;
				case "StoringEntitySchemaId":
					StoringEntitySchemaId = reader.GetGuidValue();
				break;
				case "StoringColumnUId":
					StoringColumnUId = reader.GetGuidValue();
				break;
				case "StoringPrimaryColumnValue":
					StoringPrimaryColumnValue = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

