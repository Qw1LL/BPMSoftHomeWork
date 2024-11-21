namespace BPMSoft.Configuration.FileImport
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Text;
	using Common;
	using Core;
	using Core.DB;
	using global::Common.Logging;
	using BPMSoft.Core.Factories;

	#region  Class: ImportLogger

	/// <summary>
	/// An instance of this class is responsible for logging import information.
	/// </summary>
	[DefaultBinding(typeof(IImportLogger), Name = nameof(ImportLogger))]
	public class ImportLogger: IImportLogger
	{
		#region  Fields: Private

		/// <summary>
		/// Error message template.
		/// </summary>
		private string _errorMessageTemplate;
		
		/// <summary>
		/// Error row template.
		/// </summary>
		private string _errorRowTemplate;

		private string _fileName;

		private List<IImportLogItem> _importLog;
		
		private ILog _log;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of type <see cref="ImportLogger" />.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="importParameters">Import parameters.</param>
		public ImportLogger(UserConnection userConnection, ImportParameters importParameters) {
			UserConnection = userConnection;
			ImportParameters = importParameters;
		}

		/// <summary>
		/// Creates instance of type <see cref="ImportLogger" />.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ImportLogger(UserConnection userConnection) => UserConnection = userConnection;

		#endregion

		#region Properties: Private

		/// <summary>
		/// Import log information.
		/// </summary>
		private List<IImportLogItem> ImportLog => _importLog ?? (_importLog = new List<IImportLogItem>());

		private string ErrorMessageTemplate {
			get {
				if (_errorMessageTemplate != null) {
					return _errorMessageTemplate;
				}
				var storage = UserConnection.Workspace.ResourceStorage;
				_errorMessageTemplate = new LocalizableString(storage, "ImportLogger",
					"LocalizableStrings.ErrorMessageTemplate.Value");
				return _errorMessageTemplate;
			}
		}
		
		private string ErrorRowTemplate {
			get {
				if (_errorRowTemplate != null) {
					return _errorRowTemplate;
				}
				var storage = UserConnection.Workspace.ResourceStorage;
				_errorRowTemplate = new LocalizableString(storage, "ImportLogger",
					"LocalizableStrings.ErrorRowTemplate.Value");
				return _errorRowTemplate;
			}
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Import parameters.
		/// </summary>
		protected ImportParameters ImportParameters { get; }

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; }

		#endregion

		#region Properties: Public

		public string FileName {
			get => _fileName ?? (_fileName = ImportParameters?.FileName ?? string.Empty);
			set => _fileName = value;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets insert log item query.
		/// </summary>
		/// <param name="importLogItem">Import log item.</param>
		/// <returns>Insert log item query.</returns>
		private Insert GetInsertLogItemQuery(IImportLogItem importLogItem) => new Insert(UserConnection)
			.Into("ExcelImportLog")
			.Set("Name", Column.Parameter(FileName))
			.Set("MessageText", Column.Parameter(importLogItem.Message))
			.Set("StackTrace", Column.Parameter(importLogItem.StackTrace));

		
		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles error.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		public void HandleError(object sender, ColumnProcessErrorEventArgs eventArgs) {
			var messageText = string.Format(ErrorMessageTemplate, eventArgs.CellReference, eventArgs.Message);
			ImportLog.Add(new ImportLogItem {
					Message = messageText
			});
		}

		/// <summary>
		/// Handles exception.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		public void HandleErrorMessage(object sender, ErrorMessageEventArgs eventArgs) {
			var messageText = string.Format("{0}: {1}", eventArgs.ImportSessionId, eventArgs.Exception.Message);
			ImportLog.Add(new ImportLogItem {
					Message = messageText,
					StackTrace = eventArgs.Exception.StackTrace
			});
		}

		/// <summary>
		/// Handles exception.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		public void HandleException(object sender, ImportEntitySaveErrorEventArgs eventArgs) {
			var messageText = string.Format(ErrorRowTemplate, eventArgs.ImportEntity.RowIndex, eventArgs.Exception.Message);
			ImportLog.Add(new ImportLogItem {
					Message = messageText,
					StackTrace = eventArgs.Exception.StackTrace ?? string.Empty
			});
		}

		/// <summary>
		/// Handles information message.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		public void HandleInfoMessage(object sender, InfoMessageEventArgs eventArgs) {
			ImportLog.Add(new ImportLogItem {
					Message = eventArgs.Message
			});
		}

		/// <summary>
		/// Logs import error.
		/// </summary>
		public void LogError(Exception exception) {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				var insert = GetInsertLogItemQuery(new ImportLogItem {
						Message = exception.Message,
						StackTrace = exception.StackTrace
				});
				insert.Execute(dbExecutor);
			}
		}

		/// <summary>
		/// Saves log.
		/// </summary>
		public void SaveLog() {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				foreach (var importLogItem in ImportLog) {
					var insert = GetInsertLogItemQuery(importLogItem);
					insert.Execute(dbExecutor);
				}
			}
		}

		#endregion
	}

	#endregion
}

