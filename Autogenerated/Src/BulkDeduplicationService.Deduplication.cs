namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Newtonsoft.Json;
	using BPMSoft.Core.Factories;

	#region Class: BulkDeduplicationService

	/// <summary>
	/// Represent class for bulk deduplication service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class BulkDeduplicationService : IReadOnlySessionState
	{

		#region Properties: Protected

		private IBulkDeduplicationManager _deduplicationManager;
		protected IBulkDeduplicationManager DeduplicationManager {
			get {
				if (_deduplicationManager == null) {
					_deduplicationManager = ClassFactory.Get<IBulkDeduplicationManager>();
				}
				return _deduplicationManager;
			}
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDeduplicationInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "deduplicationInfo")]
		public BulkDeduplicationInfo GetDeduplicationInfo(string entityName) {
			return DeduplicationManager.GetDeduplicationInfo(entityName);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "FindDuplicateEntities", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "success")]
		public bool FindDuplicateEntities(string entityName) {
			return DeduplicationManager.StartDeduplicationTask(entityName);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDuplicateEntities", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetDuplicateEntities(string entityName, string[] columns, int offset, int count) {
			var result = DeduplicationManager.GetDuplicateEntitiesGroups(entityName, columns, offset, count);
			return JsonConvert.SerializeObject(result);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetGroupsOfDuplicates", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetGroupsOfDuplicates(string entityName, string[] columns, int offset, int count, int topDuplicatesPerGroup) {
			var result = DeduplicationManager.GetGroupsOfDuplicates(entityName, columns, offset, count, topDuplicatesPerGroup);
			return JsonConvert.SerializeObject(result);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDuplicateEntitiesByGroup", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetDuplicateEntitiesByGroup(string entityName, string[] columns, Guid groupId, int offset, int count) {
			var result = DeduplicationManager.GetDuplicateEntitiesByGroup(entityName, columns, groupId, offset, count);
			return JsonConvert.SerializeObject(result);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "AddToUniqueList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "success")]
		public bool AddToUniqueList(string schemaName, Guid[] uniqueRecordIds) {
			return DeduplicationManager.AddToUniqueList(schemaName, uniqueRecordIds);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDuplicatesCountData", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetDuplicatesCountData(string entityName) {
			var result = DeduplicationManager.GetDuplicateCountData(entityName);
			return JsonConvert.SerializeObject(result);
		}

		#endregion
	}

	#endregion

}
