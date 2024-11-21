namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.FileImport;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: UpdateSsoContactMethodsWrapper

	/// <exclude/>
	public class UpdateSsoContactMethodsWrapper : ProcessModel
	{

		public UpdateSsoContactMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ActualizeContactScriptTaskExecute", ActualizeContactScriptTaskExecute);
		}

		#region Methods: Private

		private bool ActualizeContactScriptTaskExecute(ProcessExecutingContext context) {
			Dictionary<string, string> contactValues = Json.Deserialize<Dictionary<string, string>>(Get<string>("ClaimData"));
			UserConnection userConnection = Get<UserConnection>("UserConnection");
			var contact = new BPMSoft.Configuration.Contact(userConnection);
			string contactId;
			if (!contactValues.TryGetValue(contact.Schema.GetPrimaryColumnName(), out contactId)) {
				return true;
			}
			if (contact.FetchFromDB(new Guid(contactId))) {
				UpdateContact(contact, contactValues);
				string isNewRecord;
				if (contactValues.TryGetValue("IsNewRecord", out isNewRecord) &&
						isNewRecord.Equals("true", StringComparison.InvariantCultureIgnoreCase)) {
					EntitySchema schema = userConnection.EntitySchemaManager.GetInstanceByName("Contact");
					var userId = new Guid(contactValues["SysAdminUnitId"]);
					userConnection.DBSecurityEngine.AddDefRights(contact.Id, userId, contact.Id, schema);
				}
			}
			return true;
		}

			private void UpdateContact(Entity contact, Dictionary<string, string> contactValues) {
				UserConnection userConnection = Get<UserConnection>("UserConnection");
				var importParamsGenerator = new BaseImportParamsGenerator();
				ImportParameters parameters = importParamsGenerator.GenerateParameters(contact.Schema, contactValues);
				var fileImporter = new FileImporter(userConnection);
				fileImporter.ImportWithParams(parameters);
			}

		#endregion

	}

	#endregion

}

