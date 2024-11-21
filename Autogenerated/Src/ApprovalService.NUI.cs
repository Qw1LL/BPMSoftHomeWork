namespace BPMSoft.Configuration
{
	using Core.Factories;
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core.ServiceModelContract;
	using Web.Common;

	#region Class: ApprovalService

	/// <summary>
	/// ApprovalService service class for working with Approval Entities
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ApprovalService : BaseService
	{

		#region Methods: Private

		private bool ChangeApproval(ApprovalRequest request, Guid statusId) {
			if (request == null) {
				return false;
			}
			var action = ClassFactory.Get<IApprovalAction>(new ConstructorArgument("userConnection", UserConnection));
			request.AdditionalColumnValues = GenerateAdditionalColumnValues(request,
				new Dictionary<string, object>() {
					{"StatusId", statusId}
				});
			return action.ChangeApproval(request.SchemaName, request.Id, request.AdditionalColumnValues);
		}

		private BaseResponse ChangeApprovalWithResponse(ApprovalRequest request, Guid statusId) {
			var response = new BaseResponse() {
				Success = false,
				ErrorInfo = new ErrorInfo() {
					Message = $"Exception: Unexpected exception."
				}
			};
			if (request == null) {
				response.ErrorInfo.Message = "Exception: Approval request is empty.";
				return response;
			}
			try {
				var action = ClassFactory.Get<IApprovalAction>(new ConstructorArgument("userConnection", UserConnection));
				request.AdditionalColumnValues = GenerateAdditionalColumnValues(request,
					new Dictionary<string, object>() {
						{"StatusId", statusId}
					});
				response.Success = action.ChangeApprovalWithLocationException(request.SchemaName, request.Id,
					request.AdditionalColumnValues);
			} catch (VisaNotFoundException) {
				response.ErrorInfo.Message = "Exception: Visa not found.";
			} catch (VisaFinalStatusException) {
				response.ErrorInfo.Message = "This request has already been approved or denied. No further activities are required on your part.";
			} catch (SaveVisaChangesException) {
				response.ErrorInfo.Message = "Exception: Visa changes didn't save.";
			} catch (Exception e) {
				response.ErrorInfo.Message = $"Exception: {e.Message}";
			}
			return response;
		}

		private Dictionary<string, object> GenerateAdditionalColumnValues(ApprovalRequest request,
			Dictionary<string, object> extraValues = null) {
			var additionalColumnValues = request.AdditionalColumnValues ?? new Dictionary<string, object>();
			request.AdditionalValues?.ForEach(item => {
				if (!additionalColumnValues.ContainsKey(item.Key)) {
					additionalColumnValues.Add(item.Key, item.Value);
				}
			});
			extraValues?.ForEach(item => {
				if (!additionalColumnValues.ContainsKey(item.Key)) {
					additionalColumnValues.Add(item.Key, item.Value);
				}
			});
			return additionalColumnValues;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public bool Approve(ApprovalRequest request) {
			return ChangeApproval(request, ApprovalConstants.Accepted);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public bool Reject(ApprovalRequest request) {
			return ChangeApproval(request, ApprovalConstants.Rejected);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse ApproveWithResponse(ApprovalRequest request) {
			return ChangeApprovalWithResponse(request, ApprovalConstants.Accepted);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse RejectWithResponse(ApprovalRequest request) {
			return ChangeApprovalWithResponse(request, ApprovalConstants.Rejected);
		}

		#endregion

	}

	#endregion

	#region Class: ApprovalRequest

	/// <summary>
	/// ApprovalRequest json object.
	/// </summary>
	[DataContract]
	public class ApprovalRequest
	{

		#region Properties: Public

		/// <summary>
		/// Identifier.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id;

		/// <summary>
		/// Approval schema name.
		/// </summary>
		[DataMember(Name = "schemaName")]
		public string SchemaName;

		/// <summary>
		/// Additional column values.
		/// </summary>
		[DataMember(Name = "additionalColumnValues")]
		public Dictionary<string, object> AdditionalColumnValues;

		/// <summary>
		/// Additional values.
		/// </summary>
		[DataMember(Name = "additionalValues")]
		public List<ApprovalRequestAdditionalItem> AdditionalValues;

		#endregion

	}

	#endregion

	#region Class: ApprovalRequestAdditionalItem

	[DataContract]
	public class ApprovalRequestAdditionalItem
	{
		[DataMember(Name = "key")]
		public string Key;

		[DataMember(Name = "value")]
		public object Value;
	}

	#endregion

}

