namespace BPMSoft.Configuration.DynamicContent
{
	using System.Runtime.Serialization;
	using BPMSoft.Configuration.DynamicContent.DataContract;

	#region Class: DCTemplateContractResponse

	/// <summary>
	/// Response class which contains <see cref="DCTemplateContract"/> 
	/// and functionality of the <see cref="ConfigurationServiceResponse"/>.
	/// Returns template's information.
	/// </summary>
	[DataContract]
	public class DCTemplateContractResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// Template contract object.
		/// </summary>
		[DataMember]
		public DCTemplateContract TemplateContract { get; set; }

		#endregion

	}

	#endregion

}
