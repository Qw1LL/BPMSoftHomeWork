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

	#region Class: ChannelSchema

	/// <exclude/>
	public class ChannelSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ChannelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChannelSchema(ChannelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChannelSchema(ChannelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7");
			RealUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7");
			Name = "Channel";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("dd72812f-a6da-48bb-b7bf-5b0b6ca1daff")) == null) {
				Columns.Add(CreateProviderColumn());
			}
			if (Columns.FindByUId(new Guid("b3e8f54d-e256-43f1-9941-697d03be1083")) == null) {
				Columns.Add(CreateMsgSettingsIdColumn());
			}
			if (Columns.FindByUId(new Guid("c09c9229-998c-461f-bb1a-5719860fd701")) == null) {
				Columns.Add(CreateChatQueueColumn());
			}
			if (Columns.FindByUId(new Guid("ab862d6b-9ce2-4788-b9e1-4b6557ed612d")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("e4f00381-8872-437f-97d4-7e0b9dc80d62")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("5e187c78-acfc-d6b6-5380-ea06ce35015f")) == null) {
				Columns.Add(CreateLanguageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("1fc650ac-b636-403d-9490-ce6e1f934537"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				ModifiedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae")
			};
		}

		protected virtual EntitySchemaColumn CreateProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dd72812f-a6da-48bb-b7bf-5b0b6ca1daff"),
				Name = @"Provider",
				ReferenceSchemaUId = new Guid("a1beb75e-87bf-4400-9c5e-445aadcc5f05"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				ModifiedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae")
			};
		}

		protected virtual EntitySchemaColumn CreateMsgSettingsIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b3e8f54d-e256-43f1-9941-697d03be1083"),
				Name = @"MsgSettingsId",
				CreatedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				ModifiedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				CreatedInPackageId = new Guid("559bd000-2cc9-4c85-a75e-e0f0e89dfe52")
			};
		}

		protected virtual EntitySchemaColumn CreateChatQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c09c9229-998c-461f-bb1a-5719860fd701"),
				Name = @"ChatQueue",
				ReferenceSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				ModifiedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ab862d6b-9ce2-4788-b9e1-4b6557ed612d"),
				Name = @"Source",
				CreatedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				ModifiedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e4f00381-8872-437f-97d4-7e0b9dc80d62"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				ModifiedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988")
			};
		}

		protected virtual EntitySchemaColumn CreateLanguageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5e187c78-acfc-d6b6-5380-ea06ce35015f"),
				Name = @"Language",
				ReferenceSchemaUId = new Guid("2f96cb61-7e14-41e5-980a-bcb856edab51"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				ModifiedInSchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"),
				CreatedInPackageId = new Guid("6f05d58c-8c35-4460-8cdc-92bf987e5f26")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Channel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Channel_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChannelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChannelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7"));
		}

		#endregion

	}

	#endregion

	#region Class: Channel

	/// <summary>
	/// Chat channel.
	/// </summary>
	public class Channel : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Channel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Channel";
		}

		public Channel(Channel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid ProviderId {
			get {
				return GetTypedColumnValue<Guid>("ProviderId");
			}
			set {
				SetColumnValue("ProviderId", value);
				_provider = null;
			}
		}

		/// <exclude/>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
				if (_provider != null) {
					_provider.Name = value;
				}
			}
		}

		private ChannelProvider _provider;
		/// <summary>
		/// Provider.
		/// </summary>
		public ChannelProvider Provider {
			get {
				return _provider ??
					(_provider = LookupColumnEntities.GetEntity("Provider") as ChannelProvider);
			}
		}

		/// <summary>
		/// Messenger settings record Id.
		/// </summary>
		public Guid MsgSettingsId {
			get {
				return GetTypedColumnValue<Guid>("MsgSettingsId");
			}
			set {
				SetColumnValue("MsgSettingsId", value);
			}
		}

		/// <exclude/>
		public Guid ChatQueueId {
			get {
				return GetTypedColumnValue<Guid>("ChatQueueId");
			}
			set {
				SetColumnValue("ChatQueueId", value);
				_chatQueue = null;
			}
		}

		/// <exclude/>
		public string ChatQueueName {
			get {
				return GetTypedColumnValue<string>("ChatQueueName");
			}
			set {
				SetColumnValue("ChatQueueName", value);
				if (_chatQueue != null) {
					_chatQueue.Name = value;
				}
			}
		}

		private ChatQueue _chatQueue;
		/// <summary>
		/// Chat queue.
		/// </summary>
		public ChatQueue ChatQueue {
			get {
				return _chatQueue ??
					(_chatQueue = LookupColumnEntities.GetEntity("ChatQueue") as ChatQueue);
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
		/// Is active channel.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <exclude/>
		public Guid LanguageId {
			get {
				return GetTypedColumnValue<Guid>("LanguageId");
			}
			set {
				SetColumnValue("LanguageId", value);
				_language = null;
			}
		}

		/// <exclude/>
		public string LanguageName {
			get {
				return GetTypedColumnValue<string>("LanguageName");
			}
			set {
				SetColumnValue("LanguageName", value);
				if (_language != null) {
					_language.Name = value;
				}
			}
		}

		private SysLanguage _language;
		/// <summary>
		/// Language.
		/// </summary>
		public SysLanguage Language {
			get {
				return _language ??
					(_language = LookupColumnEntities.GetEntity("Language") as SysLanguage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Channel_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new Channel(this);
		}

		#endregion

	}

	#endregion

	#region Class: Channel_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class Channel_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Channel
	{

		public Channel_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Channel_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a26e0c98-9a52-4e80-9a04-75221742fed7");
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

	#region Class: Channel_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class Channel_OmnichannelMessagingEventsProcess : Channel_OmnichannelMessagingEventsProcess<Channel>
	{

		public Channel_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Channel_OmnichannelMessagingEventsProcess

	public partial class Channel_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ChannelEventsProcess

	/// <exclude/>
	public class ChannelEventsProcess : Channel_OmnichannelMessagingEventsProcess
	{

		public ChannelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

