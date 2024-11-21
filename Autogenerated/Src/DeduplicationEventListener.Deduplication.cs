namespace BPMSoft.Configuration.Deduplication
{
	using RestSharp;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: DeduplicationEventListener

	/// <summary>
	/// Deduplication application event listener.
	/// </summary>
	public class DeduplicationEventListener : AppEventListenerBase
	{

		#region Constants: Public

		public static readonly string DuplicatesRuleCheckerTag = "DuplicatesRuleChecker";

		public static readonly string BulkDeduplicationRestClientTag = "BulkDeduplicationRestClient";

		public static readonly string BulkDeduplicationTaskRestClientTag = "BulkDeduplicationTaskRestClientTag";

		#endregion

		#region Fields: Private

		private const string DeduplicationConfigurationScriptBuilderTag = "DeduplicationConfigurationScriptBuilder";

		#endregion

		#region Methods: Protected

		protected virtual void InitializeDeduplicationDependencyInjectionModel() {
			ClassFactory.Bind<ICustomConfigurationScriptBuilder, DeduplicationConfigurationScriptBuilder>(
				DeduplicationConfigurationScriptBuilderTag);
			ClassFactory.Bind<IDeduplicationManager, DeduplicationManager>();
			ClassFactory.Bind<IDuplicatesRuleChecker, DuplicatesRuleManager>(DuplicatesRuleCheckerTag);
			ClassFactory.Bind<IDeduplicationSearchQueryBuilder, DeduplicationSearchQueryBuilder>();
			ClassFactory.Bind<IRestClient, RestClient>(BulkDeduplicationRestClientTag);
			ClassFactory.Bind<IRestClient, RestClient>(BulkDeduplicationTaskRestClientTag);
			ClassFactory.Bind<IBulkDeduplicationTaskStarter, BulkDeduplicationManager>();
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="AppEventListenerBase.OnAppStart"/>
		public override void OnAppStart(AppEventContext context) {
			InitializeDeduplicationDependencyInjectionModel();
		}

		#endregion

	}

	#endregion

}

