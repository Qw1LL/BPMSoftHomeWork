namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ChatMessages

	/// <exclude/>
	public class ChatMessages : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ChatMessages(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChatMessages";
		}

		public ChatMessages(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ChatMessages";
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

		/// <summary>
		/// Message Direction.
		/// </summary>
		public string MessageDirection {
			get {
				return GetTypedColumnValue<string>("MessageDirection");
			}
			set {
				SetColumnValue("MessageDirection", value);
			}
		}

		/// <exclude/>
		public Guid ChannelId {
			get {
				return GetTypedColumnValue<Guid>("ChannelId");
			}
			set {
				SetColumnValue("ChannelId", value);
				_channel = null;
			}
		}

		/// <exclude/>
		public string ChannelName {
			get {
				return GetTypedColumnValue<string>("ChannelName");
			}
			set {
				SetColumnValue("ChannelName", value);
				if (_channel != null) {
					_channel.Name = value;
				}
			}
		}

		private Channel _channel;
		/// <summary>
		/// Channel.
		/// </summary>
		public Channel Channel {
			get {
				return _channel ??
					(_channel = new Channel(LookupColumnEntities.GetEntity("Channel")));
			}
		}

		/// <exclude/>
		public Guid OmniChatId {
			get {
				return GetTypedColumnValue<Guid>("OmniChatId");
			}
			set {
				SetColumnValue("OmniChatId", value);
				_omniChat = null;
			}
		}

		/// <exclude/>
		public string OmniChatName {
			get {
				return GetTypedColumnValue<string>("OmniChatName");
			}
			set {
				SetColumnValue("OmniChatName", value);
				if (_omniChat != null) {
					_omniChat.Name = value;
				}
			}
		}

		private OmniChat _omniChat;
		/// <summary>
		/// Chat.
		/// </summary>
		public OmniChat OmniChat {
			get {
				return _omniChat ??
					(_omniChat = new OmniChat(LookupColumnEntities.GetEntity("OmniChat")));
			}
		}

		/// <summary>
		/// Source.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		/// <summary>
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// Recipient.
		/// </summary>
		public string Recipient {
			get {
				return GetTypedColumnValue<string>("Recipient");
			}
			set {
				SetColumnValue("Recipient", value);
			}
		}

		/// <summary>
		/// Sender.
		/// </summary>
		public string Sender {
			get {
				return GetTypedColumnValue<string>("Sender");
			}
			set {
				SetColumnValue("Sender", value);
			}
		}

		/// <summary>
		/// Timestamp.
		/// </summary>
		public string Timestamp {
			get {
				return GetTypedColumnValue<string>("Timestamp");
			}
			set {
				SetColumnValue("Timestamp", value);
			}
		}

		/// <summary>
		/// Created Date.
		/// </summary>
		public DateTime CreatedDate {
			get {
				return GetTypedColumnValue<DateTime>("CreatedDate");
			}
			set {
				SetColumnValue("CreatedDate", value);
			}
		}

		#endregion

	}

	#endregion

}

