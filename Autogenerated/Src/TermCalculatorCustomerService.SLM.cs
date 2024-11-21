using System;
using System.Linq;
using BPMSoft.Core;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{

	#region Class: TermCalculatorCustomerService

	public class TermCalculatorCustomerService : TermCalculator
	{
		#region Constructors: Public

		public TermCalculatorCustomerService(UserConnection userConnection, Guid serviceItemId, Guid priorityId) 
			: base(userConnection, serviceItemId, priorityId) {
		}

		#endregion
		
		#region Methods: Protected

		protected override Guid GetCalendarId() {
			return ServiceItem != null && ServiceItem.CalendarId != Guid.Empty
				? ServiceItem.CalendarId
				: base.GetCalendarId();
		}

		#endregion

		#region Methods: Public

		public override ResponseTime GetMinResponseTime(ResponseTimeColumnsConfig respondTimeColumnsConfig) {
			ResponseTime serviceResponse = base.GetMinResponseTime(respondTimeColumnsConfig);
			return GetMinResponseTimeByPriority(serviceResponse, respondTimeColumnsConfig);
		}

		#endregion
	}

	#endregion
}
