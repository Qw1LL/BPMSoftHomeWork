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

	#region Class: AddDataToEntityCollectionUserTask

	[DesignModeProperty(Name = "EntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d86f08f2b04f4b1080d0731c55b045ab", CaptionResourceItem = "Parameters.EntityCollection.Caption", DescriptionResourceItem = "Parameters.EntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SamplingEntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d86f08f2b04f4b1080d0731c55b045ab", CaptionResourceItem = "Parameters.SamplingEntityCollection.Caption", DescriptionResourceItem = "Parameters.SamplingEntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d86f08f2b04f4b1080d0731c55b045ab", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "RecordDefValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d86f08f2b04f4b1080d0731c55b045ab", CaptionResourceItem = "Parameters.RecordDefValues.Caption", DescriptionResourceItem = "Parameters.RecordDefValues.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsSelectedSamplingAddMode", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "d86f08f2b04f4b1080d0731c55b045ab", CaptionResourceItem = "Parameters.IsSelectedSamplingAddMode.Caption", DescriptionResourceItem = "Parameters.IsSelectedSamplingAddMode.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class AddDataToEntityCollectionUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public AddDataToEntityCollectionUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("d86f08f2-b04f-4b10-80d0-731c55b045ab");
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

		public virtual string DataSourceFilters {
			get;
			set;
		}

		private EntityColumnMappingValues _recordDefValues;
		public virtual EntityColumnMappingValues RecordDefValues {
			get {
				return _recordDefValues ?? ( _recordDefValues = new EntityColumnMappingValues (
					new Dictionary<string, object>(),
					new Dictionary<string, string>()));
			}
			set {
				_recordDefValues = value;
			}
		}

		public virtual bool IsSelectedSamplingAddMode {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (EntityCollection == null || EntityCollection.Schema == null) {
				return true;
			}
			EntitySchema entitySchema = EntityCollection.Schema;
			EntitySchema samplingEntitySchema;
			var selectedConstColumnValues = new Dictionary<EntitySchemaColumn, object>();
			var selectedFuncColumnValues = new Dictionary<EntitySchemaColumn, Func<Entity, object>>();
			var selectedSamplingColumnValues = new Dictionary<EntitySchemaColumn, EntitySchemaColumn>();
			if (SamplingEntityCollection != null) {
				samplingEntitySchema = SamplingEntityCollection.Schema;
			} else {
				samplingEntitySchema = null;
			}
			if (IsSelectedSamplingAddMode) {
				if (samplingEntitySchema == null) {
					return true;
				} else {
					foreach (KeyValuePair<string, string> selectedColumnValue in RecordDefValues.FetchMetaPathes) {
						EntitySchemaColumn entitySchemaColumn = entitySchema.GetSchemaColumnByMetaPath(selectedColumnValue.Key);
						EntitySchemaColumn samplingEntitySchemaColumn = samplingEntitySchema
							.GetSchemaColumnByMetaPath(selectedColumnValue.Value);
						selectedSamplingColumnValues.Add(entitySchemaColumn, samplingEntitySchemaColumn);
					}
				}
			}
			foreach (KeyValuePair<string, object> selectedColumnValue in RecordDefValues.Values) {
				EntitySchemaColumn entitySchemaColumn = entitySchema.GetSchemaColumnByMetaPath(selectedColumnValue.Key);
				var func = selectedColumnValue.Value as Func<Entity, object>;
				if (func != null) {
					selectedFuncColumnValues.Add(entitySchemaColumn, func);
				} else {
					selectedConstColumnValues.Add(entitySchemaColumn, selectedColumnValue.Value);
				}
			}
			if (IsSelectedSamplingAddMode) {
				IQueryable<Entity> samplingEntityQuery = CreateQuery();
				foreach (Entity samplingEntity in samplingEntityQuery) {
					Entity newEntity = entitySchema.CreateEntity(UserConnection);
					//newEntity.SetDefColumnValues();
					
					//CopyColumnValues(samplingEntity, newEntity);
					SetColumnValues(newEntity, selectedConstColumnValues);
					SetSamplingFuncColumnValues(newEntity, samplingEntity, selectedFuncColumnValues);
					SetSamplingColumnValues(newEntity, samplingEntity, selectedSamplingColumnValues);
					EntityCollection.Add(newEntity);
				}
			} else {
				Entity newEntity = entitySchema.CreateEntity(UserConnection);
				//newEntity.SetDefColumnValues();
				SetColumnValues(newEntity, selectedConstColumnValues);
				EntityCollection.Add(newEntity);
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

		public virtual IQueryable<Entity> CreateQuery() {
			DataSourceFilterCollection filterCollection = null;
			if (!string.IsNullOrEmpty(DataSourceFilters)) {
				filterCollection = ProcessUserTaskUtilities.ConvertToProcessDataSourceFilterCollection(
					UserConnection, SamplingEntityCollection.Schema, this, DataSourceFilters);
			}
			var linqConvertor = new DataSourceFilterLinqConverter(UserConnection);
			return linqConvertor.BuildQuery(SamplingEntityCollection, filterCollection);
		}

		public virtual void SetColumnValues(Entity entity, Dictionary<EntitySchemaColumn, object> selectedConstColumnValues) {
			if (selectedConstColumnValues.Count == 0) {
				return;
			}
			foreach (KeyValuePair<EntitySchemaColumn, object> selectedConstColumnValue in selectedConstColumnValues) {
				EntitySchemaColumn entitySchemaColumn = selectedConstColumnValue.Key;
				if (ShouldSetColumnValue(entitySchemaColumn, selectedConstColumnValue.Value)) {
					entity.SetColumnValue(entitySchemaColumn, selectedConstColumnValue.Value);
				}
			}
		}

		public virtual void SetSamplingColumnValues(Entity entity, Entity samplingEntity, Dictionary<EntitySchemaColumn, EntitySchemaColumn> selectedSamplingColumnValues) {
			if (selectedSamplingColumnValues.Count == 0) {
				return;
			}
			foreach (KeyValuePair<EntitySchemaColumn, EntitySchemaColumn> selectedSamplingColumnValue in selectedSamplingColumnValues) {
				EntitySchemaColumn entitySchemaColumn = selectedSamplingColumnValue.Key;
				EntitySchemaColumn samplingEntitySchemaColumn = selectedSamplingColumnValue.Value;
				object samplingColumnValue = samplingEntity.GetColumnValue(samplingEntitySchemaColumn);
				if (ShouldSetColumnValue(entitySchemaColumn, samplingColumnValue)) {
					entity.SetColumnValue(entitySchemaColumn, samplingColumnValue);
				}
			}
		}

		public virtual bool ShouldSetColumnValue(EntitySchemaColumn entitySchemaColumn, object value) {
			if(DataTypeUtilities.GetIsNullOrDBNullValue(value)) {
				return false;
			}
			if ((entitySchemaColumn.IsLookupType || entitySchemaColumn.IsMultiLookupType)
					&& (Guid)value == Guid.Empty) {
				return false;
			}
			return true;
		}

		public virtual void SetSamplingFuncColumnValues(Entity entity, Entity samplingEntity, Dictionary<EntitySchemaColumn, Func<Entity, object>> selectedFuncColumnValues) {
			if (selectedFuncColumnValues.Count == 0) {
				return;
			}
			foreach (KeyValuePair<EntitySchemaColumn, Func<Entity, object>> funcColumnValue in selectedFuncColumnValues) {
				EntitySchemaColumn entitySchemaColumn = funcColumnValue.Key;
				object samplingColumnValue = funcColumnValue.Value.Invoke(samplingEntity);
				if (ShouldSetColumnValue(entitySchemaColumn, samplingColumnValue)) {
					entity.SetColumnValue(entitySchemaColumn, samplingColumnValue);
				}
			}
		}

		public virtual void CopyColumnValues(Entity sourceEntity, Entity targetEntity) {
			/*
			EntitySchemaColumnCollection schemaColumns = sourceEntity.Schema.Columns;
			foreach (EntitySchemaColumn schemaColumn in schemaColumns) {
				string columnValueName = schemaColumn.ColumnValueName;
				targetEntity.LoadColumnValue(sourceEntity, columnValueName);
				string displayColumnValueName = schemaColumn.DisplayColumnValueName;
				if (columnValueName != displayColumnValueName) {
					targetEntity.LoadColumnValue(sourceEntity, displayColumnValueName);
				}
				if (schemaColumn.IsMultiLookupType) {
					string  sourceSchemaUIdColumnValueName = schemaColumn.SourceSchemaUIdColumnValueName;
					targetEntity.LoadColumnValue(sourceEntity, sourceSchemaUIdColumnValueName);
				}
			}
			*/
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
			if (!HasMapping("IsSelectedSamplingAddMode")) {
				writer.WriteValue("IsSelectedSamplingAddMode", IsSelectedSamplingAddMode, false);
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
				case "RecordDefValues":
					if (UseFlowEngineMode) {
						RecordDefValues = reader.GetValue<EntityColumnMappingValues>();
					}
				break;
				case "IsSelectedSamplingAddMode":
					IsSelectedSamplingAddMode = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

