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

	#region Class: VwProcessLibFileSchema

	/// <exclude/>
	public class VwProcessLibFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public VwProcessLibFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProcessLibFileSchema(VwProcessLibFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProcessLibFileSchema(VwProcessLibFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			RealUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			Name = "VwProcessLibFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fbcd7bc3-cdd7-4522-8478-34010184d858")) == null) {
				Columns.Add(CreateVwProcessLibColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedByColumn() {
			EntitySchemaColumn column = base.CreateLockedByColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedOnColumn() {
			EntitySchemaColumn column = base.CreateLockedOnColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateDataColumn() {
			EntitySchemaColumn column = base.CreateDataColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateVersionColumn() {
			EntitySchemaColumn column = base.CreateVersionColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateSizeColumn() {
			EntitySchemaColumn column = base.CreateSizeColumn();
			column.ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected virtual EntitySchemaColumn CreateVwProcessLibColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fbcd7bc3-cdd7-4522-8478-34010184d858"),
				Name = @"VwProcessLib",
				CreatedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc"),
				ModifiedInSchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc"),
				CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwProcessLibFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProcessLibFile_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProcessLibFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProcessLibFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLibFile

	/// <summary>
	/// Attachments detail object for "Process library" section object.
	/// </summary>
	public class VwProcessLibFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public VwProcessLibFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessLibFile";
		}

		public VwProcessLibFile(VwProcessLibFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Process library.
		/// </summary>
		public Guid VwProcessLib {
			get {
				return GetTypedColumnValue<Guid>("VwProcessLib");
			}
			set {
				SetColumnValue("VwProcessLib", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProcessLibFile_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwProcessLibFileDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwProcessLibFileInserting", e);
			Updated += (s, e) => ThrowEvent("VwProcessLibFileUpdated", e);
			Validating += (s, e) => ThrowEvent("VwProcessLibFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwProcessLibFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLibFile_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class VwProcessLibFile_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : VwProcessLibFile
	{

		public VwProcessLibFile_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProcessLibFile_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("46d85d4c-c6b5-4ed7-b600-a3b195d70acc");
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

	#region Class: VwProcessLibFile_ProcessLibraryEventsProcess

	/// <exclude/>
	public class VwProcessLibFile_ProcessLibraryEventsProcess : VwProcessLibFile_ProcessLibraryEventsProcess<VwProcessLibFile>
	{

		public VwProcessLibFile_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProcessLibFile_ProcessLibraryEventsProcess

	public partial class VwProcessLibFile_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwProcessLibFileEventsProcess

	/// <exclude/>
	public class VwProcessLibFileEventsProcess : VwProcessLibFile_ProcessLibraryEventsProcess
	{

		public VwProcessLibFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

