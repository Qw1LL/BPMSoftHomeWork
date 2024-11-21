namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;

	#region Enum: CampaignAudienceDataSource

	/// <summary>
	/// Enum with the list of supported datasources.
	/// </summary>
	public enum CampaignAudienceDataSource
	{
		DefaultAudience,
		SessionedAudience
	}

	#endregion

	#region Class: CampaignAudienceFactory

	/// <summary>
	/// Factory for create campaign audience store.
	/// </summary>
	public sealed class CampaignAudienceFactory
	{

		#region Fields: Private

		private static volatile CampaignAudienceFactory _instance;
		private static readonly object _syncInstanceObject = new object();
		private volatile Dictionary<CampaignAudienceDataSource, Func<CampaignAudienceConfig, ICampaignAudience>> _dataSources;

		#endregion

		#region Constructors: Private

		private CampaignAudienceFactory() {
			InitFactory();
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Singleton instance of the factory.
		/// </summary>
		public static CampaignAudienceFactory Instance {
			get {
				if (_instance == null) {
					lock (_syncInstanceObject) {
						if (_instance == null) {
							_instance = new CampaignAudienceFactory();
						}
					}
				}
				return _instance;
			}
		}

		#endregion

		#region Methods: Private

		private CampaignAudienceDataSource ResolveDataSource(CampaignAudienceConfig config) {
			config.CheckArgumentNull("config");
			if (config.SessionId != default(Guid)) {
				return CampaignAudienceDataSource.SessionedAudience;
			}
			return CampaignAudienceDataSource.DefaultAudience;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initialized factory with default data sources.
		/// </summary>
		public void InitFactory() => InitFactory(null);

		/// <summary>
		/// Initialized factory with default or predefined rules.
		/// </summary>
		/// <param name="predefinedDataSources">The dictionary with predefined rules.</param>
		public void InitFactory(Dictionary<CampaignAudienceDataSource,
				Func<CampaignAudienceConfig, ICampaignAudience>> predefinedDataSources) {
			_dataSources = predefinedDataSources
				?? new Dictionary<CampaignAudienceDataSource, Func<CampaignAudienceConfig, ICampaignAudience>> {
					[CampaignAudienceDataSource.SessionedAudience] = config => new SessionedCampaignAudience(config),
					[CampaignAudienceDataSource.DefaultAudience] = config => new CampaignAudience(config)
				};
		}

		/// <summary>
		/// Create object for manipulation campaign audience based on config <paramref name="config"/>.
		/// </summary>
		/// <param name="config">Contains description for campaign audience class.</param>
		/// <returns>Concrete instance of campaign audience object.</returns>
		public ICampaignAudience GetCampaignAudience(CampaignAudienceConfig config) {
			var dataSourceKey = ResolveDataSource(config);
			if (!_dataSources.ContainsKey(dataSourceKey)) {
				throw new KeyNotFoundException();
			}
			return _dataSources[dataSourceKey](config);
		}

		#endregion

	}


	#endregion

}
