namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.FileImport;
	using BPMSoft.Configuration.GeneratedWebFormService;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using global::Common.Logging;

	#region Class: WebFormAsyncHandler

	/// <summary>
	/// Provides web form save handling.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.IWebFormHandler" />
	public class WebFormAsyncHandler : IWebFormHandler
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		private static readonly ILog _log = LogManager.GetLogger("WebToObject");

		#endregion

		#region Constructors

		public WebFormAsyncHandler(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		public WebFormAsyncHandler(UserConnection userConnection, IWebFormImportParamsGenerator importParamsGenerator,
			IWebFormProcessHandlersFactory factory, FileImporter fileImporter) {
			_userConnection = userConnection;
			FileImporter = fileImporter;
		}

		#endregion

		#region Properties: Protected

		protected FormData FormData {
			get;
			set;
		}

		private FileImporter _fileImporter;
		protected FileImporter FileImporter {
			get {
				return _fileImporter ??
					(_fileImporter = GetFileImporter());
			}
			set { _fileImporter = value; }
		}

		private GeneratedWebFormValidator _webFormValidator;
		protected GeneratedWebFormValidator WebFormValidator {
			get {
				return _webFormValidator ??
					(_webFormValidator = new GeneratedWebFormValidator(_userConnection));
			}
			set { _webFormValidator = value; }
		}

		private IWebFormHandler _webFormHandler;
		protected IWebFormHandler WebFormHandler {
			get {
				return _webFormHandler ?? (_webFormHandler = new WebFormHandler(_userConnection, WebFormValidator));
			}
			set { _webFormHandler = value; }
		}

		#endregion

		#region Properties: Public

		public bool Success {
			get;
			private set;
		}

		public string ErrorMessage {
			get;
			private set;
		}

		public Exception Exception {
			get;
			private set;
		}

		#endregion

		#region Methods: Private

		private FileImporter GetFileImporter() {
			var fileImporter = new FileImporter(_userConnection);
			fileImporter.ImportEntitySaveError += (sender, args) => {
				SetErrorStatus(args.Message ?? args.Exception.Message, args.Exception);
			};
			fileImporter.ColumnProcessError += (sender, args) => {
				SetErrorStatus(args.Message);
			};
			return fileImporter;
		}

		private void LogError() {
			_log.Error($"Error: {ErrorMessage}. Exception: {Exception}");
		}

		private void LogSuccess(string schemaName, Guid webFormId) {
			var formDataJson = Json.Serialize(FormData);
			_log.Debug($"Entity {schemaName} is created. Landing: {webFormId}. Form data: {formDataJson}");
		}

		private void UpdateValidatorRules(GeneratedWebFormValidator validator) {
			var disableRefererPolicy = (FormData?.options?.disableRefererPolicy).GetValueOrDefault();
			if (disableRefererPolicy) {
				validator.DisableExternalUrlValidation = true;
			}
		}

		private void SetErrorStatus(string message) {
			Success = false;
			ErrorMessage = message;
			LogError();
		}

		private void SetErrorStatus(string message, Exception exception) {
			Exception = exception;
			SetErrorStatus(message);
		}

		private void SaveWebFormData(Guid webFormDataId, Guid webFormId) {
			EntitySchema schema = _userConnection.EntitySchemaManager.FindInstanceByName(nameof(WebFormData));
			if (schema == null) {
				SetErrorStatus(GeneratedWebFormLczUtilities.GetLczStringValue("SchemaNotFoundError",
					"WebFormImportParamsGenerator", _userConnection));
				return;
			}
			var fieldsData = new Dictionary<string, string>();
			FormData.formFieldsData.ForEach(data => {
				fieldsData[data.name] = data.value;
			});
			var values = new Dictionary<string, string>();
			values["Id"] = webFormDataId.ToString();
			values["WebFormId"] = webFormId.ToString();
			values["Data"] = Json.Serialize(fieldsData, true);
			if (FormData.contactFieldsData != null) {
				FormData.contactFieldsData.ForEach(data => {
					values[data.name] = data.value;
				});
			}
			ImportParameters parameters = new BaseImportParamsGenerator().GenerateParameters(schema, values);
			FileImporter.ImportWithParams(parameters);
			if (Success) {
				LogSuccess(schema?.Name, webFormId);
			}
		}

		private static EntitySchemaQuery GetWebFormFindContactProcessEsq(UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "GeneratedWebForm");
			esq.AddColumn("IdentificationProcess.SysProcess.UId");
			esq.AddColumn("CreateContact");
			esq.AddColumn("Type.SchemaUid");
			return esq;
		}

		private Guid StartFindOrCreateContactProcess(Guid webFormId, Guid webFormDataId) {
			var esq = GetWebFormFindContactProcessEsq(_userConnection);
			var entity = esq.GetEntity(_userConnection, webFormId);
			if (entity == null) {
				return Guid.Empty;
			}
			var isCreateContact = entity.GetTypedColumnValue<bool>("CreateContact");
			var schemaUid = entity.GetTypedColumnValue<Guid>("Type_SchemaUidId");
			var webFormEntity = _userConnection.EntitySchemaManager.FindInstanceByUId(schemaUid);
			if (webFormEntity.Name == "Lead" && !isCreateContact) {
				return Guid.Empty;
			}
			var processUId = entity.GetTypedColumnValue<Guid>("IdentificationProcess_SysProcess_UId");
			if (processUId == Guid.Empty) {
				return Guid.Empty;
			}
			IProcessEngine processEngine = _userConnection.ProcessEngine;
			IProcessExecutor processExecutor = processEngine.ProcessExecutor;
			var inputParameters = new Dictionary<string, string> {
				["WebFormDataId"] = webFormDataId.ToString()
			};
			return processExecutor.Execute<Guid>(processUId, "ContactId", inputParameters);
		}

		private void AddFormFieldValue(string fieldName, string value) {
			var fieldsData = FormData.formFieldsData.ToList();
			var contactField = fieldsData.FirstOrDefault(f => f.name.Equals(fieldName));
			if (contactField == null) {
				fieldsData.Add(new FormFieldsData() {
					name = fieldName,
					value = value
				});
				FormData.formFieldsData = fieldsData.ToArray();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles the form data.
		/// </summary>
		/// <param name="formData">The form data.</param>
		public void HandleForm(FormData formData) {
			Success = true;
			FormData = formData;
			Guid webFormId = WebFormHelper.GetWebFormId(formData);
			if (webFormId.Equals(Guid.Empty)) {
				SetErrorStatus(GeneratedWebFormLczUtilities
					.GetLczStringValue("UnknownWebFormIdentifierMessage",
						"WebFormHandler", _userConnection));
				return;
			}
			UpdateValidatorRules(WebFormValidator);
			var formItemValidationResult = WebFormValidator.Validate(webFormId);
			if (!formItemValidationResult.Succes) {
				Success = false;
				ErrorMessage = formItemValidationResult.Message;
				LogError();
				return;
			}
			var webFormDataId = Guid.NewGuid();
			SaveWebFormData(webFormDataId, webFormId);
			if (!Success) {
				return;
			}
			AddFormFieldValue("WebFormDataId", webFormDataId.ToString());
			Task.Run(() => {
				var contactId = StartFindOrCreateContactProcess(webFormId, webFormDataId);
				if (contactId != Guid.Empty) {
					AddFormFieldValue("ContactId", contactId.ToString());
				}
				WebFormHandler.HandleForm(FormData);
			});
		}

		#endregion

	}

	#endregion

}

