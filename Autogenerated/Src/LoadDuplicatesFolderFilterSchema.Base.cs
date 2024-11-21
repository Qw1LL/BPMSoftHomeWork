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

	#region Class: LoadDuplicatesFolderFilter

	[DesignModeProperty(Name = "DataSource", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1e3195d9976c421b85705207023cf352", CaptionResourceItem = "Parameters.DataSource.Caption", DescriptionResourceItem = "Parameters.DataSource.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DuplicatesTableName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1e3195d9976c421b85705207023cf352", CaptionResourceItem = "Parameters.DuplicatesTableName.Caption", DescriptionResourceItem = "Parameters.DuplicatesTableName.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class LoadDuplicatesFolderFilter : ProcessUserTask
	{

		#region Constructors: Public

		public LoadDuplicatesFolderFilter(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("1e3195d9-976c-421b-8570-5207023cf352");
		}

		#endregion

		#region Properties: Public

		public virtual Object DataSource {
			get;
			set;
		}

		public virtual string DuplicatesTableName {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var dataSource = DataSource as BPMSoft.UI.WebControls.Controls.EntityDataSource;
			dataSource.Loading += DataSourceLoading;
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public virtual void UpdateFiltersRightExprMetaDataByParameterValue(Process process, DataSourceFilterCollection filters) {
			foreach (var filter in filters) {
				var dataSourcefilter = (DataSourceFilter)filter;
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

		public virtual void DataSourceLoading(object sender, DataSourceEventArgs args) {
			var dataSource = sender as BPMSoft.UI.WebControls.Controls.EntityDataSource;
			Guid duplicateStatusId;
			var duplicateStatusEntity = UserConnection.EntitySchemaManager.FindInstanceByName("DuplicateStatus").CreateEntity(UserConnection);
			duplicateStatusEntity.FetchFromDB("Code", "Duplicate");
			duplicateStatusId = duplicateStatusEntity.GetTypedColumnValue<Guid>("Id");	
			var select = args.SelectQuery;
			var subSelect = new Select(UserConnection)
								.From(DuplicatesTableName)
								.Column("Entity1Id")
								.Distinct()
								.Where("StatusOfDuplicateId").IsEqual(Column.Parameter(duplicateStatusId)) as Select;
			var newCondition = new QueryCondition(select);
			newCondition.ConditionType = QueryConditionType.Block;
			var cond = select.Condition;
			newCondition.LeftExpression = new QueryColumnExpression(dataSource.Schema.Name, "Id");
			newCondition.In(subSelect);
			if (cond.Count > 0) {
				cond.ConditionType = QueryConditionType.Block;
				cond = cond.WrapBlock();
				newCondition.LogicalOperation = LogicalOperation.And;
			}
			cond.Add(newCondition);
			dataSource.Loading -= DataSourceLoading;
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (DataSource != null) {
				if (DataSource.GetType().IsSerializable || DataSource.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("DataSource", DataSource, null);
				}
			}
			if (!HasMapping("DuplicatesTableName")) {
				writer.WriteValue("DuplicatesTableName", DuplicatesTableName, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "DataSource":
					DataSource = reader.GetSerializableObjectValue();
				break;
				case "DuplicatesTableName":
					DuplicatesTableName = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

