using System.Collections.Generic;
using BPMSoft.Core;

namespace BPMSoft.Configuration
{
	
	#region Class: SocialMessagePublisher

	public class SocialMessagePublisher : BaseMessagePublisher
	{

		#region Constructor: Public

		public SocialMessagePublisher(UserConnection userConnection, Dictionary<string, string> entityFieldsData)
			: base(userConnection, entityFieldsData) {
			EntitySchemaName = "SocialMessage";
		}

		#endregion

	}

	#endregion

}
