namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Messaging.Common;

	#region Interface: INotificationMessageBuilder

	/// <summary>
	/// Provides methods to build notification message.
	/// </summary>
	public interface INotificationMessageBuilder
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets identifier of the admin unit.
		/// </summary>
		Guid SysAdminUnitId {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Builds a message identifier.
		/// </summary>
		Guid BuildId();

		/// <summary>
		/// Builds a message header.
		/// </summary>
		IMsgHeader BuildHeader();

		/// <summary>
		/// Builds a message body.
		/// </summary>
		string BuildBody();

		/// <summary>
		/// Builds a notification message.
		/// </summary>
		IMsg Build();

		#endregion

	}

	#endregion

}

