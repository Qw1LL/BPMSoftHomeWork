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

	#region Class: OmniChatActionSchema

	/// <exclude/>
	public class OmniChatActionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OmniChatActionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OmniChatActionSchema(OmniChatActionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OmniChatActionSchema(OmniChatActionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06");
			RealUId = new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06");
			Name = "OmniChatAction";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("78e2b210-da08-49b6-87fe-83ea82f0feba")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("aa6e3644-a165-483a-a928-26d8d7f8f278")) == null) {
				Columns.Add(CreateProcessSchemaIdColumn());
			}
			if (Columns.FindByUId(new Guid("6d10cea1-1608-4860-bfbb-56f85f3fb36c")) == null) {
				Columns.Add(CreateChatQueueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("78e2b210-da08-49b6-87fe-83ea82f0feba"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06"),
				ModifiedInSchemaUId = new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateProcessSchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("aa6e3644-a165-483a-a928-26d8d7f8f278"),
				Name = @"ProcessSchemaId",
				CreatedInSchemaUId = new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06"),
				ModifiedInSchemaUId = new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06"),
				CreatedInPackageId = new Guid("01343ce8-0448-497f-b2c3-9511b4580fa3")
			};
		}

		protected virtual EntitySchemaColumn CreateChatQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6d10cea1-1608-4860-bfbb-56f85f3fb36c"),
				Name = @"ChatQueue",
				ReferenceSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06"),
				ModifiedInSchemaUId = new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06"),
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
			return new OmniChatAction(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OmniChatAction_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OmniChatActionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OmniChatActionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06"));
		}

		#endregion

	}

	#endregion

	#region Class: OmniChatAction

	/// <summary>
	/// Chat actions.
	/// </summary>
	public class OmniChatAction : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OmniChatAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OmniChatAction";
		}

		public OmniChatAction(OmniChatAction source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Process schema id.
		/// </summary>
		public Guid ProcessSchemaId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaId");
			}
			set {
				SetColumnValue("ProcessSchemaId", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OmniChatAction_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new OmniChatAction(this);
		}

		#endregion

	}

	#endregion

	#region Class: OmniChatAction_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class OmniChatAction_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OmniChatAction
	{

		public OmniChatAction_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OmniChatAction_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("333245ea-900f-43b9-b8d2-e1857cfdfb06");
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

	#region Class: OmniChatAction_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class OmniChatAction_OmnichannelMessagingEventsProcess : OmniChatAction_OmnichannelMessagingEventsProcess<OmniChatAction>
	{

		public OmniChatAction_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OmniChatAction_OmnichannelMessagingEventsProcess

	public partial class OmniChatAction_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OmniChatActionEventsProcess

	/// <exclude/>
	public class OmniChatActionEventsProcess : OmniChatAction_OmnichannelMessagingEventsProcess
	{

		public OmniChatActionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

