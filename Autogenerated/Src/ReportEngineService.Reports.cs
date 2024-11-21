namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using System.Collections.Generic;
	using System.Linq;

	#region Class: ReportInfoItem

	/// <summary>
	/// Report info item class.
	/// </summary>
	[DataContract]
	public class ReportTemplateInfoItem
	{

		#region Properties: Public

		/// <summary>
		/// Report identifier.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Report caption.
		/// </summary>
		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		/// <summary>
		/// Report type.
		/// </summary>
		[DataMember(Name = "type")]
		public ReportType Type { get; set; }

		/// <summary>
		/// Name of the report entity schema.
		/// </summary>
		[DataMember(Name = "entitySchemaName")]
		public string EntitySchemaName { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a new instance of the <see cref="ReportTemplateInfoItem"/> and initializes it's property values with the
		/// <paramref name="reportTemplateInfo"/>'s property values.
		/// </summary>
		/// <param name="reportTemplateInfo">An instance of the <see cref="IReportTemplateInfo"/> type.</param>
		/// <returns>Initialized instance of the <see cref="ReportTemplateInfoItem"/> type.</returns>
		public static ReportTemplateInfoItem FromReportInfo(IReportTemplateInfo reportTemplateInfo) {
			return new ReportTemplateInfoItem {
				Id = reportTemplateInfo.Id,
				Caption = reportTemplateInfo.Caption,
				Type = reportTemplateInfo.Type,
				EntitySchemaName = reportTemplateInfo.EntitySchemaName
			};
		}

		#endregion

	}

	#endregion

	#region Class: GetReportsResponse

	/// <summary>
	/// Get reports response class.
	/// </summary>
	[DataContract]
	public class GetReportTemplatesResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// Collection of the report infos.
		/// </summary>
		[DataMember(Name = "reportTemplates")]
		public List<ReportTemplateInfoItem> ReportTemplates { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="GetReportTemplatesResponse"/> with the <paramref name="reportInfos"/>
		/// provided.
		/// </summary>
		/// <param name="reportInfos">The list of the <see cref="IReportInfo"/> to initialize a new instance with.
		/// </param>
		public GetReportTemplatesResponse(IReadOnlyList<IReportTemplateInfo> reportInfos) {
			ReportTemplates = reportInfos.Select(ReportTemplateInfoItem.FromReportInfo).ToList();
		}

		#endregion

	}

	#endregion

	#region Class: ReportFileProcessingService

	/// <summary>
	/// Report file processing service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ReportEngineService : BaseService
	{

		#region Fields: Private

		private readonly IReportEngine _reportEngine;
		
		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ReportEngineService"/> type.
		/// </summary>
		public ReportEngineService() {
			_reportEngine = ClassFactory.Get<IReportEngine>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ReportEngineService"/> type.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ReportEngineService(UserConnection userConnection)
			: base(userConnection) {
			_reportEngine = ClassFactory.Get<IReportEngine>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns available reports.
		/// </summary>
		/// <returns>Available reports.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public GetReportTemplatesResponse GetReportTemplates() {
			var reportTemplates = _reportEngine.GetReportTemplates();
			return new GetReportTemplatesResponse(reportTemplates);
		}

		#endregion

	}

	#endregion

}

