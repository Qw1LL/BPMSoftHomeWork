namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: InvoiceRemindingTextFormer

	/// <summary>
	/// Provides methods to form "Invoice" remindings text data. 
	/// </summary>
	public class InvoiceRemindingTextFormer : IRemindingTextFormer
	{
		#region Fields: Private

		private const string ClassName = nameof(InvoiceRemindingTextFormer);

		#endregion
		
		#region Fields: Protected

		protected readonly UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		public InvoiceRemindingTextFormer(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion
		
		#region Methods: Private

		private string GetDate(DateTime datetime) {
			var dateMacros = UserConnection.GetLocalizableString(ClassName ,"DateMacros");
			return datetime.ToString(dateMacros);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public string GetBody(IDictionary<string, object> formParameters) {
			formParameters.CheckArgumentNull("formParameters");
			var bodyTemplate = UserConnection.GetLocalizableString(ClassName, "BodyTemplate");
			var number = (string)formParameters["Number"];
			var startDate = (DateTime)formParameters["StartDate"];
			var accountName = (string)formParameters["AccountName"];
			var contactName = (string)formParameters["ContactName"];
			var date = GetDate(startDate);
			var body = string.Format(bodyTemplate, number, date);
			var customer = new [] {accountName, contactName}.ConcatIfNotEmpty(", ");
			body += customer;
			return body;
		}

		/// <inheritdoc />
		public string GetTitle(IDictionary<string, object> formParameters) {
			return UserConnection.GetLocalizableString(ClassName, "TitleTemplate");
		}

		#endregion
	}

	#endregion
}
