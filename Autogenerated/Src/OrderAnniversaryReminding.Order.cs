namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using Constants = OrderPackage.Constants.Order;

	#region Class: OrderAnniversaryReminding

	public class OrderAnniversaryReminding : BaseAnniversaryReminding
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
		public OrderAnniversaryReminding(UserConnection userConnection): base(userConnection) {
			SchemaName = "Order";
			SourceId = RemindingConsts.OrderRemindSourceId;
		}
		
		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// <param name="id">Current record Id.</param>
		/// </summary>
		public OrderAnniversaryReminding(UserConnection userConnection, Guid id): this(userConnection) {
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
			select.And(SchemaName, "StatusId").In(Column.Parameters(Constants.OrderInProgressStatusId,
				Constants.OrderDraftStatusId, Constants.OrderConfirmationStatusId));
			select = AnniversaryRemindingsHelper.JoinTable(select, SchemaName, queryProperty.Key);
			return select;
		}

		protected override void InitQueryProperties() {
			base.InitQueryProperties();
			AddQueryProperty("Account", string.Empty);
			AddQueryProperty("Contact", string.Empty);
		}

		protected override Dictionary<string, KeyValuePair<string, string>> GetQueryOptionsDictionary() {
			var optionsDict = base.GetQueryOptionsDictionary();
			optionsDict.Add(AccountOption, new KeyValuePair<string, string>("Account", string.Empty));
			optionsDict.Add(ContactOption, new KeyValuePair<string, string>("Contact", string.Empty));
			return optionsDict;
		}

		#endregion

	}

	#endregion
}

