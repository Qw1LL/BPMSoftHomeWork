namespace BPMSoft.Configuration.SysSettingsService
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SysSettingsService : BaseService
	{
		
		#region Methods: Public
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int GetIncrementValue(string sysSettingName) {
			var coreSysSettings = new CoreSysSettings(UserConnection);
			int resultValue = 0;
			if (coreSysSettings.FetchFromDB("Code", sysSettingName)) {
				int sysSettingsLastNumber = Convert.ToInt32(CoreSysSettings.GetDefValue(UserConnection, sysSettingName));
				++sysSettingsLastNumber;
				CoreSysSettings.SetDefValue(UserConnection, sysSettingName, sysSettingsLastNumber);
				resultValue = sysSettingsLastNumber;
			}
			return resultValue;
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetIncrementValueVsMask(string sysSettingName, string sysSettingMaskName) {
			string sysSettingsCodeMask = (string)CoreSysSettings.GetValue(UserConnection, sysSettingMaskName);
			string result = string.Empty;
			if (GlobalAppSettings.UseDBSequence) {
				var sequenceMap = new SequenceMap(UserConnection);
				var sequence = sequenceMap.GetByNameOrDefault(sysSettingName);
				result = string.Format(sysSettingsCodeMask, sequence.GetNextValue());
				return result;
			}
			var coreSysSettings = new CoreSysSettings(UserConnection);
			if (coreSysSettings.FetchFromDB("Code", sysSettingName)) {
				int sysSettingsLastNumber = Convert.ToInt32(CoreSysSettings.GetDefValue(UserConnection, sysSettingName));
				++sysSettingsLastNumber;
				CoreSysSettings.SetDefValue(UserConnection, sysSettingName, sysSettingsLastNumber);
				result = string.Format(sysSettingsCodeMask, sysSettingsLastNumber);
			}
			return result;
		}
		
		#endregion
	}
}

