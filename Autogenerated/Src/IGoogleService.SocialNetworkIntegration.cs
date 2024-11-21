namespace BPMSoft.Configuration.Social
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;

	#region Interface: IGoogleService

	[ServiceContract(Name = "GoogleService")]
	public interface IGoogleService
	{

		#region Methods: Public

		/// <summary>
		/// Returns consumer information about google shared application.
		/// </summary>
		/// <returns>Consumer information.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		GoogleConsumerInfoResponse GetConsumerInfo();

		#endregion

	}

	#endregion

}
