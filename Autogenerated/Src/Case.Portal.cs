namespace BPMSoft.Configuration
{

	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Case_PortalEventsProcess

	public partial class Case_PortalEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual Guid GetContactSspUser(Guid ContactId) {
			var select = new Select(UserConnection)
				.Column("Id")
			.From("SysAdminUnit")
			.Where(Func.Upper("ContactId")).IsEqual(Func.Upper(Column.Parameter(ContactId)))
				.And("ConnectionType").IsEqual(Column.Parameter((int)BPMSoft.Core.UserType.SSP)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						return Guid.Parse(reader.GetValue(0).ToString());
					}
				}
			}
			return Guid.Empty;
		}

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		public override string GetServiceCaption() {
			var serviceItemId = Entity.GetTypedColumnValue<Guid>("ServiceItemId");
			var serviceQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ServiceItem");
			serviceQuery.AddColumn("Name"); 
			var service = serviceQuery .GetEntity(UserConnection, serviceItemId);
			if(service == null) {
				return string.Empty;
			} 
			return service.GetTypedColumnValue<string>("Name"); 
		}

		public virtual  Dictionary<Guid, Guid> GetSysAdminUnit(Guid contactId, Guid contactIdOld) {
			Dictionary<Guid, Guid> result = new Dictionary<Guid, Guid>();
			var sysAdminUnitSelect = new Select(UserConnection)
					.Column("Id")
					.Column("ContactId")
					.From("SysAdminUnit")
					.Where("Active").IsEqual(Column.Parameter(true))
					.And("ContactId").In(Column.Parameters(new List<Guid>() { contactIdOld, contactId })) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = sysAdminUnitSelect.ExecuteReader(dbExecutor)) {
					while(dr.Read()){
						result[dr.GetColumnValue<Guid>("ContactId")] = dr.GetColumnValue<Guid>("Id");
					} 
				}
			}
			return result;
		}

		public virtual bool IsResolved(Guid caseStatusId) {
			var IsResolvedSelect = new Select(UserConnection)
					.Column("IsResolved")
					.From("CaseStatus")
					.Where("Id").IsEqual(Column.Parameter(caseStatusId)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = IsResolvedSelect.ExecuteReader(dbExecutor)) {
					if(dr.Read()){
						return dr.GetColumnValue<bool>("IsResolved");
					} else {
						return false;
					}
				}
			}
		}

		public virtual void SetPortalCaseRights() {
			Guid contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			Guid caseStatusId = Entity.GetTypedColumnValue<Guid>("StatusId");
			bool isResolved = IsResolved(caseStatusId);
			bool isContactChanged = contactId != OldContactId;
			var sysAdminUnitIds = GetSysAdminUnit(contactId, OldContactId);
			Guid contactUserId = contactId == Guid.Empty ? Guid.Empty : GetContactSspUser(contactId);
			Guid oldContactUserId = OldContactId == Guid.Empty ? Guid.Empty : GetContactSspUser(OldContactId);
			int read = 0;
			int allow = 1;
			int rightLevel = 2;
			if(isContactChanged) {
				if(oldContactUserId != Guid.Empty && sysAdminUnitIds.ContainsKey(OldContactId)){
					ActualizePortalUsersRights(false, Entity.PrimaryColumnValue, 
							sysAdminUnitIds[OldContactId], read, rightLevel);
				}
				if(contactUserId != Guid.Empty && sysAdminUnitIds.ContainsKey(contactId)){
					ActualizePortalUsersRights(true, Entity.PrimaryColumnValue, 
							sysAdminUnitIds[contactId], read, rightLevel);
				}
			}
			if(sysAdminUnitIds.ContainsKey(contactId) && IsPortalUser(contactId)) {
				if(isResolved) {
					ActualizePortalUsersRights(true, Entity.PrimaryColumnValue, 
							sysAdminUnitIds[contactId], allow, rightLevel);
				} else {
					ActualizePortalUsersRights(false, Entity.PrimaryColumnValue, 
							sysAdminUnitIds[contactId], allow, rightLevel);
				}
			}
		}

		public virtual bool IsPortalUser(Guid contactId) {
			var isPortalUserSelect = new Select(UserConnection)
					.Column("ConnectionType")
					.From("SysAdminUnit")
					.Where("ContactId").IsEqual(Column.Parameter(contactId)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = isPortalUserSelect.ExecuteReader(dbExecutor)) {
					if(dr.Read()){
						if (dr.GetColumnValue<int>("ConnectionType") == 1) {
							return true;
						}
						return false;
					}
				}
				return false;
			}
		}

		public virtual void ActualizePortalUsersRights(bool action, Guid recordId, Guid sysAdminUnitId, int operation, int rightLevel) {
			var storedProcedure = new StoredProcedure(UserConnection, "tsp_ActualizePortalUsersRights");
			storedProcedure.WithParameter("Action", action);
			storedProcedure.WithParameter("RecordId", recordId);
			storedProcedure.WithParameter("SysAdminUnitId", sysAdminUnitId);
			storedProcedure.WithParameter("Operation", operation);
			storedProcedure.WithParameter("RightLevel", rightLevel);
			storedProcedure.Execute();
		}

		#endregion

	}

	#endregion

}

