namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.MarketingCampaign;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: EventTarget_MarketingCampaignEventsProcess

	public partial class EventTarget_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateEventRecipientCount(int incCount) {
			var eventId = Entity.GetTypedColumnValue<Guid>("EventId");
			if (eventId == Guid.Empty) {
				return;
			}
			var updateEvent = new Update(UserConnection, "Event")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
				.Set("RecipientCount", QueryColumnExpression.Add(new QueryColumnExpression("RecipientCount"),
					Column.Parameter(incCount)))
				.Where("Id").IsEqual(Column.Parameter(eventId)) as Update;
			updateEvent.Execute();
		}

		public virtual void OnInserting() {
			if (UserConnection.GetIsFeatureEnabled("EventAudienceImport")) {
				return;
			}
			var conditions = new Dictionary<string, object>();
			conditions.Add("Event", Entity.EventId);
			conditions.Add("Contact", Entity.ContactId);
			if (Entity.ExistInDB(conditions)) {
				throw new SaveDuplicatedEntityException(UniqueConstraintMessageText.Value);
			}
		}

		#endregion

	}

	#endregion

}

