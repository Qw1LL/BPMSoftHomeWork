namespace BPMSoft.Configuration.ScoringService {
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Net;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Configuration.ScoringEngine;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: ScoringService

	/// <summary>
	///Represent class of scoring service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ScoringService {

		#region Fields: Private

		private UserConnection _userConnection;

		private bool _isAnonymousAuthentication = false;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="UserConnection"/>.
		/// </summary>
		public UserConnection UserConnection {
			get {
				if (_userConnection != null) {
					return _userConnection;
				}
				_userConnection = HttpContext.Current.Session["UserConnection"] as UserConnection;
				if (_userConnection != null) {
					return _userConnection;
				}
				if (_isAnonymousAuthentication) {
					var appConnection = (AppConnection)HttpContext.Current.Application["AppConnection"];
					_userConnection = appConnection.SystemUserConnection;
				}
				return _userConnection;
			}
			set {
				_userConnection = value;
			}
		}

		#endregion

		#region Methods: Private

		private ScoringEngine CreateScoringEngine() {
			var args = new ConstructorArgument[] {
				new ConstructorArgument("userConnection", UserConnection)
			};
			ScoringEngine scoringEngine = ClassFactory.Get<ScoringEngine>(args);
			return scoringEngine;
		}

		private ScoringEngine CreateScoringEngineWithRequestValidation() {
			HttpRequest request = HttpContext.Current.Request;
			ScoringEngine scoringEngine = CreateScoringEngine();
			string validationExceptionMessage = scoringEngine.ValidateAuthKey(request);
			if (!string.IsNullOrEmpty(validationExceptionMessage)) {
				throw new WebFaultException<string>(validationExceptionMessage, System.Net.HttpStatusCode.Forbidden);
			}
			return scoringEngine;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Web-method returns collection of required records.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="lastSynchronizationDate">Least modified date of recoreds.</param>
		/// <param name="lastSynchronizationId">Least unique identifier of recoreds.</param>
		/// <param name="columns">Requested columns.</param>
		/// <param name="limit">Records count.</param>
		/// <returns>An <see cref="GetSynchronizationDataResponse"/> result of invoking method.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSynchronizationData", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetSynchronizationDataResponse GetSynchronizationData(string schemaName, string lastSynchronizationDate,
					Guid lastSynchronizationId, List<string> columns, int limit) {
			_isAnonymousAuthentication = true;
			GetSynchronizationDataResponse response = new GetSynchronizationDataResponse();
			response.Columns = columns;
			ScoringEngine scoringEngine = CreateScoringEngineWithRequestValidation();
			response.Data
				= scoringEngine.GetSynchronizationRecords(schemaName, lastSynchronizationDate, lastSynchronizationId,
				columns, limit);
			return response;
		}

		// <summary>
		/// Web-method saves scored results for entities.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="schemaColumnName">Schema column name.</param>
		/// <param name="scoredData">Dictionary of unique record identifiers and their result score values.</param>
		[WebInvoke(Method = "POST", UriTemplate = "SaveScoredData", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SaveScoredData(string schemaName, string schemaColumnName,
				Dictionary<string, object> scoredData) {
			HttpRequest request = HttpContext.Current.Request;
			if (request.HttpMethod == WebRequestMethods.Http.Head) {
				return;
			}
			if (request.HttpMethod != WebRequestMethods.Http.Post) {
				throw new HttpException(HttpStatusCode.MethodNotAllowed, "Method not allowed");
			}
			_isAnonymousAuthentication = true;
			ScoringEngine scoringEngine = CreateScoringEngineWithRequestValidation();
			scoringEngine.SaveScoredResults(schemaName, schemaColumnName, scoredData);
		}

		// <summary>
		/// Web-method returns serialized rule select query.
		/// </summary>
		/// <param name="ruleId">Unique identifier of the scoring rule.</param>
		/// <param name="entitySchemaName">Rule entity schema name.</param>
		/// <returns>serialized select query.</returns>
		[WebInvoke(Method = "POST", UriTemplate = "GetSerializedRuleConditions", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetSerializedRuleConditions(Guid ruleId, string entitySchemaName) {
			string result = string.Empty;
			var helper = new RuleSerializationHelper();
			Select query = helper.GetRuleSelectQuery(UserConnection, ruleId, entitySchemaName);
			if (query != null) {
				result = helper.SerializeSelectQuery(query);
			}
			return result;
		}

		/// <summary>
		/// Returns scoring map.
		/// </summary>
		/// <returns>An <see cref="GetScoringMapResponse"/> result of invoking method.</returns>
		[WebInvoke(Method = "POST", UriTemplate = "GetScoringMap", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetScoringMapResponse GetScoringMap() {
			_isAnonymousAuthentication = true;
			ScoringEngine scoringEngine = CreateScoringEngineWithRequestValidation();
			GetScoringMapResponse scoringMap = scoringEngine.GetScoringMap();
			return scoringMap;
		}

		#endregion
	}

	#endregion

	#region Class: GetSynchronizationDataResponse

	/// <summary>
	/// Exposes the object, which contains collection of records.
	/// </summary>
	[DataContract]
	public class GetSynchronizationDataResponse {

		#region Properties: Public

		/// <summary>
		/// List of required columns.
		/// </summary>
		[DataMember]
		public List<string> Columns {
			get;
			set;
		}

		/// <summary>
		/// Records collection.
		/// </summary>
		[DataMember]
		public List<List<object>> Data {
			get;
			set;
		}

		#endregion
	}

	#endregion

}

