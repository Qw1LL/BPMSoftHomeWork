namespace BPMSoft.Configuration.Tracking
{
	using Newtonsoft.Json;
	using System;
	using BPMSoft.Core;

	#region Class: GoalDataProvider

	/// <summary>
	/// Provide information from tenant goal service.
	/// </summary>
	public class GoalDataProvider : TenantServiceDataProvider
	{

		#region Enum: EventNameFilterTypes

		public enum EventNameFilterTypes
		{
			None = 0,
			Equal = 1,
			Contains = 2,
			BeginWith = 3,
			EndWith = 4
		}

		#endregion

		#region Enum: EventValueFilterTypes

		private enum EventValueFilterTypes
		{
			None = 0,
			Equal = 1,
			Contains = 2,
			BeginWith = 3,
			EndWith = 4
		}

		#endregion

		#region Enum : EventCostFilterTypes

		private enum EventCostFilterTypes
		{
			None = 0,
			Equal = 1,
			LessOrEqual = 2,
			MoreOrEqual = 3
		}

		#endregion

		#region Class: GoalSettings

		private class GoalSettings
		{
			public string EventTypeFilter { get; set; }

			public EventNameFilterTypes EventNameFilterType { get; set; }

			public string EventNameFilterData { get; set; }

			public EventValueFilterTypes EventValueFilterType { get; set; }

			public string EventValueFilterData { get; set; }

			public EventCostFilterTypes EventCostFilterType { get; set; }

			public float EventCostFilterData { get; set; }
		}

		#endregion

		#region Fields: Private

		private readonly string _goalPathSuffix = "/api/Goal";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public GoalDataProvider(UserConnection userConnection)
				: base(userConnection) { }

		#endregion

		#region Methods: Private

		private GoalSettings DeserializeGoalSettings(string settings) {
			return JsonConvert.DeserializeObject<GoalSettings>(settings,
				new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates goal with parameters.
		/// </summary>
		/// <returns>Response from the service.</returns>
		public DataProviderResponse Create(Guid goalId, Guid resourceId, bool isActive, string settings) {
			var requestUrl = TenantUrl + _goalPathSuffix;
			return SendTokenizedPostRequest<DataProviderResponse>(requestUrl, new {
				Id = goalId,
				ResourceId = resourceId,
				IsActive = isActive,
				Settings = DeserializeGoalSettings(settings)
			});
		}

		/// <summary>
		/// Updates goal with parameters.
		/// </summary>
		/// <returns>Response from the service.</returns>
		public DataProviderResponse Update(Guid goalId, bool isActive, string settings) {
			var requestUrl = TenantUrl + _goalPathSuffix;
			return SendTokenizedPutRequest<DataProviderResponse>(requestUrl, new {
				Id = goalId,
				IsActive = isActive,
				Settings = DeserializeGoalSettings(settings)
			});
		}

		/// <summary>
		/// Delete goal.
		/// </summary>
		/// <param name="goalId">Goal identifier.</param>
		/// <returns>Status code from server request.</returns>
		public DataProviderResponse Delete(Guid goalId) {
			var requestUrl = TenantUrl + _goalPathSuffix + $"/{goalId}";
			return SendTokenizedDeleteRequest<DataProviderResponse>(requestUrl);
		}

		#endregion

	}

	#endregion

}

