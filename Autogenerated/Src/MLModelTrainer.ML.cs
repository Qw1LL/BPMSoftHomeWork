namespace BPMSoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.ML.Interfaces;
	using BPMSoft.ML.Interfaces.Responses;

	#region Interface: IMLModelTrainer

	/// <summary>
	/// Defines methods to train a new machine learning model.
	/// </summary>
	public interface IMLModelTrainer
	{

		#region Methods: Public

		/// <summary>
		/// Starts the train session.
		/// </summary>
		/// <param name="ignoreMetricThreshold">if set to <c>true</c> ignore metric threshold on applying model
		/// instance.</param>
		/// <returns>
		/// New train session identifier.
		/// </returns>
		Guid StartTrainSession(bool ignoreMetricThreshold = false);

		/// <summary>
		/// Uploads the data.
		/// </summary>
		void UploadData();

		/// <summary>
		/// Begins the training.
		/// </summary>
		void BeginTraining();

		/// <summary>
		/// Queries for the actual model state and updates it in database.
		/// </summary>
		void UpdateModelState();

		#endregion

	}

	#endregion

	#region Class: MLModelTrainer

	/// <summary>
	/// Provides a base class for implementations of the <see cref="IMLModelTrainer"/> interface.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.ML.IMLModelTrainer" />
	[DefaultBinding(typeof(IMLModelTrainer))]
	public class MLModelTrainer : IMLModelTrainer
	{

		#region Constants: Private

		private const string ClassifierBeginTrainingMethodName = "/classifier/beginTraining";
		private const string DefaultOutputColumnAlias = "Output__";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("ML");
		private readonly UserConnection _userConnection;
		private readonly MLModelConfig _modelConfig;
		private readonly IMLServiceProxy _proxy;
		private readonly IMLModelEventsNotifier _modelEventsNotifier;
		private readonly IMLMetadataGenerator _metadataGenerator;
		private readonly TrainSessionState[] _notificationStates = {
			TrainSessionState.DataTransferring,
			TrainSessionState.Training,
			TrainSessionState.Error,
			TrainSessionState.Done
		};
		private readonly IMLModelQueryBuilder _queryBuilder;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLModelTrainer"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="modelConfig">The model configuration.</param>
		public MLModelTrainer(UserConnection userConnection, MLModelConfig modelConfig) {
			userConnection.CheckArgumentNull("userConnection");
			modelConfig.CheckArgumentNull("modelConfig");
			modelConfig.Id.CheckArgumentEmpty("MLModelConfig.Id");
			_userConnection = userConnection;
			_modelConfig = modelConfig;
			_proxy = InitServiceProxy();
			ConstructorArgument userConnectionArg = new ConstructorArgument("userConnection", _userConnection);
			_modelEventsNotifier = ClassFactory.Get<IMLModelEventsNotifier>(userConnectionArg);
			_metadataGenerator = ClassFactory.Get<IMLMetadataGenerator>();
			_queryBuilder = ClassFactory.Get<IMLModelQueryBuilder>(userConnectionArg);
			InitProblemTypeFeatures();
		}

		#endregion

		#region Properties: Private

		private IMLDataUploader _dataUploader;
		private IMLDataUploader DataUploader => _dataUploader ?? (_dataUploader = InitDataUploader());

		private string _apiKey;
		private string ApiKey {
			get {
				if (_apiKey.IsNullOrEmpty()) {
					_apiKey = MLUtils.GetAPIKey(_userConnection);
				}
				return _apiKey;
			}
		}

		private Dictionary<TrainSessionState, Guid> _trainSessionStateMapping;
		private Dictionary<TrainSessionState, Guid> TrainSessionStateMapping =>
			_trainSessionStateMapping ?? (_trainSessionStateMapping = GetTrainSessionStateMapping());

		private Select _trainingSelectQuery;
		private IMLProblemTypeFeatures _problemTypeFeatures;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets the finite train session states.
		/// </summary>
		public static TrainSessionState[] FiniteStates { get; } =
			{ TrainSessionState.NotStarted, TrainSessionState.Error, TrainSessionState.Done };

		#endregion

		#region Methods: Private

		private void InitProblemTypeFeatures() {
			var problemTypeStr = _modelConfig.ProblemType.ToString().ToUpperInvariant();
			_problemTypeFeatures = ClassFactory.HasBinding(typeof(IMLProblemTypeFeatures), problemTypeStr)
				? ClassFactory.Get<IMLProblemTypeFeatures>(problemTypeStr)
				: ClassFactory.Get<IMLProblemTypeFeatures>(name: null);
		}

		private Select BuildTrainingSelectQuery() {
			if (_trainingSelectQuery != null) {
				return _trainingSelectQuery;
			}
			_trainingSelectQuery = _queryBuilder.BuildSelect(_modelConfig.EntitySchemaId,
				_modelConfig.TrainingSetQuery, _modelConfig.ColumnExpressions, _modelConfig.TrainingFilterData);
			if (_problemTypeFeatures.HasOutputColumn) {
				AddQueryOutputColumn(_trainingSelectQuery, _modelConfig);
			}
			return _trainingSelectQuery;
		}

		private IMLServiceProxy InitServiceProxy() {
			string serviceUrl = _modelConfig.ServiceUrl;
			serviceUrl.CheckArgumentNull("MLModelConfig.ServiceUrl");
			ConstructorArgument serviceUrlArg = new ConstructorArgument("serviceUrl", serviceUrl);
			ConstructorArgument apiKeyArg = new ConstructorArgument("apiKey", ApiKey);
			IMLServiceProxy proxy = ClassFactory.Get<IMLServiceProxy>(serviceUrlArg, apiKeyArg);
			return proxy;
		}

		private IMLDataUploader InitDataUploader() {
			Guid sessionId = _modelConfig.TrainSessionId;
			sessionId.CheckArgumentEmpty("MLModelConfig.TrainSessionId");
			ConstructorArgument sessionIdArg = new ConstructorArgument("sessionId", _modelConfig.TrainSessionId);
			ConstructorArgument proxyArg = new ConstructorArgument("mlServiceProxy", _proxy);
			ConstructorArgument userConnectionArg = new ConstructorArgument("userConnection", _userConnection);
			var chunkSize = Core.Configuration.SysSettings.GetValue(_userConnection, "MLTrainingChunkSize", 1000);
			var config = new MLDataLoaderConfig {
				MinRecordsCount = _modelConfig.TrainingMinimumRecordsCount,
				MaxRecordsCount = _modelConfig.TrainingMaxRecordsCount,
				ChunkSize = chunkSize
			};
			ConstructorArgument configArg = new ConstructorArgument("config", config);
			IMLDataLoader loader = ClassFactory.Get<IMLDataLoader>(userConnectionArg, configArg);
			ConstructorArgument loaderArg = new ConstructorArgument("loader", loader);
			var eventsNotifierArg = new ConstructorArgument("modelEventsNotifier", _modelEventsNotifier);
			IMLDataUploader dataUploader = ClassFactory.Get<IMLDataUploader>(proxyArg, sessionIdArg, loaderArg,
				eventsNotifierArg);
			return dataUploader;
		}

		private void UpdateModelOnError(Guid modelId, string errorMessage) {
			UpdateTriedToTrainOn(modelId);
			UpdateTrainSessionStatus(TrainSessionState.Error, modelId, errorMessage);
		}

		private void UpdateTriedToTrainOn(Guid modelId) {
			Update updateQuery = (Update)new Update(_userConnection, "MLModel")
					.Set("TriedToTrainOn", Column.Parameter(DateTime.UtcNow))
				.Where("Id").IsEqual(Column.Parameter(modelId, "Guid"));
			updateQuery.Execute();
		}

		private Dictionary<TrainSessionState, Guid> GetTrainSessionStateMapping() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "MLModelState") {
				Cache = _userConnection.ApplicationCache,
				CacheItemName = "MLModelTrainer_MLModelState"
			};
			esq.PrimaryQueryColumn.IsVisible = true;
			esq.AddColumn("Code");
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			var mapping = new Dictionary<TrainSessionState, Guid>();
			foreach (Entity entity in entities) {
				if (!Enum.TryParse(entity.GetTypedColumnValue<string>("Code"), out TrainSessionState state)) {
					continue;
				}
				mapping.Add(state, entity.PrimaryColumnValue);
			}
			return mapping;
		}

		private void InsertTrainSession(Guid mlModelId, Guid trainSessionId, TrainSessionState sessionState,
				bool ignoreMetricThreshold, string errorMessage = null) {
			Guid mlModelStateId = TrainSessionStateMapping[sessionState];
			var insertQuery = new Insert(_userConnection).Into("MLTrainSession")
				.Set("Id", Column.Parameter(trainSessionId))
				.Set("MLModelId", Column.Parameter(mlModelId))
				.Set("StateId", Column.Parameter(mlModelStateId))
				.Set("InUse", Column.Parameter(false))
				.Set("IgnoreMetricThreshold", Column.Parameter(ignoreMetricThreshold))
				.Set("Error", Column.Parameter(errorMessage ?? string.Empty));
			insertQuery.Execute();
		}

		private bool GetIsTrainSessionIgnoresMetric(Guid trainSessionId) {
			var select = (Select)new Select(_userConnection)
					.Column("IgnoreMetricThreshold")
				.From("MLTrainSession")
				.Where("Id").IsEqual(Column.Parameter(trainSessionId));
			return select.ExecuteScalar<bool>();
		}

		private void SaveTrainSession(Guid trainSessionId, TrainSessionState sessionState,
				bool inUse = false, ModelSummary modelSummary = null, string errorMessage = null) {
			Guid mlModelStateId = TrainSessionStateMapping[sessionState];
			var updateQuery = (Update)new Update(_userConnection, "MLTrainSession")
				.Set("StateId", Column.Parameter(mlModelStateId))
				.Set("Error", Column.Parameter(errorMessage ?? string.Empty))
				.Set("TrainedOn", Column.Parameter(DateTime.UtcNow))
				.Where("Id").IsEqual(Column.Parameter(trainSessionId));
			if (inUse) {
				updateQuery = updateQuery.Set("InUse", Column.Parameter(true));
			}
			if (modelSummary != null) {
				string serializedFeatureImportances = JsonConvert.SerializeObject(modelSummary.FeatureImportances);
				updateQuery = updateQuery
					.Set("TrainSetSize", Column.Parameter(modelSummary.DataSetSize))
					.Set("InstanceMetric", Column.Parameter(modelSummary.Metric))
					.Set("TrainingTimeMinutes", Column.Parameter(modelSummary.TrainingTimeMinutes))
					.Set("FeatureImportances", Column.Parameter(serializedFeatureImportances));
			}
			updateQuery.Execute();
		}

		private void SaveAcceptedSession(Guid mlModelId, Guid trainSessionId, ModelSummary modelSummary) {
			Update updateQuery = (Update)new Update(_userConnection, "MLTrainSession")
				.Set("InUse", Column.Parameter(false))
				.Where("MLModelId").IsEqual(Column.Parameter(mlModelId));
			updateQuery.Execute();
			SaveTrainSession(trainSessionId, TrainSessionState.Done, true, modelSummary);
		}

		private void SaveUnacceptedSession(Guid trainSessionId, ModelSummary modelSummary) {
			SaveTrainSession(trainSessionId, TrainSessionState.Done, false, modelSummary);
		}

		private void SaveFailedSession(Guid trainSessionId, string errorMessage) {
			SaveTrainSession(trainSessionId, TrainSessionState.Error, false, errorMessage: errorMessage);
		}

		private string GetMetadataOutputName() {
			return _modelConfig.GetModelSchemaMetadata().Output?.Name;
		}

		private bool GetIsCFModel(MLModelConfig modelConfig) {
			return _modelConfig.ProblemType == new Guid(MLConsts.CollaborativeFiltering);
		}

		private void AddQueryOutputColumn(Select query, MLModelConfig modelConfig) {
			string metadataOutputName = GetMetadataOutputName();
			if (metadataOutputName.IsNotNullOrEmpty()) {
				return;
			}
			if (GetIsCFModel(modelConfig)) {
				query.Column(Column.Const(1)).As(DefaultOutputColumnAlias);
				return;
			}
			if (query.Columns.ExistsByAlias(DefaultOutputColumnAlias)) {
				return;
			}
			if (modelConfig.TrainingOutputFilterData?.Length > 0) {
				_queryBuilder.AddTrainingOutputExpression(query, modelConfig.TrainingOutputFilterData,
					DefaultOutputColumnAlias);
				return;
			}
			if (_modelConfig.TrainingTargetColumnName.IsNullOrEmpty()) {
				throw new ValidateException($"No output defined for the model {_modelConfig.Id}");
			}
			string sourceExpressionAlias = query.SourceExpression.Alias ?? query.SourceExpression.SchemaName;
			query.Column(sourceExpressionAlias, _modelConfig.TrainingTargetColumnName).As(DefaultOutputColumnAlias);
		}

		private void MergeFitParams(ModelSchemaMetadata metadata, MLModelConfig modelConfig) {
			if (!GetIsCFModel(modelConfig)) {
				return;
			}
			if (modelConfig.FactorsCounts.IsNullOrEmpty() &&
					modelConfig.RegularizationValues.IsNullOrEmpty()) {
				return;
			}
			metadata.Params = metadata.Params ?? new ModelSchemaParams() {
				Fit = new ModelSchemaFitParams()
			};
			ModelSchemaFitParams fitParams = metadata.Params.Fit; 
			fitParams.Factors = fitParams.Factors.IsNullOrEmpty() ? modelConfig.FactorsCounts : fitParams.Factors;
			fitParams.Regularizations = fitParams.Regularizations.IsNullOrEmpty() 
				? modelConfig.RegularizationValues
				: fitParams.Regularizations;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Saves the train session identifier.
		/// </summary>
		/// <param name="sessionId">The session identifier.</param>
		protected virtual void SaveTrainSessionId(Guid sessionId) {
			_modelConfig.TrainSessionId = sessionId;
			Update updateQuery = (Update)new Update(_userConnection, "MLModel")
					.Set("TrainSessionId", Column.Parameter(sessionId))
				.Where("Id").IsEqual(Column.Parameter(_modelConfig.Id));
			updateQuery.Execute();
		}

		private Guid GetErrorId(string errorMessage) {
			if (errorMessage.IsNullOrWhiteSpace()) {
				return Guid.Empty;
			}
			var likeExpression = new ConcatQueryFunction(new QueryColumnExpressionCollection {
				Column.Parameter("%"), Column.SourceColumn("Pattern"), Column.Parameter("%")
			});
			var select = (Select)new Select(_userConnection).Top(1)
				.Cols("Id")
				.From("MLError")
				.Where(Column.Parameter(errorMessage)).IsLike(likeExpression);
			var errorId = select.ExecuteScalar<Guid>();
			return errorId;
		}

		/// <summary>
		/// Updates the train session status.
		/// </summary>
		/// <param name="newSessionState">New state of the train session.</param>
		/// <param name="modelId">The model's identifier.</param>
		/// <param name="errorMessage">Optional error message to save into MLModel entity.</param>
		protected virtual void UpdateTrainSessionStatus(TrainSessionState newSessionState, Guid modelId,
				string errorMessage = "") {
			if (_modelConfig.CurrentState == newSessionState && errorMessage.IsNullOrEmpty()) {
				return;
			}
			if (!TrainSessionStateMapping.ContainsKey(newSessionState)) {
				throw new ItemNotFoundException($"Session state {newSessionState} is unknown");
			}
			Guid mlModelStateId = TrainSessionStateMapping[newSessionState];
			Guid errorId = GetErrorId(errorMessage);
			var errorIdParam = errorId.IsEmpty() ? Column.Parameter(null, "Guid") : Column.Parameter(errorId);
			Update updateQuery = (Update)new Update(_userConnection, "MLModel")
					.Set("StateId", Column.Parameter(mlModelStateId))
					.Set("LastError", Column.Parameter(errorMessage ?? string.Empty))
					.Set("LastTrainingErrorId", errorIdParam)
				.Where("Id").IsEqual(Column.Parameter(modelId, "Guid"));
			updateQuery.Execute();
			_modelConfig.CurrentState = newSessionState;
			if (_notificationStates.Contains(newSessionState)) {
				_modelEventsNotifier.NotifyModelStateChanged(modelId, newSessionState, _modelConfig.TrainSessionId);
			}
		}

		/// <summary>
		/// Gets the model is acceptable for using.
		/// </summary>
		/// <param name="trainSessionInfo">The train session information.</param>
		/// <returns><c>true</c> if model is acceptable and can be used for future prediction.</returns>
		protected virtual bool GetIsModelAcceptable(GetSessionInfoResponse trainSessionInfo) {
			if (_modelConfig.MetricThreshold <= 0) {
				return true;
			}
			trainSessionInfo.ModelSummary.CheckArgumentNull("ModelSummary");
			return trainSessionInfo.ModelSummary.Metric >= _modelConfig.MetricThreshold;
		}

		/// <summary>
		/// Updates the model instance.
		/// </summary>
		/// <param name="trainSessionInfo">The train session information.</param>
		/// <param name="trainSessionId">The train session identifier.</param>
		protected virtual void UpdateModelInstance(GetSessionInfoResponse trainSessionInfo, Guid trainSessionId) {
			ModelSummary modelSummary = trainSessionInfo.ModelSummary;
			modelSummary.CheckArgumentNull("ModelSummary");
			modelSummary.ModelInstanceUId.CheckArgumentEmpty("MLModelConfig.ModelSummary.ModelInstanceUId");
			Update updateQuery = (Update)new Update(_userConnection, "MLModel")
					.Set("ModelInstanceUId", Column.Parameter(modelSummary.ModelInstanceUId))
					.Set("InstanceMetric", Column.Parameter(modelSummary.Metric))
					.Set("TrainedOn", Column.Parameter(DateTime.UtcNow))
				.Where("TrainSessionId").IsEqual(Column.Parameter(trainSessionId));
			updateQuery.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Starts the train session.
		/// </summary>
		/// <param name="ignoreMetricThreshold">if set to <c>true</c> ignore metric threshold on applying model
		/// instance.</param>
		/// <returns>
		/// New train session identifier.
		/// </returns>
		public Guid StartTrainSession(bool ignoreMetricThreshold = false) {
			try {
				Select trainingSelectQuery = BuildTrainingSelectQuery();
				var modelValidator = ClassFactory.Get<IMLModelValidator>();
				string outputColumnName = GetMetadataOutputName() ?? DefaultOutputColumnAlias;
				modelValidator.CheckColumns(trainingSelectQuery, outputColumnName);
				modelValidator.CheckSqlQuery(trainingSelectQuery);
				ModelSchemaMetadata modelSchemaMetadata = _metadataGenerator.GenerateMetadata(trainingSelectQuery,
					_modelConfig.MetaData, outputColumnName);
				MergeFitParams(modelSchemaMetadata, _modelConfig);
				Guid sessionId = _proxy.StartTrainSession(ServiceStackTextHelper.Serialize(modelSchemaMetadata),
					_modelConfig.Id);
				SaveTrainSessionId(sessionId);
				InsertTrainSession(_modelConfig.Id, sessionId, TrainSessionState.DataTransferring,
					ignoreMetricThreshold);
				return sessionId;
			} catch (Exception ex) {
				_modelConfig.TrainSessionId = Guid.NewGuid();
				UpdateModelOnError(_modelConfig.Id, ex.Message);
				InsertTrainSession(_modelConfig.Id, _modelConfig.TrainSessionId, TrainSessionState.Error,
					ignoreMetricThreshold, ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Uploads the data.
		/// </summary>
		public void UploadData() {
			UpdateTrainSessionStatus(TrainSessionState.DataTransferring, _modelConfig.Id);
			string error = null;
			try {
				Select trainingSelectQuery = BuildTrainingSelectQuery();
				DataUploader.Upload(trainingSelectQuery);
			} catch (NotEnoughDataForTrainingException ex) {
				error = $"Data upload for model id {_modelConfig.Id} failed with: {ex.Message}";
				throw new NotEnoughDataForTrainingException(error);
			} catch (Exception ex) {
				error = ex.Message;
				throw;
			} finally {
				if (error != null) {
					UpdateModelOnError(_modelConfig.Id, error);
					SaveFailedSession(_modelConfig.TrainSessionId, error);
				}
			}
		}

		/// <summary>
		/// Begins the training.
		/// </summary>
		public void BeginTraining() {
			try {
				var methodName = _modelConfig.TrainingEndpoint.IsNotNullOrEmpty()
					? _modelConfig.TrainingEndpoint
					: ClassifierBeginTrainingMethodName;
				_proxy.BeginTraining(_modelConfig.TrainSessionId, methodName);
			} catch (Exception ex) {
				UpdateModelOnError(_modelConfig.Id, ex.Message);
				SaveFailedSession(_modelConfig.TrainSessionId, ex.Message);
				throw;
			}
			UpdateTrainSessionStatus(TrainSessionState.QueuedToTrain, _modelConfig.Id);
			SaveTrainSession(_modelConfig.TrainSessionId, TrainSessionState.QueuedToTrain);
		}

		/// <summary>
		/// Queries for the actual model state and updates it in database.
		/// </summary>
		public void UpdateModelState() {
			Guid modelId = _modelConfig.Id;
			Guid sessionId = _modelConfig.TrainSessionId;
			sessionId.CheckArgumentEmpty("MLModel.TrainSessionId");
			GetSessionInfoResponse response;
			try {
				response = _proxy.GetTrainingSessionInfo(sessionId);
			} catch (Exception e) {
				UpdateModelOnError(_modelConfig.Id, e.Message);
				throw;
			}
			TrainSessionState newSessionState = response.SessionState;
			_log.Info($"For model {modelId} new model state - {newSessionState}, old was {_modelConfig.CurrentState}");
			if (FiniteStates.Contains(newSessionState)) {
				UpdateTriedToTrainOn(modelId);
			}
			if (newSessionState == TrainSessionState.Done) {
				try {
					ModelSummary modelSummary = response.ModelSummary;
					var ignoresMetric = GetIsTrainSessionIgnoresMetric(sessionId);
					if (ignoresMetric || GetIsModelAcceptable(response)) {
						UpdateModelInstance(response, sessionId);
						SaveAcceptedSession(modelId, sessionId, response.ModelSummary);
						_log.Info("\tModel was successfully trained. " +
							$"Instance uid: {modelSummary.ModelInstanceUId}, instance metric: {modelSummary.Metric}");
					} else {
						string message = "\tModel for schema {0} was successfully trained, but is not acceptable " +
							"to be applied. Instance uid: {1}, instance metric: {2}, metric threshold: {3}";
						_log.WarnFormat(message, _modelConfig.Id, modelSummary.ModelInstanceUId, modelSummary.Metric,
							_modelConfig.MetricThreshold);
						SaveUnacceptedSession(sessionId, modelSummary);
					}
				} catch (Exception ex) {
					UpdateModelOnError(modelId, ex.Message);
					SaveFailedSession(sessionId, ex.Message);
					throw;
				}
			}
			UpdateTrainSessionStatus(newSessionState, modelId, response.ErrorMessage);
			SaveTrainSession(_modelConfig.TrainSessionId, newSessionState, errorMessage: response.ErrorMessage);
		}

		#endregion

	}

	#endregion

}

