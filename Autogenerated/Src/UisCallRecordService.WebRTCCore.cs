using BPMSoft.Web.Common;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace BPMSoft.Configuration.TelephonyCallRecordService
{
	/// <summary>
	/// Сервис получения записей для телефонии Uis.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class UisCallRecordService : BaseService
	{

	   /// <summary>
	   /// Получение ссылки на запись звонка
	   /// <param name="intergrationId"> Id интеграции звонка.</param>
	   /// <returns> Ссылка на запись звонка.</returns>
	   /// </summary>
	[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		 ResponseFormat = WebMessageFormat.Json)]
		public RecordLinkResult GetRecordLink(string intergrationId)
		{
			try
			{
				var handler = new UisServiceHandler();
				var helper = new TelephonyCallRecordServiceHelper(handler, UserConnection);
				return helper.GetRecordLink(new Guid(intergrationId));
			}
			catch (Exception ex)
            {
				return new RecordLinkResult
				{
					ErrorLastMessage = ex.Message,
				};
            }
		}
	}
}
