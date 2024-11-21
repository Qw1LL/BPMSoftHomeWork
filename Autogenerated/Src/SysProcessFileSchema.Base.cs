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

	#region Class: SysProcessFileSchema

	/// <exclude/>
	public class SysProcessFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public SysProcessFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessFileSchema(SysProcessFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessFileSchema(SysProcessFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("19acfe2d-92f9-9d4a-b4b5-58f387e3091b");
			RealUId = new Guid("19acfe2d-92f9-9d4a-b4b5-58f387e3091b");
			Name = "SysProcessFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2dcabb6f-fa06-2ed4-063e-89b5c6cbd22d")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2dcabb6f-fa06-2ed4-063e-89b5c6cbd22d"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("19acfe2d-92f9-9d4a-b4b5-58f387e3091b"),
				ModifiedInSchemaUId = new Guid("19acfe2d-92f9-9d4a-b4b5-58f387e3091b"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessFile_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("19acfe2d-92f9-9d4a-b4b5-58f387e3091b"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessFile

	/// <summary>
	/// Process files.
	/// </summary>
	public class SysProcessFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public SysProcessFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessFile";
		}

		public SysProcessFile(SysProcessFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysProcessId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessId");
			}
			set {
				SetColumnValue("SysProcessId", value);
				_sysProcess = null;
			}
		}

		private SysProcessData _sysProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public SysProcessData SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as SysProcessData);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessFile_BaseEventsProcess(UserConnection);
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
			return new SysProcessFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessFile_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessFile_BaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : SysProcessFile
	{

		public SysProcessFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessFile_BaseEventsProcess";
			SchemaUId = new Guid("19acfe2d-92f9-9d4a-b4b5-58f387e3091b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("19acfe2d-92f9-9d4a-b4b5-58f387e3091b");
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

	#region Class: SysProcessFile_BaseEventsProcess

	/// <exclude/>
	public class SysProcessFile_BaseEventsProcess : SysProcessFile_BaseEventsProcess<SysProcessFile>
	{

		public SysProcessFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessFile_BaseEventsProcess

	public partial class SysProcessFile_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessFileEventsProcess

	/// <exclude/>
	public class SysProcessFileEventsProcess : SysProcessFile_BaseEventsProcess
	{

		public SysProcessFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

