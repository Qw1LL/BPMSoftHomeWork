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
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Text.RegularExpressions;

	#region Class: ReadDataIntoEntityCollectionItemsUserTask

	[DesignModeProperty(Name = "EntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "18553bfd3ef6469180dfebe71def3602", CaptionResourceItem = "Parameters.EntityCollection.Caption", DescriptionResourceItem = "Parameters.EntityCollection.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultEntitySchemaProcessData", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "18553bfd3ef6469180dfebe71def3602", CaptionResourceItem = "Parameters.ResultEntitySchemaProcessData.Caption", DescriptionResourceItem = "Parameters.ResultEntitySchemaProcessData.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ResultEntityCollection", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "18553bfd3ef6469180dfebe71def3602", CaptionResourceItem = "Parameters.ResultEntityCollection.Caption", DescriptionResourceItem = "Parameters.ResultEntityCollection.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class ReadDataIntoEntityCollectionItemsUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ReadDataIntoEntityCollectionItemsUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("18553bfd-3ef6-4691-80df-ebe71def3602");
		}

		#endregion

		#region Properties: Public

		public virtual EntityCollection EntityCollection {
			get;
			set;
		}

		public virtual string ResultEntitySchemaProcessData {
			get;
			set;
		}

		public virtual EntityCollection ResultEntityCollection {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (string.IsNullOrEmpty(ResultEntitySchemaProcessData)) {
				throw new NullOrEmptyException("ResultEntitySchemaProcessData");
			}
			if (EntityCollection == null || EntityCollection.Count == 0) {
				return true;
			}
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			var processData = Json.Deserialize<EntitySchemaProcessData>(ResultEntitySchemaProcessData);
			EntitySchema parentSchema = entitySchemaManager.GetInstanceByUId(processData.ParentSchemaUId);
			EntitySchema resultEntitySchema = entitySchemaManager.ForceGetSchema(processData);
			var schemaQueryInfo = new Dictionary<EntitySchema, Dictionary<string, Dictionary<EntitySchemaColumn, string>>>();
			var regexColumnNameParser = new Regex(@"\[(?<TableName>[\w\-]+):(?<ColumnName>[\w\-]+):?(?<PrimaryColumnName>[\w\-]*)\]$");
			foreach (KeyValuePair<Guid, string> selectedColumnData in processData.ParentSchemaColumnMetaPath) {
				string schemaColumnMetaPath = selectedColumnData.Value;
				string schemaColumnPath = parentSchema.GetSchemaColumnPathByMetaPath(schemaColumnMetaPath);
				string newSchemaColumnName = StringUtilities.CleanUpColumnName(schemaColumnPath);
				EntitySchemaColumn resultEntitySchemaColumn = resultEntitySchema.Columns.GetByName(newSchemaColumnName);
				EntitySchemaColumn column = FindFirstLookupSchemaColumnByMetaPath(parentSchema, schemaColumnMetaPath,
					regexColumnNameParser);
				if (column == null) {
					continue;
				}
				EntitySchema entitySchema = column.ReferenceSchema;
				string foreignPrimaryColumnName = column.ColumnValueName;
				string columnUId = column.UId.ToString();
				int index = schemaColumnMetaPath.IndexOf(columnUId);
				string referSchemaColumnMetaPath = schemaColumnMetaPath.Substring(index + columnUId.Length + 1);
				string esqColumnPath = entitySchema.GetSchemaColumnPathByMetaPath(referSchemaColumnMetaPath);
				Dictionary<string, Dictionary<EntitySchemaColumn, string>> schemaRelations;
				if (!schemaQueryInfo.TryGetValue(entitySchema, out schemaRelations)) {
					schemaRelations = new Dictionary<string, Dictionary<EntitySchemaColumn, string>>();
					schemaQueryInfo.Add(entitySchema, schemaRelations);
				}
				Dictionary<EntitySchemaColumn, string> entitySchemaColumns;
				if (!schemaRelations.TryGetValue(foreignPrimaryColumnName, out entitySchemaColumns)) {
					entitySchemaColumns = new Dictionary<EntitySchemaColumn, string>();
					schemaRelations.Add(foreignPrimaryColumnName, entitySchemaColumns);
				}
				entitySchemaColumns.Add(resultEntitySchemaColumn, esqColumnPath);
			}
			ResultEntityCollection.Schema = resultEntitySchema;
			if (schemaQueryInfo.Count == 0) {
				ResultEntityCollection = EntityCollection;
				return true;
			}
			bool isNotLoadedResultEntityCollection = true;
			int parametersLength = 1000;
			foreach (KeyValuePair<EntitySchema, Dictionary<string, Dictionary<EntitySchemaColumn, string>>> schemaQueryInfoItem in schemaQueryInfo) {
				EntitySchema entitySchema = schemaQueryInfoItem.Key;
				var schemaRelations = schemaQueryInfoItem.Value;
				foreach (KeyValuePair<string, Dictionary<EntitySchemaColumn, string>> schemaRelation in schemaRelations) {
					string primaryColumnName = entitySchema.GetPrimaryColumnName();
					string foreignPrimaryColumnName = schemaRelation.Key;
					var parameters = new List<object>(parametersLength);
					Dictionary<object, List<Entity>> hashTable = GetHashTable(foreignPrimaryColumnName, ref isNotLoadedResultEntityCollection);
					int keysCount = hashTable.Keys.Count;
					foreach (object parameterValue in hashTable.Keys) {
						parameters.Add(parameterValue);
						if (parameters.Count == parametersLength || parameters.Count == keysCount) {
							Dictionary<EntitySchemaColumn, string> selectedSchemaColumns = schemaRelation.Value;
							EntityCollection esqEntityCollection = GetESQEntityCollection(primaryColumnName, entitySchema,
								ref selectedSchemaColumns, parameters);
							parameters.Clear();
							LoadColumnValues(primaryColumnName, hashTable, esqEntityCollection, selectedSchemaColumns);
						}
					}
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

		public virtual EntityCollection GetESQEntityCollection(string primaryColumnName, EntitySchema entitySchema, ref Dictionary<EntitySchemaColumn, string> selectedSchemaColumns, List<object> parameters) {
			var esq = new EntitySchemaQuery(entitySchema);
			esq.UseAdminRights = false;
			esq.PrimaryQueryColumn.IsVisible = true;
			var schemaColumnNameTies = new Dictionary<EntitySchemaColumn, string>(selectedSchemaColumns.Count);
			foreach (KeyValuePair<EntitySchemaColumn, string> selectedSchemaColumn in selectedSchemaColumns) {
				string columnNameTie = esq.AddColumn(selectedSchemaColumn.Value).Name;
				schemaColumnNameTies.Add(selectedSchemaColumn.Key, columnNameTie);
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, primaryColumnName, parameters));
			esq.IgnoreDisplayValues = true;
			selectedSchemaColumns = schemaColumnNameTies;
			return esq.GetEntityCollection(UserConnection);
		}

		public virtual void LoadColumnValues(string esqColumnValueName, Dictionary<object, List<Entity>> hashTable, EntityCollection esqEntityCollection, Dictionary<EntitySchemaColumn, string> selectedSchemaColumns) {
			var matchSelectedSchemaColumns = new Dictionary<EntitySchemaColumn, EntitySchemaColumn>(selectedSchemaColumns.Count);
			EntitySchema esqEntitySchema = esqEntityCollection.Schema;
			foreach (KeyValuePair<EntitySchemaColumn, string> selectedSchemaColumn in selectedSchemaColumns) {
				matchSelectedSchemaColumns.Add(selectedSchemaColumn.Key, esqEntitySchema.Columns.GetByName(selectedSchemaColumn.Value));
			}
			foreach (Entity esqEntity in esqEntityCollection) {
				object esqValue = esqEntity.GetColumnValue(esqColumnValueName);
				List<Entity> resultEntities;
				if (hashTable.TryGetValue(esqValue, out resultEntities)) {
					foreach (Entity resultEntity in resultEntities) {
						foreach (KeyValuePair<EntitySchemaColumn, EntitySchemaColumn> matchSelectedSchemaColumn in matchSelectedSchemaColumns) {
							EntitySchemaColumn resultEntitySchemaColumn = matchSelectedSchemaColumn.Key;
							object esqEntityColumnValue = esqEntity.GetColumnValue(matchSelectedSchemaColumn.Value.ColumnValueName);
							if (esqEntityColumnValue == null) {
								EntityColumnValue resultEntityColumnValue = resultEntity.ForceGetEntityColumnValue(matchSelectedSchemaColumn.Key.ColumnValueName);
								if (resultEntityColumnValue.Column == null) {
									resultEntityColumnValue.Column = resultEntitySchemaColumn;
								}
								resultEntityColumnValue.Value = null;
								continue;
							}
							resultEntity.LoadColumnValue(matchSelectedSchemaColumn.Key.ColumnValueName, esqEntityColumnValue);
							if (resultEntitySchemaColumn.IsLookupType && esqEntity.IsColumnValueLoaded(matchSelectedSchemaColumn.Value.DisplayColumnValueName)) {
								esqEntityColumnValue = esqEntity.GetColumnValue(matchSelectedSchemaColumn.Value.DisplayColumnValueName);
								resultEntity.LoadColumnValue(matchSelectedSchemaColumn.Key.DisplayColumnValueName, esqEntityColumnValue);
							} else if (resultEntitySchemaColumn.IsMultiLookupType) {
								esqEntityColumnValue = esqEntity.GetColumnValue(matchSelectedSchemaColumn.Value.SourceSchemaUIdColumnValueName);
								resultEntity.LoadColumnValue(matchSelectedSchemaColumn.Key.SourceSchemaUIdColumnValueName, esqEntityColumnValue);
							}
						}
					}
				}
			}
		}

		public virtual Dictionary<object, List<Entity>> GetHashTable(string columnValueName, ref bool isNotLoadedResultEntityCollection) {
			var entityCollection = isNotLoadedResultEntityCollection ? EntityCollection : ResultEntityCollection;
			var hashTable = new Dictionary<object, List<Entity>>();
			foreach (Entity entity in entityCollection) {
				Entity resultEntity;
				if (isNotLoadedResultEntityCollection) {
					resultEntity = new Entity(UserConnection) {
						Schema = ResultEntityCollection.Schema
					};
					//resultEntity.SetDefColumnValues();
					CopyColumnValues(entity, resultEntity);
					ResultEntityCollection.Add(resultEntity);
				} else {
					resultEntity = entity;
				}
				List<Entity> entities;
				object columnValue = resultEntity.GetColumnValue(columnValueName);
				if (columnValue == null) {
					continue;
				}
				if (!hashTable.TryGetValue(columnValue, out entities)) {
					entities = new List<Entity>();
					hashTable.Add(columnValue, entities);
				}
				entities.Add(resultEntity);
			}
			isNotLoadedResultEntityCollection = false;
			return hashTable;
		}

		public virtual EntitySchemaColumn FindFirstLookupSchemaColumnByMetaPath(EntitySchema entitySchema, string columnMetaPath, Regex regexColumnNameParser) {
			if (string.IsNullOrEmpty(columnMetaPath)) {
				throw new ArgumentNullOrEmptyException("columnMetaPath");
			}
			string[] columnUIds = columnMetaPath.Split('.');
			EntitySchema currentSchema = entitySchema;
			EntitySchemaColumn lookupColumn = null;
			for (var i = 0; i < columnUIds.Length - 1; i++) {
				string columnUId = columnUIds[i];
				Match match = regexColumnNameParser.Match(columnUId);
				if (match.Success) {
					currentSchema = UserConnection.EntitySchemaManager
						.GetInstanceByUId(new Guid(match.Groups["TableName"].Value));
					continue;
				}
				lookupColumn = currentSchema.Columns.GetByUId(new Guid(columnUId));
				if (lookupColumn.IsLookupType) {
					currentSchema = lookupColumn.ReferenceSchema;
					if (currentSchema == null) {
						throw new InvalidObjectStateException(
							new LocalizableString("BPMSoft.Core",
								"EntitySchemaColumn.Exception.ReferenceSchemaEmpty"),
							lookupColumn.Caption);
					}
				} else {
					throw new InvalidTypeCastException(new LocalizableString("BPMSoft.Core",
						"Common.Exception.ColumnMustHaveLookupType"));
				}
				break;
			}
			return lookupColumn;
		}

		public virtual void CopyColumnValues(Entity sourceEntity, Entity targetEntity) {
			EntitySchemaColumnCollection schemaColumns = sourceEntity.Schema.Columns;
			foreach (EntitySchemaColumn schemaColumn in schemaColumns) {
				string columnValueName = schemaColumn.ColumnValueName;
				CopyColumnValue(sourceEntity, targetEntity, columnValueName);
				string displayColumnValueName = schemaColumn.DisplayColumnValueName;
				if (columnValueName != displayColumnValueName) {
					CopyColumnValue(sourceEntity, targetEntity, displayColumnValueName);
				}
				if (schemaColumn.IsMultiLookupType) {
					string sourceSchemaUIdColumnValueName = schemaColumn.SourceSchemaUIdColumnValueName;
					CopyColumnValue(sourceEntity, targetEntity, sourceSchemaUIdColumnValueName);
				}
			}
		}

		public virtual void CopyColumnValue(Entity sourceEntity, Entity targetEntity, string columnValueName) {
			EntityColumnValue entityColumnValue = sourceEntity.FindEntityColumnValue(columnValueName);
			if (entityColumnValue == null) {
				return;
			}
			if (entityColumnValue.IsLoaded) {
				if (entityColumnValue.Value == null) {
					EntityColumnValue targetEntityColumnValue = targetEntity.ForceGetEntityColumnValue(columnValueName);
					targetEntityColumnValue.Value = null;
				} else {
					targetEntity.ForceSetColumnValue(entityColumnValue.Name, entityColumnValue.Value);
				}
			} else {
				targetEntity.ForceGetEntityColumnValue(columnValueName);
			}
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("ResultEntitySchemaProcessData")) {
				writer.WriteValue("ResultEntitySchemaProcessData", ResultEntitySchemaProcessData, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ResultEntitySchemaProcessData":
					ResultEntitySchemaProcessData = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

