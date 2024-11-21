namespace BPMSoft.Configuration
{

	using System;
	using BPMSoft.Core.DB;

	#region Class: VwAccountRelationship_NUIEventsProcess

	public partial class VwAccountRelationship_NUIEventsProcess<TEntity>
	{

		#region Properties: Protected

		protected Guid? ChildAccountId { get; set; }

		#endregion

		#region Methods: Protected

		protected Guid? GetChildAccountId() {
			var relationTypeId = Entity.GetTypedColumnValue<Guid>("RelationTypeId");
			var reverseRelationTypeId = Entity.GetTypedColumnValue<Guid>("ReverseRelationTypeId");
			var accountId = Entity.GetTypedColumnValue<Guid>("AccountId");
			var relatedAccountId = Entity.GetTypedColumnValue<Guid>("RelatedAccountId");
			if (accountId == Guid.Empty || relatedAccountId == Guid.Empty) {
				return null;
			}
			Guid? childAccountId = null;
			if (relationTypeId == GetParentRelationTypeId()) {
				childAccountId = relatedAccountId;
			} else if (reverseRelationTypeId == GetParentRelationTypeId()) {
				childAccountId = accountId;
			}
			return childAccountId;
		}

		protected virtual void CheckCanEditAccount() {
			ChildAccountId = GetChildAccountId();
			if (ChildAccountId.HasValue) {
				new RelationshipAccountUpdater(UserConnection).CheckCanEditAccount(ChildAccountId.Value);
			}
		}

		#endregion

		#region Methods: Public

		public virtual Guid GetParentRelationTypeId() {
			return (Guid)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "ParentAccountRelationType");
		}

		public virtual void ClearAccountParentId() {
			if (ChildAccountId.HasValue) {
				new RelationshipAccountUpdater(UserConnection).UpdateAccountParentId(ChildAccountId.Value, null);
			}
		}

		#endregion

	}

	#endregion

}

