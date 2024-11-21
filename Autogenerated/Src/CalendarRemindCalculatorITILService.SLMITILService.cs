using System;
using BPMSoft.Core;

namespace BPMSoft.Configuration
{

	#region Class: CalendarRemindCalculatorITILService

	public class CalendarRemindCalculatorITILService : CalendarRemindCalculator
	{
		#region Constructors: Private

		private CalendarRemindCalculatorITILService(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Methods: Public

		public static CalendarRemindCalculatorITILService CreateInstanceITILService(UserConnection userConnection, Guid caseId) {
			var caseEntity = getCaseEntity(userConnection, caseId, new[] { "ServiceItemId", "PriorityId", "ServicePactId" });
			if(caseEntity == null || caseEntity.ServicePactId == Guid.Empty || caseEntity.PriorityId == Guid.Empty) {
				return null;
			}
			return new CalendarRemindCalculatorITILService(userConnection) { Case = caseEntity };
		}

		#endregion
	}

	#endregion
}
