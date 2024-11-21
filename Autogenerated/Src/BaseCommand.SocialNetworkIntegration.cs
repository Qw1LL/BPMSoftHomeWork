namespace BPMSoft.Configuration.Social
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Configuration;

	#region Class: BaseCommand

	[DataContract]
	public class BaseCommand
	{

		#region Properties: Public

		private List<BaseCommandParameter> _parameters;
		[DataMember(Name = "parameters")]
		public List<BaseCommandParameter> Parameters {
			get {
				return _parameters ?? (_parameters = new List<BaseCommandParameter>());
			}
			set {
				_parameters = value;
			}
		}

		private List<BasePermission> _permissions;
		[DataMember(Name = "permissions")]
		public List<BasePermission> Permissions {
			get {
				return _permissions ?? (_permissions = new List<BasePermission>());
			}
			set {
				_permissions = value;
			}
		}

		[DataMember(Name = "name")]
		public string Name { get; set; }

		#endregion

		#region Constructors: Public

		public BaseCommand() {
			Permissions = new List<BasePermission>();
		}

		public BaseCommand(List<BasePermission> permissions) {
			Permissions = permissions;
		}

		#endregion

		#region Methods: Public

		public virtual string GetText() {
			if (Parameters == null || Parameters.Count == 0) {
				return Name;
			}
			IEnumerable<string> list = Parameters.Select(p => p.ToString());
			string parameters = string.Join("&", list);
			return string.Format("{0}?{1}", Name, parameters);
		}

		#endregion

	}

	#endregion

}
