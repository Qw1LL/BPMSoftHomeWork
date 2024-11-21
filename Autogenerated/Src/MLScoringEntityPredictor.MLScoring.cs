namespace BPMSoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using Core;
	using Core.Factories;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.ML.Interfaces;

	/// <summary>
	/// Scoring implementation of <see cref="IMLEntityPredictor"/> and <see cref="IMLPredictor{TOut}"/>.
	/// </summary>
	/// <seealso cref="MLBaseEntityPredictor{ScoringOutput}" />
	/// <seealso cref="IMLEntityPredictor" />
	[DefaultBinding(typeof(IMLEntityPredictor), Name = MLConsts.ScoringProblemType)]
	[DefaultBinding(typeof(IMLPredictor<ScoringOutput>), Name = MLConsts.ScoringProblemType)]
	public class MLScoringEntityPredictor : MLBaseEntityPredictor<ScoringOutput>
	{

		#region Contructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLScoringEntityPredictor"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLScoringEntityPredictor(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets the problem type identifier.
		/// </summary>
		/// <value>
		/// The problem type identifier.
		/// </value>
		protected override Guid ProblemTypeId => new Guid(MLConsts.ScoringProblemType);

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Predicts using the specified proxy.
		/// </summary>
		/// <param name="proxy">The proxy.</param>
		/// <param name="model">The model.</param>
		/// <param name="data">The input data.</param>
		/// <param name="predictionUserTask">User task with prediction extra params.</param>
		/// <returns>
		/// Predicted result.
		/// </returns>
		protected override ScoringOutput Predict(IMLServiceProxy proxy, MLModelConfig model,
				Dictionary<string, object> data, MLDataPredictionUserTask predictionUserTask) {
			return proxy.Score(model, data, true);
		}

		/// <summary>
		/// Predicts results for the given batch of records.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="dataList">Batch of records.</param>
		/// <param name="proxy">ML service proxy.</param>
		/// <param name="predictionUserTask">User task with prediction extra params.</param>
		/// <returns>Prediction result.</returns>
		protected override List<ScoringOutput> Predict(MLModelConfig model, IList<Dictionary<string, object>> dataList,
				IMLServiceProxy proxy, MLDataPredictionUserTask predictionUserTask) {
			return proxy.Score(model, dataList, true);
		}

		/// <summary>
		/// Saves the predicted result in entity.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="predictedResult">The predicted result.</param>
		protected override void SaveEntityPredictedValues(MLModelConfig model, Guid entityId,
				ScoringOutput predictedResult) {
			var predictedValues = new Dictionary<MLModelConfig, double> {
				{ model, predictedResult.Score }
			};
			PredictionSaver.SaveEntityScoredValues(model.PredictionEntitySchemaId, entityId, predictedValues);
		}

		/// <summary>
		/// Saves the prediction result.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="predictedResult">The predicted result.</param>
		protected override void SavePrediction(MLModelConfig model, Guid entityId, ScoringOutput predictedResult) {
			PredictionSaver.SavePrediction(model.Id, model.ModelInstanceUId, entityId, predictedResult);
		}

		#endregion

	}
}

