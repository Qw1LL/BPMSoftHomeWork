namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Configuration.CES;

	#region class: CESMailingProviderConfig

	/// <summary>
	/// Provides config of the mailing provider.
	/// </summary>
	public class CESMailingProviderConfig : IMailingProviderConfig
	{

		#region Properties: Public

		/// <summary>
		/// Instance of the <see cref="IMailingTemplateFactory"/>.
		/// </summary>
		public IMailingTemplateFactory TemplateFactory {
			get;
			set;
		}

		/// <summary>
		/// Instance of the <see cref="IMailingAudienceDataSourceFactory"/>.
		/// </summary>
		[Obsolete("Will be removed after 7.17.3")]
		public IMailingAudienceDataSourceFactory AudienceDataSourceFactory { 
			get;
			set;
		}

		/// <summary>
		/// Instance of the <see cref="ICESApi"/>.
		/// </summary>
		public ICESApi ServiceApi {
			get;
			set;
		}

		#endregion

	}

	#endregion

}

