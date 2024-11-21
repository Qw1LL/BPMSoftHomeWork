namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CheckUniqueNumberValueUserTask

	[DesignModeProperty(Name = "EntitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "5f4f8d00f75043979ae2c043a7442f05", CaptionResourceItem = "Parameters.EntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ColumnUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "5f4f8d00f75043979ae2c043a7442f05", CaptionResourceItem = "Parameters.ColumnUId.Caption", DescriptionResourceItem = "Parameters.ColumnUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "NumberValue", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "5f4f8d00f75043979ae2c043a7442f05", CaptionResourceItem = "Parameters.NumberValue.Caption", DescriptionResourceItem = "Parameters.NumberValue.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Result", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "5f4f8d00f75043979ae2c043a7442f05", CaptionResourceItem = "Parameters.Result.Caption", DescriptionResourceItem = "Parameters.Result.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class CheckUniqueNumberValueUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public CheckUniqueNumberValueUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("5f4f8d00-f750-4397-9ae2-c043a7442f05");
		}

		#endregion

		#region Properties: Public

		public virtual Guid EntitySchemaUId {
			get;
			set;
		}

		public virtual Guid ColumnUId {
			get;
			set;
		}

		public virtual string NumberValue {
			get;
			set;
		}

		public virtual bool Result {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (string.IsNullOrEmpty(NumberValue)) {
				Result = true;
			} else {
				var entitySchemaManager = context.UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
				var entitySchema = entitySchemaManager.GetInstanceByUId(EntitySchemaUId) as EntitySchema;
				var entitySchemaName = entitySchema.Name;
				var columnName = entitySchema.Columns.GetByUId(ColumnUId).Name;
				var numberSelect = new BPMSoft.Core.DB.Select(context.UserConnection)
									.Column(BPMSoft.Core.DB.Func.Count(columnName)).As("NumberCount")
								.From(entitySchema.Name).Where(columnName).IsEqual(new QueryParameter(NumberValue)) as BPMSoft.Core.DB.Select;
				using (var dbExecutor = context.UserConnection.EnsureDBConnection()) {
					using (var reader = numberSelect.ExecuteReader(dbExecutor)) {
						if (reader.Read() && UserConnection.DBTypeConverter.DBValueToInt(reader[0]) > 0) {
							Result = false;
						} else {
							Result = true;
						}
					}
				}
			}
			return true;
		}

		#endregion

		#region Methods: Public

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
			if (!HasMapping("EntitySchemaUId")) {
				writer.WriteValue("EntitySchemaUId", EntitySchemaUId, Guid.Empty);
			}
			if (!HasMapping("ColumnUId")) {
				writer.WriteValue("ColumnUId", ColumnUId, Guid.Empty);
			}
			if (!HasMapping("NumberValue")) {
				writer.WriteValue("NumberValue", NumberValue, null);
			}
			if (!HasMapping("Result")) {
				writer.WriteValue("Result", Result, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "EntitySchemaUId":
					EntitySchemaUId = reader.GetGuidValue();
				break;
				case "ColumnUId":
					ColumnUId = reader.GetGuidValue();
				break;
				case "NumberValue":
					NumberValue = reader.GetStringValue();
				break;
				case "Result":
					Result = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

