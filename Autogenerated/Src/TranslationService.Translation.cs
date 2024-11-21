namespace BPMSoft.Configuration.Translation
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel.Activation;
	using System.Web.SessionState;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.DB;

	#region Class: TranslationService

	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TranslationService : BaseService, ITranslationService, IReadOnlySessionState
	{

		#region Constants: Private

		private const string TranslationActualizedOnSysSettingCode = "TranslationActualizedOn";
		private const string TranslationActualizedErrorMessageName = "ActualizeTranslationError";

		#endregion

		#region Properties: Private

		private ITranslationActualizersFactory _translationActualizersFactory;
		private ITranslationActualizersFactory TranslationActualizersFactory {
			get {
				if (_translationActualizersFactory == null) {
					_translationActualizersFactory = ClassFactory.Get<ITranslationActualizersFactory>(
						new ConstructorArgument("userConnection", UserConnection));
				}
				return _translationActualizersFactory;
			}
		}

		/// <summary>
		/// Translation actualizer.
		/// </summary>
		private ITranslationActualizer _translationActualizer;
		private ITranslationActualizer TranslationActualizer {
			get {
				return _translationActualizer ??
					(_translationActualizer = TranslationActualizersFactory.GetTranslationActualizer());
			}
		}

		/// <summary>
		/// Translation actualization date.
		/// </summary>
		/// <remarks>
		/// Kind = DateTimeKind.Utc
		/// </remarks>
		private DateTime TranslationActualizedOn {
			get {
				DataValueType dataValueType =
					UserConnection.DataValueTypeManager.GetDataValueTypeByValueType(typeof(DateTime));
				DateTime dateTime = SysSettings.GetValue(UserConnection, TranslationActualizedOnSysSettingCode,
					DateTime.MinValue);
				DateTime saveDateTime = (DateTime)dataValueType.GetValueForSave(UserConnection, dateTime);
				return saveDateTime;
			}
		}

		private List<string> _translationApplyingLog;
		private List<string> TranslationApplyingLog {
			get {
				return _translationApplyingLog ?? (_translationApplyingLog = new List<string>());
			}
		}

		#endregion

		#region Methods: Private

		private void OnWriteLocalizableValueError(object sender, WriteLocalizableValueEventArgs e) {
			TranslationApplyingLog.Add(e.Result.Message);
		}

		private void ClearUnusedReference() {
			var storedProcedure = new StoredProcedure(UserConnection, "tsp_RemoveUnusedReferences") as StoredProcedure;
			storedProcedure.PackageName = "tspkg_Translation";
			storedProcedure.Execute();
		}

		private IEnumerable<TranslationColumnConfigure> GetSysTranslationColumnsConfigured() {
			var translationColumnsConfigurator = ClassFactory.Get<ISysTranslationColumnsConfigurator>(
				new ConstructorArgument("userConnection", UserConnection));
			return translationColumnsConfigurator.GetTranslationColumnsConfigured();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Actualizes translation.
		/// </summary>
		public void ActualizeTranslation() {
			try {
				TranslationActualizer.ActualizeTranslation(TranslationActualizedOn);
				SysSettings.SetDefValue(UserConnection, TranslationActualizedOnSysSettingCode, DateTime.UtcNow);
			} catch (Exception ex) {
				MsgChannelUtilities.PostMessage(UserConnection, TranslationActualizedErrorMessageName, ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Applies translation.
		/// </summary>
		public TranslationServiceResponse ApplyTranslation() {
			try {
				ClearUnusedReference();
				TranslationActualizer.WriteLocalizableValueError += OnWriteLocalizableValueError;
				TranslationActualizer.ActualizeLocalizableValues();
			} catch (Exception e) {
				return TranslationServiceResponse.CreateFailureResult(e);
			} finally {
				TranslationActualizer.WriteLocalizableValueError -= OnWriteLocalizableValueError;
			}
			return TranslationServiceResponse.CreateSuccessResult(TranslationApplyingLog);
		}

		/// <summary>
		/// Checks if translations can be applied.
		/// </summary>
		public TranslationServiceResponse CheckTranslation() {
			return TranslationServiceResponse.CreateSuccessResult();
		}

		#endregion

	}

	#endregion

}

