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

	#region Class: ClearActualResponseDateRuleHandler

	public class ClearActualResponseDateRuleHandler : ICaseRuleHandler
	{
		#region Constructors: Public

		public ClearActualResponseDateRuleHandler(UserConnection userConnection) {
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
			if (entity.GetTypedColumnValue<DateTime>("RespondedOn") != null) {
				entity.SetColumnValue("RespondedOn", null);
			}
		}

		#endregion
	}

	#endregion

}

