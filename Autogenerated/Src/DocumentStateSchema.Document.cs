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

	#region Class: DocumentStateSchema

	/// <exclude/>
	public class DocumentStateSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public DocumentStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DocumentStateSchema(DocumentStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DocumentStateSchema(DocumentStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3fa49baa-57d4-40d7-9293-1e6742b1b0dd");
			RealUId = new Guid("3fa49baa-57d4-40d7-9293-1e6742b1b0dd");
			Name = "DocumentState";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("93f2b0e4-b421-42dc-86e5-35e5b932239c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9e97b79d-5d55-4b98-bfb0-c803e3d1467f")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9e97b79d-5d55-4b98-bfb0-c803e3d1467f"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("3fa49baa-57d4-40d7-9293-1e6742b1b0dd"),
				ModifiedInSchemaUId = new Guid("3fa49baa-57d4-40d7-9293-1e6742b1b0dd"),
				CreatedInPackageId = new Guid("93f2b0e4-b421-42dc-86e5-35e5b932239c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DocumentState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DocumentState_DocumentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DocumentStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DocumentStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3fa49baa-57d4-40d7-9293-1e6742b1b0dd"));
		}

		#endregion

	}

	#endregion

	#region Class: DocumentState

	/// <summary>
	/// Состояние документа.
	/// </summary>
	public class DocumentState : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public DocumentState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DocumentState";
		}

		public DocumentState(DocumentState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DocumentState_DocumentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DocumentStateDeleted", e);
			Validating += (s, e) => ThrowEvent("DocumentStateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DocumentState(this);
		}

		#endregion

	}

	#endregion

	#region Class: DocumentState_DocumentEventsProcess

	/// <exclude/>
	public partial class DocumentState_DocumentEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : DocumentState
	{

		public DocumentState_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DocumentState_DocumentEventsProcess";
			SchemaUId = new Guid("3fa49baa-57d4-40d7-9293-1e6742b1b0dd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3fa49baa-57d4-40d7-9293-1e6742b1b0dd");
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

	#region Class: DocumentState_DocumentEventsProcess

	/// <exclude/>
	public class DocumentState_DocumentEventsProcess : DocumentState_DocumentEventsProcess<DocumentState>
	{

		public DocumentState_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DocumentState_DocumentEventsProcess

	public partial class DocumentState_DocumentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DocumentStateEventsProcess

	/// <exclude/>
	public class DocumentStateEventsProcess : DocumentState_DocumentEventsProcess
	{

		public DocumentStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

