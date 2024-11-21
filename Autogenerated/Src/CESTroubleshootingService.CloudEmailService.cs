namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Web.Http.Abstractions;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.DB;
	using BPMSoft.Common;

	#region Class: CESTroubleshootingService

	///<summary>
	/// Provides service methods for email troubleshooting.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CESTroubleshootingService : BaseService
	{

		#region Properties: Private

		private UserConnection UserConnectionSafe => UserConnection ?? AppConnection.SystemUserConnection;

		#endregion

		#region Methods: Private

		private void Authenticate() {
			HttpContext httpContext = HttpContextAccessor.GetInstance();
			AuthenticationResult authenticationResult =
				BpmCrmCloudEngine.Authenticate(httpContext.Request, UserConnectionSafe);
			var enabledMonitoring = (bool)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnectionSafe,
				"EnableEmailIndicatorMonitoring");
			if (!(authenticationResult.Success && enabledMonitoring)) {
				throw new WebFaultException<string>(authenticationResult.Message, HttpStatusCode.Forbidden);
			}
		}

		private Select CreateSessionSelect(Guid sessionId) {
			var select = new Select(UserConnectionSafe)
				.Column("Caption")
				.Column("Benchmark")
				.Column("ActualCount")
				.Column("State")
				.From("EmailIndicator")
				.Where("SessionId")
				.IsEqual(Column.Parameter(sessionId)) as Select;
			return select;
		}

		private void TryCreateParameter(StoredProcedure storedProcedure, string parameterName, object parameterValue) {
			if (parameterValue != null) {
				storedProcedure.WithParameter(parameterName, parameterValue);
			}
		}

		private StoredProcedure CreateStoredProcedure(EmailStateRequest filters, Guid sessionId) {
			var storedProcedure = new StoredProcedure(UserConnectionSafe, "tsp_CreateEmailIndicators");
			storedProcedure.WithParameter("sessionId", sessionId);
			TryCreateParameter(storedProcedure, "emailId", filters.EmailId);
			TryCreateParameter(storedProcedure, "startDate", filters.StartDate);
			TryCreateParameter(storedProcedure, "endDate", filters.EndDate);
			return storedProcedure;
		}

		private Delete CreateSessionDelete(Guid sessionId) {
			var delete = new Delete(UserConnectionSafe)
				.From("EmailIndicator")
				.Where("SessionId")
				.IsEqual(Column.Parameter(sessionId)) as Delete;
			return delete;
		}

		private List<EmailIndicator> GetEmailIndicatorList(EmailStateRequest filters) {
			var response = new List<EmailIndicator>();
			var sessionId = Guid.NewGuid();
			StoredProcedure storedProcedure = CreateStoredProcedure(filters, sessionId);
			Select select = CreateSessionSelect(sessionId);
			Delete delete = CreateSessionDelete(sessionId);
			using (DBExecutor dbExecutor = UserConnectionSafe.EnsureDBConnection()) {
				storedProcedure.Execute(dbExecutor);
				using (var reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var emailStateItem = new EmailIndicator();
						emailStateItem.Caption = reader.GetColumnValue<string>("Caption");
						object benchmarkValue = reader["Benchmark"];
						if (benchmarkValue != DBNull.Value) {
							emailStateItem.Benchmark = UserConnectionSafe.DBTypeConverter.DBValueToInt(benchmarkValue);
						}
						object actualCountValue = reader["ActualCount"];
						if (actualCountValue != DBNull.Value) {
							emailStateItem.ActualValue = UserConnectionSafe.DBTypeConverter.DBValueToInt(actualCountValue);
						}
						emailStateItem.State = reader.GetColumnValue<string>("State");
						response.Add(emailStateItem);
					}
				}
				delete.Execute(dbExecutor);
			}
			return response;
		}

		#endregion

		#region Methods: Protected

		protected virtual void PrepareCorsHeaders() {
#if !NETSTANDARD2_0
			WebOperationContext operationContext = WebOperationContext.Current;
			WebHeaderCollection outgoingResponseHeaders = operationContext.OutgoingResponse.Headers;
			string incomingRequestOrigin = operationContext.IncomingRequest.Headers["Origin"];
			outgoingResponseHeaders.Add("Access-Control-Allow-Origin", incomingRequestOrigin);
#else
			HttpContext httpContext = HttpContextAccessor.GetInstance();
			string incomingRequestOrigin = httpContext.Request.Headers["Origin"];
			httpContext.Response.AddHeader("Access-Control-Allow-Origin", incomingRequestOrigin);
#endif
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles OPTIONS request for EmailState service.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "OPTIONS", UriTemplate = "EmailState")]
		public void GetEmailStateOptions() {
			var bpmCrmSignatureKey = (string)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "BpmCrmSignatureKey", "bpmcrm-signature");
			string allowHeaders = $"Origin, Content-Type, Accept, {bpmCrmSignatureKey}";
#if !NETSTANDARD2_0
			WebOperationContext operationContext = WebOperationContext.Current;
			WebHeaderCollection outgoingResponseHeaders = operationContext.OutgoingResponse.Headers;
			outgoingResponseHeaders.Add("Access-Control-Allow-Origin", "*");
			outgoingResponseHeaders.Add("Access-Control-Allow-Methods", "POST");
			outgoingResponseHeaders.Add("Access-Control-Allow-Headers", allowHeaders);
#else
			HttpContext httpContext = HttpContextAccessor.GetInstance();
			httpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
			httpContext.Response.AddHeader("Access-Control-Allow-Methods", "POST");
			httpContext.Response.AddHeader("Access-Control-Allow-Headers", allowHeaders);
#endif
		}

		/// <summary>
		/// Handles request for emails state.
		/// </summary>
		/// <param name="filters">Request body.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "EmailState", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<EmailIndicator> GetEmailState(EmailStateRequest filters) {
			PrepareCorsHeaders();
			Authenticate();
			return GetEmailIndicatorList(filters);
		}

		#endregion

	}

	#endregion

}
