namespace BPMSoft.Configuration.LocalizationUtilitiesService
{
	using System;
	using System.Globalization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Web.Common;

	public class LocalizableValueConfig {
		public string key { get; set; }
		public string value { get; set; }
	}

	public class LocalizableStringConfig {
		public string entityName { get; set; }
		public Guid recordId { get; set; }
		public string columnName { get; set; }
	}

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class LocalizationUtilitiesService : BaseService
	{
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveLocalizableValue", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SaveLocalizableValue(string configJSON, string valuesJSON) {
			LocalizableStringConfig config = (LocalizableStringConfig)Json.Deserialize(configJSON, typeof(LocalizableStringConfig));
			LocalizableValueConfig[] values = (LocalizableValueConfig[])Json.Deserialize(valuesJSON, typeof(LocalizableValueConfig[]));
			if (config == null) {
				return;
			}
			var result = new LocalizableString();
			foreach(var lValue in values) {
				result.SetCultureValue(CultureInfo.GetCultureInfo(lValue.key), lValue.value);
			}
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(config.entityName);
			var entity = schema.CreateEntity(UserConnection);
			if (entity.FetchFromDB(config.recordId)) {
				CommonUtilities.SaveLocalizableValue(entity, result, config.columnName);
			}
		}
	}
}
