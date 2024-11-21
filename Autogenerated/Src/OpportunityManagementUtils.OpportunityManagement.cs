namespace BPMSoft.Configuration.OpportunityManagement
{
	using BPMSoft.Core;
	using System.Linq;

	public class OpportunityManagementUtils {
		public static bool GetIsAnySchemaAdministratedByRecords(UserConnection userConnection,
			params string[] entitySchemaNames) {
				return entitySchemaNames.Any(userConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByRecords);
		}
	}
	
}
