namespace BPMSoft.Configuration
{

	using Core.Store;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Messaging.Common;
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

	#region Class: ESNNotification_ESNEventsProcess

	public partial class ESNNotification_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void PublishClientNotificationInfo(string operation) {
			var contactId = Entity.OwnerId;
			var sysAdminUnit = NotificationUtilities.GetSysAdminUnitId(UserConnection, contactId);
			var message = new {
				recordId = Entity.Id,
				operation,
				notificationGroup = "ESNNotification",
				markAsRead = Entity.IsRead
			};
			var simpleMessage = new SimpleMessage {
				Body = JsonConvert.SerializeObject(message),
				Id = sysAdminUnit
			};
			simpleMessage.Header.Sender = "UpdateReminding";
			var manager = MsgChannelManager.Instance;
			var channel = manager.FindItemByUId(sysAdminUnit);
			channel?.PostMessage(simpleMessage);
		}

		#endregion

	}

	#endregion

}

