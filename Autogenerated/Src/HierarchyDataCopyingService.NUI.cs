namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: HierarchyDataCopyingService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class HierarchyDataCopyingService: BaseService
	{

		#region Fields: Private

		private IHierarchyDataCopyingController _copyController;

		#endregion

		#region Constructors: Public

		public HierarchyDataCopyingService() : base() {}

		public HierarchyDataCopyingService(UserConnection userConnection,
			IHierarchyDataCopyingController copyController)
			: base(userConnection) {
			_copyController = copyController;
		}

		#endregion


		#region Properties: Private

		private IHierarchyDataCopyingController CopyController => 
				_copyController ?? (_copyController = ClassFactory.Get<HierarchyDataCopyingController>(
					new ConstructorArgument("UserConnection", UserConnection)));

		#endregion

		#region Methods: Public

		/// <summary>
		/// Copy record with its subordinate elements.
		/// </summary>
		/// <param name="schemaName">Name of schema.</param>
		/// <param name="recordId">Id of record to be copied.</param>
		/// <returns>Service response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public HierarchyDataCopyingServiceResponse CreateRecordCopy(string schemaName, Guid recordId) {
			try {
				var copyingResult = CopyController.CopyRecord(schemaName, recordId);
				if (string.IsNullOrEmpty(copyingResult.ErrorMessage)) {
					return new HierarchyDataCopyingServiceResponse(copyingResult.CopyRecordId);
				}
				return new HierarchyDataCopyingServiceResponse(new Exception(copyingResult.ErrorMessage));
			} catch (Exception e) {
				return new HierarchyDataCopyingServiceResponse(e);
			}
		}

		#endregion

	}

	#endregion

	#region Class: HierarchyDataCopyingServiceResponse

	[DataContract]
	public class HierarchyDataCopyingServiceResponse: ConfigurationServiceResponse
	{
		public HierarchyDataCopyingServiceResponse(Guid copyRecordId): base() {
			this.RecordId = copyRecordId;
		}

		public HierarchyDataCopyingServiceResponse(Exception e): base(e) {
			RecordId = Guid.Empty;
		}

		[DataMember(Name = "recordId")]
		public Guid RecordId { get; set; }

	}

	#endregion

}

