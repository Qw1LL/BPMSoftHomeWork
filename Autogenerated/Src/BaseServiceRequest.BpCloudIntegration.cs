namespace BPMSoft.Configuration.CESModels
{

	using System.Runtime.Serialization;

	#region Class: BaseServiceRequest

	/// <summary>
	/// Class of base request to CES.
	/// </summary>
	[DataContract]
	public class BaseServiceRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the API key.
		/// </summary>
		/// <value>
		/// The API key.
		/// </value>
		[DataMember(Name = "key")]
		public string ApiKey { get; set; }

		#endregion

	}

	#endregion

}

