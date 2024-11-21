namespace BPMSoft.Configuration
{
	using Core;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using GeneratedWebFormService;

	#region Class: WebFormCasePreProcessHandler

	public class WebFormCasePreProcessHandler : IGeneratedWebFormPreProcessHandler
	{

		#region Properties: Protected

		/// <summary>
		/// User connection object.
		/// </summary>
		protected UserConnection UserConnection {
			get;
			set;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Creates and returns new field for form fields data.
		/// </summary>
		/// <param name="columnName">Column name to create</param>
		/// <returns>Created column</returns>
		private FormFieldsData CreateField(string columnName) {
			var field = new FormFieldsData {
				name = columnName
			};
			return field;
		}

		/// <summary>
		/// Extracts field with specified name from form fields data.
		/// </summary>
		/// <param name="columnName">Column name to extract</param>
		/// <param name="fieldsData">Form fields data</param>
		/// <returns>Extracted field</returns>
		private FormFieldsData GetField(string columnName, List<FormFieldsData> fieldsData) {
			return fieldsData.FirstOrDefault(field =>
				field.name.Equals(columnName));
		}

		/// <summary>
		/// Prepares phone number for quick search by digits only.
		/// </summary>
		/// <param name="phone">Phone number to process</param>
		/// <returns>Reversed phone number that contains digits only</returns>
		private static string PrepareSearchNumber(string phone) {
			string phoneDigits = Regex.Replace(phone, @"\D", "");
			char[] phoneDigitsArray = phoneDigits.ToCharArray();
			Array.Reverse(phoneDigitsArray);
			return new string(phoneDigitsArray);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Fills Registration date field default value by current date and time.
		/// </summary>
		protected void SetRegisteredOn(List<FormFieldsData> fieldsData) {
			var field = CreateField("RegisteredOn");
			field.value = UserConnection.CurrentUser.GetCurrentDateTime()
				.ToString(UserConnection.CurrentUser.Culture);
			fieldsData.Add(field);
		}

		/// <summary>
		/// Gets select query to search contact by email.
		/// </summary>
		/// <param name="email">Email</param>
		/// <returns>Select query object</returns>
		protected Select GetContactSelectByEmail(string email) {
			Select select = new Select(UserConnection)
				.Column("ContactId")
				.From("ContactCommunication").As("CC")
				.LeftOuterJoin("CommunicationType").As("CT").On("CC", "CommunicationTypeId").IsEqual("CT", "Id")
				.LeftOuterJoin("ComTypebyCommunication").As("CTC").On("CT", "Id").IsEqual("CTC", "CommunicationTypeId")
				.LeftOuterJoin("Communication").As("C").On("C", "Id").IsEqual("CTC", "CommunicationId")
				.Where("C", "Code").IsEqual(Column.Parameter("Email"))
				.And("CT", "UseforContacts").IsEqual(Column.Parameter(true))
				.And("CC", "Number").IsEqual(Column.Parameter(email)) as Select;
			return select;
		}

		/// <summary>
		/// Gets select query to search contact by phone.
		/// </summary>
		/// <param name="phone">Phone number</param>
		/// <returns>Select query object</returns>
		protected Select GetContactSelectByPhone(string phone) {
			var reversePhoneDigits = PrepareSearchNumber(phone);
			Select select = new Select(UserConnection)
				.Column("ContactId")
				.From("ContactCommunication").As("CC")
				.LeftOuterJoin("CommunicationType").As("CT").On("CC", "CommunicationTypeId").IsEqual("CT", "Id")
				.LeftOuterJoin("ComTypebyCommunication").As("CTC").On("CT", "Id").IsEqual("CTC", "CommunicationTypeId")
				.LeftOuterJoin("Communication").As("C").On("C", "Id").IsEqual("CTC", "CommunicationId")
				.Where("C", "Code").IsEqual(Column.Const("Phone"))
				.And("CT", "UseforContacts").IsEqual(Column.Const(true))
				.And("CC", "SearchNumber").IsEqual(Column.Parameter(reversePhoneDigits)) as Select;
			return select;
		}

		/// <summary>
		/// Gets select query to search contact by name.
		/// </summary>
		/// <param name="name">Full contact name</param>
		/// <returns>Select query object</returns>
		protected Select GetContactSelectByName(string name) {
			Select select = new Select(UserConnection)
				.Column("Id").As("ContactId")
				.From("Contact")
				.Where("Name").IsEqual(Column.Parameter(name)) as Select;
			return select;
		}

		/// <summary>
		/// Creates and saves new contact with specified communications.
		/// </summary>
		/// <param name="name">Full contact name</param>
		/// <param name="email">Email</param>
		/// <param name="phone">Phone number</param>
		/// <returns>Created contact id</returns>
		protected Guid CreateContact(string name, string email, string phone) {
			EntitySchema contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity contact = contactSchema.CreateEntity(UserConnection);
			contact.SetDefColumnValues();
			Guid contactId = Guid.NewGuid();
			contact.SetColumnValue("Id", contactId);
			contact.SetColumnValue("Name", name.Trim());
			contact.SetColumnValue("Email", email.Trim());
			contact.SetColumnValue("Phone", phone.Trim());
			contact.Save(false);
			return contactId;
		}

		/// <summary>
		/// Executes select contact query and returns found contact ids list.
		/// </summary>
		/// <param name="select">Select contact query</param>
		/// <returns>List of found contact ids</returns>
		private List<Guid> GetContactIdsFromQuery(Select select) {
			var contactIds = new List<Guid>();
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						contactIds.Add(dr.GetColumnValue<Guid>("ContactId"));
					}
				}
				return contactIds;
			}
		}

		/// <summary>
		/// Finds contact with specified communications and returns its id.
		/// Else creates new contact with specified communications.
		/// </summary>
		/// <param name="name">Full contact name</param>
		/// <param name="email">Email</param>
		/// <param name="phone">Phone number</param>
		/// <returns></returns>
		protected Guid GetContactId(string name, string email, string phone) {
			List<Guid> contactSelectByEmail = GetContactIdsFromQuery(GetContactSelectByEmail(email));
			if (!contactSelectByEmail.Any()) {
				return CreateContact(name, email, phone);

			}
			List<Guid> contactSelectByPhone = GetContactIdsFromQuery(GetContactSelectByPhone(phone));
			List<Guid> contactSelectByName = GetContactIdsFromQuery(GetContactSelectByName(name));
			var contactId = contactSelectByEmail.Intersect(contactSelectByPhone)
				.Intersect(contactSelectByName).FirstOrDefault();
			if (!Guid.Empty.Equals(contactId)) {
				return contactId;
			}
			contactId = contactSelectByEmail.Intersect(contactSelectByName).FirstOrDefault();
			if (!Guid.Empty.Equals(contactId)) {
				return contactId;
			}
			return contactSelectByEmail.FirstOrDefault();
		}

		/// <summary>
		/// Sets contact field into form fields data.
		/// </summary>
		protected void SetContact(List<FormFieldsData> fieldsData) {
			var contactName = GetField("Name", fieldsData).value;
			var contactPhone = GetField("Phone", fieldsData).value;
			var contactEmail = GetField("Email", fieldsData).value;
			var contactId = GetContactId(contactName, contactEmail, contactPhone);
			var field = CreateField("ContactId");
			field.value = contactId.ToString();
			fieldsData.Add(field);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handler entry point. Processes form data.
		/// </summary>
		/// <param name="userConnection">User connection</param>
		/// <param name="formData">Form data</param>
		/// <param name="paramsGenerator">Parameters generator</param>
		/// <returns></returns>
		public FormData Execute(UserConnection userConnection, FormData formData,
				IWebFormImportParamsGenerator paramsGenerator) {
			UserConnection = userConnection;
			var fieldsData = formData.formFieldsData.ToList();
			SetRegisteredOn(fieldsData);
			SetContact(fieldsData);
			formData.formFieldsData = fieldsData.ToArray();
			return formData;
		}

		#endregion

	}

	#endregion

}

