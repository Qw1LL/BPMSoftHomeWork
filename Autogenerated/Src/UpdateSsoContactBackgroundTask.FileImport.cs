namespace BPMSoft.Configuration 
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.FileImport;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Tasks;

	#region Class: UpdateSsoContactBackgroundTask

	/// <summary>
	/// Class updates sso contact using SAML response from storage.
	/// </summary>
	public class UpdateSsoContactBackgroundTask : IBackgroundTask<bool>, IUserConnectionRequired
	{

		#region Fields: Private

		private readonly ILog _log = LogManager.GetLogger("UpdateSsoContact");

		private UserConnection _uc;

		#endregion

		#region Methods: Private

		private Dictionary<string, string> GetcontactValues() {
			var rawData = ((Select)new Select(_uc).Top(1)
				.Column("Response")
				.From("SamlResponse")
				.Where("ContactId").IsEqual(Column.Parameter(_uc.CurrentUser.ContactId)))
				.ExecuteScalar<string>();
			return rawData.IsNullOrEmpty() 
				? new Dictionary<string, string>()
				: Json.Deserialize<Dictionary<string, string>>(rawData);
		}

		private void UpdateContact(Entity contact, Dictionary<string, string> contactValues) {
			var importParamsGenerator = new BaseImportParamsGenerator();
			ImportParameters parameters = importParamsGenerator.GenerateParameters(contact.Schema, contactValues);
			var fileImporter = new FileImporter(_uc);
			fileImporter.ImportWithParams(parameters);
		}

		private void UpdateContactRights(EntitySchema contactSchema, Guid contactId,
				Dictionary<string, string> contactValues) {
			if (contactValues.TryGetValue("IsNewRecord", out string isNewRecord) &&
						isNewRecord.Equals("true", StringComparison.InvariantCultureIgnoreCase)) {
				var userId = new Guid(contactValues["SysAdminUnitId"]);
				_uc.DBSecurityEngine.AddDefRights(contactId, userId, contactId, contactSchema);
			}
		}

		private void ClearSamlResponseStorage() {
			new Delete(_uc).From("SamlResponse")
				.Where("ContactId").IsEqual(Column.Parameter(_uc.CurrentUser.ContactId))
				.Execute();
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="="IBackgroundTask.Run"/>

		public void Run(bool parameters) {
			try {
				var contactValues = GetcontactValues();
				if (!contactValues.Any()) {
					_log.Debug($"No saml response for {_uc.CurrentUser.ContactId}, update skipped");
					return;
				}
				EntitySchema contactSchema = _uc.EntitySchemaManager.GetInstanceByName("Contact");
				if (!contactValues.TryGetValue(contactSchema.GetPrimaryColumnName(), out string contactId)) {
					_log.Debug($"Saml response for {_uc.CurrentUser.ContactId}, not contains contact id, update skipped");
					return;
				}
				var contact = contactSchema.CreateEntity(_uc);
				if (contact.FetchFromDB(new Guid(contactId))) {
					UpdateContact(contact, contactValues);
					UpdateContactRights(contactSchema, contact.PrimaryColumnValue, contactValues);
				}
				ClearSamlResponseStorage();
			} catch (Exception e) {
				_log.Error("Error updating contact using saml response", e);
			}
		}

		/// <inheritdoc cref="="IUserConnectionRequired.SetUserConnection"/>
		public void SetUserConnection(UserConnection userConnection) {
			_uc = userConnection;
		}

		#endregion

	}

	#endregion

}
