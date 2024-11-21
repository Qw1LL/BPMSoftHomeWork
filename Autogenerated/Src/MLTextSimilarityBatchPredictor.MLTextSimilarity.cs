namespace BPMSoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.ML.Interfaces;

	/// <summary>
	/// Batch prediction executor for Text Similarity models.
	/// </summary>
	[DefaultBinding(typeof(IMLBatchPredictor), Name = MLTextSimilarityPredictor.TextSimilarityProblemType)]
	public class MLTextSimilarityBatchPredictor : MLBatchPredictor<TextSimilarityOutput>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MLBatchNumericPredictor"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLTextSimilarityBatchPredictor(UserConnection userConnection)
			: base(userConnection) { }

		/// <summary>
		/// Saves the prediction result.
		/// </summary>
		/// <param name="modelConfig">The model config.</param>
		/// <param name="entityId">The entity identifier. Not in use.</param>
		/// <param name="value">Prediction result value.</param>
		protected override void SavePredictionResult(MLModelConfig modelConfig, Guid entityId,
				TextSimilarityOutput value) {
			var saver = ClassFactory.Get<IMLTextSimilarityPredictionSaver>(
				new ConstructorArgument("userConnection", _userConnection));
			saver.SavePredictionResults(modelConfig, value);
		}

		/// <summary>
		/// Does nothing as not applicable for this problem type.
		/// </summary>
		/// <param name="modelConfig">Machine learning model configuration.</param>
		/// <param name="predictedData">Dictionary where key is entity identifier and value is predicted
		/// result for that entity.</param>
		public override void SavePredictedData(MLModelConfig modelConfig, Dictionary<Guid, object> predictedData) {
		}
	}

}

