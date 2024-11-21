namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core.Process;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;

	#region Class: EmailTemplateUserTaskUtilities

	public static class EmailTemplateUserTaskUtilities
	{

		#region Methods: Private

		private static string GetParameterLookupValue(UserConnection userConnection, object propertyValue,
			ProcessSchemaParameter parameter) {
			var email = string.Empty;
			EntitySchema schema = userConnection.EntitySchemaManager.FindInstanceByUId(parameter.ReferenceSchemaUId);
			if (schema != null) {
				string schemaName = schema.Name;
				switch (schemaName) {
					case "Contact":
						email = GetContactEmailValue(userConnection, propertyValue);
						break;
					case "Account":
						email = GetAcountEmailValue(userConnection, propertyValue);
						break;
				}
			}
			return email;
		}

		private static string GetContactEmailValue(UserConnection userConnection, object contactGuid) {
			var email = string.Empty;
			var esqResult = new EntitySchemaQuery(userConnection.EntitySchemaManager, "Contact");
			esqResult.AddColumn("Email");
			var entity = esqResult.GetEntity(userConnection, contactGuid);
			if (entity != null) {
				email = entity.GetTypedColumnValue<string>("Email");
			}
			return email;
		}

		private static string GetAcountEmailValue(UserConnection userConnection, object accountGuid) {
			var email = string.Empty;
			var esqResult = new EntitySchemaQuery(userConnection.EntitySchemaManager, "AccountCommunication");
			esqResult.AddColumn("Account");
			esqResult.AddColumn("CommunicationType");
			esqResult.AddColumn("Number");
			esqResult.AddColumn("Primary");
			var esqFirstFilter = esqResult.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Account", accountGuid);
			var esqSecondFilter = esqResult.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Primary", true);
			var esqThirdFilter = esqResult.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[CommunicationType:Id:CommunicationType].Name", "Email");
			esqResult.Filters.Add(esqFirstFilter);
			esqResult.Filters.Add(esqSecondFilter);
			esqResult.Filters.Add(esqThirdFilter);
			var entityCollection = esqResult.GetEntityCollection(userConnection);
			var entity = entityCollection.FirstOrDefault();
			if (entity != null) {
				email = entity.PrimaryDisplayColumnValue;
			}
			return email;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns list email addresses.
		/// </summary>
		/// <param name="userConnection">User's connection.</param>
		/// <param name="propertyValue">Parameter property value.</param>
		/// <param name="parameter">Process parameter</param>
		/// <returns></returns>
		public static List<string> GetParameterEmailAddresses(UserConnection userConnection, object propertyValue,
			ProcessSchemaParameter parameter) {
			List<string> emailAddresses = new List<string>();
			var value = parameter.DataValueType.IsLookup
					? GetParameterLookupValue(userConnection, propertyValue, parameter)
					: (String)propertyValue;
			if (value.IsNotNullOrEmpty()) {
				var separators = new char[] { ';', ',' };
				var parameterAddresses = value.Split(separators)
					.Select(x => x.Trim())
					.Where(x => !string.IsNullOrEmpty(x))
					.ToList();
				emailAddresses.AddRange(parameterAddresses);
			}
			return emailAddresses;
		}

		#endregion
	}

	#endregion
}
