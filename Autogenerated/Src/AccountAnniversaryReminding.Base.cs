namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	
	#region Class: AccountAnniversaryReminding

	public class AccountAnniversaryReminding : BaseAnniversaryReminding
	{
		#region Fields: Public

		public static readonly string AccountOption = "Account";
		public static readonly string ContactOption = "Contact";

		#endregion

		#region Constructor: Public

		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// </summary>
		public AccountAnniversaryReminding(UserConnection userConnection): base(userConnection) {
			SchemaName = "Account";
			SourceId = RemindingConsts.AccountRemindSourceId;
		}

		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// <param name="id">Current record Id.</param>
		/// </summary>
		public AccountAnniversaryReminding(UserConnection userConnection, Guid id): this(userConnection) {
			RecordId = id;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns select with all filters for current entity.
		/// <param name="select">Select for getting anniversary reminding.</param>
		/// <param name="queryProperty">Query property for current select.</param>
		/// <param name="queryProperty.Key">Anniversary entity schema name</param>
		/// <param name="queryProperty.Value">The property determines type of the decoration.</param>
		/// <returns>Modified select with all filters for current entity.</returns>
		/// </summary>
		protected override Select DecorateSelect(Select select, KeyValuePair<string, string> queryProperty) {
			if (queryProperty.Key.Equals("Contact")) {
				select.Join(JoinType.Inner, "Contact")
					.On("Account", "PrimaryContactId").IsEqual("Contact", "Id");
			}
			return select;
		}

		protected override void InitQueryProperties() {
			base.InitQueryProperties();
			AddQueryProperty("Account", string.Empty);
			AddQueryProperty("Contact", string.Empty);
		}

		protected override Dictionary<string, KeyValuePair<string, string>> GetQueryOptionsDictionary() {
			var optionsDict =  base.GetQueryOptionsDictionary();
			optionsDict.Add(AccountOption, new KeyValuePair<string, string>("Account", string.Empty));
			optionsDict.Add(ContactOption, new KeyValuePair<string, string>("Contact", string.Empty));
			return optionsDict;
		}

		#endregion

	}

	#endregion
}

