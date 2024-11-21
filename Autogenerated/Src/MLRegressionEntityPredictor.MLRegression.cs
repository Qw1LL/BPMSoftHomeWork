namespace BPMSoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using Core.Factories;
	using BPMSoft.Core.Process.Configuration;

	/// <summary>
	/// Regression implementation of <see cref="IMLEntityPredictor"/> and <see cref="IMLPredictor{TOut}"/>.
	/// </summary>
	[DefaultBinding(typeof(IMLEntityPredictor), Name = MLConsts.RegressionProblemType)]
	[DefaultBinding(typeof(IMLPredictor<double>), Name = MLConsts.RegressionProblemType)]
	public class MLRegressionEntityPredictor : MLBaseEntityPredictor<double>
	{

		#region Constuctors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLRegressionEntityPredictor"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLRegressionEntityPredictor(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets the problem type identifier.
		/// </summary>
		/// <value>
		/// The problem type identifier.
		/// </value>
		protected override Guid ProblemTypeId => new Guid(MLConsts.RegressionProblemType);

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
		protected override double Predict(IMLServiceProxy proxy, MLModelConfig model,
				Dictionary<string, object> data, MLDataPredictionUserTask predictionUserTask) {
			var wrappedData = new List<Dictionary<string, object>> { data };
			return proxy.Regress(model.ModelInstanceUId, wrappedData).FirstOrDefault();
		}

		/// <summary>
		/// Predicts results for the given batch of records.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="dataList">Batch of records.</param>
		/// <param name="proxy">ML service proxy.</param>
		/// <param name="predictionUserTask">User task with prediction extra params.</param>
		/// <returns>Prediction result.</returns>
		protected override List<double> Predict(MLModelConfig model, IList<Dictionary<string, object>> dataList,
				IMLServiceProxy proxy, MLDataPredictionUserTask predictionUserTask) {
			return proxy.Regress(model.ModelInstanceUId, dataList);
		}

		/// <summary>
		/// Saves the predicted result in entity.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="predictedResult">The predicted result.</param>
		protected override void SaveEntityPredictedValues(MLModelConfig model, Guid entityId, double predictedResult) {
			var predictedValues = new Dictionary<MLModelConfig, double> {
				{ model, predictedResult }
			};
			PredictionSaver.SaveEntityRegressionValues(model.PredictionEntitySchemaId, entityId, predictedValues);
		}

		/// <summary>
		/// Saves the prediction result.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="predictedResult">The predicted result.</param>
		protected override void SavePrediction(MLModelConfig model, Guid entityId, double predictedResult) {
			PredictionSaver.SavePrediction(model.Id, model.ModelInstanceUId, entityId, predictedResult);
		}

		#endregion

	}
}
