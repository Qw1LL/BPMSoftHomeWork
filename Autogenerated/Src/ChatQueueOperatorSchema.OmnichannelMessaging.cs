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

	#region Class: ChatQueueOperatorSchema

	/// <exclude/>
	public class ChatQueueOperatorSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ChatQueueOperatorSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChatQueueOperatorSchema(ChatQueueOperatorSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChatQueueOperatorSchema(ChatQueueOperatorSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4682fa28-8b8d-4ee5-84c3-8c5f059a6714");
			RealUId = new Guid("4682fa28-8b8d-4ee5-84c3-8c5f059a6714");
			Name = "ChatQueueOperator";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e226146a-5168-4bb4-bfdf-e81e9869c778")) == null) {
				Columns.Add(CreateOperatorColumn());
			}
			if (Columns.FindByUId(new Guid("cf5ad38b-7988-4406-9dd5-b82ae5c97a7b")) == null) {
				Columns.Add(CreateChatQueueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOperatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e226146a-5168-4bb4-bfdf-e81e9869c778"),
				Name = @"Operator",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4682fa28-8b8d-4ee5-84c3-8c5f059a6714"),
				ModifiedInSchemaUId = new Guid("4682fa28-8b8d-4ee5-84c3-8c5f059a6714"),
				CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949")
			};
		}

		protected virtual EntitySchemaColumn CreateChatQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf5ad38b-7988-4406-9dd5-b82ae5c97a7b"),
				Name = @"ChatQueue",
				ReferenceSchemaUId = new Guid("607ebc03-4933-45ff-abe9-ba80df351a8c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4682fa28-8b8d-4ee5-84c3-8c5f059a6714"),
				ModifiedInSchemaUId = new Guid("4682fa28-8b8d-4ee5-84c3-8c5f059a6714"),
				CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChatQueueOperator(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChatQueueOperator_OmnichannelMessagingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChatQueueOperatorSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChatQueueOperatorSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4682fa28-8b8d-4ee5-84c3-8c5f059a6714"));
		}

		#endregion

	}

	#endregion

	#region Class: ChatQueueOperator

	/// <summary>
	/// Chat queue operators.
	/// </summary>
	public class ChatQueueOperator : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ChatQueueOperator(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChatQueueOperator";
		}

		public ChatQueueOperator(ChatQueueOperator source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OperatorId {
			get {
				return GetTypedColumnValue<Guid>("OperatorId");
			}
			set {
				SetColumnValue("OperatorId", value);
				_operator = null;
			}
		}

		/// <exclude/>
		public string OperatorName {
			get {
				return GetTypedColumnValue<string>("OperatorName");
			}
			set {
				SetColumnValue("OperatorName", value);
				if (_operator != null) {
					_operator.Name = value;
				}
			}
		}

		private SysAdminUnit _operator;
		/// <summary>
		/// Operator/Role.
		/// </summary>
		public SysAdminUnit Operator {
			get {
				return _operator ??
					(_operator = LookupColumnEntities.GetEntity("Operator") as SysAdminUnit);
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
			var process = new ChatQueueOperator_OmnichannelMessagingEventsProcess(UserConnection);
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
			return new ChatQueueOperator(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChatQueueOperator_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public partial class ChatQueueOperator_OmnichannelMessagingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ChatQueueOperator
	{

		public ChatQueueOperator_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChatQueueOperator_OmnichannelMessagingEventsProcess";
			SchemaUId = new Guid("4682fa28-8b8d-4ee5-84c3-8c5f059a6714");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4682fa28-8b8d-4ee5-84c3-8c5f059a6714");
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

	#region Class: ChatQueueOperator_OmnichannelMessagingEventsProcess

	/// <exclude/>
	public class ChatQueueOperator_OmnichannelMessagingEventsProcess : ChatQueueOperator_OmnichannelMessagingEventsProcess<ChatQueueOperator>
	{

		public ChatQueueOperator_OmnichannelMessagingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChatQueueOperator_OmnichannelMessagingEventsProcess

	public partial class ChatQueueOperator_OmnichannelMessagingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ChatQueueOperatorEventsProcess

	/// <exclude/>
	public class ChatQueueOperatorEventsProcess : ChatQueueOperator_OmnichannelMessagingEventsProcess
	{

		public ChatQueueOperatorEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

