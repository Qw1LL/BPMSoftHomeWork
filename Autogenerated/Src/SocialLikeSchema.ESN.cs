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

	#region Class: SocialLikeSchema

	/// <exclude/>
	public class SocialLikeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialLikeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialLikeSchema(SocialLikeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialLikeSchema(SocialLikeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			RealUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			Name = "SocialLike";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ae31dfb0-03d2-4994-8630-244d517283d7")) == null) {
				Columns.Add(CreateUserColumn());
			}
			if (Columns.FindByUId(new Guid("8c66404a-3763-417b-89c6-e7d56aa89cd3")) == null) {
				Columns.Add(CreateSocialMessageColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ae31dfb0-03d2-4994-8630-244d517283d7"),
				Name = @"User",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb"),
				ModifiedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateSocialMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8c66404a-3763-417b-89c6-e7d56aa89cd3"),
				Name = @"SocialMessage",
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb"),
				ModifiedInSchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialLike(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialLike_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialLikeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialLikeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialLike

	/// <summary>
	/// Social like.
	/// </summary>
	public class SocialLike : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialLike(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialLike";
		}

		public SocialLike(SocialLike source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid UserId {
			get {
				return GetTypedColumnValue<Guid>("UserId");
			}
			set {
				SetColumnValue("UserId", value);
				_user = null;
			}
		}

		/// <exclude/>
		public string UserName {
			get {
				return GetTypedColumnValue<string>("UserName");
			}
			set {
				SetColumnValue("UserName", value);
				if (_user != null) {
					_user.Name = value;
				}
			}
		}

		private SysAdminUnit _user;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit User {
			get {
				return _user ??
					(_user = LookupColumnEntities.GetEntity("User") as SysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid SocialMessageId {
			get {
				return GetTypedColumnValue<Guid>("SocialMessageId");
			}
			set {
				SetColumnValue("SocialMessageId", value);
				_socialMessage = null;
			}
		}

		/// <exclude/>
		public string SocialMessageMessage {
			get {
				return GetTypedColumnValue<string>("SocialMessageMessage");
			}
			set {
				SetColumnValue("SocialMessageMessage", value);
				if (_socialMessage != null) {
					_socialMessage.Message = value;
				}
			}
		}

		private SocialMessage _socialMessage;
		/// <summary>
		/// Message.
		/// </summary>
		public SocialMessage SocialMessage {
			get {
				return _socialMessage ??
					(_socialMessage = LookupColumnEntities.GetEntity("SocialMessage") as SocialMessage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialLike_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialLikeDeleted", e);
			Inserted += (s, e) => ThrowEvent("SocialLikeInserted", e);
			Inserting += (s, e) => ThrowEvent("SocialLikeInserting", e);
			Validating += (s, e) => ThrowEvent("SocialLikeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialLike(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialLike_ESNEventsProcess

	/// <exclude/>
	public partial class SocialLike_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialLike
	{

		public SocialLike_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialLike_ESNEventsProcess";
			SchemaUId = new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("93f0b6d7-cabb-47f4-b3eb-20b5b7bf78bb");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _likeChangedSubProcess;
		public ProcessFlowElement LikeChangedSubProcess {
			get {
				return _likeChangedSubProcess ?? (_likeChangedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "LikeChangedSubProcess",
					SchemaElementUId = new Guid("48621cac-6f15-4c88-a8df-6b1cb9fb5a90"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socialLikeInsertedStartMessage;
		public ProcessFlowElement SocialLikeInsertedStartMessage {
			get {
				return _socialLikeInsertedStartMessage ?? (_socialLikeInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialLikeInsertedStartMessage",
					SchemaElementUId = new Guid("d467955c-2858-4de2-894f-f9f31543c6d7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socialLikeDeletedStartMessage;
		public ProcessFlowElement SocialLikeDeletedStartMessage {
			get {
				return _socialLikeDeletedStartMessage ?? (_socialLikeDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialLikeDeletedStartMessage",
					SchemaElementUId = new Guid("cc95a603-938c-4a5c-be68-c1d00c730da8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateParentLikeCount;
		public ProcessScriptTask UpdateParentLikeCount {
			get {
				return _updateParentLikeCount ?? (_updateParentLikeCount = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateParentLikeCount",
					SchemaElementUId = new Guid("9d95139d-642f-41fa-b7f5-f4de6f48565e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateParentLikeCountExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("03002591-9586-470c-b024-027814138886"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socialLikeInsertingStartMessage;
		public ProcessFlowElement SocialLikeInsertingStartMessage {
			get {
				return _socialLikeInsertingStartMessage ?? (_socialLikeInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialLikeInsertingStartMessage",
					SchemaElementUId = new Guid("e74e8850-b3b9-4ae0-9d50-86f314a86948"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkUserLikes;
		public ProcessScriptTask CheckUserLikes {
			get {
				return _checkUserLikes ?? (_checkUserLikes = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckUserLikes",
					SchemaElementUId = new Guid("e0ff3dd8-0aa1-4a73-83d5-4b55d5a2025d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckUserLikesExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[LikeChangedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { LikeChangedSubProcess };
			FlowElements[SocialLikeInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialLikeInsertedStartMessage };
			FlowElements[SocialLikeDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialLikeDeletedStartMessage };
			FlowElements[UpdateParentLikeCount.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateParentLikeCount };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SocialLikeInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialLikeInsertingStartMessage };
			FlowElements[CheckUserLikes.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckUserLikes };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "LikeChangedSubProcess":
						break;
					case "SocialLikeInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("UpdateParentLikeCount");
						break;
					case "SocialLikeDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("UpdateParentLikeCount");
						break;
					case "UpdateParentLikeCount":
						break;
					case "EventSubProcess1":
						break;
					case "SocialLikeInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckUserLikes");
						break;
					case "CheckUserLikes":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SocialLikeInsertedStartMessage");
			ActivatedEventElements.Add("SocialLikeDeletedStartMessage");
			ActivatedEventElements.Add("SocialLikeInsertingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "LikeChangedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SocialLikeInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialLikeInsertedStartMessage";
					result = SocialLikeInsertedStartMessage.Execute(context);
					break;
				case "SocialLikeDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialLikeDeletedStartMessage";
					result = SocialLikeDeletedStartMessage.Execute(context);
					break;
				case "UpdateParentLikeCount":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateParentLikeCount";
					result = UpdateParentLikeCount.Execute(context, UpdateParentLikeCountExecute);
					break;
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "SocialLikeInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialLikeInsertingStartMessage";
					result = SocialLikeInsertingStartMessage.Execute(context);
					break;
				case "CheckUserLikes":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckUserLikes";
					result = CheckUserLikes.Execute(context, CheckUserLikesExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool UpdateParentLikeCountExecute(ProcessExecutingContext context) {
			var socialMessageId = Entity.GetTypedColumnValue<Guid>("SocialMessageId");
			var select =(Select)new Select(UserConnection)
				.Column(Func.Count(Column.Asterisk()))
				.From("SocialLike")
				.Where("SocialMessageId").IsEqual(Column.Parameter(socialMessageId));
			
			using (var executor = UserConnection.EnsureDBConnection()) {
				var likeCount = select.ExecuteScalar<Int32>(executor);
				DateTime localDate = DateTime.UtcNow;
				var update = (Update)new Update(UserConnection, "SocialMessage")
					.Set("LikeCount", Column.Parameter(likeCount))
					.Set("ModifiedOn", Column.Parameter(localDate))
					.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
					.Where("Id").IsEqual(Column.Parameter(socialMessageId));
				update.Execute(executor);
			}
			return true;
		}

		public virtual bool CheckUserLikesExecute(ProcessExecutingContext context) {
			var socialMessageId = Entity.GetTypedColumnValue<Guid>("SocialMessageId");
			var userId = Entity.GetTypedColumnValue<Guid>("UserId");
			var select =(Select)new Select(UserConnection)
				.Column(Func.Count(Column.Asterisk()))
				.From("SocialLike")
				.Where("SocialMessageId").IsEqual(Column.Parameter(socialMessageId))
				.And("UserId").IsEqual(Column.Parameter(userId));
			
			using (var executor = UserConnection.EnsureDBConnection()) {
				var likeCount = select.ExecuteScalar<Int32>(executor);
				if (likeCount != 0) {
					((BPMSoft.Core.Entities.EntityBeforeEventArgs)(context.ThrowEventArgs)).IsCanceled = true;
				}
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SocialLikeInserted":
							if (ActivatedEventElements.Contains("SocialLikeInsertedStartMessage")) {
							context.QueueTasks.Enqueue("SocialLikeInsertedStartMessage");
						}
						break;
					case "SocialLikeDeleted":
							if (ActivatedEventElements.Contains("SocialLikeDeletedStartMessage")) {
							context.QueueTasks.Enqueue("SocialLikeDeletedStartMessage");
						}
						break;
					case "SocialLikeInserting":
							if (ActivatedEventElements.Contains("SocialLikeInsertingStartMessage")) {
							context.QueueTasks.Enqueue("SocialLikeInsertingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SocialLike_ESNEventsProcess

	/// <exclude/>
	public class SocialLike_ESNEventsProcess : SocialLike_ESNEventsProcess<SocialLike>
	{

		public SocialLike_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialLike_ESNEventsProcess

	public partial class SocialLike_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialLikeEventsProcess

	/// <exclude/>
	public class SocialLikeEventsProcess : SocialLike_ESNEventsProcess
	{

		public SocialLikeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

