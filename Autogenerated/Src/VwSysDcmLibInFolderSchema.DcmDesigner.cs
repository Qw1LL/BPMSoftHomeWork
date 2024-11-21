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

	#region Class: VwSysDcmLibInFolderSchema

	/// <exclude/>
	public class VwSysDcmLibInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public VwSysDcmLibInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysDcmLibInFolderSchema(VwSysDcmLibInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysDcmLibInFolderSchema(VwSysDcmLibInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8229ab5c-4498-4e4e-ae87-9ae8fffe175a");
			RealUId = new Guid("8229ab5c-4498-4e4e-ae87-9ae8fffe175a");
			Name = "VwSysDcmLibInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("450fb78c-441c-4563-abb3-f7867c9400e2");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("8229ab5c-4498-4e4e-ae87-9ae8fffe175a");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysDcmLibInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysDcmLibInFolder_DcmDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysDcmLibInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysDcmLibInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8229ab5c-4498-4e4e-ae87-9ae8fffe175a"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysDcmLibInFolder

	/// <summary>
	/// "DCM library" object in folder.
	/// </summary>
	public class VwSysDcmLibInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public VwSysDcmLibInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysDcmLibInFolder";
		}

		public VwSysDcmLibInFolder(VwSysDcmLibInFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysDcmLibInFolder_DcmDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysDcmLibInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("VwSysDcmLibInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysDcmLibInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysDcmLibInFolder_DcmDesignerEventsProcess

	/// <exclude/>
	public partial class VwSysDcmLibInFolder_DcmDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : VwSysDcmLibInFolder
	{

		public VwSysDcmLibInFolder_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysDcmLibInFolder_DcmDesignerEventsProcess";
			SchemaUId = new Guid("8229ab5c-4498-4e4e-ae87-9ae8fffe175a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8229ab5c-4498-4e4e-ae87-9ae8fffe175a");
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

	#region Class: VwSysDcmLibInFolder_DcmDesignerEventsProcess

	/// <exclude/>
	public class VwSysDcmLibInFolder_DcmDesignerEventsProcess : VwSysDcmLibInFolder_DcmDesignerEventsProcess<VwSysDcmLibInFolder>
	{

		public VwSysDcmLibInFolder_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysDcmLibInFolder_DcmDesignerEventsProcess

	public partial class VwSysDcmLibInFolder_DcmDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysDcmLibInFolderEventsProcess

	/// <exclude/>
	public class VwSysDcmLibInFolderEventsProcess : VwSysDcmLibInFolder_DcmDesignerEventsProcess
	{

		public VwSysDcmLibInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

