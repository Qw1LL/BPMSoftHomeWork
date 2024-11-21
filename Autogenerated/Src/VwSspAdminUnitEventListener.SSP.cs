namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: VwSspAdminUnitEventListener

	/// <summary>
	/// Listener for 'VwSspAdminUnit' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "VwSspAdminUnit")]
	public class VwSspAdminUnitEventListener : BaseEntityEventListener
	{
		#region Fields: Private

		private static readonly Guid ManualRightSource = Guid.Parse("8A248A03-E9A5-DF11-9989-485B39C18470");

		#endregion

		#region Methods: Private

		private bool IsNeedToAddAccountRights(Entity adminUnit) {
			var selectAdminUnit = GetSysAdminUnitSelect(adminUnit);
			using (DBExecutor dbExec = adminUnit.UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectAdminUnit.ExecuteReader(dbExec)) {
					while (reader.Read()) {
						return reader.GetColumnValue<bool>("ConnectionType") &&
						       reader.GetColumnValue<int>("SysAdminUnitTypeValue") == 0 &&
						       reader.GetColumnValue<Guid>("PortalAccountId") != Guid.Empty;
					}
				}
			}
			return false;
		}

		private Select GetSysAdminUnitSelect(Entity adminUnit) {
			return new Select(adminUnit.UserConnection)
				.Column("SysAdminUnitTypeValue")
				.Column("ConnectionType")
				.Column("PortalAccountId")
				.From("SysAdminUnit")
				.Where("Id").IsEqual(
					Column.Parameter(adminUnit.GetTypedColumnValue<Guid>("Id"))) as Select;
		}

		private void AddAccountRights(Entity adminUnit) {
			AddAccountRights(adminUnit, 0);
			AddAccountRights(adminUnit, 1);
		}

		private void AddAccountRights(Entity adminUnit, int operation) {
			var insert = new Insert(adminUnit.UserConnection).Into("SysAccountRight")
				.Set("RecordId",
					Column.Parameter(adminUnit.GetTypedColumnValue<Guid>("PortalAccountId")))
				.Set("SysAdminUnitId",
					Column.Parameter(adminUnit.GetTypedColumnValue<Guid>("Id")))
				.Set("Operation", Column.Parameter(operation))
				.Set("RightLevel", Column.Parameter(2))
				.Set("SourceId", Column.Parameter(ManualRightSource));
			insert.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Inserted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			Entity adminUnit = (Entity)sender;
			if(IsNeedToAddAccountRights(adminUnit)) {
				AddAccountRights(adminUnit);
			}
		}

		#endregion

	}

	#endregion

}
 
