using System;
using System.Collections.Generic;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{

	#region Class: SocialMessageNotifier

	public class SocialMessageNotifier : BaseMessageNotifier
	{

		#region Constructor: Public

		public SocialMessageNotifier(Entity entity) {
			MessageInfo = new MessageInfo {
				Message = entity.GetTypedColumnValue<string>("Message"),
				CreatedById = entity.GetTypedColumnValue<Guid>("CreatedById"),
				CreatedOn = entity.GetTypedColumnValue<DateTime>("CreatedOn"),
				ModifiedById = entity.GetTypedColumnValue<Guid>("ModifiedById"),
				ModifiedOn = entity.GetTypedColumnValue<DateTime>("ModifiedOn"),
				HasAttachment = true,
				NotifierRecordId = entity.PrimaryColumnValue,
				SchemaUId = entity.Schema.UId,
				ListenersData = new Dictionary<Guid, Guid> {
					{ entity.GetTypedColumnValue<Guid>("EntitySchemaUId"), entity.GetTypedColumnValue<Guid>("EntityId") }
				},
				EntityState = entity.ChangeType
			};
		}

		#endregion

	}

	#endregion

}
