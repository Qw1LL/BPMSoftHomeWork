namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;

	#region Class: SplitTestService

	/// <summary>Service to manage the split-tests.</summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class BulkEmailSplitService : BaseService
	{

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="BulkEmailSplitValidator"/>.
		/// </summary>
		public BulkEmailSplitValidator SplitTestValidator => new BulkEmailSplitValidator(UserConnection);

		#endregion

		#region Methods: Private

		private void SetSplitTestStatus(Guid splitTestId, Guid statusId) {
			var bulkEmailSplit = new BulkEmailSplit(UserConnection);
			if (bulkEmailSplit.FetchFromDB(splitTestId)) {
				bulkEmailSplit.SetColumnValue("StatusId", statusId);
				bulkEmailSplit.Save();
			}
		}

		public void UpdateBulkEmail(Guid splitTestId, Guid bulkEmailStatusId, DateTime startDate) {
			var bulkEmailESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "BulkEmail");
			bulkEmailESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			bulkEmailESQ.AddAllSchemaColumns();
			bulkEmailESQ.Filters.Add(
				bulkEmailESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "SplitTest", splitTestId));
			var bulkEmails = bulkEmailESQ.GetEntityCollection(UserConnection);
			if (bulkEmails.Count > 0) {
				foreach (var bulkEmail in bulkEmails) {
					bulkEmail.SetColumnValue("StatusId", bulkEmailStatusId);
					if (startDate != DateTime.MinValue) {
						bulkEmail.SetColumnValue("LaunchOptionId", MarketingConsts.BulkEmailScheduledaunchOptionId);
						bulkEmail.SetColumnValue("StartDate", startDate);
					}
				}
			}
			bulkEmails.Save();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Stops split-test.
		/// </summary>
		/// <param name="splitTestId">Uniqueidentifier BulkEmailSplit.</param>
		/// <returns>Response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AbandonSplitTest", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BulkEmailSplitServiceResponse AbandonSplitTest(Guid splitTestId) {
			var result = new BulkEmailSplitServiceResponse();
			var selectCount = new Select(UserConnection)
				.Column(Func.Count("Id"))
				.From("BulkEmail")
				.Where("SplitTestId").IsEqual(Column.Parameter(splitTestId))
					.And("StatusId").IsNotEqual(Column.Parameter(MarketingConsts.BulkEmailStatusStartPlanedId))
				as Select;
			var count = selectCount.ExecuteScalar<int>();
			if (count > 0) {
				return result;
			}
			UpdateBulkEmail(splitTestId, MarketingConsts.BulkEmailStatusPlannedId, DateTime.MinValue);
			SetSplitTestStatus(splitTestId, MarketingConsts.BulkEmailSplitStatusPlannedId);
			result.Success = true;
			result.StatusId = MarketingConsts.BulkEmailSplitStatusPlannedId;
			return result;
		}

		/// <summary>
		/// Launches split-test.
		/// </summary>
		/// <param name="splitTestId">Uniqueidentifier BulkEmailSplit.</param>
		/// <param name="startDate">Date of launch.</param>
		/// <param name="startManual">Is manual launch.</param>
		/// <returns>Response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "StartSplitTest", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BulkEmailSplitServiceResponse StartSplitTest(Guid splitTestId, string startDate, bool startManual) {
			var response = new BulkEmailSplitServiceResponse();
			var validationResult = SplitTestValidator.Validate(splitTestId);
			if (!validationResult.Success) {
				response.Message = validationResult.Message;
				return response;
			}
			DateTime startDateValue;
			if (!DateTime.TryParse(startDate, out startDateValue)) {
				return null;
			}
			UpdateBulkEmail(splitTestId, MarketingConsts.BulkEmailStatusStartPlanedId,
					startDateValue.ToUniversalTime());
			Guid statusId = startManual 
				? MarketingConsts.BulkEmailSplitStatusLaunchedId 
				: MarketingConsts.BulkEmailSplitStatusStartPlanedId;
			SetSplitTestStatus(splitTestId, statusId);
			response.Success = true;
			response.StatusId = statusId;
			return response;
		}

		#endregion

	}

	#endregion

	#region Class: SplitTestServiceResponse

	/// <summary> Response of the BulkEmailSplitService.</summary>
	[DataContract]
	public class BulkEmailSplitServiceResponse {

		#region Properties: Public

		/// <summary>
		/// Execution result.
		/// </summary>
		[DataMember]
		public bool Success { get; set; }

		/// <summary>
		/// Message.
		/// </summary>
		[DataMember]
		public string Message { get; set; }

		/// <summary>
		/// BulkEmailSplitStatus.
		/// </summary>
		[DataMember]
		public Guid StatusId { get; set; }

		#endregion
	}

	#endregion
}

