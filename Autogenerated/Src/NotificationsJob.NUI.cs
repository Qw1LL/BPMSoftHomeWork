namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Core.Store;

	#region Class: NotificationsJob

	/// <summary>
	/// Class of notifications job.
	/// </summary>
	[Obsolete("7.16.2 | Class will be removed after delete feature 'NotificationsOnOneClassJob'.")]
	public class NotificationsJob : IJobExecutor
	{

		#region Constants: Private

		private const string FEATURE_CODE = "NotificationsOnOneClassJob";		

		#endregion


		#region Fields: Private

		private Boolean? _isFeatureEnabled;
		private readonly ICacheStore _store;

		#endregion

		#region Constructors: Public

		public NotificationsJob() {
			_store = Store.Cache[CacheLevel.Application];
			_isFeatureEnabled = _store.GetValue<Boolean?>(FEATURE_CODE, null);
		}

		#endregion

		#region Methods: Private

		private bool? IsFeatureEnabled(UserConnection userConnection) {
			if (_isFeatureEnabled == null) {
				_isFeatureEnabled = userConnection.GetIsFeatureEnabled(FEATURE_CODE);
				_store[FEATURE_CODE] = _isFeatureEnabled;
			}
			return _isFeatureEnabled;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes job.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters for instances class.</param>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			if (IsFeatureEnabled(userConnection) == true) {
				NotificationInfoRunner runner = ClassFactory.ForceGet<NotificationInfoRunner>(
					typeof(NotificationInfoRunner).AssemblyQualifiedName,
					new ConstructorArgument("userConnection", userConnection),
					new ConstructorArgument("parameters", parameters));
				runner.Run();
			}
		}

		#endregion
	}

	#endregion
}

