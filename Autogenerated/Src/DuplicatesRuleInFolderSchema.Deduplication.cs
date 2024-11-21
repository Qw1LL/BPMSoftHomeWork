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

	#region Class: DuplicatesRuleInFolderSchema

	/// <exclude/>
	public class DuplicatesRuleInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public DuplicatesRuleInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DuplicatesRuleInFolderSchema(DuplicatesRuleInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DuplicatesRuleInFolderSchema(DuplicatesRuleInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("644c8bd1-d215-4710-861a-e554ec29dd31");
			RealUId = new Guid("644c8bd1-d215-4710-861a-e554ec29dd31");
			Name = "DuplicatesRuleInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("642e1b93-32fe-4cca-aefe-e71452bbfc69");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e5692bbb-7ddd-411d-8f70-d5b26741be87")) == null) {
				Columns.Add(CreateDuplicatesRuleColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("470793e7-c562-479e-ba33-d6c22808c8d2");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("644c8bd1-d215-4710-861a-e554ec29dd31");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDuplicatesRuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e5692bbb-7ddd-411d-8f70-d5b26741be87"),
				Name = @"DuplicatesRule",
				ReferenceSchemaUId = new Guid("f9838ef2-f0f9-448c-b968-e36103b33919"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("644c8bd1-d215-4710-861a-e554ec29dd31"),
				ModifiedInSchemaUId = new Guid("644c8bd1-d215-4710-861a-e554ec29dd31"),
				CreatedInPackageId = new Guid("642e1b93-32fe-4cca-aefe-e71452bbfc69")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DuplicatesRuleInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DuplicatesRuleInFolder_DeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DuplicatesRuleInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DuplicatesRuleInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("644c8bd1-d215-4710-861a-e554ec29dd31"));
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesRuleInFolder

	/// <summary>
	/// "Duplicates rule" in folder.
	/// </summary>
	public class DuplicatesRuleInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public DuplicatesRuleInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DuplicatesRuleInFolder";
		}

		public DuplicatesRuleInFolder(DuplicatesRuleInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DuplicatesRuleId {
			get {
				return GetTypedColumnValue<Guid>("DuplicatesRuleId");
			}
			set {
				SetColumnValue("DuplicatesRuleId", value);
				_duplicatesRule = null;
			}
		}

		/// <exclude/>
		public string DuplicatesRuleName {
			get {
				return GetTypedColumnValue<string>("DuplicatesRuleName");
			}
			set {
				SetColumnValue("DuplicatesRuleName", value);
				if (_duplicatesRule != null) {
					_duplicatesRule.Name = value;
				}
			}
		}

		private DuplicatesRule _duplicatesRule;
		/// <summary>
		/// Duplicate rule.
		/// </summary>
		public DuplicatesRule DuplicatesRule {
			get {
				return _duplicatesRule ??
					(_duplicatesRule = LookupColumnEntities.GetEntity("DuplicatesRule") as DuplicatesRule);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DuplicatesRuleInFolder_DeduplicationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DuplicatesRuleInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("DuplicatesRuleInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DuplicatesRuleInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesRuleInFolder_DeduplicationEventsProcess

	/// <exclude/>
	public partial class DuplicatesRuleInFolder_DeduplicationEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : DuplicatesRuleInFolder
	{

		public DuplicatesRuleInFolder_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DuplicatesRuleInFolder_DeduplicationEventsProcess";
			SchemaUId = new Guid("644c8bd1-d215-4710-861a-e554ec29dd31");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("644c8bd1-d215-4710-861a-e554ec29dd31");
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

	#region Class: DuplicatesRuleInFolder_DeduplicationEventsProcess

	/// <exclude/>
	public class DuplicatesRuleInFolder_DeduplicationEventsProcess : DuplicatesRuleInFolder_DeduplicationEventsProcess<DuplicatesRuleInFolder>
	{

		public DuplicatesRuleInFolder_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DuplicatesRuleInFolder_DeduplicationEventsProcess

	public partial class DuplicatesRuleInFolder_DeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DuplicatesRuleInFolderEventsProcess

	/// <exclude/>
	public class DuplicatesRuleInFolderEventsProcess : DuplicatesRuleInFolder_DeduplicationEventsProcess
	{

		public DuplicatesRuleInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

