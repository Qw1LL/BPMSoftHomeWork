namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwLastActivityByQueue

	/// <exclude/>
	public class VwLastActivityByQueue : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwLastActivityByQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwLastActivityByQueue";
		}

		public VwLastActivityByQueue(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwLastActivityByQueue";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Активность.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = new Activity(LookupColumnEntities.GetEntity("Activity")));
			}
		}

		/// <exclude/>
		public Guid QueueItemId {
			get {
				return GetTypedColumnValue<Guid>("QueueItemId");
			}
			set {
				SetColumnValue("QueueItemId", value);
				_queueItem = null;
			}
		}

		/// <exclude/>
		public string QueueItemCaption {
			get {
				return GetTypedColumnValue<string>("QueueItemCaption");
			}
			set {
				SetColumnValue("QueueItemCaption", value);
				if (_queueItem != null) {
					_queueItem.Caption = value;
				}
			}
		}

		private QueueItem _queueItem;
		/// <summary>
		/// Элемент очереди единого окна.
		/// </summary>
		public QueueItem QueueItem {
			get {
				return _queueItem ??
					(_queueItem = new QueueItem(LookupColumnEntities.GetEntity("QueueItem")));
			}
		}

		#endregion

	}

	#endregion

}

