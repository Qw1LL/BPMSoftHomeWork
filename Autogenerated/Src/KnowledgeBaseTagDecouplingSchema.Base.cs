namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: KnowledgeBaseTagDecouplingSchema

	/// <exclude/>
	public class KnowledgeBaseTagDecouplingSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public KnowledgeBaseTagDecouplingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnowledgeBaseTagDecouplingSchema(KnowledgeBaseTagDecouplingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnowledgeBaseTagDecouplingSchema(KnowledgeBaseTagDecouplingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a9330870-42a9-43ed-9138-3ef56cfded77");
			RealUId = new Guid("a9330870-42a9-43ed-9138-3ef56cfded77");
			Name = "KnowledgeBaseTagDecoupling";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("65eb5ae3-5843-4713-afa8-c3d47696c309")) == null) {
				Columns.Add(CreateTagColumn());
			}
			if (Columns.FindByUId(new Guid("d4a60dbd-6440-46ad-8cbe-7975e1bf0ccb")) == null) {
				Columns.Add(CreateKnowledgeBaseColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8b1a4d36-6231-43a8-b2a3-3143b570f710"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("a9330870-42a9-43ed-9138-3ef56cfded77"),
				ModifiedInSchemaUId = new Guid("a9330870-42a9-43ed-9138-3ef56cfded77"),
				CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTagColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("65eb5ae3-5843-4713-afa8-c3d47696c309"),
				Name = @"Tag",
				ReferenceSchemaUId = new Guid("48c6d215-5f38-4967-8482-6b04ba8c0ede"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a9330870-42a9-43ed-9138-3ef56cfded77"),
				ModifiedInSchemaUId = new Guid("a9330870-42a9-43ed-9138-3ef56cfded77"),
				CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f")
			};
		}

		protected virtual EntitySchemaColumn CreateKnowledgeBaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d4a60dbd-6440-46ad-8cbe-7975e1bf0ccb"),
				Name = @"KnowledgeBase",
				ReferenceSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a9330870-42a9-43ed-9138-3ef56cfded77"),
				ModifiedInSchemaUId = new Guid("a9330870-42a9-43ed-9138-3ef56cfded77"),
				CreatedInPackageId = new Guid("eb96f059-97b4-4cc9-b308-10d25043227f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnowledgeBaseTagDecoupling(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnowledgeBaseTagDecoupling_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnowledgeBaseTagDecouplingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnowledgeBaseTagDecouplingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a9330870-42a9-43ed-9138-3ef56cfded77"));
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseTagDecoupling

	/// <summary>
	/// Knowledge base article resolution module.
	/// </summary>
	public class KnowledgeBaseTagDecoupling : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public KnowledgeBaseTagDecoupling(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBaseTagDecoupling";
		}

		public KnowledgeBaseTagDecoupling(KnowledgeBaseTagDecoupling source)
			: base(source) {
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
		public Guid TagId {
			get {
				return GetTypedColumnValue<Guid>("TagId");
			}
			set {
				SetColumnValue("TagId", value);
				_tag = null;
			}
		}

		/// <exclude/>
		public string TagName {
			get {
				return GetTypedColumnValue<string>("TagName");
			}
			set {
				SetColumnValue("TagName", value);
				if (_tag != null) {
					_tag.Name = value;
				}
			}
		}

		private KnowledgeBaseTag _tag;
		/// <summary>
		/// Tag.
		/// </summary>
		public KnowledgeBaseTag Tag {
			get {
				return _tag ??
					(_tag = LookupColumnEntities.GetEntity("Tag") as KnowledgeBaseTag);
			}
		}

		/// <exclude/>
		public Guid KnowledgeBaseId {
			get {
				return GetTypedColumnValue<Guid>("KnowledgeBaseId");
			}
			set {
				SetColumnValue("KnowledgeBaseId", value);
				_knowledgeBase = null;
			}
		}

		/// <exclude/>
		public string KnowledgeBaseName {
			get {
				return GetTypedColumnValue<string>("KnowledgeBaseName");
			}
			set {
				SetColumnValue("KnowledgeBaseName", value);
				if (_knowledgeBase != null) {
					_knowledgeBase.Name = value;
				}
			}
		}

		private KnowledgeBase _knowledgeBase;
		public KnowledgeBase KnowledgeBase {
			get {
				return _knowledgeBase ??
					(_knowledgeBase = LookupColumnEntities.GetEntity("KnowledgeBase") as KnowledgeBase);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnowledgeBaseTagDecoupling_BaseEventsProcess(UserConnection);
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
			return new KnowledgeBaseTagDecoupling(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseTagDecoupling_BaseEventsProcess

	/// <exclude/>
	public partial class KnowledgeBaseTagDecoupling_BaseEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : KnowledgeBaseTagDecoupling
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public KnowledgeBaseTagDecoupling_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnowledgeBaseTagDecoupling_BaseEventsProcess";
			SchemaUId = new Guid("a9330870-42a9-43ed-9138-3ef56cfded77");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a9330870-42a9-43ed-9138-3ef56cfded77");
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

	#region Class: KnowledgeBaseTagDecoupling_BaseEventsProcess

	/// <exclude/>
	public class KnowledgeBaseTagDecoupling_BaseEventsProcess : KnowledgeBaseTagDecoupling_BaseEventsProcess<KnowledgeBaseTagDecoupling>
	{

		public KnowledgeBaseTagDecoupling_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnowledgeBaseTagDecoupling_BaseEventsProcess

	public partial class KnowledgeBaseTagDecoupling_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnowledgeBaseTagDecouplingEventsProcess

	/// <exclude/>
	public class KnowledgeBaseTagDecouplingEventsProcess : KnowledgeBaseTagDecoupling_BaseEventsProcess
	{

		public KnowledgeBaseTagDecouplingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

