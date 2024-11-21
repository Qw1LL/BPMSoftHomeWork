namespace BPMSoft.Core.Process.Configuration
{

	using System;
	using System.Security;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;

	#region Class: CheckRecordReadRightsUserTask

	/// <exclude/>
	public partial class CheckRecordReadRightsUserTask
	{

		#region Methods: Private

		protected bool CanReadRecord(string entitySchemaName, Guid recordId) {
			var dbSecurityEngine = UserConnection.DBSecurityEngine;
			return dbSecurityEngine.GetIsEntitySchemaReadingAllowed(EntitySchemaName) && dbSecurityEngine
				.GetEntitySchemaRecordRightLevel(entitySchemaName, recordId).HasFlag(SchemaRecordRightLevels.CanRead);
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (!CanReadRecord(EntitySchemaName, RecordId)) {
				throw new SecurityException(string.Format(new LocalizableString("BPMSoft.Core",
					"EntitySchema.Exception.NoRightForRead"), EntitySchemaName));
			}
			return true;
		}

		#endregion

	}

	#endregion

}

