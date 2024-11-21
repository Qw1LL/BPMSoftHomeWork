namespace BPMSoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;

	/// <summary>
	/// Sequence settings service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SequenceSettingsService: BaseService
	{
		/// <summary>
		/// Get Sequence current value.
		/// </summary>
		/// <param name="sysSettingName">Name of syssetting</param>
		/// <returns>Sequence value</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public int GetSequenceValue(string sysSettingName) {
			var sequenceMap = new SequenceMap(UserConnection);
			var sequence = sequenceMap.GetByNameOrDefault(sysSettingName);
			return sequence.GetCurrentValue();
		}

		/// <summary>
		/// Set Sequence value.
		/// </summary>
		/// <param name="sysSettingName">Name of sequence</param>
		/// <param name="startValue">Value of sequence</param>
		/// <returns>Sequence value</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public void SetSequenceValue(string sysSettingName, int startValue) {
			var sequenceMap = new SequenceMap(UserConnection);
			sequenceMap.CreateOrAlterSequence(sysSettingName, startValue);
		}
	}
}
