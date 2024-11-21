using System;
using BPMSoft.Core;

namespace BPMSoft.Configuration
{

	#region Class: CalendarRemindCalculatorCustomerService

	public class CalendarRemindCalculatorCustomerService : CalendarRemindCalculator
	{
		#region Constructors: Private

		private CalendarRemindCalculatorCustomerService(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Methods: Public

		public static CalendarRemindCalculatorCustomerService CreateInstanceCustomerService(UserConnection userConnection, Guid caseId) {
			var caseEntity = getCaseEntity(userConnection, caseId, new[] { "ServiceItemId", "PriorityId" });
			if(caseEntity == null || caseEntity.PriorityId == Guid.Empty) {
				return null;
			}
			return new CalendarRemindCalculatorCustomerService(userConnection) { Case = caseEntity };
		}

		#endregion
	}

	#endregion
}
