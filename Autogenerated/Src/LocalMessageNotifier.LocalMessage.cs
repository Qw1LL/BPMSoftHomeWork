using System;
using System.Collections.Generic;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{

	#region Class: LocalMessageNotifier

	public class LocalMessageNotifier : BaseMessageNotifier
	{

		#region Constructor: Public

		public LocalMessageNotifier(Entity entity) {
			MessageInfo = new MessageInfo {
				Message = entity.GetTypedColumnValue<string>("Message"),
				CreatedById = entity.GetTypedColumnValue<Guid>("CreatedById"),
				CreatedOn = entity.GetTypedColumnValue<DateTime>("CreatedOn"),
				HasAttachment = true,
				NotifierRecordId = entity.PrimaryColumnValue,
				SchemaUId = entity.Schema.UId,
				ListenersData = new Dictionary<Guid, Guid> {
					{ entity.GetTypedColumnValue<Guid>("EntitySchemaUId"), entity.GetTypedColumnValue<Guid>("EntityId") }
				}
			};
		}

		#endregion

	}

	#endregion

}


