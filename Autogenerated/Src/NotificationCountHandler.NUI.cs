namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.Collections.Generic;
	using BPMSoft.Common;

	#region Class: NotificationCountHandler

	/// <summary>
	/// Provides method to retrieve the counters
	/// </summary>
	public class NotificationCountHandler : INotificationCountHandler
	{
		#region Fields: Private

		private readonly INotificationCounterFactory _factory;

		#endregion

		#region Constructors: Public

		public NotificationCountHandler(INotificationCounterFactory factory) {
			factory.CheckArgumentNull(nameof(factory));
			_factory = factory;
		}

		#endregion

		#region Methods: Private

		private void ApplyCounter(IDictionary<string, int> result, IDictionary<string, int> counters) {
			foreach (KeyValuePair<string, int> counter in counters) {
				if (result.ContainsKey(counter.Key)) {
					result[counter.Key] += counter.Value;
					continue;
				}
				result[counter.Key] = counter.Value;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns the counters for a user. 
		/// </summary>
		/// <param name="contactId">User identifier.</param>
		/// <param name="group">Name of the group.</param>
		/// <returns>Dictionary, where key is group of count and value is count.</returns>
		public IDictionary<string, int> GetNotificationCounters(Guid contactId, string group) {
			contactId.CheckArgumentEmpty(nameof(contactId));
			group.CheckArgumentNullOrEmpty(nameof(group));
			var result = new Dictionary<string, int>();
			IEnumerable<INotificationCounter> notificationCounters = _factory.GetNotificationCounters(group);
			foreach (INotificationCounter notificationCounter in notificationCounters) {
				var counter = notificationCounter.GetNotificationCount(contactId);
				ApplyCounter(result, counter);
			}

			return result;
		}

		#endregion
	}

	#endregion
}

