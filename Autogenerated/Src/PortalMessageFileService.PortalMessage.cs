namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Common.ServiceRouting;
	using Web.Common;

	#region  Class: ReadingOptions

	/// <summary>
	/// Reading messages options.
	/// </summary>
	[DataContract]
	public class ReadingOptions
	{

		#region Properties: Public

		/// <summary>
		/// Count of rows to be retrieved.
		/// </summary>
		[DataMember(Name = "rowCount")]
		public int RowCount { get; set; }

		/// <summary>
		/// last loaded value.
		/// </summary>
		[DataMember(Name = "lastValue")]
		public Guid LastValue { get; set; }

		#endregion

	}

	#endregion

	#region  Class: PortalFileServiceResponse

	/// <summary>
	/// Reading messages response.
	/// </summary>
	[DataContract]
	public class PortalFileServiceResponse : ConfigurationServiceResponse
	{

		[DataMember(Name = "PortalMessageFiles")]
		public IEnumerable<PortalMessageFileDTO> PortalMessageFiles { get; set; }

	}

	#endregion

	#region Class: PortalFileService

	/// <summary>
	/// Portal message file service.
	/// </summary>
	[DefaultServiceRoute]
	[SspServiceRoute]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class PortalMessageFileService : BaseService
	{
		#region Properties: Protected

		private IPortalMessageFileReader _portalMessageFilesReader;

		protected IPortalMessageFileReader PortalMessageFilesReader =>
			_portalMessageFilesReader ?? (_portalMessageFilesReader = new PortalMessageFilesReader(UserConnection));

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get portal message files.
		/// </summary>
		/// <param name="portalMessageId">Portal message uniqueidentifier.</param>
		/// <param name="readingOptions">Reading message options <see cref="ReadingOptions"/>.</param>
		/// <returns>Container with Portal message files collection <see cref="PortalFileServiceResponse"/>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public PortalFileServiceResponse GetPortalMessageFiles(string portalMessageId, ReadingOptions readingOptions) {
			var result = new PortalFileServiceResponse();
			result.PortalMessageFiles = PortalMessageFilesReader.GetPortalMessageFiles(portalMessageId, readingOptions);
			return result;

		}

		/// <summary>
		/// Deletes portal message file by given identifier of portal message file.
		/// </summary>
		/// <param name="portalMessageFileId">Identifier of portal message file.</param>
		/// <returns>True, if file was deleted, otherwise - false.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public bool DeletePortalMessageFile(Guid portalMessageFileId) {
			var cleaner = new PortalMessageFileCleaner(UserConnection);
			return cleaner.DeletePortalMessageFile(portalMessageFileId);
		}

		#endregion
	}

	#endregion

}
