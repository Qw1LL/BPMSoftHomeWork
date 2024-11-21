namespace BPMSoft.Configuration.Social
{

	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;

	#region Enum: PermissionStatus

	public enum PermissionStatus
	{
		Declined = 0,
		Granted = 1
	}

	#endregion

	#region Class: BasePermission

	public class BasePermission
	{

		#region Properties: Public

		string Name { get; set; }

		string Description { get; set; }

		PermissionStatus Status { get; set; }

		#endregion

	}

	#endregion

}
