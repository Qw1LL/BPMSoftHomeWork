namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: OperatorLogoutEventHandler

	/// <summary>
	/// Set operator state on user logout.
	/// </summary>
	/// <seealso cref="ILogoutEventHandler"/>.
	[DefaultBinding(typeof(ILogoutEventHandler), Name = "OperatorLogoutEventHandler")]
	public class OperatorLogoutEventHandler : ILogoutEventHandler
	{

		#region Methods: Public

		/// <inheritdoc cref="ILogoutEventHandler.HandleEvent(UserConnection)"/>
		public void HandleEvent(UserConnection uc) {
			try {
				var currentUserId = uc.CurrentUser.Id;
				var operatorManager = new OperatorManager(uc);
				operatorManager.ChangeOperatorState(currentUserId, OmnichannelMessagingConsts.OperatorState.Inactive.Code);
			} catch (Exception) { }
		}

		#endregion

	}

	#endregion

}

