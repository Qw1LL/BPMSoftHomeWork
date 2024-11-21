namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ListenerByNotifier

	/// <exclude/>
	public class ListenerByNotifier : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ListenerByNotifier(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ListenerByNotifier";
		}

		public ListenerByNotifier(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ListenerByNotifier";
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

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <exclude/>
		public Guid MessageNotifierId {
			get {
				return GetTypedColumnValue<Guid>("MessageNotifierId");
			}
			set {
				SetColumnValue("MessageNotifierId", value);
				_messageNotifier = null;
			}
		}

		/// <exclude/>
		public string MessageNotifierName {
			get {
				return GetTypedColumnValue<string>("MessageNotifierName");
			}
			set {
				SetColumnValue("MessageNotifierName", value);
				if (_messageNotifier != null) {
					_messageNotifier.Name = value;
				}
			}
		}

		private MessageNotifier _messageNotifier;
		/// <summary>
		/// Notifier.
		/// </summary>
		public MessageNotifier MessageNotifier {
			get {
				return _messageNotifier ??
					(_messageNotifier = new MessageNotifier(LookupColumnEntities.GetEntity("MessageNotifier")));
			}
		}

		/// <exclude/>
		public Guid MessageListenerId {
			get {
				return GetTypedColumnValue<Guid>("MessageListenerId");
			}
			set {
				SetColumnValue("MessageListenerId", value);
				_messageListener = null;
			}
		}

		/// <exclude/>
		public string MessageListenerName {
			get {
				return GetTypedColumnValue<string>("MessageListenerName");
			}
			set {
				SetColumnValue("MessageListenerName", value);
				if (_messageListener != null) {
					_messageListener.Name = value;
				}
			}
		}

		private MessageListener _messageListener;
		/// <summary>
		/// Listener.
		/// </summary>
		public MessageListener MessageListener {
			get {
				return _messageListener ??
					(_messageListener = new MessageListener(LookupColumnEntities.GetEntity("MessageListener")));
			}
		}

		/// <summary>
		/// Notifier connection column name.
		/// </summary>
		public string NotifierConnectionColumn {
			get {
				return GetTypedColumnValue<string>("NotifierConnectionColumn");
			}
			set {
				SetColumnValue("NotifierConnectionColumn", value);
			}
		}

		#endregion

	}

	#endregion

}

