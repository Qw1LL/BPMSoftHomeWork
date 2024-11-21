namespace BPMSoft.Configuration.Social
{
	using System.Runtime.Serialization;

	#region Class: ConsumerInfo

	[DataContract]
	public class ConsumerInfo
	{

		#region Properties: Public

		[DataMember(Name = "key")]
		public string Key {
			get;
			set;
		}

		[DataMember(Name = "secret")]
		public string Secret {
			get;
			set;
		}

		[DataMember(Name = "version")]
		public string Version {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
