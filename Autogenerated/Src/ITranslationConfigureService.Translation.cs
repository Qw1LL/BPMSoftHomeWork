namespace BPMSoft.Configuration.Translation
{
	using System.ServiceModel;
	using System.ServiceModel.Web;

	#region Interface: ITranslationConfigureService

	/// <summary>
	/// SysTranslation cofigure service.
	/// </summary>
	[ServiceContract(Name = "TranslationConfigureService")]
	public interface ITranslationConfigureService
	{

		/// <summary>
		/// Gets SysTranlation columns configure.
		/// </summary>
		/// <returns><see cref="TranslationColumnsConfiguredResponse"/></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		TranslationColumnsConfiguredResponse GetConfiguredSysTranslationColumns();

	}

	#endregion

}

