namespace BPMSoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using Core.Factories;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.ML.Interfaces;
	using BPMSoft.ML.Interfaces.Responses;

	/// <summary>
	/// Text similarity implementation of <see cref="IMLEntityPredictor"/> and <see cref="IMLPredictor{TOut}"/>.
	/// </summary>
	[DefaultBinding(typeof(IMLEntityPredictor), Name = TextSimilarityProblemType)]
	[DefaultBinding(typeof(IMLPredictor<TextSimilarityOutput>), Name = TextSimilarityProblemType)]
	public class MLTextSimilarityPredictor : MLBaseEntityPredictor<TextSimilarityOutput>
	{

		#region Constants: Public

		public const string TextSimilarityProblemType = "AB660B9A-AB35-45F1-BE3A-5B383D6E5A6C";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLTextSimilarityPredictor"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLTextSimilarityPredictor(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Methods: Private

		private TextSimilarityResponse FindSimilarDocuments(IMLServiceProxy serviceProxy, MLModelConfig model,
				IList<Dictionary<string, object>> dataList, MLDataPredictionUserTask predictionUserTask = null) {
			TextSimilarityInput predictionParams = predictionUserTask != null
				? new TextSimilarityInput { PredictionRecordsCount = predictionUserTask.TopN }
				: null;
			TextSimilarityResponse response = serviceProxy.Predict<TextSimilarityResponse>(
				model.ModelInstanceUId, dataList, model.PredictionEndpoint, predictionParams);
			return response;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets the problem type identifier.
		/// </summary>
		/// <value>
		/// The problem type identifier.
		/// </value>
		protected override Guid ProblemTypeId => new Guid(TextSimilarityProblemType);

		/// <summary>
		/// Model should have <see cref="MLModelConfig.PredictedResultColumnName"/> filled.
		/// </summary>
		protected override bool MustHavePredictedResultColumn { get; } = false;

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Predicts using the specified proxy.
		/// </summary>
		/// <param name="proxy">The proxy.</param>
		/// <param name="model">The model.</param>
		/// <param name="data">The input data.</param>
		/// <param name="predictionUserTask">User task with prediction extra params.</param>
		/// <returns>Predicted result.</returns>
		protected override TextSimilarityOutput Predict(IMLServiceProxy proxy, MLModelConfig model,
				Dictionary<string, object> data, MLDataPredictionUserTask predictionUserTask) {
			var dataList = new List<Dictionary<string, object>> { data };
			TextSimilarityResponse response = FindSimilarDocuments(proxy, model, dataList, predictionUserTask);
			return response?.Outputs.FirstOrDefault();
		}

		/// <summary>
		/// Predicts results for the given batch of records with extra params taken from user task.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="dataList">Batch of records.</param>
		/// <param name="proxy">ML service proxy.</param>
		/// <param name="predictionUserTask">User task with prediction extra params.</param>
		/// <returns>Prediction results.</returns>
		protected override List<TextSimilarityOutput> Predict(MLModelConfig model,
				IList<Dictionary<string, object>> dataList, IMLServiceProxy proxy,
				MLDataPredictionUserTask predictionUserTask) {
			TextSimilarityResponse response = FindSimilarDocuments(proxy, model, dataList, predictionUserTask);
			return response.Outputs;
		}

		/// <summary>
		/// Saves the prediction result.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="predictedResult">The predicted result.</param>
		protected override void SavePrediction(MLModelConfig model, Guid entityId,
				TextSimilarityOutput predictedResult) {
			var saver = ClassFactory.Get<IMLTextSimilarityPredictionSaver>(
				new ConstructorArgument("userConnection", _userConnection));
			saver.SavePredictionResults(model, predictedResult);
		}

		/// <summary>
		/// Does nothing as not applicable for this problem type.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="predictedResult">The predicted result.</param>
		protected override void SaveEntityPredictedValues(MLModelConfig model, Guid entityId,
			TextSimilarityOutput predictedResult) {
		}

		#endregion

	}

}

