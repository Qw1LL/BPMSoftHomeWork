namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;

	#region Class: ReadDataUserTask

	/// <exclude/>
	public partial class ReadDataUserTask
	{

		#region Methods: Private

		private void RemoveUnsupportedColumns(EntitySchemaQuery esq) {
			EntitySchemaQueryColumnCollection columns = esq.Columns;
			for (int i = columns.Count; i != 0; i--) {
				EntitySchemaQueryColumn column = columns[i - 1];
				DataValueType resultDataValueType = column.GetResultDataValueType(UserConnection.DataValueTypeManager);
				if (!CompositeObject.IsTypeSupported(resultDataValueType.ValueType)) {
					Log.TraceFormat(
						"Column {0} of type {1} is not supported when in \"Read collection of records\" mode.",
						column.Path, resultDataValueType.ValueType.Name);
					columns.Remove(column);
				}
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			EntitySchema entitySchema = ResultEntity.Schema;
			if (entitySchema == null) {
				return true;
			}
			EntitySchemaQuery esq = CreateEntitySchemaQuery(entitySchema.Name);
			esq.UseAdminRights = false;
			string aggregationColumnName = "Function";
			ProcessReadDataResultType resultType = (ProcessReadDataResultType)ResultType;
			SpecifyESQColumns(esq, resultType, ref aggregationColumnName);
			ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, entitySchema, esq, DataSourceFilters);
			SpecifyESQOrderByStatements(esq, resultType);
			esq.CanReadUncommitedData = CanReadUncommitedData;
			esq.IgnoreDisplayValues = IgnoreDisplayValues;
			if (GlobalAppSettings.FeatureReadDataUserTaskUseChunks &&
					resultType == ProcessReadDataResultType.EntityCollection) {
				esq.ChunkSize = Core.Configuration.SysSettings.GetValue(UserConnection, "ReadDataChunkSize", 50);
			}
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			ResultRowsCount = entityCollection.Count;
			if (resultType == ProcessReadDataResultType.EntityCollection) {
				FillResultCompositeObjectList((IProcessParametersMetaInfo)GetSchemaElement(), entityCollection);
			}
			if (ResultRowsCount == 0) {
				ResultEntityCollection = entityCollection;
				return true;
			}
			Entity resultEntity = entityCollection.First.Value;
			if (resultType != ProcessReadDataResultType.Function) {
				ResultEntity = resultEntity;
				ResultEntityCollection = entityCollection;
				return true;
			}
			EntitySchemaColumn aggregationColumn = resultEntity.Schema.Columns.GetByName(aggregationColumnName);
			if (FunctionType == (int)AggregationTypeStrict.Count) {
				ResultCount = resultEntity.GetTypedColumnValue<int>(aggregationColumnName);
			} else if (aggregationColumn.DataValueType is IntegerDataValueType) {
				ResultIntegerFunction = resultEntity.GetTypedColumnValue<int>(aggregationColumnName);
			} else if (aggregationColumn.DataValueType is NumericDataValueType) {
				ResultFloatFunction = resultEntity.GetTypedColumnValue<decimal>(aggregationColumnName);
			} else if (aggregationColumn.DataValueType is DateTimeDataValueType) {
				ResultDateTimeFunction = resultEntity.GetTypedColumnValue<DateTime>(aggregationColumnName);
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual void SpecifyESQColumns(EntitySchemaQuery esq, ProcessReadDataResultType resultType,
				ref string aggregationColumnName) {
			if (resultType == ProcessReadDataResultType.Function) {
				var aggregationType = (AggregationTypeStrict)FunctionType;
				if (string.IsNullOrEmpty(AggregationColumnName) && aggregationType == AggregationTypeStrict.Count) {
					EntitySchema entitySchema = esq.RootSchema;
					aggregationColumnName = entitySchema.PrimaryColumn.Name;
				} else {
					aggregationColumnName = AggregationColumnName;
				}
				aggregationColumnName = esq.AddColumn(
					esq.CreateAggregationFunction(aggregationType, aggregationColumnName)).Name;
				return;
			}
			if (string.IsNullOrEmpty(EntityColumnMetaPathes)) {
				esq.AddAllSchemaColumns();
			} else {
				EntitySchema entitySchema = esq.RootSchema;
				string[] metaPaths = EntityColumnMetaPathes.Split(';');
				foreach (string metaPath in metaPaths) {
					string columnPath = entitySchema.GetSchemaColumnPathByMetaPath(metaPath);
					if (columnPath == esq.PrimaryQueryColumn.Path) {
						continue;
					}
					esq.AddColumn(columnPath);
				}
			}
			if (resultType == ProcessReadDataResultType.EntityCollection &&
					!UserConnection.GetIsFeatureEnabled("ReadDataThrowExceptionsOnUnsupportedTypes")) {
				RemoveUnsupportedColumns(esq);
			}
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			if (resultType == ProcessReadDataResultType.Entity) {
				esq.RowCount = 1;
			} else if (ReadSomeTopRecords) {
				esq.RowCount = NumberOfRecords;
			}
			if (ReadSomeTopRecords && GlobalAppSettings.FeatureReadDataUserTaskEntityReadOldMode) {
				esq.RowCount = NumberOfRecords;
			}
		}

		/// <summary>
		/// Initializes the specified ESQ with order by statement.
		/// </summary>
		/// <param name="esq">Instance of the EntitySchemaQuery class.</param>
		/// <param name="resultType">Read data result type.</param>
		public virtual void SpecifyESQOrderByStatements(EntitySchemaQuery esq, ProcessReadDataResultType resultType) {
			if (resultType == ProcessReadDataResultType.Function) {
				return;
			}
			ProcessUserTaskUtilities.SpecifyESQOrderByStatement(esq, OrderInfo);
		}

		public virtual void FillResultCompositeObjectList(IProcessParametersMetaInfo schemaElement,
				EntityCollection entityCollection) {
			if (!entityCollection.Any()) {
				return;
			}
			Entity entity = entityCollection.First();
			ProcessSchemaParameterCollection schemaParameters = schemaElement.Parameters;
			ProcessSchemaParameter metadataParameter = schemaParameters.GetByName("ResultCompositeObjectList");
			var keyMap = new Dictionary<string, string>();
			EntitySchema schema = entity.Schema;
			EntitySchemaColumnCollection schemaColumns = schema.Columns;
			foreach (ProcessSchemaParameter nestedParameterItemProperty in metadataParameter.ItemProperties) {
				Guid tagValue = Guid.Parse(nestedParameterItemProperty.Tag);
				EntitySchemaColumn column = schemaColumns.FindByUId(tagValue);
				if (column != null) {
					keyMap[nestedParameterItemProperty.Name] = column.Name;
				}
			}
			ResultCompositeObjectList = entityCollection.Transform(keyMap);
		}

		public virtual EntitySchemaQuery CreateEntitySchemaQuery(string entitySchemaName) {
			return new EntitySchemaQuery(UserConnection.EntitySchemaManager, entitySchemaName);
		}

		#endregion

	}

	#endregion

	#region Class: ReadDataUserTaskSchemaExtension

	/// <exclude/>
	public class ReadDataUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override void SynchronizeParameters(ProcessSchemaUserTask schemaElement) {
			void RemoveEntityColumnParameters(IEnumerable<EntitySchemaColumn> entityColumns, ref ProcessSchemaParameterCollection parameters)
			{
				var missedParameters = parameters.Where(parameter => entityColumns.All(column => column.UId != Guid.Parse(parameter.Tag)));
				parameters.RemoveRange(missedParameters.ToList());
			}

			void AddEntityColumnParameters(IEnumerable<EntitySchemaColumn> entityColumns, ref ProcessSchemaParameterCollection parameters,
					BaseProcessSchema processSchema, Guid containerUId)
			{
				foreach (var column in entityColumns)
				{
					if (parameters.All(parameter => Guid.Parse(parameter.Tag) != column.UId))
					{
						parameters.Add(CreateParameter(column, processSchema, containerUId));
					}
				}
			}

			void UpdateEntityColumnParameters(IEnumerable<EntitySchemaColumn> entityColumns, ref ProcessSchemaParameterCollection parameters)
			{
				foreach (var parameter in parameters)
				{
					var sourceColumn = entityColumns.First(column => column.UId == Guid.Parse(parameter.Tag));
					parameter.Name = sourceColumn.Name;
					parameter.Caption = sourceColumn.Caption.ToString();
					parameter.DataValueType = sourceColumn.DataValueType;
				}
			}

			ProcessSchemaParameter CreateParameter(EntitySchemaColumn column, BaseProcessSchema processSchema, Guid containerUId)
			{
				return new ProcessSchemaParameter
				{
					UId = Guid.NewGuid(),
					ContainerUId = containerUId,
					Tag = column.UId.ToString(),
					Caption = column.Caption.ToString(),
					DataValueType = column.DataValueType,
					Name = column.Name,
					ParentMetaSchema = processSchema,
					Direction = ProcessSchemaParameterDirection.Out
				};
			}

			var parametersRef = schemaElement.Parameters;
			var baseProcessSchema = schemaElement.ParentMetaSchema as BaseProcessSchema;
			var elementUId = schemaElement.UId;

			if (parametersRef.ExistsByName("ResultType"))
			{
				var resultTypeParameter = parametersRef.GetByName("ResultType");
				var resultTypeValue = resultTypeParameter.SourceValue.Value;
				int.TryParse(resultTypeValue, out int resultType);
				if (resultType == (int)ProcessReadDataResultType.EntityCollection)
				{
					var entitySchemaManager = (EntitySchemaManager)baseProcessSchema.SchemaManagerProvider.GetManager("EntitySchemaManager");
					Guid entitySchemaUId = parametersRef.GetByName("ResultEntity").ReferenceSchemaUId;
					EntitySchema entitySchema =
						entitySchemaManager.FindInstanceFromMetaDataByPackageUId(entitySchemaUId,
							baseProcessSchema.PackageUId,
							baseProcessSchema.SystemUserConnection);
					ProcessSchemaParameter resultCompositeObjectListParameter = parametersRef.GetByName("ResultCompositeObjectList");
					ProcessSchemaParameterCollection parameters = resultCompositeObjectListParameter.ItemProperties;
					if (entitySchema != null)
					{
						var entityColumns = entitySchema.Columns.AsEnumerable();
						ProcessSchemaParameter entityColumnMetaPathesParameter = parametersRef.GetByName("EntityColumnMetaPathes");
						string entityColumnMetaPathes = entityColumnMetaPathesParameter.SourceValue.Value;
						if (entityColumnMetaPathes.IsNotNullOrEmpty())
						{
							var entityColumnsUIds = entityColumnMetaPathes.Split(';');
							entityColumns = entityColumns.Join(entityColumnsUIds, column => column.UId, columnUId => Guid.Parse(columnUId),
								(column, columnUId) => column);
						}
						var valueTypesNotToSynchronize = new[] { DataValueType.BinaryDataValueTypeUId };
						var entitySchemaColumns = entityColumns.Where(x => !valueTypesNotToSynchronize.Contains(x.DataValueTypeUId)).ToArray();
						RemoveEntityColumnParameters(entitySchemaColumns, ref parameters);
						UpdateEntityColumnParameters(entitySchemaColumns, ref parameters);
						AddEntityColumnParameters(entitySchemaColumns, ref parameters, baseProcessSchema, elementUId);
					}
					else
					{
						parameters.Clear();
					}
				}
			}
		}

		#endregion

	}

	#endregion

}
