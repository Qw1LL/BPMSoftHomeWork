namespace BPMSoft.Configuration.ML
{
	using System;
	using Core;
	using Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.ML.Interfaces;

	public interface IMLTextSimilarityPredictionSaver
	{
		/// <summary>
		/// Save Text Similarity prediction results.
		/// </summary>
		/// <param name="modelConfig">Model config.</param>
		/// <param name="output">Text similarity output.</param>
		void SavePredictionResults(MLModelConfig modelConfig, TextSimilarityOutput output);
	}

	/// <summary>
	/// Provides class for saving text similarity prediction results.
	/// </summary>
	[DefaultBinding(typeof(IMLTextSimilarityPredictionSaver))]
	public class MLTextSimilarityPredictionSaver : MLPredictionSaver, IMLTextSimilarityPredictionSaver
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLTextSimilarityPredictionSaver"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLTextSimilarityPredictionSaver(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Save Text Similarity prediction results.
		/// </summary>
		/// <param name="modelConfig">Model config.</param>
		/// <param name="output">Text similarity output.</param>
		public void SavePredictionResults(MLModelConfig modelConfig, TextSimilarityOutput output) {
			var resultListSchemaConfig = GetResultListSchemaConfig(modelConfig);
			var entityCollection = new EntityCollection(_userConnection, resultListSchemaConfig.EntitySchema);
			foreach (SimilarDocument item in output.SimilarDocuments) {
				if (item.Score < modelConfig.LowerScoreThreshold) {
					Log.Info($"Similar item {item.DocumentId} to document {output.DocumentId} not saved, " + 
						$"because it's similarity score lower than {modelConfig.LowerScoreThreshold}. " + 
						$"Model id {modelConfig.Id}");
					continue;
				}
				Entity entity = resultListSchemaConfig.EntitySchema.CreateEntity(_userConnection);
				entity.UseAdminRights = UseAdminRights;
				entity.SetColumnValue("Id", Guid.NewGuid());
				entity.SetColumnValue(resultListSchemaConfig.SubjectColumn, output.DocumentId);
				entity.SetColumnValue(resultListSchemaConfig.ObjectColumn, item.DocumentId);
				if (resultListSchemaConfig.ValueColumn != null) {
					entity.SetColumnValue(resultListSchemaConfig.ValueColumn, item.Score);
				}
				if (resultListSchemaConfig.ModelColumn != null) {
					entity.SetColumnValue(resultListSchemaConfig.ModelColumn, modelConfig.Id);
				}
				if (resultListSchemaConfig.DateColumn != null) {
					entity.SetColumnValue(resultListSchemaConfig.DateColumn, DateTime.UtcNow);
				}
				entityCollection.Add(entity);
			}
			entityCollection.Save();
		}

		#endregion

	}

}

