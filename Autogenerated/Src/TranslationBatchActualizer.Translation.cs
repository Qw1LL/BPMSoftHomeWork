namespace BPMSoft.Configuration.Translation
{
	using System;
	using BPMSoft.Core.Translation;

	#region Class: TranslationBatchActualizer

	public class TranslationBatchActualizer : TranslationActualizer
	{

		#region Constructors: Public

		public TranslationBatchActualizer(ITranslationProvider translationProvider,
				ISysCultureInfoProvider sysCultureInfoProvider, ITranslationLogger translationLogger)
				: base(translationProvider, sysCultureInfoProvider, translationLogger) {
		}

		public TranslationBatchActualizer(IResourceProvider resourceProvider, ITranslationProvider translationProvider,
				ISysCultureInfoProvider sysCultureInfoProvider, ITranslationLogger translationLogger)
				: base(resourceProvider, translationProvider, sysCultureInfoProvider, translationLogger) {
		}

		#endregion

		#region Properties: Protected

		private TranslationBatchProvider _translationBatchProvider;
		protected TranslationBatchProvider TranslationBatchProvider {
			get {
				return _translationBatchProvider ??
					(_translationBatchProvider = (TranslationBatchProvider)TranslationProvider);
			}
		}

		#endregion

		#region Methods: Protected

		protected override void InternalActualizeTranslation(DateTime readFrom) {
			base.InternalActualizeTranslation(readFrom);
			TranslationBatchProvider.WriteTranslationBatches();
		}

		#endregion

	}

	#endregion

}

