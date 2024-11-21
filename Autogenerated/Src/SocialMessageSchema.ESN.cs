namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.ESN;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
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
	using System.Security;
	using System.Text.RegularExpressions;

	#region Class: SocialMessage_ESN_BPMSoftSchema

	/// <exclude/>
	public class SocialMessage_ESN_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialMessage_ESN_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialMessage_ESN_BPMSoftSchema(SocialMessage_ESN_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialMessage_ESN_BPMSoftSchema(SocialMessage_ESN_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			RealUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			Name = "SocialMessage_ESN_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateMessageColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a7a910aa-80d0-4e1a-95cc-79d9f2d291f9")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("b076a792-429d-47db-891d-6621341a0bde")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("bee7652b-3271-4ef4-ae9b-2d52545b33d5")) == null) {
				Columns.Add(CreateLikeCountColumn());
			}
			if (Columns.FindByUId(new Guid("f7957826-183c-4351-9c96-9e68ac436451")) == null) {
				Columns.Add(CreateCommentCountColumn());
			}
			if (Columns.FindByUId(new Guid("8f678ac8-8a72-46e0-929f-bde1a8411997")) == null) {
				Columns.Add(CreateLastActionOnColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a7a910aa-80d0-4e1a-95cc-79d9f2d291f9"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b076a792-429d-47db-891d-6621341a0bde"),
				Name = @"EntityId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("fb47c81f-a125-488b-b2fb-05415b8da84c"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("de240686-3bf2-4759-b6fc-8e859b0b25cc"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateLikeCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("bee7652b-3271-4ef4-ae9b-2d52545b33d5"),
				Name = @"LikeCount",
				CreatedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCommentCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f7957826-183c-4351-9c96-9e68ac436451"),
				Name = @"CommentCount",
				CreatedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLastActionOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("8f678ac8-8a72-46e0-929f-bde1a8411997"),
				Name = @"LastActionOn",
				CreatedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				ModifiedInSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialMessage_ESN_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialMessage_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialMessage_ESN_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialMessage_ESN_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialMessage_ESN_BPMSoft

	/// <summary>
	/// Сообщение/комментарий.
	/// </summary>
	public class SocialMessage_ESN_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialMessage_ESN_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialMessage_ESN_BPMSoft";
		}

		public SocialMessage_ESN_BPMSoft(SocialMessage_ESN_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Схема.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Экземпляр объекта.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// Сообщение/комментарий.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentMessage {
			get {
				return GetTypedColumnValue<string>("ParentMessage");
			}
			set {
				SetColumnValue("ParentMessage", value);
				if (_parent != null) {
					_parent.Message = value;
				}
			}
		}

		private SocialMessage _parent;
		/// <summary>
		/// Родительское сообщение.
		/// </summary>
		public SocialMessage Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SocialMessage);
			}
		}

		/// <summary>
		/// Количество лайков.
		/// </summary>
		public int LikeCount {
			get {
				return GetTypedColumnValue<int>("LikeCount");
			}
			set {
				SetColumnValue("LikeCount", value);
			}
		}

		/// <summary>
		/// Количество комментариев.
		/// </summary>
		public int CommentCount {
			get {
				return GetTypedColumnValue<int>("CommentCount");
			}
			set {
				SetColumnValue("CommentCount", value);
			}
		}

		/// <summary>
		/// Последнее действие.
		/// </summary>
		public DateTime LastActionOn {
			get {
				return GetTypedColumnValue<DateTime>("LastActionOn");
			}
			set {
				SetColumnValue("LastActionOn", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialMessage_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialMessage_ESN_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("SocialMessage_ESN_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("SocialMessage_ESN_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("SocialMessage_ESN_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("SocialMessage_ESN_BPMSoftSaved", e);
			Updated += (s, e) => ThrowEvent("SocialMessage_ESN_BPMSoftUpdated", e);
			Updating += (s, e) => ThrowEvent("SocialMessage_ESN_BPMSoftUpdating", e);
			Validating += (s, e) => ThrowEvent("SocialMessage_ESN_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialMessage_ESN_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialMessage_ESNEventsProcess

	/// <exclude/>
	public partial class SocialMessage_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialMessage_ESN_BPMSoft
	{

		public SocialMessage_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialMessage_ESNEventsProcess";
			SchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _socialMessageCahngeSubProcess;
		public ProcessFlowElement SocialMessageCahngeSubProcess {
			get {
				return _socialMessageCahngeSubProcess ?? (_socialMessageCahngeSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SocialMessageCahngeSubProcess",
					SchemaElementUId = new Guid("ab847359-b95e-4aa0-afaf-0ae9ad8943b3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socialMessageInsertedStartMessage;
		public ProcessFlowElement SocialMessageInsertedStartMessage {
			get {
				return _socialMessageInsertedStartMessage ?? (_socialMessageInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialMessageInsertedStartMessage",
					SchemaElementUId = new Guid("2271869d-efb9-445c-b054-c0fc0aed56b0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socialMessageDeletedStartMessage;
		public ProcessFlowElement SocialMessageDeletedStartMessage {
			get {
				return _socialMessageDeletedStartMessage ?? (_socialMessageDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialMessageDeletedStartMessage",
					SchemaElementUId = new Guid("5262f53d-a9d8-432f-b36e-9ae9c7f85cd6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateParentCommentCount;
		public ProcessScriptTask UpdateParentCommentCount {
			get {
				return _updateParentCommentCount ?? (_updateParentCommentCount = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateParentCommentCount",
					SchemaElementUId = new Guid("1ee35785-a433-4e93-9211-3e1049fc1a84"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateParentCommentCountExecute,
				});
			}
		}

		private ProcessFlowElement _socialMessageUpdating;
		public ProcessFlowElement SocialMessageUpdating {
			get {
				return _socialMessageUpdating ?? (_socialMessageUpdating = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialMessageUpdating",
					SchemaElementUId = new Guid("a6e1fc59-4314-4bbc-8d03-6c2fb5aff1bc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateParentLastActionOn;
		public ProcessScriptTask UpdateParentLastActionOn {
			get {
				return _updateParentLastActionOn ?? (_updateParentLastActionOn = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateParentLastActionOn",
					SchemaElementUId = new Guid("4cf3bd6a-337a-4f70-b7a7-ce0d06c6c9b8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateParentLastActionOnExecute,
				});
			}
		}

		private ProcessScriptTask _sendSocialMessage;
		public ProcessScriptTask SendSocialMessage {
			get {
				return _sendSocialMessage ?? (_sendSocialMessage = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendSocialMessage",
					SchemaElementUId = new Guid("8162e0b0-c9b6-4a60-8b0c-8992a1480435"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SendSocialMessageExecute,
				});
			}
		}

		private ProcessScriptTask _subscribeUser;
		public ProcessScriptTask SubscribeUser {
			get {
				return _subscribeUser ?? (_subscribeUser = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SubscribeUser",
					SchemaElementUId = new Guid("83d25c93-9688-4bb8-bce9-9c89186c69bf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SubscribeUserExecute,
				});
			}
		}

		private ProcessScriptTask _sendUpdateMessage;
		public ProcessScriptTask SendUpdateMessage {
			get {
				return _sendUpdateMessage ?? (_sendUpdateMessage = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendUpdateMessage",
					SchemaElementUId = new Guid("2cbc96bf-9efc-4335-8572-6b8c9087b2b4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SendUpdateMessageExecute,
				});
			}
		}

		private ProcessFlowElement _socialMessageUpdated;
		public ProcessFlowElement SocialMessageUpdated {
			get {
				return _socialMessageUpdated ?? (_socialMessageUpdated = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialMessageUpdated",
					SchemaElementUId = new Guid("1dd10180-c2b1-49c8-ace9-4d4c445ac45d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sendDeleteSocialMessage;
		public ProcessScriptTask SendDeleteSocialMessage {
			get {
				return _sendDeleteSocialMessage ?? (_sendDeleteSocialMessage = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SendDeleteSocialMessage",
					SchemaElementUId = new Guid("d3d46d69-9bf0-4afe-934a-be0ec174426e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SendDeleteSocialMessageExecute,
				});
			}
		}

		private ProcessFlowElement _socialMessageDeleting;
		public ProcessFlowElement SocialMessageDeleting {
			get {
				return _socialMessageDeleting ?? (_socialMessageDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialMessageDeleting",
					SchemaElementUId = new Guid("cd83857b-fd76-4bfa-b9d9-3c77d8c576bc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkInsertRightsScriptTask;
		public ProcessScriptTask CheckInsertRightsScriptTask {
			get {
				return _checkInsertRightsScriptTask ?? (_checkInsertRightsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckInsertRightsScriptTask",
					SchemaElementUId = new Guid("a5a05e18-c40a-4544-8cf5-040e66935e32"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckInsertRightsScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _socialMessageInserting;
		public ProcessFlowElement SocialMessageInserting {
			get {
				return _socialMessageInserting ?? (_socialMessageInserting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialMessageInserting",
					SchemaElementUId = new Guid("7f9ab86b-e8d8-405e-9adf-b2320d788a6d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _deleteLinkPreviewInfoScriptTask;
		public ProcessScriptTask DeleteLinkPreviewInfoScriptTask {
			get {
				return _deleteLinkPreviewInfoScriptTask ?? (_deleteLinkPreviewInfoScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DeleteLinkPreviewInfoScriptTask",
					SchemaElementUId = new Guid("7dd0f3b8-8281-40ef-9cbd-61513be24f03"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = DeleteLinkPreviewInfoScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _addLinkPreviewInfoScriptTask;
		public ProcessScriptTask AddLinkPreviewInfoScriptTask {
			get {
				return _addLinkPreviewInfoScriptTask ?? (_addLinkPreviewInfoScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "AddLinkPreviewInfoScriptTask",
					SchemaElementUId = new Guid("4c8627ed-2007-4e3f-b713-a5eb66417e13"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = AddLinkPreviewInfoScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _socialMessageSavedStartMessage;
		public ProcessFlowElement SocialMessageSavedStartMessage {
			get {
				return _socialMessageSavedStartMessage ?? (_socialMessageSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialMessageSavedStartMessage",
					SchemaElementUId = new Guid("716269d4-dc7e-4211-a19b-41b3e4c4f9af"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _deleteLinkPreviewInfoIfUpdatedScriptTask;
		public ProcessScriptTask DeleteLinkPreviewInfoIfUpdatedScriptTask {
			get {
				return _deleteLinkPreviewInfoIfUpdatedScriptTask ?? (_deleteLinkPreviewInfoIfUpdatedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DeleteLinkPreviewInfoIfUpdatedScriptTask",
					SchemaElementUId = new Guid("3c6ac282-094d-4c64-a738-0da1926afd18"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = DeleteLinkPreviewInfoIfUpdatedScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_636cba8936dc48d2b329009662a6745f;
		public ProcessScriptTask ScriptTask3_636cba8936dc48d2b329009662a6745f {
			get {
				return _scriptTask3_636cba8936dc48d2b329009662a6745f ?? (_scriptTask3_636cba8936dc48d2b329009662a6745f = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_636cba8936dc48d2b329009662a6745f",
					SchemaElementUId = new Guid("636cba89-36dc-48d2-b329-009662a6745f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_636cba8936dc48d2b329009662a6745fExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SocialMessageCahngeSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageCahngeSubProcess };
			FlowElements[SocialMessageInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageInsertedStartMessage };
			FlowElements[SocialMessageDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageDeletedStartMessage };
			FlowElements[UpdateParentCommentCount.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateParentCommentCount };
			FlowElements[SocialMessageUpdating.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageUpdating };
			FlowElements[UpdateParentLastActionOn.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateParentLastActionOn };
			FlowElements[SendSocialMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SendSocialMessage };
			FlowElements[SubscribeUser.SchemaElementUId] = new Collection<ProcessFlowElement> { SubscribeUser };
			FlowElements[SendUpdateMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SendUpdateMessage };
			FlowElements[SocialMessageUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageUpdated };
			FlowElements[SendDeleteSocialMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SendDeleteSocialMessage };
			FlowElements[SocialMessageDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageDeleting };
			FlowElements[CheckInsertRightsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckInsertRightsScriptTask };
			FlowElements[SocialMessageInserting.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageInserting };
			FlowElements[DeleteLinkPreviewInfoScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { DeleteLinkPreviewInfoScriptTask };
			FlowElements[AddLinkPreviewInfoScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AddLinkPreviewInfoScriptTask };
			FlowElements[SocialMessageSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialMessageSavedStartMessage };
			FlowElements[DeleteLinkPreviewInfoIfUpdatedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { DeleteLinkPreviewInfoIfUpdatedScriptTask };
			FlowElements[ScriptTask3_636cba8936dc48d2b329009662a6745f.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_636cba8936dc48d2b329009662a6745f };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SocialMessageCahngeSubProcess":
						break;
					case "SocialMessageInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("UpdateParentCommentCount");
						e.Context.QueueTasks.Enqueue("UpdateParentLastActionOn");
						e.Context.QueueTasks.Enqueue("SendSocialMessage");
						e.Context.QueueTasks.Enqueue("SubscribeUser");
						break;
					case "SocialMessageDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("DeleteLinkPreviewInfoScriptTask");
						break;
					case "UpdateParentCommentCount":
						break;
					case "SocialMessageUpdating":
						e.Context.QueueTasks.Enqueue("UpdateParentLastActionOn");
						break;
					case "UpdateParentLastActionOn":
						break;
					case "SendSocialMessage":
						break;
					case "SubscribeUser":
						break;
					case "SendUpdateMessage":
						e.Context.QueueTasks.Enqueue("DeleteLinkPreviewInfoIfUpdatedScriptTask");
						break;
					case "SocialMessageUpdated":
						e.Context.QueueTasks.Enqueue("SendUpdateMessage");
						break;
					case "SendDeleteSocialMessage":
						break;
					case "SocialMessageDeleting":
						e.Context.QueueTasks.Enqueue("SendDeleteSocialMessage");
						break;
					case "CheckInsertRightsScriptTask":
						break;
					case "SocialMessageInserting":
						e.Context.QueueTasks.Enqueue("CheckInsertRightsScriptTask");
						break;
					case "DeleteLinkPreviewInfoScriptTask":
						e.Context.QueueTasks.Enqueue("UpdateParentCommentCount");
						break;
					case "AddLinkPreviewInfoScriptTask":
						break;
					case "SocialMessageSavedStartMessage":
						e.Context.QueueTasks.Enqueue("AddLinkPreviewInfoScriptTask");
						e.Context.QueueTasks.Enqueue("ScriptTask3_636cba8936dc48d2b329009662a6745f");
						break;
					case "DeleteLinkPreviewInfoIfUpdatedScriptTask":
						break;
					case "ScriptTask3_636cba8936dc48d2b329009662a6745f":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SocialMessageInsertedStartMessage");
			ActivatedEventElements.Add("SocialMessageDeletedStartMessage");
			ActivatedEventElements.Add("SocialMessageUpdating");
			ActivatedEventElements.Add("SocialMessageUpdated");
			ActivatedEventElements.Add("SocialMessageDeleting");
			ActivatedEventElements.Add("SocialMessageInserting");
			ActivatedEventElements.Add("SocialMessageSavedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SocialMessageCahngeSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SocialMessageInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialMessageInsertedStartMessage";
					result = SocialMessageInsertedStartMessage.Execute(context);
					break;
				case "SocialMessageDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialMessageDeletedStartMessage";
					result = SocialMessageDeletedStartMessage.Execute(context);
					break;
				case "UpdateParentCommentCount":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateParentCommentCount";
					result = UpdateParentCommentCount.Execute(context, UpdateParentCommentCountExecute);
					break;
				case "SocialMessageUpdating":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialMessageUpdating";
					result = SocialMessageUpdating.Execute(context);
					break;
				case "UpdateParentLastActionOn":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateParentLastActionOn";
					result = UpdateParentLastActionOn.Execute(context, UpdateParentLastActionOnExecute);
					break;
				case "SendSocialMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SendSocialMessage";
					result = SendSocialMessage.Execute(context, SendSocialMessageExecute);
					break;
				case "SubscribeUser":
					context.QueueTasks.Dequeue();
					context.SenderName = "SubscribeUser";
					result = SubscribeUser.Execute(context, SubscribeUserExecute);
					break;
				case "SendUpdateMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SendUpdateMessage";
					result = SendUpdateMessage.Execute(context, SendUpdateMessageExecute);
					break;
				case "SocialMessageUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialMessageUpdated";
					result = SocialMessageUpdated.Execute(context);
					break;
				case "SendDeleteSocialMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SendDeleteSocialMessage";
					result = SendDeleteSocialMessage.Execute(context, SendDeleteSocialMessageExecute);
					break;
				case "SocialMessageDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialMessageDeleting";
					result = SocialMessageDeleting.Execute(context);
					break;
				case "CheckInsertRightsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckInsertRightsScriptTask";
					result = CheckInsertRightsScriptTask.Execute(context, CheckInsertRightsScriptTaskExecute);
					break;
				case "SocialMessageInserting":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialMessageInserting";
					result = SocialMessageInserting.Execute(context);
					break;
				case "DeleteLinkPreviewInfoScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "DeleteLinkPreviewInfoScriptTask";
					result = DeleteLinkPreviewInfoScriptTask.Execute(context, DeleteLinkPreviewInfoScriptTaskExecute);
					break;
				case "AddLinkPreviewInfoScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "AddLinkPreviewInfoScriptTask";
					result = AddLinkPreviewInfoScriptTask.Execute(context, AddLinkPreviewInfoScriptTaskExecute);
					break;
				case "SocialMessageSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialMessageSavedStartMessage";
					result = SocialMessageSavedStartMessage.Execute(context);
					break;
				case "DeleteLinkPreviewInfoIfUpdatedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "DeleteLinkPreviewInfoIfUpdatedScriptTask";
					result = DeleteLinkPreviewInfoIfUpdatedScriptTask.Execute(context, DeleteLinkPreviewInfoIfUpdatedScriptTaskExecute);
					break;
				case "ScriptTask3_636cba8936dc48d2b329009662a6745f":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_636cba8936dc48d2b329009662a6745f";
					result = ScriptTask3_636cba8936dc48d2b329009662a6745f.Execute(context, ScriptTask3_636cba8936dc48d2b329009662a6745fExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool UpdateParentCommentCountExecute(ProcessExecutingContext context) {
			var parentId = Entity.GetTypedColumnValue<Guid>("ParentId");
			if (parentId != Guid.Empty) {
				var select =(Select)new Select(UserConnection)
					.Column(Func.Count(Column.Asterisk()))
					.From("SocialMessage")
					.Where("ParentId").IsEqual(Column.Parameter(parentId));
			
				using (var executor = UserConnection.EnsureDBConnection()) {
					var commentCount = select.ExecuteScalar<Int32>(executor);
					DateTime localDate = DateTime.UtcNow;
					var update = (Update)new Update(UserConnection, "SocialMessage")
						.Set("CommentCount", Column.Parameter(commentCount))
						.Set("ModifiedOn", Column.Parameter(localDate))
						.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
						.Where("Id").IsEqual(Column.Parameter(parentId));
					update.Execute(executor);
			
					//SendUpdateDeleteSocialMessage(false, commentCount);
				}
			}
			return true;
		}

		public virtual bool UpdateParentLastActionOnExecute(ProcessExecutingContext context) {
			var parentId = Entity.GetTypedColumnValue<Guid>("ParentId");
			if (parentId != Guid.Empty) {
				using (var executor = UserConnection.EnsureDBConnection()) {
					var update = (Update)new Update(UserConnection, "SocialMessage")
						.Set("LastActionOn", Column.Parameter(DateTime.UtcNow))
						.Where("Id").IsEqual(Column.Parameter(parentId));
					update.Execute(executor);
				}
			}
			return true;
		}

		public virtual bool SendSocialMessageExecute(ProcessExecutingContext context) {
			SendUpdateDeleteSocialMessage("insert");
			return true;
		}

		public virtual bool SubscribeUserExecute(ProcessExecutingContext context) {
			var sysAdminUnitId = UserConnection.CurrentUser.Id;
			var entityId = Entity.GetTypedColumnValue<Guid>("EntityId");
			var parentId = Entity.GetTypedColumnValue<Guid>("ParentId");
			var entitySchemaId = Entity.GetTypedColumnValue<Guid>("EntitySchemaUId");
			if (entityId == Guid.Empty && parentId != Guid.Empty) {
				var select = (Select)new Select(UserConnection)
					.Column("EntityId")
					.From("SocialMessage")
					.Where("Id").IsEqual(Column.Parameter(parentId));
				entityId = select.ExecuteScalar<Guid>();
			}
			var selectPostSubscribers = (Select)new Select(UserConnection)
				.Column("Id")
				.From("SocialSubscription")
				.Where("SysAdminUnitId").IsEqual(Column.Parameter(sysAdminUnitId))
					.And("EntityId").IsEqual(Column.Parameter(entityId));
			var socialSubscriptionId = selectPostSubscribers.ExecuteScalar<Guid>();
			if (socialSubscriptionId == Guid.Empty) {
				var schemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
				var subscriptionSchema = schemaManager.GetInstanceByName("SocialSubscription");
				var subscription = subscriptionSchema.CreateEntity(UserConnection) as SocialSubscription;
				subscription.SetDefColumnValues();
				subscription.SysAdminUnitId = sysAdminUnitId;
				subscription.EntityId = entityId;
				subscription.CanUnsubscribe = true;
				subscription.EntitySchemaUId = entitySchemaId;
				subscription.UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic;
				subscription.Save();
			}
			return true;
		}

		public virtual bool SendUpdateMessageExecute(ProcessExecutingContext context) {
			SendUpdateDeleteSocialMessage("update");
			return true;
		}

		public virtual bool SendDeleteSocialMessageExecute(ProcessExecutingContext context) {
			SendUpdateDeleteSocialMessage("delete");
			PublishDeleteNotificationsMessage();
			return true;
		}

		public virtual bool CheckInsertRightsScriptTaskExecute(ProcessExecutingContext context) {
			CheckInsertRights();
			return true;
		}

		public virtual bool DeleteLinkPreviewInfoScriptTaskExecute(ProcessExecutingContext context) {
			DeleteLinkPreviewInfo();
			return true;
		}

		public virtual bool AddLinkPreviewInfoScriptTaskExecute(ProcessExecutingContext context) {
			AddLinkPreviewInfo();
			return true;
		}

		public virtual bool DeleteLinkPreviewInfoIfUpdatedScriptTaskExecute(ProcessExecutingContext context) {
			DeleteLinkPreviewInfoIfUpdated();
			return true;
		}

		public virtual bool ScriptTask3_636cba8936dc48d2b329009662a6745fExecute(ProcessExecutingContext context) {
			MentionUsers();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SocialMessage_ESN_BPMSoftInserted":
							if (ActivatedEventElements.Contains("SocialMessageInsertedStartMessage")) {
							context.QueueTasks.Enqueue("SocialMessageInsertedStartMessage");
						}
						break;
					case "SocialMessage_ESN_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("SocialMessageDeletedStartMessage")) {
							context.QueueTasks.Enqueue("SocialMessageDeletedStartMessage");
						}
						break;
					case "SocialMessage_ESN_BPMSoftUpdating":
							if (ActivatedEventElements.Contains("SocialMessageUpdating")) {
							context.QueueTasks.Enqueue("SocialMessageUpdating");
						}
						break;
					case "SocialMessage_ESN_BPMSoftUpdated":
							if (ActivatedEventElements.Contains("SocialMessageUpdated")) {
							context.QueueTasks.Enqueue("SocialMessageUpdated");
						}
						break;
					case "SocialMessage_ESN_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("SocialMessageDeleting")) {
							context.QueueTasks.Enqueue("SocialMessageDeleting");
						}
						break;
					case "SocialMessage_ESN_BPMSoftInserting":
							if (ActivatedEventElements.Contains("SocialMessageInserting")) {
							context.QueueTasks.Enqueue("SocialMessageInserting");
						}
						break;
					case "SocialMessage_ESN_BPMSoftSaved":
							if (ActivatedEventElements.Contains("SocialMessageSavedStartMessage")) {
							context.QueueTasks.Enqueue("SocialMessageSavedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SocialMessage_ESNEventsProcess

	/// <exclude/>
	public class SocialMessage_ESNEventsProcess : SocialMessage_ESNEventsProcess<SocialMessage_ESN_BPMSoft>
	{

		public SocialMessage_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

