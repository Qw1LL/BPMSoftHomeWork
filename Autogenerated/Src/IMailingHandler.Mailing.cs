namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Interface: IMailingHandler

	/// <summary>
	/// Provides interface for the mailing handler.
	/// </summary>
	public interface IMailingHandler
	{

		#region Methods: Public

		/// <summary>
		/// Creates instance of the handler.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		void CreateInstance(UserConnection userConnection);

		/// <summary>
		/// Removes instance of the handler.
		/// </summary>
		void RemoveInstance();

		#endregion

	}

	#endregion

}

