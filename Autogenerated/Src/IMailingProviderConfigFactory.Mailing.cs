namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region Interface: IMailingProviderConfigFactory

	/// <summary>
	/// Provides methods for creating instancies of the <see cref="IMailingProviderConfig"/>.
	/// </summary>
	public interface IMailingProviderConfigFactory
	{

		#region Methods: Public

		/// <summary>
		/// Creates instance of the <see cref="IMailingProviderConfig"/>.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Returns instance of the <see cref="IMailingProviderConfig"/>.</returns>
		IMailingProviderConfig CreateInstance(UserConnection userConnection);

		#endregion

	}

	#endregion

}

