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

	#region Class: LookupInFolderSchema

	/// <exclude/>
	public class LookupInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public LookupInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LookupInFolderSchema(LookupInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LookupInFolderSchema(LookupInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ef4ef612-076e-4770-b0b1-9111e8a33116");
			RealUId = new Guid("ef4ef612-076e-4770-b0b1-9111e8a33116");
			Name = "LookupInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("34391227-ac90-4b55-9739-6720e97a0594")) == null) {
				Columns.Add(CreateLookupColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("4a7a4c42-aa47-4387-a6e7-97888f454651");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("ef4ef612-076e-4770-b0b1-9111e8a33116");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLookupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("34391227-ac90-4b55-9739-6720e97a0594"),
				Name = @"Lookup",
				ReferenceSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ef4ef612-076e-4770-b0b1-9111e8a33116"),
				ModifiedInSchemaUId = new Guid("ef4ef612-076e-4770-b0b1-9111e8a33116"),
				CreatedInPackageId = new Guid("a5417542-8c18-4c74-bbb4-8c29ec7679f6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LookupInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LookupInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LookupInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LookupInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ef4ef612-076e-4770-b0b1-9111e8a33116"));
		}

		#endregion

	}

	#endregion

	#region Class: LookupInFolder

	/// <summary>
	/// "Lookup" object in folder.
	/// </summary>
	public class LookupInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public LookupInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LookupInFolder";
		}

		public LookupInFolder(LookupInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LookupId {
			get {
				return GetTypedColumnValue<Guid>("LookupId");
			}
			set {
				SetColumnValue("LookupId", value);
				_lookup = null;
			}
		}

		/// <exclude/>
		public string LookupName {
			get {
				return GetTypedColumnValue<string>("LookupName");
			}
			set {
				SetColumnValue("LookupName", value);
				if (_lookup != null) {
					_lookup.Name = value;
				}
			}
		}

		private Lookup _lookup;
		/// <summary>
		/// Lookup.
		/// </summary>
		public Lookup Lookup {
			get {
				return _lookup ??
					(_lookup = LookupColumnEntities.GetEntity("Lookup") as Lookup);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LookupInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LookupInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("LookupInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LookupInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: LookupInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class LookupInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : LookupInFolder
	{

		public LookupInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LookupInFolder_BaseEventsProcess";
			SchemaUId = new Guid("ef4ef612-076e-4770-b0b1-9111e8a33116");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ef4ef612-076e-4770-b0b1-9111e8a33116");
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

	#region Class: LookupInFolder_BaseEventsProcess

	/// <exclude/>
	public class LookupInFolder_BaseEventsProcess : LookupInFolder_BaseEventsProcess<LookupInFolder>
	{

		public LookupInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LookupInFolder_BaseEventsProcess

	public partial class LookupInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LookupInFolderEventsProcess

	/// <exclude/>
	public class LookupInFolderEventsProcess : LookupInFolder_BaseEventsProcess
	{

		public LookupInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

