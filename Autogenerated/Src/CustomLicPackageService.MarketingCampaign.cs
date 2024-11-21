namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;

	#region Class: ActualizedCondition

	/// <summary>
	/// Class contains information about active contact.
	/// </summary>
	public class ActualizedCondition
	{
		
		#region Properties: Public

		/// <summary>
		/// Gets or sets the name of licence.
		/// </summary>
		public string PackageName { get; set; }

		/// <summary>
		/// Gets or sets the count of active contact.
		/// </summary>
		public int ConditionCount { get; set; }

		/// <summary>
		/// Gets or sets the date/time of update.
		/// </summary>
		public string ConditionDate { get; set; }

		#endregion

	}

	#endregion
		
	#region Class: CustomLicPackageServiceResponse
	
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CustomLicPackageService : BaseService
	{
		
		#region Constants: Private
		
		private const string CurrentConditionCountParam = "CurrentConditionCount";
		
		private const string CurrentConditionDateParam = "CurrentConditionDate";
		
		#endregion
		
		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
		RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int GetCurrentConditionScalarResult(string packageName) {
			if (UserConnection == null) {
				return 0;
			}
			return UserConnection.LicHelper.GetLicPackageCurrentConditionResult(packageName);
		}
		
		/// <summary>
		/// Finds full license name by name patterns.
		/// </summary>
		/// <param name="namePatterns">The list of patterns to find the full license name.</param>
		/// <returns>Full license name.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetFullPackageNameByNamePatterns(List<string> namePatterns) {
			if (UserConnection == null) {
				return null;
			}
			string actualLicenseFullName = null;
			foreach (var packageNamePattern in namePatterns) {
				actualLicenseFullName = UserConnection.LicHelper.GetExistingLicNameByNamePattern(packageNamePattern);
				if (!string.IsNullOrEmpty(actualLicenseFullName)) {
					return actualLicenseFullName;
				}
			}
			return actualLicenseFullName;
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
		RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<ActualizedCondition> GetMaxConditionCount(List<string> packageNames) {
			var result = new List<ActualizedCondition>();
			if (UserConnection == null) {
				return result;
			}
			foreach(string packageName in packageNames) {
				int maxConditionCount = UserConnection.LicHelper.GetLicPackageMaxConditionCount(packageName);
				var condition = new ActualizedCondition {
					PackageName = packageName,
					ConditionCount = maxConditionCount
				};
				result.Add(condition);
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
		RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<ActualizedCondition> GetLastActualizedConditionResult(List<string> packageNames) {
			var result = new List<ActualizedCondition>();
			if (UserConnection != null) {
				foreach(string packageName in packageNames) {
					int currentConditionCount = UserConnection.LicHelper.GetLicPackageCurrentConditionResult(packageName); 
					DateTime currentConditionDate = UserConnection.LicHelper.GetLicPackageCurrentConditionDate(packageName);
					DateTime value = TimeZoneInfo.ConvertTimeFromUtc(currentConditionDate.ToUniversalTime(), UserConnection.CurrentUser.TimeZone);
					var condition = new ActualizedCondition {
						PackageName = packageName,
						ConditionCount = currentConditionCount,
						ConditionDate = DateTimeDataValueType.Serialize(value, TimeZoneInfo.Utc)
					};
					result.Add(condition);
				}
			}
			return result;
		}
		
		#endregion
	}

	#endregion
	
}

