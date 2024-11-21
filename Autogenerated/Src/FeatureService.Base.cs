namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;

	#region Class: FeatureInfo

	[DataContract]
	public class FeatureInfo
	{
		#region Properties: Public

		[DataMember]
		public Guid Id;

		[DataMember]
		public string Name;

		[DataMember]
		public string Code;

		[DataMember]
		public string Description;

		[DataMember]
		public List<FeatureStateInfo> StatesInfo;

		[DataMember]
		public int ActualState;

		[DataMember]
		public bool HasStateForUser;

		[DataMember]
		public bool HasStateForGroup;

		[DataMember]
		public int GroupState;

		#endregion

		#region Methods: Private

		private void CheckCurrentUserState(UserConnection userConnection) {
			foreach (var state in StatesInfo) {
				if (state.SysAdminUnitId == userConnection.CurrentUser.Id) {
					ActualState = state.State;
					HasStateForUser = true;
				}
			}
		}

		private void CheckGroupState() {
			foreach (var state in StatesInfo) {
				if (state.SysAdminUnitId == BaseConsts.AllEmployersSysAdminUnitUId) {
					GroupState = state.State;
					HasStateForGroup = true;
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Actualizes HasStateForUser and HasGroupState flags.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public void ActualizeFeatureState(UserConnection userConnection) {
			if (StatesInfo.Count > 0) {
				CheckCurrentUserState(userConnection);
				CheckGroupState();
			}
		}

		#endregion
	}

	#endregion

	#region Class: FeatureStateInfo

	[DataContract]
	public class FeatureStateInfo
	{
		#region Fields: Public

		[DataMember(Name = "code")]
		public string Code;

		[DataMember(Name = "state")]
		public int State;

		[DataMember(Name = "adminUnitId")]
		public Guid SysAdminUnitId;

		#endregion
	}

	#endregion

	#region Class: FeatureService

	/// <summary>
	/// Provides web-service for work with features.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class FeatureService : BaseService
	{
		#region Methods: Public

		/// <summary>
		/// Returns feature state by code.
		/// </summary>
		/// <param name="code">Feature code.</param>
		/// <returns>Feature state.</returns>
		/// <remarks>Result parameter name "FeatureState".</remarks>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetFeatureState", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "FeatureState")]
		public int GetFeatureState(string code) {
			return UserConnection.GetFeatureState(code);
		}

		/// <summary>
		/// Sets feature state for current user.
		/// </summary>
		/// <param name="code">Feature code.</param>
		/// <param name="state">New feature state.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetFeatureState", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public ConfigurationServiceResponse SetFeatureState(string code, int state) {
			try {
				UserConnection.SetFeatureState(code, state);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
			
		}

		/// <summary>
		/// Sets features state for current user.
		/// </summary>
		/// <param name="features">Features list</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetFeaturesState", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public ConfigurationServiceResponse SetFeaturesState(List<FeatureStateInfo> features) {
			try {
				foreach (FeatureStateInfo item in features) {
					UserConnection.SetFeatureState(item.Code, item.State);
				}
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		/// <summary>
		/// Sets feature state for all users.
		/// </summary>
		/// <param name="code">Feature code.</param>
		/// <param name="state">New feature state.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SetFeatureStateForAllUsers", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public void SetFeatureStateForAllUsers(string code, int state) {
			UserConnection.SetFeatureState(code, state, forAllUsers: true);
		}

		/// <summary>
		/// Creates feature.
		/// </summary>
		/// <param name="code">Feature code.</param>
		/// <param name="name">Feature name.</param>
		/// <param name="description">Feature description.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateFeature", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public ConfigurationServiceResponse CreateFeature(string code, string name, string description) {
			try {
				UserConnection.CreateFeature(code, name, description);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		/// <summary>
		/// Returns features and their states information.
		/// </summary>
		/// <returns>List of the all features with their states.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetFeaturesInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<FeatureInfo> GetFeaturesInfo() {
			return UserConnection.GetFeaturesInfo();
		}


		/// <summary>
		/// Returns all feature states.
		/// </summary>
		/// <returns>List of features.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetFeatureStates", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<string, int> GetFeatureStates() {
			return UserConnection.GetFeatureStates();
		}

		#endregion

	}

	#endregion

}

