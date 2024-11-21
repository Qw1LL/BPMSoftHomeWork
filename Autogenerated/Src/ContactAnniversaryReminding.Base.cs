namespace BPMSoft.Configuration
{
	using Common;
	using System;
	using System.Collections.Generic;
	using Core;
	using Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: ContactAnniversaryReminding

	/// <summary>
	/// Contact data used by <see cref="ContactAnniversaryReminding"/>
	/// </summary>
	public class ContactAnniversaryRemindingInfo {

		/// <summary>
		/// Contact id column value.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Contact TypeId column value.
		/// </summary>
		public Guid TypeId { get; set; }

		/// <summary>
		/// Returns true if current contact type is Employee.
		/// </summary>
		public virtual bool IsEmployee {
			get { return TypeId == ContactConsts.EmployeeTypeId; }
		}

		/// <summary>
		/// Initializes required data from entity instance, or from database if column value is not loaded.
		/// </summary>
		/// <param name="contactEntity"></param>
		public void Initialize(Entity contactEntity) {
			contactEntity.CheckArgumentNull("contactEntity");
			Id = contactEntity.PrimaryColumnValue;
			EntitySchema schema = contactEntity.Schema;
			EntitySchemaColumn primaryColumn = schema.PrimaryColumn; 
			EntitySchemaColumn typeColumn = schema.Columns.FindByName("Type"); 
			if (!contactEntity.GetIsColumnValueLoaded(typeColumn)) {
				contactEntity.FetchFromDB(schema.PrimaryColumn, Id, new[] {primaryColumn, typeColumn});
			}
			TypeId = contactEntity.GetTypedColumnValue<Guid>(typeColumn);
		}
	}

	#endregion

	#region Class: ContactAnniversaryReminding

	public class ContactAnniversaryReminding : BaseAnniversaryReminding
	{

		#region Properies: Protected

		protected readonly ContactAnniversaryRemindingInfo ContactInfo;

		#endregion

		#region Constructor: Public

		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// </summary>
		public ContactAnniversaryReminding(UserConnection userConnection): base(userConnection) {
			SchemaName = "Contact";
			ContactInfo = new ContactAnniversaryRemindingInfo();
			SourceId = RemindingConsts.ContactRemindSourceId;
		}
		
		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// <param name="id">Current record Id.</param>
		/// </summary>
		public ContactAnniversaryReminding(UserConnection userConnection, Guid id): this(userConnection) {
			RecordId = id;
			ContactInfo.Id = id;
		}

		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// <param name="info">Current contact data.</param>
		/// </summary>
		public ContactAnniversaryReminding(UserConnection userConnection, ContactAnniversaryRemindingInfo info) 
				: this(userConnection) {
			info.CheckArgumentNull("info");
			RecordId = info.Id;
			ContactInfo = info;
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
			select.And("Contact", "TypeId").IsEqual(Column.Parameter(ContactConsts.EmployeeTypeId));
		}

		private void SetNotEmployeeFilter(Select select) {
			select.And()
				.OpenBlock("Contact", "TypeId")
					.IsNotEqual(Column.Parameter(ContactConsts.EmployeeTypeId))
					.Or("Contact", "TypeId").IsNull()
				.CloseBlock();
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
			if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
				SetNotEmployeeFilter(select);
			} else if (ContactInfo.IsEmployee) {
				SetReceiverIdFromActiveEmployees(select);
			}
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

