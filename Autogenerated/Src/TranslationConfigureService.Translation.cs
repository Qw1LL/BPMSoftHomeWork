namespace BPMSoft.Configuration.Translation
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel.Activation;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: TranslationService

	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TranslationConfigureService : BaseService, ITranslationConfigureService
	{

		#region Methods: Private

		private IEnumerable<TranslationColumnConfigure> GetSysTranslationColumnsConfigured() {
			var translationColumnsConfigurator = ClassFactory.Get<ISysTranslationColumnsConfigurator>(
				new ConstructorArgument("userConnection", UserConnection));
			return translationColumnsConfigurator.GetTranslationColumnsConfigured();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// <see cref="ITranslationConfigureService"/>
		/// </summary>
		public TranslationColumnsConfiguredResponse GetConfiguredSysTranslationColumns() {
			var response = new TranslationColumnsConfiguredResponse();
			try {
				response.ColumnsConfig = GetSysTranslationColumnsConfigured().ToList();
			} catch(Exception e) {
				response.Exception = e;
			}
			return response;
		}

		#endregion

	}

	#endregion

	#region Class: TranslationColumnsConfiguredResponse

	/// <summary>
	/// Response contract for configuring SysTranslation columns.
	/// </summary>
	[DataContract]
	public class TranslationColumnsConfiguredResponse : ConfigurationServiceResponse
	{
		/// <summary>
		/// Configuration data, <see cref="TranslationColumnConfigure"/>.
		/// </summary>
		[DataMember(Name = "ColumnsConfig")]
		public List<TranslationColumnConfigure> ColumnsConfig { get; set; }
	}

	#endregion

}

