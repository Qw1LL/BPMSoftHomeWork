namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Messaging.Common;

	#region Class: SysProcessElementDataOwner

	/// <summary>
	/// Manages owner of process element data.
	/// </summary>
	public class SysProcessElementDataOwner
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly IMsgChannelManager _msgChannelManager = MsgChannelManager.Instance;


		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="SysProcessElementDataOwner"/>
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public SysProcessElementDataOwner(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Guid[] GetEntityProcesses(SysProcessElementDataOwnerInfo elementDataOwnerInfo) {
			var select = new Select(_userConnection)
				.Column("SysProcessId")
				.From("SysProcessEntity").WithHints(new NoLockHint())
				.Where("EntityId")
				.IsEqual(Column.Parameter(elementDataOwnerInfo.EntityId)) as Select;
			return select.ExecuteEnumerable(r => r.GetColumnValue<Guid>("SysProcessId")).ToArray();
		}

		private List<Guid> GetProcessToDo(IEnumerable<Guid> processesId, SysProcessElementDataOwnerInfo elementDataOwnerInfo) {
			Select select = new Select(_userConnection)
					.Column("Id")
					.From("SysProcessElementToDo")
					.Where("SysProcessDataId").In(Column.Parameters(processesId))
					.And("ContactId").IsEqual(Column.Parameter(elementDataOwnerInfo.OldOwnerId)) as Select;
			return select.ExecuteEnumerable(reader => reader.GetColumnValue<Guid>("Id")).ToList();
		}

		private void UpdateSysProcessElementToDoOwner(IEnumerable<Guid> processesId, SysProcessElementDataOwnerInfo elementDataOwnerInfo) {
			var processToDo = GetProcessToDo(processesId, elementDataOwnerInfo);
			new Update(_userConnection, "SysProcessElementToDo")
				.Set("ContactId", Column.Parameter(elementDataOwnerInfo.NewOwnerId))
				.Where("Id").In(Column.Parameters(processToDo))
				.Execute();
			foreach (var id in processToDo) {
				NotifyOwners(id, elementDataOwnerInfo);
			}
		}

		private void UpdateSysProcessElementDataOwner(IEnumerable<Guid> processesId, SysProcessElementDataOwnerInfo elementDataOwnerInfo) {
			new Update(_userConnection, "SysProcessElementData")
				.Set("OwnerId", Column.Parameter(elementDataOwnerInfo.NewOwnerId))
				.Where("SysProcessId").In(Column.Parameters(processesId))
				.And("OwnerId").IsEqual(Column.Parameter(elementDataOwnerInfo.OldOwnerId))
				.Execute();
		}

		private Guid GetUserIdByContact(Guid contactId) {
			Select selectQuery = new Select(_userConnection)
					.Top(1)
					.Column("Id")
					.From("VwSysAdminUnit")
					.Where("ContactId").IsEqual(Column.Parameter(contactId))
					.And("SysAdminUnitTypeId").IsEqual(Column.Parameter(BaseConsts.UserSysAdminUnitTypeId))
				as Select;
			selectQuery.ExecuteSingleRecord(reader => reader.GetColumnValue<Guid>("Id"), out Guid adminUnit);
			return adminUnit;
		}

		private SimpleMessage CreateNotificationChangedMessage(Guid entityRecordId, string operation) {
			var message = new SimpleMessage {
				Id = Guid.NewGuid(),
				Body = $"{{ \"recordId\": \"{entityRecordId}\", \"operation\":\"{operation}\"}}",
				Header = {
					Sender = "ProcessDashboard"
				}
			};
			return message;
		}

		private void Notify(Guid entityId, Guid contactId, string operation) {
			var message = CreateNotificationChangedMessage(entityId, operation);
			var userId = GetUserIdByContact(contactId);
			_msgChannelManager.Post(new List<Guid>() { userId }, message);
		}

		private void NotifyOwners(Guid processId, SysProcessElementDataOwnerInfo elementDataOwnerInfo) {
			Notify(processId, elementDataOwnerInfo.OldOwnerId, "delete");
			Notify(processId, elementDataOwnerInfo.NewOwnerId, "update");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Changes owner of process element data.
		/// <param name="elementDataOwnerInfo">Information about owner of process element data.</param>
		/// </summary>
		public void Change(SysProcessElementDataOwnerInfo elementDataOwnerInfo) {
			var ownerProcessesId = GetEntityProcesses(elementDataOwnerInfo);
			if (ownerProcessesId.Length > 0) {
				UpdateSysProcessElementDataOwner(ownerProcessesId, elementDataOwnerInfo);
				UpdateSysProcessElementToDoOwner(ownerProcessesId, elementDataOwnerInfo);
			}
		}

		#endregion
	}

	#endregion

}
