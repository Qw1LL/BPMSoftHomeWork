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

	#region Class: LoadRecentFolderFilterUserTask

	[DesignModeProperty(Name = "DataSource", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d45a14b377634005942327a8bcebb6ef", CaptionResourceItem = "Parameters.DataSource.Caption", DescriptionResourceItem = "Parameters.DataSource.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class LoadRecentFolderFilterUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public LoadRecentFolderFilterUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("d45a14b3-7763-4005-9423-27a8bcebb6ef");
		}

		#endregion

		#region Properties: Public

		public virtual Object DataSource {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			const string filtersName = "FilterRecent";
			var dataSource = DataSource as BPMSoft.UI.WebControls.Controls.DataSource;
			
			var filters = dataSource.CurrentStructure.CreateFiltersGroup(filtersName);
			filters.Add(
			    dataSource.CurrentStructure.CreateFilterWithParameters(
			        dataSource.Schema, 
			        FilterComparisonType.Equal,
			        "[SysRecentEntity:EntityId].SysUser",
			        new object[] { UserConnection.CurrentUser.Id }));
			filters.Add(
			    dataSource.CurrentStructure.CreateFilterWithParameters(
			        dataSource.Schema,
			        FilterComparisonType.Equal,
			        "[SysRecentEntity:EntityId].SysEntitySchemaUId",
			        new object[] { dataSource.Schema.UId }));
			
			var existingFilterCollection = dataSource.CurrentStructure.Filters.FindByName(filtersName) as DataSourceFilterCollection;
			if (existingFilterCollection != null)
			{
				dataSource.CurrentStructure.Filters.Remove(existingFilterCollection);
			} 
			dataSource.CurrentStructure.Filters.Add(filters);
			
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
			if (DataSource != null) {
				if (DataSource.GetType().IsSerializable || DataSource.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("DataSource", DataSource, null);
				}
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
			}
		}

		#endregion

	}

	#endregion

}

