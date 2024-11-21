namespace BPMSoft.Configuration.Translation
{
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: TranslationBatchProvider

	public class TranslationBatchProvider : TranslationProvider
	{

		#region Constants: Private

		private const int WriteTranslationLogInterval = 1000;
		private const string WriteTranslationBatchesStartMessageTemplate = "Translations count = [{0}]";
		private const string WriteTranslationEndMessageTemplate = "Localizable values added = [{0}]";
		private const string WriteTranslationBatchEndMessageTemplate = "Translations left = [{0}]";

		#endregion

		#region Fields: Private

		private int _processedTranslationsCount;

		#endregion

		#region Constructors: Public

		public TranslationBatchProvider(UserConnection userConnection, ITranslationLogger translationLogger)
			: base(userConnection, translationLogger) {
		}

		#endregion

		#region Properties: Private

		private Dictionary<string, ITranslationBatch> _translationBatches;
		private Dictionary<string, ITranslationBatch> TranslationBatches {
			get {
				return _translationBatches ?? (_translationBatches = new Dictionary<string, ITranslationBatch>());
			}
		}

		#endregion

		#region Methods: Private

		private ITranslationBatch ForceGetTranslationBatch(string key) {
			ITranslationBatch batch;
			if (!TranslationBatches.TryGetValue(key, out batch)) {
				batch = new TranslationBatch(key);
				TranslationBatches.Add(key, batch);
			}
			return batch;
		}

		private void WriteTranslationBatch(ITranslationBatch batch) {
			Insert insert = GetTranslationBatchInsert(batch);
			ExecuteQuery(insert);
			OnWriteTranslationBatchEnd();
		}

		private Insert GetTranslationBatchInsert(ITranslationBatch batch) {
			Insert translationBatchInsert =
				new Insert(UserConnection)
					.Into(TranslationSchemaName);
			translationBatchInsert.Set(TranslationKeyColumnName, Column.Parameter(batch.Key));
			batch.ForEach(translation => {
				translationBatchInsert.Set(translation.Key, Column.Parameter(translation.Value));
			});
			return translationBatchInsert;
		}

		private void OnWriteTranslationBatchesStart() {
			TranslationLogger.Info(
				string.Format(WriteTranslationBatchesStartMessageTemplate, TranslationBatches.Count));
		}

		private void OnWriteTranslationEnd() {
			_processedTranslationsCount++;
			if (_processedTranslationsCount % WriteTranslationLogInterval == 0) {
				TranslationLogger.Info(string.Format(WriteTranslationEndMessageTemplate, _processedTranslationsCount));
			}
		}

		private void OnWriteTranslationBatchEnd() {
			if (TranslationBatches.Count % WriteTranslationLogInterval == 0) {
				TranslationLogger.Info(
					string.Format(WriteTranslationBatchEndMessageTemplate, TranslationBatches.Count));
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Writes translation.
		/// </summary>
		/// <param name="key">Resource key.</param>
		/// <param name="translationColumnName">Translation column name.</param>
		/// <param name="translationColumnValue">Translation column value.</param>
		public override void WriteTranslation(string key, string translationColumnName,
				string translationColumnValue) {
			ITranslationBatch batch = ForceGetTranslationBatch(key);
			if (batch.ContainsKey(translationColumnName)) {
				return;
			}
			batch.Add(translationColumnName, translationColumnValue);
			OnWriteTranslationEnd();
		}

		/// <summary>
		/// Writes translation batches.
		/// </summary>
		public void WriteTranslationBatches() {
			OnWriteTranslationBatchesStart();
			ITranslationBatch batch;
			while ((batch = TranslationBatches.Values.FirstOrDefault()) != null) {
				WriteTranslationBatch(batch);
				TranslationBatches.Remove(batch.Key);
			}
		}

		#endregion

	}

	#endregion

}

