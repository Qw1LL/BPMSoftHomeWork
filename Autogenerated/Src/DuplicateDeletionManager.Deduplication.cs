namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Net;
	using DeduplicationElastic.WebApi.Contracts.Requests;
	using RestSharp;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: DuplicateDeletionManager

	[DefaultBinding(typeof(IDuplicateDeletionManager))]
	public class DuplicateDeletionManager : BaseDeduplicationManager, IDuplicateDeletionManager
	{

		#region Contructors: Public

		public DuplicateDeletionManager(UserConnection userConnection) : base(userConnection)
		{
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IDuplicateDeletionManager.Delete"/>
		public void Delete(string entityName, Guid[] uniqueRecordIds) {
			Log.Debug($"Removing duplicates data. Entity name: {entityName}, ids: {string.Join(",", uniqueRecordIds)}");
			var deleteDuplicatesRequest = new DeleteDuplicatesRequest {
				IndexName = IndexName,
				SourceEntityName = entityName,
				DuplicateEntityIds = new Collection<Guid>(uniqueRecordIds.ToList())
			};
			var request = new RestRequest(DuplicationControllerPath, Method.DELETE) {
				RequestFormat = DataFormat.Json
			};
#if NETFRAMEWORK
			request.AddBody(deleteDuplicatesRequest);
#else
			request.AddJsonBody(deleteDuplicatesRequest);
#endif
			RestClient.ExecuteAsync(request, response => {
				if(response.StatusCode != HttpStatusCode.OK) {
					Log.ErrorFormat("Cannot remove records for section {0} and index {1}. The message is {2}",
						entityName, IndexName, response.Content);
				}
			});
		}

		#endregion

	}

	#endregion

}
