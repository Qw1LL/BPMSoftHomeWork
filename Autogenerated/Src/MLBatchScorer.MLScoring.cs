namespace BPMSoft.Configuration.ML
{
	using System;
	using Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.ML.Interfaces;

	#region Class: MLBatchScorer

	/// <summary>
	/// Scores entities using predictive machine learning model.
	/// </summary>
	[DefaultBinding(typeof(IMLBatchPredictor), Name = MLConsts.ScoringProblemType)]
	public class MLBatchScorer : MLBatchPredictor<ScoringOutput>
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLBatchScorer"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLBatchScorer(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Formats the result value for saving.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		/// Formatted value.
		/// </returns>
		protected override object FormatValueForSaving(ScoringOutput scoringOutput) {
			return Convert.ToInt32(scoringOutput.Score * 100);
		}

		/// <summary>
		/// Saves the prediction result.
		/// </summary>
		/// <param name="modelConfig">The model config.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="value">Prediction result value.</param>
		protected override void SavePredictionResult(MLModelConfig modelConfig, Guid entityId,
				ScoringOutput value) {
			PredictionSaver.SavePrediction(modelConfig.Id, modelConfig.ModelInstanceUId, entityId, value);
		}

		#endregion

	}

	#endregion

}

