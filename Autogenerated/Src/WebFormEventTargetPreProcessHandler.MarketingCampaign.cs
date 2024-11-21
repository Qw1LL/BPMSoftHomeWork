namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core.Entities;
	using Common;
	using Core;
	using GeneratedWebFormService;
	using BPMSoft.Configuration.MarketingCampaign;

	#region Class: WebFormEventTargetPreProcessHandler

	/// <summary>
	/// Executes pre event target saving processing.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.IGeneratedWebFormPreProcessHandler" />
	public class WebFormEventTargetPreProcessHandler : IGeneratedWebFormPreProcessHandler
	{

		#region Fields: Private

		private List<FormFieldsData> _fieldsData;
		private UserConnection _userConnection;
		private const string ContactSchemaName = "Contact";
		private const string ContactIdFieldName = "ContactId";
		private const string WebFormIdFieldName = "GeneratedWebForm";

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the default value manager.
		/// </summary>
		private IDefaultValueManager _defaultValueManager;
		public IDefaultValueManager DefaultValueManager {
			get => _defaultValueManager ?? (_defaultValueManager = new ObjectDefaultValueManager());
			set {
				if (value != null) {
					_defaultValueManager = value;
				}
			}
		}

		#endregion

		#region Methods: Private

		private FormFieldsData CreateField(string columnName) {
			var field =  new FormFieldsData() {
				name = columnName
			};
			return field;
		}

		private FormFieldsData CreateContactIdField(Guid contactId) {
			var field = CreateField(ContactIdFieldName);
			field.value = contactId.ToString();
			return field;
		}

		private FormFieldsData GetField(string columnName) {
			return _fieldsData.FirstOrDefault(field =>
				field.name.ToLower().Equals(columnName));
		}

		private FormFieldsData GetContactNameField() {
			return GetField("contact");
		}

		private FormFieldsData GetContactIdField() {
			return GetField("contactid");
		}

		private bool CheckGeneratedWebFormExists(Guid webFormId) {
			var webForm = new GeneratedWebForm(_userConnection);
			return webForm.FetchFromDB("Id", webFormId, new[] {"Id"});
		}

		private FormFieldsData CreateWebFormIdField() {
			return CreateField(WebFormIdFieldName);
		}

		private FormFieldsData GetWebFormIdField() {
			return GetField(WebFormIdFieldName);
		}

		private Guid GetEventIdValue() {
			var webFormIdField = _fieldsData.FirstOrDefault(x => x.name == WebFormIdFieldName);
			Guid.TryParse(webFormIdField.value, out var webFormId);
			var defaultValues = DefaultValueManager.GetValues(webFormId, _userConnection);
			defaultValues.TryGetValue("EventId", out var eventIdDefaultValue);
			return eventIdDefaultValue == null ? Guid.Empty : (Guid)eventIdDefaultValue;
		}

		private bool CheckContactIdField(FormFieldsData contactIdField, ref Guid contactId) {
			if (contactIdField.value.IsValidGuid()) {
				contactId = Guid.Parse(contactIdField.value);
				if (CheckContactExists(contactId)) {
					CheckEventTargetExists(contactId);
					return true;
				}
			} else {
				_fieldsData.Remove(contactIdField);
			}
			return false;
		}

		#endregion

		#region Methods: Protected

		protected void CheckEventTargetExists(Guid contactId) {
			var eventId = GetEventIdValue();
			var eventTarget = new EventTarget(_userConnection);
			var conditions = new Dictionary<string, object>();
			conditions.Add("Event", eventId);
			conditions.Add("Contact", contactId);
			if (eventTarget.ExistInDB(conditions)) {
				throw new SaveDuplicatedEntityException("Event participant is already exists");
			}
		}

		protected bool CheckContactExists(Guid contactId) {
			var contact = new Contact(_userConnection);
			return contact.FetchFromDB("Id", contactId, new[] {"Id"});
		}

		protected Guid CheckContactExists(string contactName) {
			var contact = new Contact(_userConnection);
			contact.FetchFromDB("Name", contactName, new[] { "Id" });
			return contact.IsColumnValueLoaded("Id") ? contact.GetTypedColumnValue<Guid>("Id") : Guid.Empty;
		}

		protected virtual void CreateContactEntity(Guid contactId, FormFieldsData contactNameField) {
			EntitySchema contactSchema = _userConnection.EntitySchemaManager.GetInstanceByName(ContactSchemaName);
			Entity contact = contactSchema.CreateEntity(_userConnection);
			contact.SetDefColumnValues();
			contact.SetColumnValue("Id", contactId);
			contact.SetColumnValue("Name", contactNameField.value);
			contact.Save(false);
		}

		protected void ProcessContactField() {
			var contactId = Guid.NewGuid();
			var contactIdField = GetContactIdField();
			if (contactIdField != null && CheckContactIdField(contactIdField, ref contactId)) {
				return;
			}
			var contactNameField = GetContactNameField();
			if (contactNameField == null || contactNameField.value.IsNullOrEmpty()) {
				return;
			}
			var existingContactId = CheckContactExists(contactNameField.value);
			if (existingContactId.IsNotEmpty()) {
				CheckEventTargetExists(existingContactId);
				contactId = existingContactId;
			} else {
				CreateContactEntity(contactId, contactNameField);
			}
			if (contactIdField == null) {
				contactIdField = CreateContactIdField(contactId);
			}
			_fieldsData.Add(contactIdField);
		}

		protected void ProcessGeneratedWebFormField(FormData formData) {
			Guid webFormId;
			if (Guid.TryParse(formData.formId, out webFormId)) {
				if (CheckGeneratedWebFormExists(webFormId)) {
					FormFieldsData webFormIdField = GetWebFormIdField() ?? CreateWebFormIdField();
					webFormIdField.value = webFormId.ToString();
					_fieldsData.Add(webFormIdField);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes pre event target saving processing.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="formData">The form data.</param>
		/// <param name="paramsGenerator">The parameters generator.</param>
		/// <returns>The form data.</returns>
		public FormData Execute(UserConnection userConnection, FormData formData, 
				IWebFormImportParamsGenerator paramsGenerator) {
			_userConnection = userConnection;
			_fieldsData = formData.formFieldsData.ToList();
			ProcessGeneratedWebFormField(formData);
			ProcessContactField();
			formData.formFieldsData = _fieldsData.ToArray();
			return formData;
		}

		#endregion

	}

	#endregion

}

