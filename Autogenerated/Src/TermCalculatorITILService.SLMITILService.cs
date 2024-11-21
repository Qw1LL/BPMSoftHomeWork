using System;
using System.Linq;
using BPMSoft.Core;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{

	#region Class: TermCalculatorITILService

	public class TermCalculatorITILService : TermCalculator
	{

		#region Fields: Private

		private ServicePact _servicePact;

		private ServiceInServicePact _serviceInServicePact;

		#endregion

		#region Constructors: Public

		public TermCalculatorITILService(UserConnection userConnection, Guid servicePactId, Guid serviceItemId, Guid priorityId) 
			: base(userConnection, serviceItemId, priorityId) {
			ServicePactId = servicePactId;
			ServiceInServicePactId = GetServiceInServicePactId(servicePactId, serviceItemId);
		}

		#endregion

		#region Properties: Protected

		protected Guid ServicePactId {
			get;
			set;
		}

		protected Guid ServiceInServicePactId {
			get;
			set;
		}

		protected ServicePact ServicePact {
			get {
				if (_servicePact != null) {
					return _servicePact;
				}

				if (ServicePactId == Guid.Empty) {
					return null;
				}

				var serviceArgeement = new ServicePact(UserConnection);
				if (serviceArgeement.FetchFromDB(ServicePactId)) {
					_servicePact = serviceArgeement;
				}
				return _servicePact;
			}
		}

		protected ServiceInServicePact ServiceInServicePact {
			get {
				if (_serviceInServicePact != null) {
					return _serviceInServicePact;
				}

				if (ServiceInServicePactId == Guid.Empty) {
					return null;
				}

				var serviceInServicePact = new ServiceInServicePact(UserConnection);
				if (serviceInServicePact.FetchFromDB(ServiceInServicePactId)) {
					_serviceInServicePact = serviceInServicePact;
				}
				return _serviceInServicePact;
			}
		}
		
		#endregion

		#region Methods: Private

		private Guid GetServiceInServicePactId(Guid servicePactId, Guid serviceItemId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ServiceInServicePact");
			string idColumnName = esq.AddColumn("Id").Name;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ServiceItem", serviceItemId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ServicePact", servicePactId));
			Entity entity = esq.GetEntityCollection(UserConnection).FirstOrDefault();
			return entity != null ? entity.GetTypedColumnValue<Guid>(idColumnName) : Guid.Empty;
		}
		
		#endregion

		#region Methods: Protected
		
		protected override Guid GetCalendarId() {
			if (ServiceInServicePact != null && ServiceInServicePact.CalendarId != Guid.Empty) {
				return ServiceInServicePact.CalendarId;
			}
			return ServicePact != null && ServicePact.CalendarId != Guid.Empty
				? ServicePact.CalendarId
				: base.GetCalendarId();
		}

		#endregion
		
		#region Methods: Public

		public override ResponseTime GetMinResponseTime(ResponseTimeColumnsConfig respondTimeColumnsConfig) {
			ResponseTime serviceResponse = base.GetMinResponseTime(respondTimeColumnsConfig);
			if (ServiceInServicePact != null) {
				ResponseTime serviceDetailResponse = ServiceInServicePact.GetResponseTime(respondTimeColumnsConfig);
				return serviceDetailResponse;
			}
			return GetMinResponseTimeByPriority(serviceResponse, respondTimeColumnsConfig);
		}

		#endregion
	}

	#endregion
}
