namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common.Json;
	using BPMSoft.Common;
	using BPMSoft.Web.Common;

	#region Class: MultiOperationHelper

	/// <summary>
	/// Helper for multiple operations.
	/// </summary>
	public class MultiOperationHelper
	{

		#region Methods: Protected

		protected virtual GridUtilitiesServiceHandler GetGridUtilitiesServiceHandler() {
			return ClassFactory.Get<GridUtilitiesServiceHandler>();
		}

		protected virtual IMultiOperationStrategy GetMultiLinkEntityStrategy(string parameters) {
			if (parameters.IsNullOrEmpty()) {
				throw new ArgumentNullException("parameters");
			}
			var strategyParameters = Json.Deserialize<Dictionary<string, object>>(parameters);
			var multiLinkEntityArgs = new[] {
				new ConstructorArgument("strategyParameters", strategyParameters)
			};
			IMultiOperationStrategy multiLinkStrategy = ClassFactory.Get<MultiLinkEntity>(multiLinkEntityArgs);
			return multiLinkStrategy;
		}

		protected virtual MultiOperationProvider GetMultiOperationProvider(IMultiOperationStrategy strategy, string entityName, string[] recordsId) {
			List<Guid> recordsGuid = recordsId.Select(Guid.Parse).ToList();
			var multiOperationProviderArgs = new[] {
				new ConstructorArgument("strategy", strategy),
				new ConstructorArgument("entityName", entityName),
				new ConstructorArgument("recordsId", recordsGuid)
			};
			MultiOperationProvider provider = ClassFactory.Get<MultiOperationProvider>(multiOperationProviderArgs);
			return provider;
		}

		protected virtual string[] GetRecordsIdFromFilters(string entityName, string filtersConfig) {
			GridUtilitiesServiceHandler utilities = GetGridUtilitiesServiceHandler();
			return utilities.GetPrimaryColumnValuesFromFilters(entityName, filtersConfig);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Use strategy of multiple linker for connect entities by specified parameters.
		/// </summary>
		/// <param name="entityName">Name of entities.</param>
		/// <param name="recordsId">Identifier of records.</param>
		/// <param name="parameters">Strategy parameters.</param>
		/// <param name="filtersConfig">Filters configuration.</param>
		public virtual void MultiLinkEntity(string entityName, string[] recordsId, string parameters, string filtersConfig = null) {
			if (filtersConfig != null) {
				recordsId = GetRecordsIdFromFilters(entityName, filtersConfig);
			}
			IMultiOperationStrategy multiLinkStrategy = GetMultiLinkEntityStrategy(parameters);
			MultiOperationProvider provider = GetMultiOperationProvider(multiLinkStrategy, entityName, recordsId);
			provider.DoOperation();
		}

		#endregion
	}

	#endregion

	#region Class: MultiOperationService

	///<summary>Service of multiple operations.</summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MultiOperationService : BaseService
	{

		#region Fields: Private

		private MultiOperationHelper _multiOperationHelper;

		#endregion

		#region Properties: Public

		public MultiOperationHelper MultiOperationHelper {
			get {
				return _multiOperationHelper ?? (_multiOperationHelper = new MultiOperationHelper());
			}
			set {
				_multiOperationHelper = value;
			}
		}

		#endregion

		#region Methods: Private

		protected virtual void ValidateParameters(string entityName, string[] recordsId, string filtersConfig = null) {
			if (entityName.IsNullOrEmpty()) {
				throw new ArgumentEmptyException("EntityName");
			}
			if (recordsId.IsNullOrEmpty() && filtersConfig == null) {
				throw new ArgumentEmptyException("RecordsId");
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		///  Web-method for multiple link entities.
		/// </summary>
		/// <param name="entityName">Name of entities.</param>
		/// <param name="recordsId">Identifier of records.</param>
		/// <param name="parameters">Strategy parameters.</param>
		/// <param name="filtersConfig">Filters configuration.</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "MultiLinkEntity", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse MultiLinkEntity(string entityName, string[] recordsId, string parameters = null, string filtersConfig = null) {
			var response = new ConfigurationServiceResponse();
			try {
				ValidateParameters(entityName, recordsId, filtersConfig);
				MultiOperationHelper.MultiLinkEntity(entityName, recordsId, parameters, filtersConfig);
			}
			catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		#endregion

	}

	#endregion

}
