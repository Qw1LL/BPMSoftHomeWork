namespace BPMSoft.Configuration.Translation
{
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Translation;

	#region Class: WriteLocalizableValueEventArgs

	public class WriteLocalizableValueEventArgs : EventArgs
	{

		public IActionResult Result;

	}

	#endregion

	#region Class: TranslationActualizer

	public class TranslationActualizer : ITranslationActualizer
	{

		#region Enum: ActualizationStatus

		private enum ActualizationStatus
		{
			InProgress,
			NotStarted
		}

		#endregion

		#region Constants: Private

		private const string TranslationActualizationStartMessageTemplate =
			"Translation actualization start = [{0} ({1})]";
		private const string TranslationActualizationEndMessage = "Translation actualization end";
		private const string TranslationActualizationSkipMessage = "Translation actualization skip";
		private const string LocalizableValuesActualizationStartMessageTemplate =
			"Localizable values actualization start = [{0} ({1})]";
		private const string LocalizableValuesActualizationEndMessage = "Localizable values actualization end";

		#endregion

		#region Fields: Private

		private static readonly object LockObject = new object();

		#endregion

		#region Constructors

		public TranslationActualizer(ITranslationProvider translationProvider,
				ISysCultureInfoProvider sysCultureInfoProvider, ITranslationLogger translationLogger) {
			TranslationProvider = translationProvider;
			SysCultureInfoProvider = sysCultureInfoProvider;
			TranslationLogger = translationLogger;
			TranslationErrorHandler = translationProvider as ITranslationErrorHandler;
		}

		public TranslationActualizer(IResourceProvider resourceProvider, ITranslationProvider translationProvider,
				ISysCultureInfoProvider sysCultureInfoProvider, ITranslationLogger translationLogger)
				: this(translationProvider, sysCultureInfoProvider, translationLogger) {
			_resourceProvider = resourceProvider;
		}

		#endregion

		#region Properties: Private

		private static ActualizationStatus _currentActualizationStatus = ActualizationStatus.NotStarted;
		private static ActualizationStatus CurrentActualizationStatus {
			get {
				lock (LockObject) {
					return _currentActualizationStatus;
				}
			}
			set {
				lock (LockObject) {
					_currentActualizationStatus = value;
				}
			}
		}

		private Dictionary<string, string> _erroneousRecords = new Dictionary<string, string>();

		#endregion

		#region Properties: Protected

		private IResourceProvider _resourceProvider;
		protected IResourceProvider ResourceProvider {
			get {
				return _resourceProvider ?? (_resourceProvider = ClassFactory.Get<IResourceProvider>());
			}
		}

		protected ITranslationProvider TranslationProvider {
			get;
			private set;
		}

		protected ISysCultureInfoProvider SysCultureInfoProvider {
			get;
			private set;
		}

		protected ITranslationLogger TranslationLogger {
			get;
			private set;
		}

		public ITranslationErrorHandler TranslationErrorHandler
		{
			get;
			private set;
		}

		#endregion

		#region Events: Public

		public event EventHandler<WriteLocalizableValueEventArgs> WriteLocalizableValueError;

		#endregion

		#region Methods: Private

		/// <summary>
		/// Saves translation.
		/// </summary>
		private void WriteTranslation(ILocalizableItem item) {
			ISysCultureInfo sysCultureInfo = SysCultureInfoProvider.Read(item.CultureId);
			TranslationProvider.WriteTranslation(item.Key, sysCultureInfo.TranslationColumnName, item.Value);
		}

		/// <summary>
		/// Writes localizable value.
		/// </summary>
		/// <param name="key">Translation key.</param>
		/// <param name="value">Value.</param>
		/// <param name="cultureIndex">Culture index.</param>
		/// <param name="modifiedOn">Modification date.</param>
		private void WriteLocalizableValue(string key, string value, int cultureIndex, DateTime modifiedOn) {
			ISysCultureInfo sysCultureInfo = SysCultureInfoProvider.Read(cultureIndex);
			ILocalizableItem item = new LocalizableItem(key, value, sysCultureInfo.Id, modifiedOn, false);
			IActionResult result = ResourceProvider.WriteLocalizableValue(item);
			string resultMessage = result.IsSuccess ? result.IsSuccess.ToString() : result.Message;
			TranslationLogger.Info($"Key: {key}, value: {value}, cultureIndex: {cultureIndex}, modifiedOn: {modifiedOn} - result: {resultMessage}");
			CollectErroneousRecords(item, result);
			ProcessWriteLocalizableValueResult(result);
		}

		private void CollectErroneousRecords(ILocalizableItem item, IActionResult result) {
			if (result == null || result.IsSuccess || item == null || _erroneousRecords.ContainsKey(item.Key)) {
				return;
			}
			_erroneousRecords.Add(item.Key, result.Message);
		}

		private void SetIsChanged(Entity translation, int cultureIndex) {
			ISysCultureInfo sysCultureInfo = SysCultureInfoProvider.Read(cultureIndex);
			if (sysCultureInfo != null) {
				translation.SetColumnValue(sysCultureInfo.IsChangedColumnName, true);
			}
		}

		private void OnTranslationActualizationStart(DateTime actualizeFrom) {
			CurrentActualizationStatus = ActualizationStatus.InProgress;
			TranslationLogger.Info(string.Format(TranslationActualizationStartMessageTemplate, actualizeFrom,
				actualizeFrom.Kind));
		}

		private void OnTranslationActualizationEnd() {
			CurrentActualizationStatus = ActualizationStatus.NotStarted;
			TranslationLogger.Info(TranslationActualizationEndMessage);
		}

		private void OnLocalizableValuesActualizationStart() {
			TranslationLogger.Info(
				string.Format(LocalizableValuesActualizationStartMessageTemplate, DateTime.UtcNow,
				DateTime.UtcNow.Kind));
			_erroneousRecords.Clear();
		}

		private void OnLocalizableValuesActualizationEnd() {
			TranslationLogger.Info(LocalizableValuesActualizationEndMessage);
			_erroneousRecords.Clear();
		}

		#endregion

		#region Methods: Protected

		protected void ProcessWriteLocalizableValueResult(IActionResult result) {
			if (!result.IsSuccess) {
				var e = new WriteLocalizableValueEventArgs {
					Result = result
				};
				OnWriteLocalizableValueError(e);
				TranslationLogger.Error(result);
			}
		}

		protected virtual void InternalActualizeTranslation(DateTime readFrom) {
			ResourceProvider.ReadLocalizableValues(readFrom, WriteTranslation);
		}

		protected virtual void OnWriteLocalizableValueError(WriteLocalizableValueEventArgs e) {
			if (WriteLocalizableValueError == null) {
				return;
			}
			WriteLocalizableValueError(this, e);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Actualizes translation.
		/// </summary>
		/// <param name="actualizeFrom">The date to start actualization from.</param>
		public void ActualizeTranslation(DateTime actualizeFrom) {
			if (CurrentActualizationStatus == ActualizationStatus.InProgress) {
				while (CurrentActualizationStatus == ActualizationStatus.InProgress) {
					Thread.Sleep(500);
				}
				TranslationLogger.Info(TranslationActualizationSkipMessage);
			} else {
				OnTranslationActualizationStart(actualizeFrom);
				try {
					TranslationProvider.Transaction(() => {
						InternalActualizeTranslation(actualizeFrom);
					});
				} finally {
					OnTranslationActualizationEnd();
				}
			}
		}

		/// <summary>
		/// Actualizes localizable values.
		/// </summary>
		public void ActualizeLocalizableValues() {
			OnLocalizableValuesActualizationStart();
			List<ISysCultureInfo> sysCulturesInfo = SysCultureInfoProvider.Read();
			TranslationErrorHandler?.ResetErrors();
			TranslationProvider.ReadChangedTranslations(sysCulturesInfo, WriteLocalizableValue);
			TranslationErrorHandler?.SaveErrors(_erroneousRecords);
			TranslationProvider.ResetChangedTranslationsState(sysCulturesInfo);
			ResourceProvider.Actualize();
			OnLocalizableValuesActualizationEnd();
		}

		/// <summary>
		/// Sets translation state.
		/// </summary>
		/// <param name="translation">Translation.</param>
		public void SetIsTranslationChanged(Entity translation) {
			TranslationProvider.ReadChangedTranslationColumnsValues(translation,
					(key, value, cultureIndex, modifiedOn) => {
				SetIsChanged(translation, cultureIndex);
			});
		}

		#endregion

	}

	#endregion

}

