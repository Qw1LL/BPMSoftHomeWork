namespace BPMSoft.Configuration 
{
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Common;

	#region Class: ActivityRemindingTextFormer

	/// <summary>
	/// Provides methods to form "Activity" remindings text data. 
	/// </summary>
	public class ActivityRemindingTextFormer: IRemindingTextFormer
	{
		#region Fields: Private

		protected readonly UserConnection UserConnection;

		#endregion

		#region Constructors: Public

		public ActivityRemindingTextFormer(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion
		
		#region Methods: Public

		/// <inheritdoc />
		public string GetBody(IDictionary<string,object> formParameters) {
			formParameters.CheckArgumentNull("formParameters");
			var activityTitle = (string)formParameters["Title"];
			var accountName = (string)formParameters["AccountName"];
			var contactName = (string)formParameters["ContactName"];
			var customerTitle = new [] { accountName, contactName }.ConcatIfNotEmpty(", ");
			var bodyWithCustomerTitle = $"{customerTitle}: {activityTitle}";
			var body = string.IsNullOrWhiteSpace(customerTitle) ? activityTitle : bodyWithCustomerTitle;
			return body;
		}

		/// <inheritdoc />
		public string GetTitle(IDictionary<string,object> formParameters) {
			return UserConnection.GetLocalizableString(nameof(ActivityRemindingTextFormer), "Title");
		}

		#endregion
	}

	#endregion
}

