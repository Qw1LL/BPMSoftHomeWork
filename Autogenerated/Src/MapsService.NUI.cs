namespace BPMSoft.Configuration.MapsService
{
	using System;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;

	public class MapsItem
	{
		public Guid id;
		public string schemaName;
		public string gpsN;
		public string gpsE;
	}

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MapsService : BaseService
	{
		private static TResult FromJson<TResult>(String data) {
			return (TResult)Json.Deserialize(data, typeof(TResult));
		}

		private static String ToJson(Object data) {
			return Json.Serialize(data);
		}

		private String GetLocalizableString(String name) {
			return new LocalizableString(UserConnection.ResourceStorage, GetType().Name,
				String.Format("LocalizableStrings.{0}.Value", name)).ToString();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CacheCoordinates", BodyStyle = WebMessageBodyStyle.Wrapped,
						RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CacheCoordinates(String itemsJSON) {
			var items = FromJson<MapsItem[]>(itemsJSON).ToList();
			foreach (var item in items) {
				try {
					Update update = (Update)new Update(UserConnection, item.schemaName)
						.Set("GPSN", Column.Parameter(item.gpsN))
						.Set("GPSE", Column.Parameter(item.gpsE))
						.Where("Id").IsEqual(Column.Parameter(item.id));
					update.Execute();
				}
				catch {
				}
			}
		}	
		[OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetMapsApiKey", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json)]
        public string GetMapsApiKey() 
        {
            return
                (string)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "CartographicServicesApiKey");
        }
	}
}
