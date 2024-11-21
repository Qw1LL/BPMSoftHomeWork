namespace BPMSoft.Configuration.GlobalSearch
{
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Web.SessionState;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: IndexingConfigService

	/// <summary>
	/// WebService for managing indexing entities.
	/// </summary>
	/// <remarks>
	/// Entire point for global search indexation.
	/// </remarks>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class IndexingConfigService: BaseService, IReadOnlySessionState
	{
		
		#region Properties: Public

		/// <summary>
		/// <see cref="IndexingConfigSender"/> instance.
		/// </summary>
		private IndexingConfigSender _indexingConfigSender;
		public virtual IndexingConfigSender IndexingConfigSender {
			get {
				return _indexingConfigSender ??
						(_indexingConfigSender =
							ClassFactory.Get<IndexingConfigSender>(
								new ConstructorArgument("userConnection", AppConnection?.SystemUserConnection)));
			}
		}

		/// <summary>
		/// <see cref="IndexingEntityListManager"/> instance.
		/// </summary>
		private IndexingEntityListManager _indexingEntityListManager;
		public virtual IndexingEntityListManager IndexingEntityListManager {
			get {
				return _indexingEntityListManager ??
						(_indexingEntityListManager =
							ClassFactory.Get<IndexingEntityListManager>(
								new ConstructorArgument("userConnection", AppConnection?.SystemUserConnection)));
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initializes indexation config files for global search.
		/// </summary>
		/// <remarks>
		/// WebService entire point.
		/// </remarks>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SendIndexationConfigs", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public virtual void SendIndexationConfigs() {
			IndexingConfigSender.Send();
		}

		/// <summary>
		/// Gets indexation config files.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetIndexationConfigs", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public virtual List<IndexingEntity> GetIndexationConfigs() {
			return IndexingEntityListManager.GetIndexingEntities();
		}

		#endregion
	}
	
	#endregion
	
}
