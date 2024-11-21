namespace BPMSoft.Configuration.FileImport
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;
    using BPMSoft.Core;
    using BPMSoft.Core.DB;
    using BPMSoft.Core.Factories;
    using global::Common.Logging;
    using BPMSoft.Common;
    using System.Data;

    /// <inheritdoc cref="BaseFileImporter"/>
    [DefaultBinding(typeof(IPersistentFileImporter), Name = nameof(PersistentFileImporter))]
    public class PersistentFileImporter : BaseFileImporter, IPersistentFileImporter
    {
        #region Fields: Private

        IImportParametersRepository _importParametersRepository;
        private IImportStageFactory _importStageFactory;
        private ILog _logger;
        private const string TypeCodeParameterName = "TypeCode";
        private const string ResultCodeParameterName = "ResultCode";
        #endregion

        #region Properties: Private

        private IImportParametersRepository ImportParametersRepository => _importParametersRepository ??
            (_importParametersRepository = ClassFactory.Get<IImportParametersRepository>(UserConnectionConstructorArg));

        private ConstructorArgument UserConnectionConstructorArg => new ConstructorArgument("userConnection", UserConnection);

        private IImportStageFactory ImportStageFactory =>
                _importStageFactory ?? (_importStageFactory = ClassFactory.Get<IImportStageFactory>());

        private ILog Logger => _logger ?? (_logger = LogManager.GetLogger("FileImportAppender"));

        #endregion

        #region Constructor: Public

        /// <summary>
        /// Creates instance of type <see cref="PersistentFileImporter" />.
        /// </summary>
        /// <param name="userConnection">User connection.</param>
        public PersistentFileImporter(UserConnection userConnection)
                : base(userConnection) { }

        #endregion

        #region Methods: Private

        private void SetImportStage(ImportParameters parameters) {
            var importStage = parameters.ImportStage;
            if (importStage == default(FileImportStagesEnum)) {
                importStage = FileImportStagesEnum.PrepareFileImportStage;
            } else if (importStage > FileImportStagesEnum.ProcessColumnsFileImportStage) {
                importStage = FileImportStagesEnum.ProcessColumnsFileImportStage;
            }
            ChangeImportStage(parameters, importStage);
        }

        private void DeleteImportParameters(Guid importSessionId) {
            ImportParametersRepository.Delete(importSessionId);
        }

        private void ChangeImportStage(ImportParameters parameters, FileImportStagesEnum stage) {
            parameters.ImportStage = stage;
            ImportParametersRepository.UpdateImportStage(parameters.ImportSessionId, stage);
        }

        private void WriteFileImportLog(FileImportLogMessageType messageType, ImportParameters parameters) {
            var message = FileImportLogMessageExtensions.CreateFileImportLogMessage(messageType, parameters);
            Logger.Info(message);
        }

        private void WriteFileImportLog(FileImportLogMessageType messageType, Guid sessionId) {
            var message = FileImportLogMessageExtensions.CreateFileImportLogMessage(messageType, sessionId);
            Logger.Info(message);
        }

        private ImportParameters GetImportParametersWithStage(Guid importSessionId) {
            var parameters = GetImportParameters(importSessionId);
            SetImportStage(parameters);
            return parameters;
        }

        private void CheckIsImportCancelled(ImportParameters parameters) {
            if (parameters.GetIsImportCancelled(UserConnection)) {
                WriteFileImportLog(FileImportLogMessageType.CancelFileImport, parameters.ImportSessionId);
                DeleteImportParameters(parameters.ImportSessionId);
                throw new OperationCanceledException();
            }
        }

        /// <summary>
        /// Execute the current stage and return the next import stage.
        /// If the next stage is null, it means the last stage was executed.
        /// </summary>
        private IBaseFileImportStage ProcessStage(IBaseFileImportStage currentImportStage, ImportParameters parameters) {
            ChangeImportStage(parameters, currentImportStage.StageId);
            WriteFileImportLog(FileImportLogMessageType.StartStage, parameters);
            var nextStage = currentImportStage?.ProcessStage(parameters);
            WriteFileImportLog(FileImportLogMessageType.EndStage, parameters);
            return nextStage;
        }

		/// <summary>
		/// Logs the import process.
		/// Logs are saving to the "SysOperationAudit" table.
		/// </summary>
		private void LogImportToAudit(ImportParameters parameters)
        {
            Guid ownerId = UserConnection.CurrentUser.ContactId;            
			var insert = new Insert(UserConnection)
                .Into("SysOperationAudit")
                .Set("CreatedById", Column.Parameter( UserConnection.CurrentUser.ContactId))
                .Set("ModifiedById", Column.Parameter( UserConnection.CurrentUser.ContactId))
                .Set("OwnerId", Column.Parameter( UserConnection.CurrentUser.ContactId))                
                .Set("TypeId", CreateIdByCodeSelect("SysOperationType", "TypeCode", "Import"))
                .Set("Date", Column.Parameter(DateTime.UtcNow))
                .Set("ResultId", CreateIdByCodeSelect("SysOperationResult", "ResultCode", "Succeeded"))
                .Set("Description", Column.Parameter($@" Объект : {parameters.ImportObject.Name} || Тег для загруженных записей : {parameters.ImportTags.First().DisplayValue} || Количество созданных и обновлённых записей : {parameters.ImportedRowsCount} || Количество неимпортированных записей : {parameters.NotImportedRowsCount} || Колонки в которые загружались изменения : {string.Join(", ", parameters.Columns.SelectMany(c => c.Destinations).Select(d => d.ColumnName))} || Правила поиска дублей : {string.Join(", ", parameters.GetKeyColumns().SelectMany(c => c.Destinations).Select(d => d.ColumnName))} || Наименование загруженного файла : {parameters.FileName}"))
				.Set("ClientIP", Column.Parameter(UserConnection.GetClientIp(UserConnection)));
			insert.Execute();
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

        #region Methods: Protected

        /// <inheritdoc cref="BaseFileImporter"/>
        protected override IColumnsAggregatorAdapter CreateColumnsAggregator() =>
                new PersistentColumnsAggregatorAdapter(UserConnection);

        /// <inheritdoc cref="BaseFileImporter"/>
        protected override void Import(ImportParameters parameters) {
            try
            {
                WriteFileImportLog(FileImportLogMessageType.StartFileImport, parameters);
                var currentImportStage = ImportStageFactory.CreateImportStage(parameters.ImportStage, UserConnection, ColumnsProcessor);
                while(currentImportStage != null) {
                    CheckIsImportCancelled(parameters);
                    currentImportStage = ProcessStage(currentImportStage, parameters);
                }
                WriteFileImportLog(FileImportLogMessageType.CompleteFileImport, parameters.ImportSessionId);
                if (IsImportExport(UserConnection)) 
                    LogImportToAudit(parameters);
            }
            catch (Exception ex)
            {
                var insert = new Insert(UserConnection)
                    .Into("SysOperationAudit")  
                    .Set("CreatedById", Column.Parameter( UserConnection.CurrentUser.ContactId))
                    .Set("ModifiedById", Column.Parameter( UserConnection.CurrentUser.ContactId))
                    .Set("OwnerId", Column.Parameter( UserConnection.CurrentUser.ContactId))
                    .Set("TypeId", CreateIdByCodeSelect("SysOperationType", TypeCodeParameterName, "Import"))
                    .Set("Date", Column.Parameter(DateTime.UtcNow))
                    .Set("ResultId", CreateIdByCodeSelect("SysOperationResult", ResultCodeParameterName, "Failed"))
                    .Set("Description", Column.Parameter(ex.Message))
                    .Set("ClientIP", Column.Parameter(UserConnection.CurrentUser.ClientIP));
                insert.Execute();
            }
        }

        /// <inheritdoc cref="BaseFileImporter"/>
        protected override void ImportInternal(Guid importSessionId) {
            base.ImportInternal(importSessionId);
            Import(importSessionId, CancellationToken.None);
        }

        protected override ImportParameters ForceGetImportParameters(Guid importSessionId) {
            var importParameters = FindImportParameters(importSessionId);
            if (importParameters == null) {
                importParameters = new ImportParameters(importSessionId);
                ImportParametersRepository.Add(importParameters);
            }
            return importParameters;
        }

        public override ImportParameters FindImportParameters(Guid importSessionId) {
            ImportParameters importParameters;
            try {
                importParameters = ImportParametersRepository.Get(importSessionId);
            } catch (ItemNotFoundException) {
                importParameters = null;
            }
            return importParameters;
        }

        protected override void SaveImportParameters(ImportParameters parameters) {
            ImportParametersRepository.Update(parameters);
        }

        #endregion

        #region Methods: Public

        /// <summary>
        /// <inheritdoc cref="BaseFileImporter"/>
        /// </summary>
        /// <returns></returns>
        public override ColumnsMappingResponse GetColumnsMappingParameters(Guid importSessionId) {
            importSessionId.CheckArgumentEmpty(nameof(importSessionId));
            var parameters = GetImportParameters(importSessionId);
            if (parameters.Columns.IsNullOrEmpty()) {
                RefreshColumnMapping(importSessionId);
            }
            return base.GetColumnsMappingParameters(importSessionId);
        }

        /// <inheritdoc />
        /// <summary>
        /// Refresh column mapping.
        /// </summary>
        /// <param name="importSessionId">Import session identifier.</param>
        public override void RefreshColumnMapping(Guid importSessionId) {
            if (!UserConnection.GetIsFeatureEnabled("UploadLargeFileByChunk")) {
                base.RefreshColumnMapping(importSessionId);
                return;
            }
            var parameters = GetImportParameters(importSessionId);
            parameters.Columns = new List<ImportColumn>();
            var fileProcessor = ClassFactory.Get<ISaxFileProcessor>(UserConnectionConstructorArg);
            fileProcessor.InitRootSchema(parameters.RootSchemaUId);
            parameters.Columns = fileProcessor.GetHeaders(importSessionId);
            SaveImportParameters(parameters);
        }

        /// <summary>
        /// <inheritdoc cref="IPersistentFileImporter"/>
        /// </summary>
        public void DeleteFile(Guid fileImportSessionId) {
            fileImportSessionId.CheckArgumentEmpty(nameof(fileImportSessionId));
            ImportParametersRepository.DeleteFile(fileImportSessionId);
            var parameters = ForceGetImportParameters(fileImportSessionId);
            parameters.ResetFileData();
            SaveImportParameters(parameters);
        }

        /// <summary>
        /// <inheritdoc cref="IPersistentFileImporter"/>
        /// </summary>
        public void CheckIsFileValid(Guid fileImportSessionId) {
            fileImportSessionId.CheckArgumentEmpty(nameof(fileImportSessionId));
            var fileProcessor = ClassFactory.Get<ISaxFileProcessor>();
            fileProcessor.CheckIsFileValid(fileImportSessionId);
        }

        /// <summary>
        /// <inheritdoc cref="IPersistentFileImporter"/>
        /// </summary>
        public void Import(Guid importSessionId, CancellationToken token) {
            ImportParameters parameters = GetImportParametersWithStage(importSessionId);
            parameters.ImportCancellationToken = token;
            Import(parameters);
        }

        /// <inheritdoc />
        public override void SetImportObject(Guid importSessionId, ImportObject importObject) {
            importSessionId.CheckArgumentEmpty(nameof(importSessionId));
            importObject.CheckArgumentNull(nameof(importObject));
            var parameters = ForceGetImportParameters(importSessionId);
            parameters.ImportObject = importObject;
            if(UserConnection.GetIsFeatureEnabled("UploadLargeFileByChunk")) {
                parameters.Columns = null;
            }
            SetImportParametersHeaderColumns(parameters, importObject.UId);
        }

        #endregion
    }
}
