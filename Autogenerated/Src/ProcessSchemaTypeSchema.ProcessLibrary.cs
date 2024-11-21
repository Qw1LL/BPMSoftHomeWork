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

	#region Class: ProcessSchemaTypeSchema

	/// <exclude/>
	public class ProcessSchemaTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public ProcessSchemaTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ProcessSchemaTypeSchema(ProcessSchemaTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ProcessSchemaTypeSchema(ProcessSchemaTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			RealUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			Name = "ProcessSchemaType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			column.CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ProcessSchemaType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ProcessSchemaType_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ProcessSchemaTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ProcessSchemaTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a"));
		}

		#endregion

	}

	#endregion

	#region Class: ProcessSchemaType

	/// <summary>
	/// Process schema type.
	/// </summary>
	public class ProcessSchemaType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public ProcessSchemaType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProcessSchemaType";
		}

		public ProcessSchemaType(ProcessSchemaType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ProcessSchemaType_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ProcessSchemaTypeDeleted", e);
			Inserting += (s, e) => ThrowEvent("ProcessSchemaTypeInserting", e);
			Validating += (s, e) => ThrowEvent("ProcessSchemaTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ProcessSchemaType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ProcessSchemaType_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class ProcessSchemaType_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : ProcessSchemaType
	{

		public ProcessSchemaType_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ProcessSchemaType_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a");
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

	#region Class: ProcessSchemaType_ProcessLibraryEventsProcess

	/// <exclude/>
	public class ProcessSchemaType_ProcessLibraryEventsProcess : ProcessSchemaType_ProcessLibraryEventsProcess<ProcessSchemaType>
	{

		public ProcessSchemaType_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ProcessSchemaType_ProcessLibraryEventsProcess

	public partial class ProcessSchemaType_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ProcessSchemaTypeEventsProcess

	/// <exclude/>
	public class ProcessSchemaTypeEventsProcess : ProcessSchemaType_ProcessLibraryEventsProcess
	{

		public ProcessSchemaTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

