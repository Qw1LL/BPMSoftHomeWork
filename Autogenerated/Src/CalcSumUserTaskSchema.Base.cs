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

	#region Class: CalcSumUserTask

	[DesignModeProperty(Name = "ParentSchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "25e62f475459470f9acab6410c643c48", CaptionResourceItem = "Parameters.ParentSchemaUId.Caption", DescriptionResourceItem = "Parameters.ParentSchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ChildSchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "25e62f475459470f9acab6410c643c48", CaptionResourceItem = "Parameters.ChildSchemaUId.Caption", DescriptionResourceItem = "Parameters.ChildSchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ParentColumnResultUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "25e62f475459470f9acab6410c643c48", CaptionResourceItem = "Parameters.ParentColumnResultUId.Caption", DescriptionResourceItem = "Parameters.ParentColumnResultUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ParentColumnRelationUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "25e62f475459470f9acab6410c643c48", CaptionResourceItem = "Parameters.ParentColumnRelationUId.Caption", DescriptionResourceItem = "Parameters.ParentColumnRelationUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ChildColumnUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "25e62f475459470f9acab6410c643c48", CaptionResourceItem = "Parameters.ChildColumnUId.Caption", DescriptionResourceItem = "Parameters.ChildColumnUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ParentColumnRelationValue", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "25e62f475459470f9acab6410c643c48", CaptionResourceItem = "Parameters.ParentColumnRelationValue.Caption", DescriptionResourceItem = "Parameters.ParentColumnRelationValue.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class CalcSumUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public CalcSumUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("25e62f47-5459-470f-9aca-b6410c643c48");
		}

		#endregion

		#region Properties: Public

		public virtual Guid ParentSchemaUId {
			get;
			set;
		}

		public virtual Guid ChildSchemaUId {
			get;
			set;
		}

		public virtual Guid ParentColumnResultUId {
			get;
			set;
		}

		public virtual Guid ParentColumnRelationUId {
			get;
			set;
		}

		public virtual Guid ChildColumnUId {
			get;
			set;
		}

		public virtual Guid ParentColumnRelationValue {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var parentSchema = entitySchemaManager.GetInstanceByUId(ParentSchemaUId);
			string parentSchemaName = parentSchema.Name;
			var parentSchemaColumns = parentSchema.Columns;
			string parentColumnResultName = parentSchemaColumns.FindByUId(ParentColumnResultUId).Name;
			
			var childSchema = entitySchemaManager.GetInstanceByUId(ChildSchemaUId);
			string childSchemaName = childSchema.Name;
			var childSchemaColumns = childSchema.Columns;
			string childColumnName = childSchemaColumns.FindByUId(ChildColumnUId).Name;
			string parentColumnRelationName = childSchemaColumns.FindByUId(ParentColumnRelationUId).ColumnValueName;
			
			Select selectSum = new Select(UserConnection).
				Column(Func.Sum(childColumnName)).
				From(childSchemaName).
				Where(parentColumnRelationName).IsEqual(Column.Parameter(ParentColumnRelationValue.ToString()))
			as Select;
			Update updateParent = new Update(UserConnection, parentSchemaName).
				Set(parentColumnResultName, Func.IsNull(Column.SubSelect(selectSum), Column.Const(0))).
				Where(childSchema.PrimaryColumn.Name).IsEqual(Column.Parameter(ParentColumnRelationValue.ToString())) as Update;
			updateParent.Execute();
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
			if (!HasMapping("ParentSchemaUId")) {
				writer.WriteValue("ParentSchemaUId", ParentSchemaUId, Guid.Empty);
			}
			if (!HasMapping("ChildSchemaUId")) {
				writer.WriteValue("ChildSchemaUId", ChildSchemaUId, Guid.Empty);
			}
			if (!HasMapping("ParentColumnResultUId")) {
				writer.WriteValue("ParentColumnResultUId", ParentColumnResultUId, Guid.Empty);
			}
			if (!HasMapping("ParentColumnRelationUId")) {
				writer.WriteValue("ParentColumnRelationUId", ParentColumnRelationUId, Guid.Empty);
			}
			if (!HasMapping("ChildColumnUId")) {
				writer.WriteValue("ChildColumnUId", ChildColumnUId, Guid.Empty);
			}
			if (!HasMapping("ParentColumnRelationValue")) {
				writer.WriteValue("ParentColumnRelationValue", ParentColumnRelationValue, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ParentSchemaUId":
					ParentSchemaUId = reader.GetGuidValue();
				break;
				case "ChildSchemaUId":
					ChildSchemaUId = reader.GetGuidValue();
				break;
				case "ParentColumnResultUId":
					ParentColumnResultUId = reader.GetGuidValue();
				break;
				case "ParentColumnRelationUId":
					ParentColumnRelationUId = reader.GetGuidValue();
				break;
				case "ChildColumnUId":
					ChildColumnUId = reader.GetGuidValue();
				break;
				case "ParentColumnRelationValue":
					ParentColumnRelationValue = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

