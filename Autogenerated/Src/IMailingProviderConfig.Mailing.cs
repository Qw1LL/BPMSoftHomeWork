namespace BPMSoft.Configuration
{
	using System;

	#region Interface: IMailingProviderConfig

	/// <summary>
	/// Provides config of the mailing provider.
	/// </summary>
	public interface IMailingProviderConfig
	{

		#region Properties: Public

		/// <summary>
		/// Instance of the <see cref="IMailingTemplateFactory"/>.
		/// </summary>
		IMailingTemplateFactory TemplateFactory {
			get;
			set;
		}

		/// <summary>
		/// Instance of the <see cref="IMailingAudienceDataSourceFactory"/>.
		/// </summary>
		[Obsolete("Will be removed after 7.17.3")]
		IMailingAudienceDataSourceFactory AudienceDataSourceFactory { 
			get;
			set;
		}

		#endregion

	}

	#endregion

}

