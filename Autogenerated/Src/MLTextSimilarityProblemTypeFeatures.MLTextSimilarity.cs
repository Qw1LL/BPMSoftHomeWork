namespace BPMSoft.Configuration.ML
{
	using BPMSoft.Core.Factories;

	/// <summary>
	/// Particular features of Text Similarity problem type.
	/// </summary>
	[DefaultBinding(typeof(IMLProblemTypeFeatures), Name = MLTextSimilarityPredictor.TextSimilarityProblemType)]
	public class MLTextSimilarityProblemTypeFeatures : MLDefaultProblemTypeFeatures
	{
		
		/// <summary>
		/// Has output (target) column for model training.
		/// </summary>
		public override bool HasOutputColumn { get; } = false;
	}
}

