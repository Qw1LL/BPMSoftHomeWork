namespace BPMSoft.Configuration.ForecastV2
{
	using global::Common.Logging;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: ForecastCalculatorExecutor

	/// <summary>
	/// Executes forecast columns calculation job.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.IJobExecutor" />
	public class ForecastCalculatorExecutor : IJobExecutor
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger<ForecastCalculatorExecutor>();

		#endregion

		#region Methods: Private

		private IUpdateForecastSheetRepository GetUpdateForecastSheetRepository(UserConnection userConnection) {
			return ClassFactory.Get<IUpdateForecastSheetRepository>(
				new ConstructorArgument("userConnection", userConnection));
		}

		private IForecastCalculator GetForecastCalculator(UserConnection userConnection, string type) {
			return ClassFactory.Get<IForecastCalculator>(type,
				new ConstructorArgument("userConnection", userConnection));
		}

		private string GetLocalizableString(UserConnection userConnection, string name) {
			return userConnection.GetLocalizableString(GetType().Name, name) ?? string.Empty;
		}

		private void CreateReminding(UserConnection userConnection, Guid forecastId) {
			var remindingUtilities = ClassFactory.Get<RemindingUtilities>();
			var sheetRepository = ClassFactory.Get<IForecastSheetRepository>(
				new ConstructorArgument("userConnection", userConnection));
			var sheet = sheetRepository.GetSheet(forecastId);
			Guid entitySchemaUId = userConnection.EntitySchemaManager.GetItemByName("ForecastSheet").UId;
			var currentUserContactId = userConnection.CurrentUser.ContactId;
			var config = new RemindingConfig(entitySchemaUId) {
				AuthorId = currentUserContactId,
				ContactId = currentUserContactId,
				SubjectId = forecastId,
				Description = GetLocalizableString(userConnection, "RemindingDescription"),
				PopupTitle = string.Format(GetLocalizableString(userConnection, "RemindingPopupTitle"),
					sheet.Name)
			};
			var message = new {
				forecastId
			};
			MsgChannelUtilities.PostMessageToAll( ForecastConsts.UpdateForecastsTopic, JsonConvert.SerializeObject(message));
			remindingUtilities.CreateReminding(userConnection, config);
		}

		private void NotifyAllUsers(string messageCode, Guid forecastId) {
			var message = new {
				forecastId
			};
			MsgChannelUtilities.PostMessageToAll(messageCode, JsonConvert.SerializeObject(message));
		}

		private void Calculate(ForecastCalcParams parameters, params IForecastCalculator[] calculators) {
			foreach (IForecastCalculator calculator in calculators) {
				calculator.Calculate(parameters);
			}
		}

		private void UpdateLastCalculationDateTime(UserConnection userConnection, Guid forecastId) {
			if (!userConnection.GetIsFeatureEnabled("ForecastAutoCalculation")) {
				return;
			}
			IUpdateForecastSheetRepository updateForecastSheetRepository =
				GetUpdateForecastSheetRepository(userConnection);
			Sheet sheet = updateForecastSheetRepository.GetSheet(forecastId);
			sheet.LastCalculationDateTime = DateTime.UtcNow;
			bool result = updateForecastSheetRepository.UpdateSheet(sheet);
			if (!result) {
				_log.Warn($"Could not to update last forecast calculation date time. ForecastId:{forecastId}");
			}
		}

		private void NotifyUser(UserConnection userConnection, Guid forecastId, bool isAutoCalculationJob) {
			if (userConnection.GetIsFeatureEnabled("ForecastAutoCalculation") && isAutoCalculationJob) {
				NotifyAllUsers(ForecastConsts.UpdateForecastsTopic, forecastId);
			} else {
				CreateReminding(userConnection, forecastId);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes job operation.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="parameters">The parameters.</param>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			var forecastId = (Guid)parameters["ForecastId"];
			var periodIds = parameters["PeriodIds"] as List<Guid>;
			var isUseSystemUser = (bool)parameters["IsUseSystemUser"];
			var isAutoCalculationJob = (bool)parameters["IsAutoCalculationJob"];
			_log.Info($"Forecast calculation started. ForecastId:{forecastId}");
			var userConnectionForCalculation = userConnection;
			if (isUseSystemUser) {
				userConnectionForCalculation = userConnection.AppConnection.SystemUserConnection;
			}
			if (userConnection.GetIsFeatureEnabled("ForecastAutoCalculation")) {
				NotifyAllUsers(ForecastConsts.ForecastCalcStartedMessage, forecastId);
			}
			var forecastParams = new ForecastCalcParams(forecastId, periodIds);
			Calculate(forecastParams,
				GetForecastCalculator(userConnectionForCalculation, ForecastConsts.EditableColumnTypeName),
				GetForecastCalculator(userConnectionForCalculation, ForecastConsts.ObjectValueColumnTypeName),
				GetForecastCalculator(userConnectionForCalculation, ForecastConsts.FormulaColumnTypeName));
			_log.Info($"Forecast calculation ended. ForecastId:{forecastId}");
			UpdateLastCalculationDateTime(userConnectionForCalculation, forecastId);
			NotifyUser(userConnection, forecastId, isAutoCalculationJob);
		}

		#endregion

	}

	#endregion

}

