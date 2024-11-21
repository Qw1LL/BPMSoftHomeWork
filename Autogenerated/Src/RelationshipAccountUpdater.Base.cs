namespace BPMSoft.Configuration
{
	using System;
	using System.Security;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: RelationshipAccountUpdater

	public class RelationshipAccountUpdater
	{

		#region Fields: Private
		
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public RelationshipAccountUpdater(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		public void CheckCanEditAccount(Guid id) {
			const string schemaName = "Account";
			const SchemaRecordRightLevels canEditRight = SchemaRecordRightLevels.CanEdit;
			DBSecurityEngine securityEngine = _userConnection.DBSecurityEngine;
			if (!securityEngine.GetIsEntitySchemaEditingAllowed(schemaName) ||
					(securityEngine.GetEntitySchemaRecordRightLevel(schemaName, id) & canEditRight) != canEditRight) {
				throw new SecurityException(string.Format(
					new LocalizableString("BPMSoft.Core", "Entity.Exception.NoRightFor.Update"), schemaName));
			}
		}

		public void UpdateAccountParentId(Guid accountId, Guid? parentAccountId) {
			var updateAccountQuery = new Update(_userConnection, "Account");
			QueryColumnExpression parentAccountParameter = parentAccountId.HasValue
				? Column.Parameter(parentAccountId.Value)
				: Column.Const(null);
			updateAccountQuery.Set("ParentId", parentAccountParameter);
			updateAccountQuery.Where("Id").IsEqual(Column.Parameter(accountId));
			updateAccountQuery.Execute();
		}
		
		#endregion
		
	}
	
	#endregion
	
}
