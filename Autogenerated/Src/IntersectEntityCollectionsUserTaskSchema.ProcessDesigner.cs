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

	#region Class: IntersectEntityCollectionsUserTask

	[DesignModeProperty(Name = "EntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0b85d91320ed46edba83e131a8f49d63", CaptionResourceItem = "Parameters.EntityCollection.Caption", DescriptionResourceItem = "Parameters.EntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SamplingEntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0b85d91320ed46edba83e131a8f49d63", CaptionResourceItem = "Parameters.SamplingEntityCollection.Caption", DescriptionResourceItem = "Parameters.SamplingEntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultEntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0b85d91320ed46edba83e131a8f49d63", CaptionResourceItem = "Parameters.ResultEntityCollection.Caption", DescriptionResourceItem = "Parameters.ResultEntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0b85d91320ed46edba83e131a8f49d63", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SamplingDataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0b85d91320ed46edba83e131a8f49d63", CaptionResourceItem = "Parameters.SamplingDataSourceFilters.Caption", DescriptionResourceItem = "Parameters.SamplingDataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ColumnMetaPath", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0b85d91320ed46edba83e131a8f49d63", CaptionResourceItem = "Parameters.ColumnMetaPath.Caption", DescriptionResourceItem = "Parameters.ColumnMetaPath.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SamplingColumnMetaPath", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0b85d91320ed46edba83e131a8f49d63", CaptionResourceItem = "Parameters.SamplingColumnMetaPath.Caption", DescriptionResourceItem = "Parameters.SamplingColumnMetaPath.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class IntersectEntityCollectionsUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public IntersectEntityCollectionsUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("0b85d913-20ed-46ed-ba83-e131a8f49d63");
		}

		#endregion

		#region Properties: Public

		public virtual EntityCollection EntityCollection {
			get;
			set;
		}

		public virtual EntityCollection SamplingEntityCollection {
			get;
			set;
		}

		public virtual EntityCollection ResultEntityCollection {
			get;
			set;
		}

		public virtual string DataSourceFilters {
			get;
			set;
		}

		public virtual string SamplingDataSourceFilters {
			get;
			set;
		}

		public virtual string ColumnMetaPath {
			get;
			set;
		}

		public virtual string SamplingColumnMetaPath {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (EntityCollection == null || EntityCollection.Schema == null) {
				return true;
			}
			if (SamplingEntityCollection == null || SamplingEntityCollection.Schema == null) {
				return true;
			}
			IQueryable<Entity> entityCollectionQuery = CreateQuery(EntityCollection, DataSourceFilters);
			IQueryable<Entity> samplingEntityCollectionQuery =
				CreateQuery(SamplingEntityCollection, SamplingDataSourceFilters);
			EntitySchemaColumn column = SamplingEntityCollection.Schema
				.GetSchemaColumnByMetaPath(SamplingColumnMetaPath);
			string columnValueName = column.ColumnValueName;
			var hashSet = new HashSet<object>();
			foreach (Entity samplingEntity in samplingEntityCollectionQuery) {
				hashSet.Add(samplingEntity.GetColumnValue(columnValueName));
			}
			column = EntityCollection.Schema.GetSchemaColumnByMetaPath(ColumnMetaPath);
			columnValueName = column.ColumnValueName;
			ResultEntityCollection = new EntityCollection(UserConnection, EntityCollection.Schema);
			foreach (Entity entity in entityCollectionQuery) {
				if (hashSet.Contains(entity.GetColumnValue(columnValueName))) {
					ResultEntityCollection.Add(entity);
				}
			}
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

		public virtual IQueryable<Entity> CreateQuery(EntityCollection entityCollection, string serializedDataSourceFilters) {
			DataSourceFilterCollection filters = null;
			if (!string.IsNullOrEmpty(serializedDataSourceFilters)) {
				filters = ProcessUserTaskUtilities.ConvertToProcessDataSourceFilterCollection(
					UserConnection, entityCollection.Schema, this, DataSourceFilters);
			}
			var linqConvertor = new DataSourceFilterLinqConverter(UserConnection);
			return linqConvertor.BuildQuery(entityCollection, filters);
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
			if (!HasMapping("SamplingDataSourceFilters")) {
				writer.WriteValue("SamplingDataSourceFilters", SamplingDataSourceFilters, null);
			}
			if (!HasMapping("ColumnMetaPath")) {
				writer.WriteValue("ColumnMetaPath", ColumnMetaPath, null);
			}
			if (!HasMapping("SamplingColumnMetaPath")) {
				writer.WriteValue("SamplingColumnMetaPath", SamplingColumnMetaPath, null);
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
				case "SamplingDataSourceFilters":
					SamplingDataSourceFilters = reader.GetStringValue();
				break;
				case "ColumnMetaPath":
					ColumnMetaPath = reader.GetStringValue();
				break;
				case "SamplingColumnMetaPath":
					SamplingColumnMetaPath = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

