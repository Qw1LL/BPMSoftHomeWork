namespace BPMSoft.Configuration
{

	using System;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;

	#region Class: Relationship_BaseEventsProcess

	public partial class Relationship_BaseEventsProcess<TEntity>
	{

		#region Methods: Protected

		protected virtual void CheckCanEditAccount(Guid oldChildAccountId, Guid childAccountId) {
			var accountUpdater = new RelationshipAccountUpdater(UserConnection);
			if (oldChildAccountId.IsNotEmpty()) {
				accountUpdater.CheckCanEditAccount(oldChildAccountId);
			}
			if (childAccountId.IsNotEmpty()) {
				accountUpdater.CheckCanEditAccount(childAccountId);
			}
		}

		#endregion

		#region Methods: Public

		public virtual Guid GetParentRelationTypeId() {
			return new Guid("{FB3A75D3-5FE6-DF11-971B-001D60E938C6}");
		}

		public virtual Guid GetReverseRelationshipTypeId() {
			return new Guid("{1ED655F3-5FE6-DF11-971B-001D60E938C6}");
		}

		public virtual bool CheckParentAccountExist() {
			bool result = false;
			Guid relationTypeId = Entity.GetTypedColumnValue<Guid>("RelationTypeId");
			Guid reverseRelationTypeId = Entity.GetTypedColumnValue<Guid>("ReverseRelationTypeId");
			Guid accountId = Guid.Empty;
			if (relationTypeId == GetParentRelationTypeId()) {
				accountId = Entity.GetTypedColumnValue<Guid>("AccountAId");
			} else if (reverseRelationTypeId == GetParentRelationTypeId()) {
				accountId = Entity.GetTypedColumnValue<Guid>("AccountBId");
			}
			if (accountId != Guid.Empty) {
				var select =(Select)new Select(UserConnection)
					.Column(Func.Count(Column.Asterisk()))
					.From("VwAccountRelationship")
					.Where("AccountId").IsEqual(Column.Parameter(accountId))
					.And("RelationTypeId").IsEqual(Column.Parameter(GetParentRelationTypeId()));
				using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
					int relationshipCount = select.ExecuteScalar<Int32>(executor);
					if (relationshipCount != 0) {
						result = true;
					}
				}
			}
			return result;
		}

		public virtual void UpdateAccount(Guid id, object parentId) {
			new RelationshipAccountUpdater(UserConnection).UpdateAccountParentId(id, (Guid?)parentId);
		}

		public virtual Guid GetChildAccountId(Guid accountAId, Guid accountBId, Guid relationTypeId, Guid reverseRelationTypeId) {
			if (relationTypeId == GetParentRelationTypeId()) {
				return accountAId;
			} else if (reverseRelationTypeId == GetParentRelationTypeId()) {
				return accountBId;
			}
			return Guid.Empty;
		}

		public virtual Guid GetParentAccountId(Guid accountAId, Guid accountBId, Guid relationTypeId, Guid reverseRelationTypeId) {
			if (relationTypeId == GetParentRelationTypeId()) {
				return accountBId;
			} else if (reverseRelationTypeId == GetParentRelationTypeId()) {
				return accountAId;
			}
			return Guid.Empty;
		}

		public virtual void UpdateAccountAfterRelationshipInserted() {
			Guid relationTypeId = Entity.GetTypedColumnValue<Guid>("RelationTypeId");
			Guid reverseRelationTypeId = Entity.GetTypedColumnValue<Guid>("ReverseRelationTypeId");
			Guid childAccountId =  GetChildAccountId(
				Entity.GetTypedColumnValue<Guid>("AccountAId"),
				Entity.GetTypedColumnValue<Guid>("AccountBId"),
				relationTypeId,
				reverseRelationTypeId
			);
			Guid parentAccountId =  GetParentAccountId(
				Entity.GetTypedColumnValue<Guid>("AccountAId"),
				Entity.GetTypedColumnValue<Guid>("AccountBId"),
				relationTypeId,
				reverseRelationTypeId
			);
			if (childAccountId != Guid.Empty && parentAccountId != Guid.Empty) {
				UpdateAccount(childAccountId, parentAccountId);
			}
		}

		public virtual void UpdateAccountAfterRelationshipSaved() {
			Guid relationTypeId = RelationTypeId;
			Guid reverseRelationTypeId = ReverseRelationTypeId;
			Guid oldRelationTypeId = OldRelationTypeId;
			Guid oldReverseRelationTypeId = OldReverseRelationTypeId;
			Guid childAccountId = ChildAccountId;
			Guid oldChildAccountId = OldChildAccountId;
			Guid parentAccountId = ParentAccountId;
			Guid oldParentAccountId = OldParentAccountId;
			
			if ((childAccountId != Guid.Empty || oldChildAccountId != Guid.Empty)
				&& (parentAccountId != Guid.Empty || oldParentAccountId != Guid.Empty)) {
				bool isRelationTypeChanged = (relationTypeId != oldRelationTypeId && oldRelationTypeId != Guid.Empty)
					|| (reverseRelationTypeId != oldReverseRelationTypeId && oldReverseRelationTypeId != Guid.Empty);
				if (!isRelationTypeChanged) {
					if (oldChildAccountId != childAccountId) {
						// ######### ######## ########## (### ######## # ############)
						UpdateAccount(oldChildAccountId, null);
						UpdateAccount(childAccountId, parentAccountId);
					} else if (oldParentAccountId != parentAccountId) {
						// ######### ############ ##########
						UpdateAccount(childAccountId, parentAccountId);
					}
				}
				// ########## ###########
				if (isRelationTypeChanged) {
					if (relationTypeId != GetParentRelationTypeId() && reverseRelationTypeId != GetParentRelationTypeId()) {
						// ########/######## -> ####################
						UpdateAccount(oldChildAccountId, null);
					} if (relationTypeId == GetParentRelationTypeId() || reverseRelationTypeId == GetParentRelationTypeId()) {
						// ########/######## <-> ########/########
						UpdateAccount(oldChildAccountId, null);
						UpdateAccount(childAccountId, parentAccountId);
					} else if (oldRelationTypeId != GetParentRelationTypeId() && oldReverseRelationTypeId != GetParentRelationTypeId()) {
						// #################### -> ########/########
						UpdateAccount(childAccountId, parentAccountId);
					}
				}
			}
		}

		public virtual void SetParametersBeforeSaving() {
			RelationTypeId = Entity.GetTypedColumnValue<Guid>("RelationTypeId");
			ReverseRelationTypeId = Entity.GetTypedColumnValue<Guid>("ReverseRelationTypeId");
			OldRelationTypeId = Entity.GetTypedOldColumnValue<Guid>("RelationTypeId");
			OldReverseRelationTypeId = Entity.GetTypedOldColumnValue<Guid>("ReverseRelationTypeId");
			ChildAccountId = GetChildAccountId(
				Entity.GetTypedColumnValue<Guid>("AccountAId"),
				Entity.GetTypedColumnValue<Guid>("AccountBId"),
				RelationTypeId,
				ReverseRelationTypeId
			);
			OldChildAccountId = GetChildAccountId(
				Entity.GetTypedOldColumnValue<Guid>("AccountAId"),
				Entity.GetTypedOldColumnValue<Guid>("AccountBId"),
				OldRelationTypeId,
				OldReverseRelationTypeId
			);
			ParentAccountId = GetParentAccountId(
				Entity.GetTypedColumnValue<Guid>("AccountAId"),
				Entity.GetTypedColumnValue<Guid>("AccountBId"),
				RelationTypeId,
				ReverseRelationTypeId
			);
			OldParentAccountId = GetParentAccountId(
				Entity.GetTypedOldColumnValue<Guid>("AccountAId"),
				Entity.GetTypedOldColumnValue<Guid>("AccountBId"),
				OldRelationTypeId,
				OldReverseRelationTypeId
			);
			CheckCanEditAccount(OldChildAccountId, ChildAccountId);
		}

		#endregion

	}

	#endregion

}

