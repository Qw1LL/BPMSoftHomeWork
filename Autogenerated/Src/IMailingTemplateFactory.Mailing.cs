namespace BPMSoft.Configuration
{

	#region Interface: IMailingTemplateFactory

	/// <summary>
	/// Provides methods for creating instancies of the <see cref="IMailingTemplate"/>.
	/// </summary>
	public interface IMailingTemplateFactory
	{

		#region Methods: Public

		/// <summary>
		/// Creates instance of the <see cref="IMailingTemplate"/>.
		/// </summary>
		/// <returns>Returns instance of the <see cref="IMailingTemplate"/>.</returns>
		IMailingTemplate CreateInstance();

		#endregion

	}

	#endregion

}

