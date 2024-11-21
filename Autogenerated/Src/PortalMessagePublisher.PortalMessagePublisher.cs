using System.Collections.Generic;
using BPMSoft.Core;

namespace BPMSoft.Configuration
{
	
	#region Class: PortalMessagePublisher

	public class PortalMessagePublisher : BaseMessagePublisher
	{

		#region Constructor: Public

		public PortalMessagePublisher(UserConnection userConnection, Dictionary<string, string> entityFieldsData)
			: base(userConnection, entityFieldsData) {
			EntitySchemaName = "PortalMessage";
		}

		#endregion

	}

	#endregion

}
