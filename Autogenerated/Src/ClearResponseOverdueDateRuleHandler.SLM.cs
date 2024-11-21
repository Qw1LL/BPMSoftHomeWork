namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Configuration.Calendars;

	#region Class: ClearResponseOverdueDateRuleHandler

	public class ClearResponseOverdueDateRuleHandler : ICaseRuleHandler
	{
		#region Constructors: Public

		public ClearResponseOverdueDateRuleHandler(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get;
			private set;
		}

		#endregion

		#region Methods: Public

		public void Handle(Entity entity) {
			if (entity.GetTypedColumnValue<int>("ResponseOverdue") != 0) {
				entity.SetColumnValue("ResponseOverdue", 0);
			}
		}

		#endregion
	}

	#endregion

}

