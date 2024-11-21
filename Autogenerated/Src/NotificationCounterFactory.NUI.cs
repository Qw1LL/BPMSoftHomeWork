namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	
	#region Class: NotificationCounterFactory

	/// <summary>
	/// Provides a method to access the classes for getting the counters.
	/// </summary>
	public class NotificationCounterFactory : INotificationCounterFactory
	{		
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public NotificationCounterFactory(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private IEnumerable<INotificationCounter> GetNotificationCountersInstances(string group) {
			var instances = ClassFactory.GetAll<INotificationCounter>(group,
				new ConstructorArgument("userConnection", _userConnection));
			return instances;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns instances of <see cref="INotificationCounter"/> by <see cref="NotificationGroup"/>
		/// </summary>
		/// <param name="group"><see cref="NotificationGroup"/></param>
		/// <returns>Collection of <see cref="INotificationCounter"/></returns>
		public IEnumerable<INotificationCounter> GetNotificationCounters(string group) {
			return GetNotificationCountersInstances(group);
		}

		#endregion
	}

	#endregion
}
