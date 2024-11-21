namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Linq;

	#region Class: DeleteEntityCollectionItemsUserTask

	[DesignModeProperty(Name = "EntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3ca906cdb2f9486ba4e03893d418422e", CaptionResourceItem = "Parameters.EntityCollection.Caption", DescriptionResourceItem = "Parameters.EntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3ca906cdb2f9486ba4e03893d418422e", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class DeleteEntityCollectionItemsUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public DeleteEntityCollectionItemsUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("3ca906cd-b2f9-486b-a4e0-3893d418422e");
		}

		#endregion

		#region Properties: Public

		public virtual EntityCollection EntityCollection {
			get;
			set;
		}

		public virtual string DataSourceFilters {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (EntityCollection == null || EntityCollection.Count == 0) {
				return true;
			}
			EntitySchema entitySchema = EntityCollection.Schema;
			if (string.IsNullOrEmpty(DataSourceFilters) || entitySchema == null) {
				return true;
			}
			DataSourceFilterCollection dataSourceFilters =
				ProcessUserTaskUtilities.ConvertToProcessDataSourceFilterCollection(
					UserConnection, entitySchema, this, DataSourceFilters);
			if(dataSourceFilters == null || dataSourceFilters.Count == 0){
				return true;
			}
			var dataSourceFiltersIsNot = new DataSourceFilterCollection(dataSourceFilters) {
				LogicalOperation = LogicalOperationStrict.And,
				IsEnabled = true		
			};
			var linqConverter = new DataSourceFilterLinqConverter(UserConnection);
			IQueryable<Entity> resultQuery = linqConverter.BuildQuery(EntityCollection, dataSourceFiltersIsNot);
			EntityCollection.RemoveRange(resultQuery.ToArray());
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("DataSourceFilters")) {
				writer.WriteValue("DataSourceFilters", DataSourceFilters, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "DataSourceFilters":
					DataSourceFilters = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

