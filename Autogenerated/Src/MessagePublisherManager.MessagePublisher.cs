namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;

	#region Class: MessagePublisherManager

	public class MessagePublisherManager
	{

		#region Fiels: Private;

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructor: Public

		public MessagePublisherManager(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private object GetInstance(string className, Dictionary<string, string> fieldsData) {
			Type type = Type.GetType(className);
			return type != null ? Activator.CreateInstance(type, _userConnection, fieldsData) : null;
		}

		#endregion

		#region Methods: Public

		public void Publish(string className, Dictionary<string, string> fieldsData) {
			var messagePublisher = (IMessagePublisher)GetInstance(className, fieldsData);
			if (messagePublisher != null) {
				messagePublisher.Publish();
			}
		}

		#endregion

	}

	#endregion

}

