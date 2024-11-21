namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Interface: ILogoutEventHandler

	/// <summary>
	/// Provides api for "on user logout" actions implementation.
	/// </summary>
	public interface ILogoutEventHandler {

		#region Methods: Public

		/// <summary>
		/// This method will be called before user session end in all implementations.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> instance.</param>
		void HandleEvent(UserConnection uc);

		#endregion

	}

	#endregion

}
