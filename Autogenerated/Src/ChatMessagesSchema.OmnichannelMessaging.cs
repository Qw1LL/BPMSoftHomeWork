namespace BPMSoft.Configuration
{

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

	#region Class: ChatMessagesSchema

	/// <exclude/>
	public class ChatMessagesSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ChatMessagesSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChatMessagesSchema(ChatMessagesSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChatMessagesSchema(ChatMessagesSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767");
			RealUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767");
			Name = "ChatMessages";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateOmniChatColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("92eb7679-648d-842c-57ba-2083ce0dff22")) == null) {
				Columns.Add(CreateMessageDirectionColumn());
			}
			if (Columns.FindByUId(new Guid("b6fd1e10-af77-d123-ef03-5157a3ba9b6d")) == null) {
				Columns.Add(CreateChannelColumn());
			}
			if (Columns.FindByUId(new Guid("5c0895c2-6dc0-322f-b358-7a57ee5f1051")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("3b3a2525-2a28-ff9b-3dcc-fd70b515d91a")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("ae7584c9-6c4d-c7db-e23b-962497379a84")) == null) {
				Columns.Add(CreateRecipientColumn());
			}
			if (Columns.FindByUId(new Guid("80a6da37-9f75-5fbb-5bb1-d294bbaf2339")) == null) {
				Columns.Add(CreateSenderColumn());
			}
			if (Columns.FindByUId(new Guid("47d6998f-d97d-9398-98fe-7afe8e1731fa")) == null) {
				Columns.Add(CreateTimestampColumn());
			}
			if (Columns.FindByUId(new Guid("ad7345bf-22be-1e31-900c-011d46710629")) == null) {
				Columns.Add(CreateCreatedDateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("92eb7679-648d-842c-57ba-2083ce0dff22"),
				Name = @"MessageDirection",
				CreatedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				ModifiedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateChannelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b6fd1e10-af77-d123-ef03-5157a3ba9b6d"),
				Name = @"Channel",
				ReferenceSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				ModifiedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateOmniChatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7efb2c37-5730-997f-b9ee-9c101395fb0f"),
				Name = @"OmniChat",
				ReferenceSchemaUId = new Guid("af1f685c-315b-4b44-a957-c5094417a57a"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				ModifiedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("5c0895c2-6dc0-322f-b358-7a57ee5f1051"),
				Name = @"Source",
				CreatedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				ModifiedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3b3a2525-2a28-ff9b-3dcc-fd70b515d91a"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				ModifiedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ae7584c9-6c4d-c7db-e23b-962497379a84"),
				Name = @"Recipient",
				CreatedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				ModifiedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("80a6da37-9f75-5fbb-5bb1-d294bbaf2339"),
				Name = @"Sender",
				CreatedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				ModifiedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateTimestampColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("47d6998f-d97d-9398-98fe-7afe8e1731fa"),
				Name = @"Timestamp",
				CreatedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				ModifiedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("ad7345bf-22be-1e31-900c-011d46710629"),
				Name = @"CreatedDate",
				CreatedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				ModifiedInSchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChatMessages(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChatMessages_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChatMessagesSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChatMessagesSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767"));
		}

		#endregion

	}

	#endregion

	#region Class: ChatMessages

	/// <summary>
	/// Chat messages.
	/// </summary>
	public class ChatMessages : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ChatMessages(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChatMessages";
		}

		public ChatMessages(ChatMessages source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
					(_channel = LookupColumnEntities.GetEntity("Channel") as Channel);
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
					(_omniChat = LookupColumnEntities.GetEntity("OmniChat") as OmniChat);
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

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChatMessages_OmnichannelMessagingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChatMessages(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChatMessages_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class ChatMessages_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ChatMessages
	{

		public ChatMessages_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChatMessages_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7cddb0a3-3c39-4034-8304-cd11aa23e767");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ChatMessages_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class ChatMessages_OmnichannelMessagingEventsProcess : ChatMessages_OmnichannelMessagingEventsProcess<ChatMessages>
	{

		public ChatMessages_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChatMessages_OmnichannelMessagingEventsProcess

	public partial class ChatMessages_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ChatMessagesEventsProcess

	/// <exclude/>
	public class ChatMessagesEventsProcess : ChatMessages_OmnichannelMessagingEventsProcess
	{

		public ChatMessagesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

