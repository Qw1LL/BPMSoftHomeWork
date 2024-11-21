using System.Collections.Generic;
using BPMSoft.Core;

namespace BPMSoft.Configuration
{
	
	#region Class: CallMessagePublisher

	public class CallMessagePublisher : BaseMessagePublisher
	{

		#region Constructor: Public

		public CallMessagePublisher(UserConnection userConnection, Dictionary<string, string> entityFieldsData)
			: base(userConnection, entityFieldsData) {
			EntitySchemaName = "Activity";
		}

		#endregion

	}

	#endregion

}
