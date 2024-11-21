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

	#region Class: KnowledgeBaseInFolderSchema

	/// <exclude/>
	public class KnowledgeBaseInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public KnowledgeBaseInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnowledgeBaseInFolderSchema(KnowledgeBaseInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnowledgeBaseInFolderSchema(KnowledgeBaseInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d7811d81-e4fe-4d53-a49f-7873674f9d00");
			RealUId = new Guid("d7811d81-e4fe-4d53-a49f-7873674f9d00");
			Name = "KnowledgeBaseInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("67eb8fb5-600f-4109-8f7d-d52b6b0303e8")) == null) {
				Columns.Add(CreateKnowledgeBaseColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("54157b05-88d4-46c0-aa54-effc7c79cb86");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("d7811d81-e4fe-4d53-a49f-7873674f9d00");
			return column;
		}

		protected virtual EntitySchemaColumn CreateKnowledgeBaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("67eb8fb5-600f-4109-8f7d-d52b6b0303e8"),
				Name = @"KnowledgeBase",
				ReferenceSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d7811d81-e4fe-4d53-a49f-7873674f9d00"),
				ModifiedInSchemaUId = new Guid("d7811d81-e4fe-4d53-a49f-7873674f9d00"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnowledgeBaseInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnowledgeBaseInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnowledgeBaseInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnowledgeBaseInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d7811d81-e4fe-4d53-a49f-7873674f9d00"));
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseInFolder

	/// <summary>
	/// Knowledge base in folder.
	/// </summary>
	public class KnowledgeBaseInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public KnowledgeBaseInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBaseInFolder";
		}

		public KnowledgeBaseInFolder(KnowledgeBaseInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// <summary>
		/// Knowledge base.
		/// </summary>
		public KnowledgeBase KnowledgeBase {
			get {
				return _knowledgeBase ??
					(_knowledgeBase = LookupColumnEntities.GetEntity("KnowledgeBase") as KnowledgeBase);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new KnowledgeBaseInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("KnowledgeBaseInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("KnowledgeBaseInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("KnowledgeBaseInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("KnowledgeBaseInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("KnowledgeBaseInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("KnowledgeBaseInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("KnowledgeBaseInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new KnowledgeBaseInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class KnowledgeBaseInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : KnowledgeBaseInFolder
	{

		public KnowledgeBaseInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnowledgeBaseInFolder_BaseEventsProcess";
			SchemaUId = new Guid("d7811d81-e4fe-4d53-a49f-7873674f9d00");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d7811d81-e4fe-4d53-a49f-7873674f9d00");
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

	#region Class: KnowledgeBaseInFolder_BaseEventsProcess

	/// <exclude/>
	public class KnowledgeBaseInFolder_BaseEventsProcess : KnowledgeBaseInFolder_BaseEventsProcess<KnowledgeBaseInFolder>
	{

		public KnowledgeBaseInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnowledgeBaseInFolder_BaseEventsProcess

	public partial class KnowledgeBaseInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnowledgeBaseInFolderEventsProcess

	/// <exclude/>
	public class KnowledgeBaseInFolderEventsProcess : KnowledgeBaseInFolder_BaseEventsProcess
	{

		public KnowledgeBaseInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

