namespace BPMSoft.Configuration.Translation
{
	using System.ServiceModel;
	using System.ServiceModel.Web;

	#region Interface: ITranslationService

	[ServiceContract(Name = "TranslationService")]
	public interface ITranslationService
	{

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		void ActualizeTranslation();

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		TranslationServiceResponse ApplyTranslation();

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		TranslationServiceResponse CheckTranslation();

		#endregion

	}

	#endregion

}

