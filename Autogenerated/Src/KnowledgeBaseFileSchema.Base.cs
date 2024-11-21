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

	#region Class: KnowledgeBaseFileSchema

	/// <exclude/>
	public class KnowledgeBaseFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public KnowledgeBaseFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public KnowledgeBaseFileSchema(KnowledgeBaseFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public KnowledgeBaseFileSchema(KnowledgeBaseFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d7a8038d-63a1-42aa-bf5c-d6e0f8e97b13");
			RealUId = new Guid("d7a8038d-63a1-42aa-bf5c-d6e0f8e97b13");
			Name = "KnowledgeBaseFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateKnowledgeBaseColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected virtual EntitySchemaColumn CreateKnowledgeBaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7b9de0cf-c0b9-4ac5-b635-4d9374a0e9a2"),
				Name = @"KnowledgeBase",
				ReferenceSchemaUId = new Guid("0326868c-ce5e-4934-8f1f-178801bfe6c3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d7a8038d-63a1-42aa-bf5c-d6e0f8e97b13"),
				ModifiedInSchemaUId = new Guid("d7a8038d-63a1-42aa-bf5c-d6e0f8e97b13"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new KnowledgeBaseFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new KnowledgeBaseFile_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new KnowledgeBaseFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new KnowledgeBaseFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d7a8038d-63a1-42aa-bf5c-d6e0f8e97b13"));
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseFile

	/// <summary>
	/// File and link of knowledge base.
	/// </summary>
	public class KnowledgeBaseFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public KnowledgeBaseFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "KnowledgeBaseFile";
		}

		public KnowledgeBaseFile(KnowledgeBaseFile source)
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
			var process = new KnowledgeBaseFile_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("KnowledgeBaseFileDeleted", e);
			Inserting += (s, e) => ThrowEvent("KnowledgeBaseFileInserting", e);
			Updated += (s, e) => ThrowEvent("KnowledgeBaseFileUpdated", e);
			Validating += (s, e) => ThrowEvent("KnowledgeBaseFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new KnowledgeBaseFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: KnowledgeBaseFile_BaseEventsProcess

	/// <exclude/>
	public partial class KnowledgeBaseFile_BaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : KnowledgeBaseFile
	{

		public KnowledgeBaseFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "KnowledgeBaseFile_BaseEventsProcess";
			SchemaUId = new Guid("d7a8038d-63a1-42aa-bf5c-d6e0f8e97b13");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d7a8038d-63a1-42aa-bf5c-d6e0f8e97b13");
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

	#region Class: KnowledgeBaseFile_BaseEventsProcess

	/// <exclude/>
	public class KnowledgeBaseFile_BaseEventsProcess : KnowledgeBaseFile_BaseEventsProcess<KnowledgeBaseFile>
	{

		public KnowledgeBaseFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: KnowledgeBaseFile_BaseEventsProcess

	public partial class KnowledgeBaseFile_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: KnowledgeBaseFileEventsProcess

	/// <exclude/>
	public class KnowledgeBaseFileEventsProcess : KnowledgeBaseFile_BaseEventsProcess
	{

		public KnowledgeBaseFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

