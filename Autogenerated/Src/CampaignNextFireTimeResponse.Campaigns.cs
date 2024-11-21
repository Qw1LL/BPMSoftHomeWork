namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class: CampaignNextFireTimeResponse

	/// <summary>
	/// Contract for response about campaign next fire time.
	/// </summary>
	[DataContract]
	public class CampaignNextFireTimeResponse
	{

		#region Properties: Public

		/// <summary>
		/// String representation of <see cref="DateTime"/> which includes information about campaign next fire time.
		/// This representation should be obtained from
		/// <see cref="DateTimeDataValueType.Serialize(object, TimeZoneInfo)"/>
		/// for correct parsing in client.
		/// </summary>
		[DataMember(Name = "nextFireTime")]
		public string NextFireTime {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
