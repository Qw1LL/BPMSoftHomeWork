namespace BPMSoft.Configuration.Social
{
	using System.Runtime.Serialization;

	#region Class: BaseCommandResult

	[DataContract]
	public class BaseCommandResult : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "text")]
		public string Text {
			get;
			set;
		}

		private dynamic _raw;
		public dynamic Raw {
			get {
				return _raw;
			}
			set {
				_raw = value;
				Text = _raw.ToString();
			}
		}

		#endregion

	}

	#endregion

}
