 namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Core;
	using Core.DB;

	#region Class: EmployeeAnniversaryReminding

	public class EmployeeAnniversaryReminding : BaseAnniversaryReminding
	{

		#region Constructor: Public

		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// </summary>
		public EmployeeAnniversaryReminding(UserConnection userConnection): base(userConnection) {
			SchemaName = "Contact";
			SourceId = RemindingConsts.ContactRemindSourceId;
		}
		
		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// <param name="id">Current record Id.</param>
		/// </summary>
		public EmployeeAnniversaryReminding(UserConnection userConnection, Guid id): this(userConnection) {
			RecordId = id;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Sets ContactId from active  SysAdminUnit it as ReceiverId column.
		/// </summary>
		/// <param name="select"></param>
		private void SetReceiverIdFromActiveEmployees(Select select) {
			const string receiverColumnAlias = "ReceiverId";
			QueryColumnExpression receiverColumn = select.Columns.FindByAlias(receiverColumnAlias);
			select.CrossJoin("SysAdminUnit").As("sau");
			int receiverIndex = select.Columns.IndexOf(receiverColumn);
			receiverColumn = Column.SourceColumn("sau", "ContactId");
			receiverColumn.Alias = receiverColumnAlias;
			select.Columns[receiverIndex] = receiverColumn;
			select.And("sau", "Active").IsEqual(Column.Parameter(true));
			select.And("sau", "ContactId").Not().IsNull();
			select.And("sau", "ConnectionType").IsNotEqual(Column.Parameter(UserType.SSP));
		}

		private void SetEmployeeFilter(Select select) {
			select.And("Contact", "TypeId").IsEqual(Column.Parameter(ContactConsts.EmployeeTypeId));
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
			if (!UserConnection.GetIsFeatureEnabled("NotificationV2")) {
				return select;
			}
			SetEmployeeFilter(select);
			SetReceiverIdFromActiveEmployees(select);
			return select;
		}

		protected override void InitQueryProperties() {
			base.InitQueryProperties();
			AddQueryProperty("Contact", string.Empty);
		}

		#endregion

	}

	#endregion
}

