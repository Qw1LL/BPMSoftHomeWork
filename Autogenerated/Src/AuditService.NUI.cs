namespace BPMSoft.Configuration.AuditService
{
	using System;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class AuditService : BaseService
	{

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "MoveToArchive", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int MoveToArchive(string startDate, string endDate, string[] operationTypes) {
			OperationType[] operationTypeArray = {};
			DateTime startDateX = DateTime.Now;
			DateTime endDateX = DateTime.Now;
			if (!DateTime.TryParse(startDate, out startDateX)) {
				return 0;
			}
			if (!DateTime.TryParse(endDate, out endDateX)) {
				return 0;
			}
			OperationType currentOperationType;
			int j = 0;
			for (int i = 0; i < operationTypes.Length; i++) {
				if (Enum.TryParse<OperationType>(operationTypes[i], out currentOperationType)) {
					if (Enum.IsDefined(typeof(OperationType), currentOperationType)) {
						Array.Resize(ref operationTypeArray, operationTypeArray.Length + 1);
						operationTypeArray[j] = currentOperationType;
						j++;
					}
				}
			}
			int rowCount = BPMSoft.Core.OperationLog.OperationLogUtilities.MoveToArchive(UserConnection, startDateX,
				endDateX, Enumerable.AsEnumerable<OperationType>(operationTypeArray));
			return rowCount;
		}
	}

}
