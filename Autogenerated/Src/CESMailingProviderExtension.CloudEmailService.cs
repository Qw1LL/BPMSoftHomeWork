namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Configuration.CESResponses;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: CESMailingProviderExtension

	/// <summary>
	/// Provides extending methods for <see cref="IMailingCesApiProvider"/> to call Cloud Email Service API.
	/// </summary>
	public static class CESMailingProviderExtension
	{

		#region Constants: Private

		private const int ManualLimitStrategy = 3;
		private const string ActiveDomainStatus = "active";

		#endregion

		#region Class: Nested

		private class FieldValues
		{

			#region Properties: Public

			public string Caption { get; set; }

			public string OldValue { get; set; }

			public string NewValue { get; set; }

			#endregion

		}

		#endregion

		#region Methods: Private

		private static ConfigurationServiceResponse ExecuteRequestFunction(Func<BaseCloudResponse> sendRequestFn) {
			var serviceResponse = new ConfigurationServiceResponse();
			BaseCloudResponse cloudResponse = sendRequestFn();
			serviceResponse.Success = cloudResponse.IsSuccess;
			if (!serviceResponse.Success) {
				throw new Exception(cloudResponse.Message);
			}
			return serviceResponse;
		}

		private static BulkEmail GetBulkEmailFromDb(UserConnection userConnection, Guid emailId) {
			var bulkEmail = new BulkEmail(userConnection);
			bulkEmail.FetchFromDB("Id", emailId,
				new[] {
					"Id",
					"Priority",
					"BusinessTimeStart",
					"BusinessTimeEnd",
					"ExpirationDate",
					"DeliveryScheduleDays",
					"TimeZone",
					"DelayBetweenEmail",
					"DailyLimit"
				});
			bulkEmail.Priority.FetchFromDB("Id", bulkEmail.PriorityId, new[] { "Name" });
			bulkEmail.TimeZone.FetchFromDB("Id", bulkEmail.TimeZoneId, new[] { "Name" });
			return bulkEmail;
		}

		private static FieldValues[] GetFieldValues(BulkEmail bulkEmail, UpdateEmailScheduleRequest request) {
			UserConnection userConnection = bulkEmail.UserConnection;
			return new[] {
				new FieldValues {
					OldValue = bulkEmail.Priority.Name,
					NewValue = GetLczEntityName(userConnection, "BulkEmailPriority", request.PriorityId),
					Caption = GetLczStringValue(userConnection, "Priority"),
				},
				new FieldValues {
					OldValue = bulkEmail.BusinessTimeStart.TimeOfDay.ToString(),
					NewValue = request.BusinessTimeStart.TimeOfDay.ToString(),
					Caption = GetLczStringValue(userConnection, "BusinessTimeStart")
				},
				new FieldValues {
					OldValue = bulkEmail.BusinessTimeEnd.TimeOfDay.ToString(),
					NewValue = request.BusinessTimeEnd.TimeOfDay.ToString(),
					Caption = GetLczStringValue(userConnection, "BusinessTimeEnd")
				},
				new FieldValues {
					OldValue = bulkEmail.ExpirationDate.ToString(userConnection.CurrentUser.Culture),
					NewValue = request.ExpirationDateValue.ToString(userConnection.CurrentUser.Culture),
					Caption = GetLczStringValue(userConnection, "ExpirationDate")
				},
				new FieldValues {
					OldValue = TrimCronExpression(bulkEmail.DeliveryScheduleDays),
					NewValue = TrimCronExpression(request.DeliveryScheduleDays),
					Caption = GetLczStringValue(userConnection, "DeliveryScheduleDays")
				},
				new FieldValues {
					OldValue = bulkEmail.TimeZone.Name,
					NewValue = GetLczEntityName(userConnection, "TimeZone", request.TargetTimeZoneId),
					Caption = GetLczStringValue(userConnection, "TimeZone"),
				}
			};
		}

		private static FieldValues[] GetFieldValues(BulkEmail bulkEmail, ThrottlingScheduleRequest request) {
			UserConnection userConnection = bulkEmail.UserConnection;
			ThrottlingSchedule schedule = request.Schedule.First();
			return new[] {
				new FieldValues {
					OldValue = bulkEmail.DelayBetweenEmail.ToString(),
					NewValue = schedule.DelayPerEmail.ToString(),
					Caption = GetLczStringValue(userConnection, "DelayBetweenEmail"),
				},
				new FieldValues {
					OldValue = bulkEmail.DailyLimit.ToString(),
					NewValue = schedule.EmailsPerDay.ToString(),
					Caption = GetLczStringValue(userConnection, "DailyLimit"),
				}
			};
		}

		private static string GetLczEntityName(UserConnection userConnection, string entityName, Guid entityId) {
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByName(entityName);
			Entity entity = entitySchema.CreateEntity(userConnection);
			entity.FetchFromDB("Id", entityId, new[] { "Name" });
			return entity.GetTypedColumnValue<string>("Name");
		}

		private static string GetLczStringValue(UserConnection userConnection, string lczName) {
			var stringName = $"LocalizableStrings.{lczName}.Value";
			var localizableString = new LocalizableString(userConnection.Workspace.ResourceStorage,
				"CESMailingProviderExtension", stringName);
			string value = localizableString.Value ??
				localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			return value;
		}

		private static string GetModifiedFieldsValues(IEnumerable<FieldValues> allFields) {
			var modifiedFields = allFields.Where(x => x.NewValue != x.OldValue);
			return string.Join(", ", modifiedFields.Select(x => $"{x.Caption} - {x.OldValue} / {x.NewValue}"));
		}

		private static int GetPriorityCode(UserConnection userConnection, Guid priorityId) {
			var select = new Select(userConnection).From("BulkEmailPriority").Column("Priority").Where("Id")
				.IsEqual(Column.Parameter(priorityId)) as Select;
			return select.ExecuteScalar<int>();
		}

		private static CloudSenderDomainsInfo GetSenderDomainsInfo(
			ValidateSenderDomainRequest validateSenderDomainRequest, IMailingCesApiProvider provider) {
			var providerName = validateSenderDomainRequest.ProviderName ??
				BulkEmailQueryHelper.GetProviderName(validateSenderDomainRequest.EmailId, provider.UserConnection);
			var senderDomainsInfoRequest = new SenderDomainsInfoRequest {
				ApiKey = provider.ServiceApi.ApiKey,
				ProviderName = providerName
			};
			return provider.ServiceApi.SenderDomainsInfo(senderDomainsInfoRequest);
		}

		private static string GetTimeZoneCode(UserConnection userConnection, Guid timezoneId) {
			var select = new Select(userConnection).Column("Code").From("TimeZone").Where("TimeZone", "Id")
				.IsEqual(Column.Parameter(timezoneId)) as Select;
			return select.ExecuteScalar<string>();
		}

		private static UpdateEmailScheduleCloudRequest GetUpdateEmailScheduleCloudRequest(
			IMailingCesApiProvider provider, UpdateEmailScheduleRequest request) {
			int priority = GetPriorityCode(provider.UserConnection, request.PriorityId);
			string timeZoneCode = GetTimeZoneCode(provider.UserConnection, request.TargetTimeZoneId);
			var cesRequest = new UpdateEmailScheduleCloudRequest {
				EmailId = request.EmailId,
				ExpirationDate = request.ExpirationDateValue,
				BusinessTimeEnd = request.BusinessTimeEnd.TimeOfDay.Ticks,
				BusinessTimeStart = request.BusinessTimeStart.TimeOfDay.Ticks,
				Priority = priority,
				DeliveryScheduleDays = request.DeliveryScheduleDays,
				TargetTimeZoneId = timeZoneCode
			};
			return cesRequest;
		}

		private static IEnumerable<SenderDomainInfo> GetValidatedDomains(string[] senderDomains,
			List<CloudSenderDomain> availableSenderDomains) {
			return senderDomains.Select(domain => new SenderDomainInfo {
				Domain = domain,
				IsValid = IsDomainValid(availableSenderDomains, domain)
			});
		}

		private static bool IsDomainValid(List<CloudSenderDomain> availableSenderDomains, string domain) {
			var isValid = !availableSenderDomains.IsNullOrEmpty() && availableSenderDomains.Any(senderDomain =>
				senderDomain.Domain == domain &&
				senderDomain.Status.Equals(ActiveDomainStatus, StringComparison.CurrentCultureIgnoreCase));
			return isValid;
		}

		private static bool AnyRecipientsProcessed(IMailingCesApiProvider provider, Guid emailId) {
			var progressRepository =
				ClassFactory.Get<SendingEmailProgressRepository>(new ConstructorArgument("userConnection",
					provider.UserConnection));
			var currentProgress = progressRepository.GetProgressRecord(emailId);
			return currentProgress.ProcessedRecipientCount > 0;
		}

		private static void LogError(IMailingCesApiProvider provider, Guid emailId, UserConnection userConnection,
			string logEvent, Exception e, Guid currentUserContactId) {
			string errorMessage = GetLczStringValue(userConnection, "EmailColumnsEditCloudFailMessage");
			provider.BulkEmailEventLogger.LogError(emailId, DateTime.UtcNow, logEvent, e, errorMessage,
				currentUserContactId);
		}

		private static void LogSuccessScheduleUpdate(IMailingCesApiProvider provider, Guid emailId,
			IEnumerable<FieldValues> allFields) {
			string changedValues = GetModifiedFieldsValues(allFields);
			UserConnection userConnection = provider.UserConnection;
			string logEvent = GetLczStringValue(userConnection, "SaveEmailColumnsLogEvent");
			string logMessageTemplate = GetLczStringValue(userConnection, "UpdateScheduleSuccessMessage");
			string logMessage = string.Format(logMessageTemplate, changedValues);
			Guid currentUserContactId = userConnection.CurrentUser.ContactId;
			provider.BulkEmailEventLogger.LogInfo(emailId, DateTime.UtcNow, logEvent, logMessage, currentUserContactId);
		}

		private static ConfigurationServiceResponse SendRequest(IMailingCesApiProvider provider, Guid emailId,
			Func<BaseCloudResponse> sendRequestFn) {
			UserConnection userConnection = provider.UserConnection;
			string logEvent = GetLczStringValue(userConnection, "SaveEmailColumnsLogEvent");
			Guid currentUserContactId = userConnection.CurrentUser.ContactId;
			try {
				return ExecuteRequestFunction(sendRequestFn);
			} catch (Exception e) {
				LogError(provider, emailId, userConnection, logEvent, e, currentUserContactId);
				return new ConfigurationServiceResponse {
					Exception = e
				};
			}
		}

		private static string TrimCronExpression(string deliveryScheduleDays) {
			return deliveryScheduleDays.Replace("0 * * ? * ", "").Replace(" *", "");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calls CES API with request to connect mailing provider.
		/// </summary>
		/// <param name="provider">Extending instance.</param>
		/// <param name="request">Request instance with info about cloud account services.</param>
		/// <returns>The <see cref="BaseCloudResponse"/> with code, status and message.</returns>
		public static BaseCloudResponse ConnectMailingProvider(this IMailingCesApiProvider provider,
			UpdateCloudAccountServiceRequest request) {
			ICESApi serviceApi = provider.ServiceApi;
			return serviceApi.ConnectMailingProvider(request);
		}

		/// <summary>
		/// Calls CES API with request to update email schedule.
		/// </summary>
		/// <param name="provider">Extending instance.</param>
		/// <param name="request">Request instance with new email schedule <see cref="UpdateEmailScheduleRequest"/></param>
		/// <returns>The <see cref="BaseCloudResponse"/> with code, status and message.</returns>
		public static ConfigurationServiceResponse UpdateEmailSchedule(this IMailingCesApiProvider provider,
			UpdateEmailScheduleRequest request) {
			if(!AnyRecipientsProcessed(provider, request.EmailId)) {
				return new ConfigurationServiceResponse();
			}
			ICESApi serviceApi = provider.ServiceApi;
			UpdateEmailScheduleCloudRequest cesRequest = GetUpdateEmailScheduleCloudRequest(provider, request);
			ConfigurationServiceResponse configurationServiceResponse = SendRequest(provider, request.EmailId,
				() => serviceApi.UpdateEmailSchedule(cesRequest));
			if (!configurationServiceResponse.Success) {
				return configurationServiceResponse;
			}
			BulkEmail bulkEmail = GetBulkEmailFromDb(provider.UserConnection, request.EmailId);
			var allFields = GetFieldValues(bulkEmail, request);
			LogSuccessScheduleUpdate(provider, request.EmailId, allFields);
			return configurationServiceResponse;
		}

		/// <summary>
		/// Calls CES API with request to update email schedule.
		/// </summary>
		/// <param name="provider">Extending instance.</param>
		/// <param name="request">Request instance with new email schedule <see cref="UpdateEmailScheduleRequest"/></param>
		/// <returns>The <see cref="BaseCloudResponse"/> with code, status and message.</returns>
		public static ConfigurationServiceResponse UpdateThrottlingSchedule(this IMailingCesApiProvider provider,
			ThrottlingScheduleRequest request) {
			if (!AnyRecipientsProcessed(provider, request.EmailId)) {
				return new ConfigurationServiceResponse();
			}
			ICESApi serviceApi = provider.ServiceApi;
			ConfigurationServiceResponse configurationServiceResponse = SendRequest(provider, request.EmailId,
				() => serviceApi.SetThrottlingSchedule(request));
			if (!configurationServiceResponse.Success || request.StrategyId != ManualLimitStrategy ||
				!request.Schedule.Any()) {
				return configurationServiceResponse;
			}
			BulkEmail bulkEmail = GetBulkEmailFromDb(provider.UserConnection, request.EmailId);
			var allFields = GetFieldValues(bulkEmail, request);
			LogSuccessScheduleUpdate(provider, request.EmailId, allFields);
			return configurationServiceResponse;
		}
		
		/// <summary>
		/// Calls CES API with request to update email schedule.
		/// </summary>
		/// <param name="provider">Extending instance.</param>
		/// <param name="request">Request instance with new email schedule <see cref="UpdateEmailScheduleRequest"/></param>
		/// <returns>The <see cref="BaseCloudResponse"/> with code, status and message.</returns>
		public static GetAvailableProvidersResponse GetAvailableProviders(this IMailingCesApiProvider provider) {
			ICESApi serviceApi = provider.ServiceApi;
			return serviceApi.GetAvailableProviders();
		}

		/// <summary>
		/// Validates the sender domain.
		/// </summary>
		/// <param name="provider">Extending instance.</param>
		/// <param name="validateSenderDomainRequest">The validate sender domain request.</param>
		/// <returns>The <see cref="ValidateSenderDomainResponse"/>.</returns>
		public static ValidateSenderDomainResponse ValidateDomains(this IMailingCesApiProvider provider,
			ValidateSenderDomainRequest validateSenderDomainRequest) {
			var senderDomains = GetSenderDomainsInfo(validateSenderDomainRequest, provider);
			var validatedDomains =
				GetValidatedDomains(validateSenderDomainRequest.SenderDomains, senderDomains.Domains).ToList();
			var response = new ValidateSenderDomainResponse {
				SenderDomainInfos = validatedDomains
			};
			return response;
		}

		#endregion

	}

	#endregion

}

