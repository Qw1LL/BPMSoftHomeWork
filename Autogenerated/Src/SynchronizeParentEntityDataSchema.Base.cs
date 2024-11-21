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

	#region Class: SynchronizeParentEntityData

	[DesignModeProperty(Name = "ParentEntityColumnUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3e6374da01244817bb7c34b2b4ba4816", CaptionResourceItem = "Parameters.ParentEntityColumnUId.Caption", DescriptionResourceItem = "Parameters.ParentEntityColumnUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConditionMappingColumns", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3e6374da01244817bb7c34b2b4ba4816", CaptionResourceItem = "Parameters.ConditionMappingColumns.Caption", DescriptionResourceItem = "Parameters.ConditionMappingColumns.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MappingColumns", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3e6374da01244817bb7c34b2b4ba4816", CaptionResourceItem = "Parameters.MappingColumns.Caption", DescriptionResourceItem = "Parameters.MappingColumns.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DefaultValues", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3e6374da01244817bb7c34b2b4ba4816", CaptionResourceItem = "Parameters.DefaultValues.Caption", DescriptionResourceItem = "Parameters.DefaultValues.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DeleteChild", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "3e6374da01244817bb7c34b2b4ba4816", CaptionResourceItem = "Parameters.DeleteChild.Caption", DescriptionResourceItem = "Parameters.DeleteChild.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class SynchronizeParentEntityData : ProcessUserTask
	{

		#region Constructors: Public

		public SynchronizeParentEntityData(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("3e6374da-0124-4817-bb7c-34b2b4ba4816");
		}

		#endregion

		#region Properties: Public

		public virtual Guid ParentEntityColumnUId {
			get;
			set;
		}

		public virtual Object ConditionMappingColumns {
			get;
			set;
		}

		public virtual Object MappingColumns {
			get;
			set;
		}

		public virtual Object DefaultValues {
			get;
			set;
		}

		public virtual bool DeleteChild {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var updateQuery = CreateUpdateQuery(context);
			if (updateQuery != null) {
				updateQuery.Execute();
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual object CreateParameters(ProcessExecutingContext context) {
			if (DeleteChild){
				return CreateEmptyParameters(context);
			}
			var conditionMappingCoulmns = ConditionMappingColumns as System.Collections.Generic.Dictionary<
			Guid, System.Collections.Generic.Dictionary<
			Guid, object>
			>;
			var mappingColumns = MappingColumns as System.Collections.Generic.Dictionary<
			Guid, Guid>;
			var parameters = new System.Collections.Generic.Dictionary<
			Guid, object>();
			var defaultValues = DefaultValues as Dictionary<Guid, object> ?? new Dictionary<Guid, object>();
			var entity = context.Process.GetPropertyValue("Entity") as BPMSoft.Core.Entities.Entity;
			var entitySchema = entity.Schema;
			var parentEntityColumn = entitySchema.Columns.GetByUId(ParentEntityColumnUId);
			var parentEntitySchema = parentEntityColumn.ReferenceSchema;
			foreach (var conditionMappingCoulmnKey in conditionMappingCoulmns.Keys) {
				var conditions = conditionMappingCoulmns [conditionMappingCoulmnKey] as System.Collections.Generic.Dictionary<
					Guid, object>;
				bool forUpdate = true;
				foreach (var conditionKey in conditions.Keys) {
					var conditionColumn = entitySchema.Columns.GetByUId(conditionKey);
					var conditionColumnValue = entity.GetColumnValue(conditionColumn.ColumnValueName);
					forUpdate = object.Equals(conditionColumnValue , conditions[conditionKey]);
					if (!forUpdate) {
						break;
					}
				}
				if (forUpdate) {
					var columnUId =  mappingColumns[conditionMappingCoulmnKey];
					var column = entitySchema.Columns.GetByUId(columnUId);
					var parameterValue = entity.GetColumnValue(column.ColumnValueName);
					parameters.Add(conditionMappingCoulmnKey, parameterValue);
				}
			}
			foreach (var defaultValueKey in defaultValues.Keys) {
				if (parameters.ContainsKey(defaultValueKey)) {
					continue;
				}
				parameters.Add(defaultValueKey, defaultValues[defaultValueKey]);
			}
			return parameters;
		}

		public virtual BPMSoft.Core.DB.Update CreateUpdateQuery(ProcessExecutingContext context) {
			var parameters = CreateParameters(context) as System.Collections.Generic.Dictionary<
			Guid, object>;
			if (parameters == null || parameters.Count == 0) {
				return null;
			}
			var entity = context.Process.GetPropertyValue("Entity") as BPMSoft.Core.Entities.Entity;
			var entitySchema = entity.Schema;
			var parentEntityColumn = entitySchema.Columns.GetByUId(ParentEntityColumnUId);
			var parentEntitySchema = parentEntityColumn.ReferenceSchema;
			var update = new BPMSoft.Core.DB.Update(context.UserConnection, parentEntitySchema.Name);
			foreach (var parameterKey in parameters.Keys) {
				var parentColumn = parentEntitySchema.Columns.GetByUId(parameterKey);
				var parentColumnName = parentColumn.ColumnValueName;
				var parameterValue = parameters[parameterKey];
				update.Set(parentColumnName, BPMSoft.Core.DB.Column.Parameter(parameterValue, parentColumn.DataValueType));
			}
			var primaryColumn = parentEntitySchema.PrimaryColumn;
			var primaryColumnName = primaryColumn.ColumnValueName;
			update.Where(primaryColumnName).IsEqual(
				BPMSoft.Core.DB.Column.Parameter(entity.GetColumnValue(parentEntityColumn.ColumnValueName),
				primaryColumn.DataValueType));
			return update;
		}

		public virtual object CreateEmptyParameters(ProcessExecutingContext context) {
			var conditionMappingCoulmns = ConditionMappingColumns as System.Collections.Generic.Dictionary<
			Guid, System.Collections.Generic.Dictionary<
			Guid, object>
			>;
			var mappingColumns = MappingColumns as System.Collections.Generic.Dictionary<
			Guid, Guid>;
			var parameters = new System.Collections.Generic.Dictionary<
			Guid, object>();
			var defaultValues= new System.Collections.Generic.Dictionary<
			Guid, object>();
			var entity = context.Process.GetPropertyValue("Entity") as BPMSoft.Core.Entities.Entity;
			var entitySchema = entity.Schema;
			var parentEntityColumn = entitySchema.Columns.GetByUId(ParentEntityColumnUId);
			var parentEntitySchema = parentEntityColumn.ReferenceSchema;
			foreach (var conditionMappingCoulmnKey in conditionMappingCoulmns.Keys) {
				var conditions = conditionMappingCoulmns [conditionMappingCoulmnKey] as System.Collections.Generic.Dictionary<
					Guid, object>;
				bool forUpdate = true;
				foreach (var conditionKey in conditions.Keys) {
					var conditionColumn = entitySchema.Columns.GetByUId(conditionKey);
					var conditionColumnValue = entity.GetColumnValue(conditionColumn.ColumnValueName);
					forUpdate = object.Equals(conditionColumnValue , conditions[conditionKey]);
					if (!forUpdate) {
						break;
					}
				}
				if (forUpdate) {
					parameters.Add(conditionMappingCoulmnKey, null);
				}
			}
			foreach (var defaultValueKey in defaultValues.Keys) {
				if (parameters.ContainsKey(defaultValueKey)) {
					continue;
				}
				parameters.Add(defaultValueKey, defaultValues[defaultValueKey]);
			}
			return parameters;
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("ParentEntityColumnUId")) {
				writer.WriteValue("ParentEntityColumnUId", ParentEntityColumnUId, Guid.Empty);
			}
			if (ConditionMappingColumns != null) {
				if (ConditionMappingColumns.GetType().IsSerializable || ConditionMappingColumns.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("ConditionMappingColumns", ConditionMappingColumns, null);
				}
			}
			if (MappingColumns != null) {
				if (MappingColumns.GetType().IsSerializable || MappingColumns.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("MappingColumns", MappingColumns, null);
				}
			}
			if (DefaultValues != null) {
				if (DefaultValues.GetType().IsSerializable || DefaultValues.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("DefaultValues", DefaultValues, null);
				}
			}
			if (!HasMapping("DeleteChild")) {
				writer.WriteValue("DeleteChild", DeleteChild, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ParentEntityColumnUId":
					ParentEntityColumnUId = reader.GetGuidValue();
				break;
				case "ConditionMappingColumns":
					ConditionMappingColumns = reader.GetSerializableObjectValue();
				break;
				case "MappingColumns":
					MappingColumns = reader.GetSerializableObjectValue();
				break;
				case "DefaultValues":
					DefaultValues = reader.GetSerializableObjectValue();
				break;
				case "DeleteChild":
					DeleteChild = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

