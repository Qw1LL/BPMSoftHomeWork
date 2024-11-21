namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: DeduplicationService

	///<summary>Represent class for lead service.</summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class LeadService : BaseService
	{

		/// <summary>
		/// Web-method performs search similar records.
		/// </summary>
		/// <param name="leadId">Lead's unique identifier.</param>
		/// <returns>Collection of unique identifiers.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "FindRecordsSimilarLead", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<Guid> FindRecordsSimilarLead(string schemaName, Guid leadId) {
			var deduplicationSearchArgs = new ConstructorArgument[] { 
				new ConstructorArgument("userConnection", UserConnection)
			};
			DeduplicationSearch deduplicationSearch 
				= ClassFactory.Get<DeduplicationSearch>(deduplicationSearchArgs);
			var similarLeadSearchHelperArgs = new ConstructorArgument[] { 
				new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("deduplicationSearch", deduplicationSearch)
			};
			SimilarLeadSearchHelper similarLeadSearchHelper 
				= ClassFactory.Get<SimilarLeadSearchHelper>(similarLeadSearchHelperArgs);
			List<Guid> similarRecords = similarLeadSearchHelper.FindLeadSimilarRecords(schemaName, leadId);
			return similarRecords;
		}

	}

	#endregion

}

