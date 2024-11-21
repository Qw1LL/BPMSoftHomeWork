namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Core.Entities;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Interface: IApprovalAction

	public interface IApprovalAction
	{
		bool ChangeApproval(string entityName, Guid id, Dictionary<string, object> additionalColumnValues);

		bool ChangeApprovalWithLocationException(string entityName, Guid id,
			Dictionary<string, object> additionalColumnValues);
	}

	#endregion

	#region Class: ApprovalAction

	/// <summary>
	/// ApprovalAction class for working with Approval Entities
	/// </summary>
	[DefaultBinding(typeof(IApprovalAction))]
	public class ApprovalAction: IApprovalAction
	{

		#region Constructor: Public

		public ApprovalAction(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		#endregion

		#region Methods: Protected

		private bool GetIsFinalStatus(Guid statusId) {
			var visaStatusSelect = new Select(UserConnection)
				.Column("IsFinal")
				.From("VisaStatus")
				.Where("Id").IsEqual(Column.Parameter(statusId)) as Select;
			visaStatusSelect.SpecifyNoLockHints();
			return visaStatusSelect.ExecuteScalar<bool>();
		}

		#endregion

		#region Methods: Protected

		protected virtual bool IsFinalStatus(Entity entity) {
			var statusId = entity.GetTypedColumnValue<Guid>("StatusId");
			return GetIsFinalStatus(statusId);
		}

		#endregion

		#region Methods: Public

		public virtual bool ChangeApproval(string entityName, Guid id, Dictionary<string, object> additionalColumnValues) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
			Entity entity = entitySchema.CreateEntity(UserConnection);
			if (!entity.FetchFromDB(id) || IsFinalStatus(entity)) {
				return false;
			}
			entity.SetColumnValue("SetDate", DateTime.UtcNow);
			entity.SetColumnValue("SetById", UserConnection.CurrentUser.ContactId);
			if (additionalColumnValues != null) {
				foreach (var item in additionalColumnValues) {
					entity.SetColumnValue(item.Key, item.Value);
				}
			}
			return entity.Save();
		}

		public virtual bool ChangeApprovalWithLocationException(string entityName, Guid id,
			Dictionary<string, object> additionalColumnValues) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
			Entity entity = entitySchema.CreateEntity(UserConnection);
			if (!entity.FetchFromDB(id)) {
				throw new VisaNotFoundException();
			}
			if (IsFinalStatus(entity)) {
				throw new VisaFinalStatusException();
			}
			entity.SetColumnValue("SetDate", DateTime.UtcNow);
			entity.SetColumnValue("SetById", UserConnection.CurrentUser.ContactId);
			if (additionalColumnValues != null) {
				foreach (var item in additionalColumnValues) {
					entity.SetColumnValue(item.Key, item.Value);
				}
			}
			if (!entity.Save()) {
				throw new SaveVisaChangesException();
			}
			return true;
		}

		#endregion
	}

	#endregion

	#region VisaApprovalExceptions

	public class VisaNotFoundException : Exception {}

	public class VisaFinalStatusException : Exception {}

	public class SaveVisaChangesException : Exception {}

	#endregion

}

