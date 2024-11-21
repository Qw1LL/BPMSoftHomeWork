namespace BPMSoft.Configuration.Social
{

	using System.Linq;
	using System.Runtime.Serialization;

	#region Class: BaseCommandParameter

	[DataContract]
	public class BaseCommandParameter
	{

		#region Properties: Public

		[DataMember(Name = "name")]
		public string Name {
			get;
			set;
		}

		[DataMember(Name = "value")]
		public string Value {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public override string ToString() {
			return string.Format("{0}={1}", Name, Value);
		}

		#endregion

	}

	#endregion

}
