namespace BPMSoft.Configuration.Mailing
{

	#region Interface: IConfigurableMailingProvider

	/// <summary>
	/// Provides methods to configure mailing provider.
	/// </summary>
	public interface IConfigurableMailingProvider
	{

		#region Methods: Public

		/// <summary>
		/// Configures properties of current instance.
		/// </summary>
		void Configure();

		#endregion

	}

	#endregion

}
