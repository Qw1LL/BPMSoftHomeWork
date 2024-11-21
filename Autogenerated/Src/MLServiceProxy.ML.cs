namespace BPMSoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using global::Common.Logging;
	using RestSharp;
	using BPMSoft.Common;
	using BPMSoft.Core.Factories;
	using BPMSoft.ML.Interfaces;
	using BPMSoft.ML.Interfaces.Requests;
	using BPMSoft.ML.Interfaces.Responses;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: MLServiceProxy

	/// <summary>
	/// Base implementation of <see cref="IMLServiceProxy"/>.
	/// </summary>
	/// <seealso cref="IMLServiceProxy" />
	[DefaultBinding(typeof(IMLServiceProxy))]
	public partial class MLServiceProxy : IMLServiceProxy
	{

		#region Constants: Private

		private const string WebExceptionMessage =
			"There's network or timeout exception handled during call '{0}'. Status: {1}, Message: {2}";
		private const string CloudServicesApiKey = "CloudServicesAPIKey";

		#endregion

		#region Constants: Public

		/// <summary>
		/// Default timeout for predictions.
		/// </summary>
		public const int DefaultPredictionTimeout = 30;

		#endregion

		#region Fields: Protected

		/// <summary>
		/// The logger.
		/// </summary>
		protected static readonly ILog Log = LogManager.GetLogger("ML");

		/// <summary>
		/// The web service client.
		/// </summary>
		protected IRestClient _httpClient;

		/// <summary>
		/// The API key.
		/// </summary>
		protected readonly string _apiKey;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLServiceProxy" /> class.
		/// </summary>
		/// <param name="serviceUrl">The service URL.</param>
		/// <param name="apiKey">The API key.</param>
		/// <exception cref="IncorrectConfigurationException">Required system settings are not set.</exception>
		public MLServiceProxy(string serviceUrl, string apiKey) {
			CheckRequiredSetting(CloudServicesApiKey, apiKey);
			_apiKey = apiKey;
			InitHttpClient(serviceUrl);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MLServiceProxy" /> class for the custom scoring and
		/// classification endpoints.
		/// </summary>
		/// <param name="serviceUrl">The service URL.</param>
		/// <param name="apiKey">The API key.</param>
		/// <param name="classifyMethodName">Classification endpoint.</param>
		/// <param name="scoreMethodName">Scoring endpoint.</param>
		/// <exception cref="IncorrectConfigurationException">Required system settings are not set.</exception>
		[Obsolete("7.16.0 | Constructor is deprecated. Will be removed in future releases")]
		public MLServiceProxy(string serviceUrl, string apiKey, string classifyMethodName, string scoreMethodName)
				: this(serviceUrl, apiKey) {
			ClassifyMethodName = classifyMethodName;
			ScoreMethodName = scoreMethodName;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// The default request timeout (sec).
		/// </summary>
		protected virtual int DefaultTimeoutSec { get; } = DefaultPredictionTimeout;

		/// <summary>
		/// Upload data request timeout (sec).
		/// </summary>
		protected virtual int UploadDataTimeoutSec { get; } = 60;

		/// <summary>
		/// Classification request timeout (sec).
		/// </summary>
		protected virtual int ClassifyTimeoutSec { get; } = DefaultPredictionTimeout;

		/// <summary>
		/// Scoring request timeout (sec).
		/// </summary>
		protected virtual int ScoreTimeoutSec { get; } = DefaultPredictionTimeout;

		/// <summary>
		/// Batch scoring request timeout (sec).
		/// </summary>
		protected virtual int BatchScoreTimeoutSec { get; } = 300;

		/// <summary>
		/// Regression request timeout (sec).
		/// </summary>
		protected virtual int RegressionTimeoutSec { get; } = DefaultPredictionTimeout;

		/// <summary>
		/// Batch regression request timeout (sec).
		/// </summary>
		protected virtual int BatchRegressionTimeoutSec { get; } = 300;

		/// <summary>
		/// Recommendation request timeout (sec).
		/// </summary>
		protected virtual int RecommendationTimeoutSec { get; } = 1200;

		/// <summary>
		/// Start session request service endpoint.
		/// </summary>
		protected virtual string StartSessionMethodName { get; } = "/session/start";

		/// <summary>
		/// Upload data request service endpoint.
		/// </summary>
		protected virtual string UploadDataMethodName { get; } = "/data/upload";

		/// <summary>
		/// Get session info request service endpoint.
		/// </summary>
		protected virtual string GetSessionInfoMethodName { get; } = "/session/info/get";

		/// <summary>
		/// Classification request service endpoint.
		/// </summary>
		protected virtual string ClassifyMethodName { get; } = "classifier/predict";

		/// <summary>
		/// Scoring request service endpoint.
		/// </summary>
		protected virtual string ScoreMethodName { get; } = "scorer/predict";

		/// <summary>
		/// Regression request service endpoint.
		/// </summary>
		protected virtual string RegressMethodName { get; } = "regressor/predict";

		#endregion

		#region Method: Private

		private static void CheckRequiredSetting(string settingName, string settingValue) {
			if (settingValue.IsNullOrEmpty()) {
				throw new IncorrectConfigurationException(settingName);
			}
		}

		private void TransformResponseErrorByStatus(IRestResponse response) {
			IRestRequest request = response.Request;
			string methodName = request.Resource;
			string message = response.ErrorMessage.ToNullIfEmpty() ?? response.Content;
			Exception ex = response.ErrorException ?? new Exception(message);
			switch (response.StatusCode) {
				case HttpStatusCode.Unauthorized:
					throw new IncorrectConfigurationException(CloudServicesApiKey, _apiKey);
				case HttpStatusCode.Forbidden:
					var errorDetails = $"Response from methodName: {methodName} with [{HttpStatusCode.Forbidden}]" +
						$"{response.Content}";
					throw new HttpException(response.StatusCode, errorDetails);
				case HttpStatusCode.NotFound:
					throw new IncorrectConfigurationException("Service method", methodName,
						"Service method not found");
				case HttpStatusCode.InternalServerError:
					message = $"[{HttpStatusCode.InternalServerError}] {response.Content}";
					Log.Error(message, ex);
					throw new HttpException(response.StatusCode, message, ex);
				case HttpStatusCode.BadRequest:
					var requestBody = request.Parameters.FirstOrDefault(p =>
						p.Type == ParameterType.RequestBody)?.Value;
					message = $"[{HttpStatusCode.BadRequest}] methodName: "
						+ $"{methodName} {requestBody}";
					Log.Error(message);
					throw new HttpException(response.StatusCode, message, ex);
				default:
					throw ex;
			}
		}

		private void CheckServiceResponse(IRestResponse response) {
			switch (response.ResponseStatus) {
				case ResponseStatus.None:
				case ResponseStatus.Completed:
				case ResponseStatus.Error:
					if ((int)response.StatusCode >= 400 || (int)response.StatusCode == 0) {
						TransformResponseErrorByStatus(response);
					}
					break;
				case ResponseStatus.TimedOut:
				case ResponseStatus.Aborted:
					var methodName = response.Request.Resource;
					Log.ErrorFormat(WebExceptionMessage, methodName, response.ErrorMessage);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		/// <summary>
		/// Posts data to the specified method.
		/// </summary>
		/// <typeparam name="T">Response output type.</typeparam>
		/// <param name="methodName">Name of the service method.</param>
		/// <param name="requestBody">The request body.</param>
		/// <param name="timeoutSec">The timeout sec.</param>
		/// <returns>Response's output.</returns>
		protected void Post(string methodName, object requestBody, int timeoutSec) {
			IRestRequest request = _httpClient.CreateJsonRequest(methodName, requestBody);
			_httpClient.Timeout = timeoutSec * 1000;
			var restResponse = _httpClient.Post(request);
			CheckServiceResponse(restResponse);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Initializes internal http client.
		/// </summary>
		/// <param name="serviceUrl"></param>
		protected virtual void InitHttpClient(string serviceUrl) {
			CheckRequiredSetting("MLProblemType.ServiceUrl", serviceUrl);
			if (ClassFactory.TryGet("MLServiceClient", out _httpClient)) {
#if NETFRAMEWORK
				_httpClient.BaseUrl = serviceUrl;
#else
				_httpClient.BaseUrl = new Uri(serviceUrl);
#endif
			} else {
				_httpClient = RestClientFactory.CreateRestClient(serviceUrl);
			}
			_httpClient.AddDefaultHeader("ApiKey", _apiKey);
		}

		/// <summary>
		/// Posts data to the specified method.
		/// </summary>
		/// <typeparam name="T">Response output type.</typeparam>
		/// <param name="methodName">Name of the service method.</param>
		/// <param name="requestBody">The request body.</param>
		/// <param name="timeoutSec">The timeout sec.</param>
		/// <returns>Response's output.</returns>
		protected T Post<T>(string methodName, object requestBody, int timeoutSec) where T: new() {
			IRestRequest request = _httpClient.CreateJsonRequest(methodName, requestBody);
			_httpClient.Timeout = (int)TimeSpan.FromSeconds(timeoutSec).TotalMilliseconds;
			var restResponse = _httpClient.Post<T>(request);
			CheckServiceResponse(restResponse);
			if (restResponse.Data == null) {
				throw new WebException($"Service {_httpClient.BaseUrl} with method {methodName} returned status " + 
					$"{restResponse.StatusCode}, but returned no data. Check Service Url and Endpoint method. " +
					$"ErrorMessage: {restResponse.ErrorMessage}");
			}
			T response = restResponse.Data;
			return response;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Starts new train session.
		/// </summary>
		/// <param name="metaData">Meta data of the model's input and output.</param>
		/// <param name="modelSchemaId">ML model schema identifier.</param>
		/// <returns>
		/// The identifier of the started session.
		/// </returns>
		public Guid StartTrainSession(string metaData, Guid modelSchemaId) {
			var request = new StartSessionRequest {
				ModelSchemaMetadata = metaData,
				ModelSchemaId = modelSchemaId
			};
			StartSessionResponse response = Post<StartSessionResponse>(StartSessionMethodName, request,
				DefaultTimeoutSec);
			return response.SessionId;
		}

		/// <summary>
		/// Uploads data to the service.
		/// </summary>
		/// <param name="data">Data to upload.</param>
		/// <param name="sessionId">The identifier of the upload / training session.</param>
		public void UploadData(string data, Guid sessionId) {
			data.CheckArgumentNull("data");
			sessionId.CheckArgumentEmpty("sessionId");
			var request = new UploadDataRequest {
				Data = data,
				SessionId = sessionId
			};
			Post(UploadDataMethodName, request, UploadDataTimeoutSec);
		}

		/// <summary>
		/// Begins the training.
		/// </summary>
		/// <param name="trainSessionId">The train session identifier.</param>
		/// <param name="methodName">Name of the web method.</param>
		public void BeginTraining(Guid trainSessionId, string methodName) {
			trainSessionId.CheckArgumentEmpty("trainSessionId");
			var request = new BeginClassifierTrainingRequest {
				SessionId = trainSessionId
			};
			Post(methodName, request, DefaultTimeoutSec);
		}

		/// <summary>
		/// Gets information about the training session.
		/// </summary>
		/// <param name="trainSessionId">The train session identifier.</param>
		/// <returns>Session state. If session is completed, returns information about the training.</returns>
		public GetSessionInfoResponse GetTrainingSessionInfo(Guid trainSessionId) {
			trainSessionId.CheckArgumentEmpty("trainSessionId");
			var request = new GetSessionInfoRequest {
				SessionId = trainSessionId
			};
			GetSessionInfoResponse response =
				Post<GetSessionInfoResponse>(GetSessionInfoMethodName, request, DefaultTimeoutSec);
			return response;
		}
		
		/// <summary>
		/// Predicts using ML Service.
		/// </summary>
		/// <param name="modelInstanceUId">Model instance identifier.</param>
		/// <param name="methodName">Predict ML Service method name.</param>
		/// <param name="predictionParams">Prediction params.</param>
		/// <param name="timeoutSec">Timeout for prediction.</param>
		/// <typeparam name="TOut">ML Service response type.</typeparam>
		/// <returns>Prediction response.</returns>
		public TOut Predict<TOut>(Guid modelInstanceUId, string methodName, PredictionInput predictionParams,
				int timeoutSec = DefaultPredictionTimeout) where TOut: new() {
			modelInstanceUId.CheckArgumentEmpty(nameof(modelInstanceUId));
			predictionParams.CheckArgumentNull(nameof(predictionParams));
			var request = new PredictionRequest<PredictionInput> {
				ModelId =  modelInstanceUId,
				PredictionParams = predictionParams
			};
			TOut response = Post<TOut>(methodName, request, timeoutSec);
			return response;
		}
		
		/// <summary>
		/// Predicts using ML Service.
		/// </summary>
		/// <param name="modelInstanceUId">Model instance identifier.</param>
		/// <param name="dataList">Entities with list of input data.</param>
		/// <param name="methodName">Predict ML Service method name.</param>
		/// <param name="defaultPredictionParams">Default prediction params.</param>
		/// <param name="timeoutSec">Timeout for prediction.</param>
		/// <typeparam name="TOut">ML Service response type.</typeparam>
		/// <returns>Prediction response.</returns>
		public TOut Predict<TOut>(Guid modelInstanceUId, IList<Dictionary<string, object>> dataList,
				string methodName, DatasetInput defaultPredictionParams = null,
				int timeoutSec = DefaultPredictionTimeout) where TOut: new() {
			dataList.CheckArgumentNullOrEmpty(nameof(dataList));
			var dataset = new List<DatasetValue>();
			foreach (Dictionary<string, object> data in dataList) {
				var input = new DatasetValue();
				data.Where(keyValue => keyValue.Value != null).ForEach(keyValue =>
					input.Add(keyValue.Key, keyValue.Value));
				dataset.Add(input);
			}
			var predictionParams = defaultPredictionParams ?? new DatasetInput();
			predictionParams.Data = dataset;
			return Predict<TOut>(modelInstanceUId, methodName, predictionParams, timeoutSec);
		}

		/// <summary>
		/// Calls classification service.
		/// </summary>
		/// <param name="modelInstanceUId">The model instance id.</param>
		/// <param name="data">Input data fields for classification model.</param>
		/// <returns>
		/// List of <see cref="ClassificationResult" />.
		/// </returns>
		public ClassificationOutput Classify(Guid modelInstanceUId, Dictionary<string, object> data) {
			var predictionParams = new DatasetInput { PredictContributions = false };
			ClassificationResponse response = Predict<ClassificationResponse>(modelInstanceUId,
				new List<Dictionary<string, object>> { data }, ClassifyMethodName, predictionParams,
				ClassifyTimeoutSec);
			return response.Outputs.FirstOrDefault();
		}

		/// <summary>
		/// Scores rate for item with the given data using the specified model.
		/// </summary>
		/// <param name="model">Model, that should perform scoring.</param>
		/// <param name="data">The data of the item that should be scored.</param>
		/// <param name="predictContributions">
		/// Indicates, if service should return individual feature contributions to overall prediction.
		/// </param>
		/// <returns>Predicted score rate.</returns>
		public ScoringOutput Score(MLModelConfig model, Dictionary<string, object> data, bool predictContributions) {
			var predictionParams = new DatasetInput { PredictContributions = predictContributions };
			ScoringResponse response = Predict<ScoringResponse>(model.ModelInstanceUId,
				new List<Dictionary<string, object>> { data }, model.PredictionEndpoint, predictionParams,
				ScoreTimeoutSec);
			return response.Outputs.FirstOrDefault();
		}

		/// <summary>
		/// Scores rates for list of items with the given data using the specified model.
		/// </summary>
		/// <param name="model">Model, that should perform scoring.</param>
		/// <param name="dataList">The list of data of items that should be scored.</param>
		/// <param name="predictContributions">
		/// Indicates, if service should return individual feature contributions to overall prediction.
		/// </param>
		/// <returns>Predicted score rates.</returns>
		public List<ScoringOutput> Score(MLModelConfig model, IList<Dictionary<string, object>> dataList,
				bool predictContributions) {
			int count = Math.Min(1, dataList.Count);
			int timeout = Math.Max(ScoreTimeoutSec * count, BatchScoreTimeoutSec);
			var predictionParams = new DatasetInput { PredictContributions = predictContributions };
			ScoringResponse response = Predict<ScoringResponse>(model.ModelInstanceUId,
				dataList, model.PredictionEndpoint, predictionParams, timeout);
			return response.Outputs;
		}

		/// <summary>
		/// Performs regression of numeric value for list of items with the given data using the specified model.
		/// </summary>
		/// <param name="modelInstanceUId">The model instance identifier.</param>
		/// <param name="dataList">The list of data of items for regression.</param>
		/// <returns>
		/// Predicted numeric value.
		/// </returns>
		public List<double> Regress(Guid modelInstanceUId, IList<Dictionary<string, object>> dataList) {
			int timeout = Math.Max(RegressionTimeoutSec * dataList.Count, BatchRegressionTimeoutSec);
			var predictionParams = new DatasetInput { PredictContributions = false };
			List<double> response = Predict<List<double>>(modelInstanceUId, dataList, RegressMethodName,
				predictionParams, timeout);
			return response;
		}

		/// <summary>
		/// Performs recommendation for specified users.
		/// </summary>
		/// <param name="model">Model instance.</param>
		/// <param name="users">Users to get recommendation.</param>
		/// <param name="recordsCount">Number of items to recommend for each user.</param>
		/// <param name="filterItems">Items to filter.</param>
		/// <param name="filterItemsMode">Mode of filter,</param>
		/// <param name="filterAlreadyInteractedItems">Filter out already interacted items from prediction.</param>
		/// <param name="userItems">Updated users items.</param>
		/// <param name="recalculateUsers">Recalculate users recommendations using <see cref="userItems"/></param>
		public RecommendationResponse Recommend(MLModelConfig model, List<Guid> users, int recordsCount = 10,
				List<Guid> filterItems = null,
				RecommendationFilterItemsMode filterItemsMode = RecommendationFilterItemsMode.White,
				bool filterAlreadyInteractedItems = true, List<DatasetValue> userItems = null,
				bool recalculateUsers = false) {
			var predictionParams = new RecommendationInput {
				UserIds = users.Select(e => e.ToString()).ToList(),
				PredictionRecordsCount = recordsCount,
				FilterItems = filterItems?.Select(e => e.ToString()).ToList() ?? new List<string>(),
				FilterItemsMode = filterItemsMode.ToString().ToLowerInvariant(),
				FilterAlreadyInteractedItems = filterAlreadyInteractedItems,
				UserItems = userItems,
				RecalculateUsers = recalculateUsers
			};
			return Predict<RecommendationResponse>(model.ModelInstanceUId, model.PredictionEndpoint, predictionParams,
				RecommendationTimeoutSec);
		}

		#endregion

	}

	#endregion

}

