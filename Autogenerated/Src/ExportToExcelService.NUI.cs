namespace BPMSoft.Configuration.ExportToExcel
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Text;
    using global::Common.Logging;
    using Newtonsoft.Json;
    using BPMSoft.Common;
    using BPMSoft.Common.Json;
    using BPMSoft.Core;
    using BPMSoft.Core.DB;
    using BPMSoft.Core.Entities;
    using BPMSoft.Core.Factories;
    using BPMSoft.Nui.ServiceModel.DataContract;
    using BPMSoft.Nui.ServiceModel.Extensions;
    using BPMSoft.Web.Common;
    using System.Data;

    #region Class: ExportToExcelResponse

    /// <summary>
    /// Export to excel DTO.
    /// </summary>
    [DataContract]
    public class ExportToExcelResponse : ConfigurationServiceResponse
    {

        #region Constructors: Public

        public ExportToExcelResponse()
        {
        }

        public ExportToExcelResponse(Exception ex) : base(ex)
        {
        }

        #endregion

        #region Properties: Public

        [DataMember(Name = "key")]
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [DataMember(Name = "count")]
        [JsonProperty(PropertyName = "count")]
        public UInt64 Count { get; set; }

        #endregion

    }

    #endregion

    #region Class: ExportToExcelService

    /// <summary>
    /// Entity that handles excel creation request.
    /// </summary>
    public class ExportToExcelService : BaseService
    {

        #region Constants: Public

        public const string CanExportGridOperationCode = "CanExportGrid";
        public const string CanExportGridEntityOperationCode = "Export";
        public const string UseEntityOperationFeatureCode = "UseEntityOperationGrantee";

        #endregion

        #region Fields: Private

        private IRepository<StorableStreamEntity> _streamRepository;

        private ExcelConverter _excelConverter;

        private const string TypeCodeParameterName = "TypeCode";
        private const string ResultCodeParameterName = "ResultCode";

        private StringBuilder _columns;
        private StringBuilder _columnFilters;
        private StringBuilder _filters;

        #endregion

        #region Properties: Protected

        /// <summary>
        /// Stream repository.
        /// </summary>
        protected IRepository<StorableStreamEntity> StreamRepository
        {
            get
            {
                if (_streamRepository == null)
                {
                    _streamRepository = ClassFactory.Get<IRepository<StorableStreamEntity>>();
                }
                _streamRepository.CheckArgumentNull("ExportToExcelService.StreamRepository");
                return _streamRepository;
            }
        }

        /// <summary>
        /// Error logger.
        /// </summary>
        private ILog _log;
        protected ILog Log => _log ?? (_log = LogManager.GetLogger("Excel"));

        /// <summary>
        /// Excel converter.
        /// </summary>
        protected ExcelConverter ExcelConverter
        {
            get
            {
                if (_excelConverter == null)
                {
                    _excelConverter = ClassFactory.Get<ExcelConverter>(
                        new ConstructorArgument("excelCulture", GetExcelCulture()));
                }
                _excelConverter.CheckArgumentNull("ExportToExcelService.ExcelConverter");
                return _excelConverter;
            }
        }

        /// <summary>
        /// Default size for excel export batch.
        /// </summary>
        protected int DefaultExcelExportBatchSize => 2000;

        /// <summary>
        /// Excel export batch size system setting name.
        /// </summary>
        protected string ExcelExportBatchSizeSettingsName => "ExcelExportBatchSize";

        /// <summary>
        /// Size for excel export batch
        /// </summary>
        protected int BatchSize
        {
            get
            {
                if (Convert.ToBoolean(Core.Configuration.SysSettings.TryGetValue(UserConnection,
                    ExcelExportBatchSizeSettingsName, out var batchSizeSetting)))
                {
                    if (batchSizeSetting is int batchSize)
                    {
                        return batchSize;
                    }
                    else
                    {
                        return DefaultExcelExportBatchSize;
                    }
                }
                else
                {
                    return DefaultExcelExportBatchSize;
                }
            }
        }

        #endregion

        #region Methods: Private

        private CultureInfo GetExcelCulture()
        {
            var currentUser = UserConnection.CurrentUser;
            try
            {
                var dateTimeFormatCode = currentUser?.DateTimeFormatCode;
                if (!string.IsNullOrEmpty(dateTimeFormatCode))
                {
                    return CultureInfo.GetCultureInfo(dateTimeFormatCode);
                }
            }
            catch (CultureNotFoundException ex)
            {
                Log.Error($"CultureNotFoundException. {ex}");
            }
            return currentUser?.Culture;
        }

        private EntitySchemaQuery RemoveBinaryColumnsFromQuery(EntitySchemaQuery entitySchemaQuery)
        {
            var columns = entitySchemaQuery.Columns.Where(x =>
                        x.GetResultDataValueType(entitySchemaQuery.RootSchema.DataValueTypeManager) is BinaryDataValueType
                        || x.GetResultDataValueType(entitySchemaQuery.RootSchema.DataValueTypeManager) is ImageLookupDataValueType)
                    .ToList();
            foreach (var column in columns)
            {
                entitySchemaQuery.RemoveColumn(column.Name);
            }
            return entitySchemaQuery;
        }

        private void CheckCanExport(string schemaName)
        {
            try
            {
                UserConnection.DBSecurityEngine.CheckCanExecuteOperation(CanExportGridOperationCode);
            }
            catch (SecurityException e)
            {
                if (UserConnection.GetIsFeatureEnabled(UseEntityOperationFeatureCode))
                {
                    UserConnection.DBSecurityEngine.CheckCanExecuteEntityOperation(schemaName, CanExportGridEntityOperationCode);
                }
                else
                {
                    throw;
                }
            }
        }

		/// <summary>
		/// Logs the export process.
		/// Logs are saving to the "SysOperationAudit" table.
		/// </summary>
		private void LogExcelExport(EntitySchemaQuery entitySchemaQuery, string schemaName, ulong rowsCount)
        {
            if (String.IsNullOrEmpty(schemaName))
                throw new ArgumentNullException(nameof(schemaName));
			_filters = new StringBuilder();
            _columns = new StringBuilder();
            _columnFilters = new StringBuilder();
            ProcessColumns(schemaName, entitySchemaQuery);
            ProcessFilters(entitySchemaQuery.Filters.First(), _filters);
            var insert = new Insert(UserConnection)
                .Into("SysOperationAudit")
                .Set("CreatedById", Column.Parameter( UserConnection.CurrentUser.ContactId))
                .Set("ModifiedById", Column.Parameter( UserConnection.CurrentUser.ContactId))
                .Set("OwnerId", Column.Parameter( UserConnection.CurrentUser.ContactId))
                .Set("TypeId", CreateIdByCodeSelect("SysOperationType", TypeCodeParameterName, "Export"))
                .Set("Date", Column.Parameter(DateTime.UtcNow))
                .Set("ResultId", CreateIdByCodeSelect("SysOperationResult", ResultCodeParameterName, "Succeeded"))
                .Set("Description", Column.Parameter($@" Объект : {schemaName} || Количество выгруженных записей : {rowsCount} || Колонки : {_columns} || Фильтры : {_filters} || Фильтры колонок : {_columnFilters}"))
				.Set("ClientIP", Column.Parameter(UserConnection.GetClientIp(UserConnection)));
			insert.Execute();
        }

        /// <summary>
        /// Get data for columns.
        /// Called recursively if there are subcolumns.
        /// </summary>
        private void ProcessColumns(string schemaName, EntitySchemaQuery entitySchemaQuery)
        {
            foreach (var column in entitySchemaQuery.Columns.Where(c => c.IsVisible))
            {
                var subQuery = column.ValueExpression?.SubQuery;
                if (subQuery != null)
                {
                    foreach (var subColumn in subQuery.Columns.Where(c => c.IsVisible))
                    {
                        string columnName = null;
                        if (subColumn.ValueExpression.Function is EntitySchemaAggregationQueryFunction aggregationQueryFunction)
                        {
                            columnName = $@", {aggregationQueryFunction.AggregationType}({aggregationQueryFunction.Expression.RootSchema.Name}.{aggregationQueryFunction.Expression.SchemaColumnName})";
                            _columns.Append(columnName);
                        }
                        if (subQuery.Filters != null)
                        {
                            _columnFilters.Append($"{columnName}: ");
                            ProcessFilters(subQuery.Filters, _columnFilters);
                        }
                    }
                    continue;
                }

                _columns.Append(", ");

                if (!column.DisplayValueQueryAlias.Contains("."))
                    _columns.Append($"{schemaName}.");

                _columns.Append(column.DisplayValueQueryAlias);
            }

            if (_columns.Length != 0)
                _columns.Remove(0, 2);

            if (_columnFilters.Length != 0)
                _columnFilters.Remove(0, 2);
        }

        /// <summary>
        /// Get data for filters.
        /// Called recursively if there are subfilters.
        /// </summary>
        private void ProcessFilters(IEntitySchemaQueryFilterItem filters, StringBuilder sb)
        {
            switch (filters)
            {
                case EntitySchemaQueryFilter esqFilter:
                    {
                        if (!esqFilter.IsEnabled)
                            return;
                        sb.Append("( ");
                        if (esqFilter.LeftExpression != null)
                        {
                            if (esqFilter.LeftExpression.SubQuery != null)
                                ProcessFilters(esqFilter.LeftExpression.SubQuery.Filters, sb);
                            else
                                sb.Append($"{esqFilter.LeftExpression.SourceName}.{esqFilter.LeftExpression.SchemaColumnName}");
                            sb.Append(" ");
                        }
                        var rightExpression = esqFilter.RightExpressions?.FirstOrDefault();
                        if (rightExpression is null)
                            return;

                        sb.Append($"{esqFilter.ComparisonType} ");
                        if (rightExpression.Function != null)
                            sb.Append(rightExpression.Function.QueryAlias);
                        
                        else if (rightExpression.SubQuery != null)
                            ProcessFilters(rightExpression.SubQuery.Filters, sb);
                        else
                        {
                            if (rightExpression.ParameterValue != null)
                                sb.Append(rightExpression.ParameterValue);
                            else
                                sb.Append($"{rightExpression.SourceName}.{rightExpression.SchemaColumnName}");
                        }
                        sb.Append(" )");
                        return;
                    }
                case EntitySchemaQueryFilterCollection esqFilterCollection:
                    {
                        if (!esqFilterCollection.IsEnabled)
                            return;

                        var isFirstFilter = true;
                        foreach (var filterItem in esqFilterCollection.Where(filter => filter.IsEnabled))
                        {
                            var parenthesisNeeded = false;

                            if (filterItem is EntitySchemaQueryFilterCollection filterCollection)
                            {
                                if (filterCollection.Count == 0)
                                    continue;
                                if (filterCollection.Count > 1)
                                    parenthesisNeeded = true;
                            }
                            if (!isFirstFilter)
                            {
                                sb.Append($" {esqFilterCollection.LogicalOperation} ");

                                if (parenthesisNeeded)
                                    sb.Append("( ");
                            }
                            ProcessFilters(filterItem, sb);

                            if (!isFirstFilter && parenthesisNeeded)
                                sb.Append(" )");
                            isFirstFilter = false;
                        }
                        break;
                    }
            }
        }

        private Select CreateIdByCodeSelect(string schemaName,
            string parameterName, string parameterValue)
        {
            return new Select(UserConnection)
                .Column("Id")
                .From(schemaName)
                .Where("Code").IsEqual(new QueryParameter(parameterName, parameterValue, "Text")) as Select;
        }


		private static bool IsImportExport(UserConnection UserConnection) {
			object isImportExport = null;
			if (BPMSoft.Core.Configuration.SysSettings.TryGetValue(UserConnection, "UseAdminOperationImportExport", out isImportExport)) {
				return (bool)isImportExport;
			}
			return false;
		}

        #endregion

        #region Methods: Public

        /// <summary>
        /// Creates and writes excel stream to local storage and return export key.
        /// </summary>
        /// <param name="esqSerialized">Serialized export esq.</param>
        /// <returns><see cref="ExportToExcelResponse"/>.</returns>
        public virtual ExportToExcelResponse PrepareExport(string esqSerialized) {
			esqSerialized.CheckArgumentNull("ExportToExcelService.PrepareExport esqSerialized");
			UserConnection.CheckArgumentNull("ExportToExcelService UserConnection");
			var selectQuery = Json.Deserialize<SelectQuery>(esqSerialized);
			selectQuery.CheckArgumentNull("ExportToExcelService.PrepareExport deserialized SelectQuery");
			CheckCanExport(selectQuery.RootSchemaName);
			var entitySchemaQuery = selectQuery.BuildEsq(UserConnection);
			entitySchemaQuery.CheckArgumentNull("ExportToExcelService.PrepareExport entitySchemaQuery");
			entitySchemaQuery = RemoveBinaryColumnsFromQuery(entitySchemaQuery);
			ExcelConverter.BatchSize = BatchSize;
			var excelData = ExcelConverter.GetExcelData(entitySchemaQuery, UserConnection);
			var storableExcelStream = new StorableStreamEntity { Data = excelData };
			var id = StreamRepository.Create(storableExcelStream);
            if (IsImportExport(UserConnection)) 
                LogExcelExport(entitySchemaQuery, selectQuery.RootSchemaName, ExcelConverter.ExportedRowCount);
			return new ExportToExcelResponse {
				Key = id.ToString(),
				Count = ExcelConverter.ExportedRowCount
			};
		}


        /// <summary>
        /// Returns excel memory stream by id and removes it from storage.
        /// </summary>
        /// <returns>Excel memory stream.</returns>
        public virtual Stream GetExcelStream(string id)
        {
            var streamId = Guid.Parse(id);
            var stream = StreamRepository.Find(streamId);
            StreamRepository.Remove(streamId);
            return new MemoryStream(stream.Data);
        }

        #endregion
    }

    #endregion
}
