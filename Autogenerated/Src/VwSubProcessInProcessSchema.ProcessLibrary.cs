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

	#region Class: VwSubProcessInProcessSchema

	/// <exclude/>
	public class VwSubProcessInProcessSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSubProcessInProcessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSubProcessInProcessSchema(VwSubProcessInProcessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSubProcessInProcessSchema(VwSubProcessInProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12");
			RealUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12");
			Name = "VwSubProcessInProcess";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("462ab5a4-d59d-41f7-9e05-ca80a935cf00")) == null) {
				Columns.Add(CreateHostProcessColumn());
			}
			if (Columns.FindByUId(new Guid("cc877183-d49f-4b8b-82a4-4eeab7ed525a")) == null) {
				Columns.Add(CreateParentProcessColumn());
			}
			if (Columns.FindByUId(new Guid("a3aced01-18cf-43bb-ab73-dca82a7cfa3e")) == null) {
				Columns.Add(CreateSubProcessColumn());
			}
			if (Columns.FindByUId(new Guid("92ca3bc9-2ed6-4388-b826-697e1d1c7fa0")) == null) {
				Columns.Add(CreateParentSubProcessColumn());
			}
			if (Columns.FindByUId(new Guid("1a783861-0266-486a-b584-e68d40e9a48b")) == null) {
				Columns.Add(CreateActiveSubProcessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateHostProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("462ab5a4-d59d-41f7-9e05-ca80a935cf00"),
				Name = @"HostProcess",
				ReferenceSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				ModifiedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected virtual EntitySchemaColumn CreateParentProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cc877183-d49f-4b8b-82a4-4eeab7ed525a"),
				Name = @"ParentProcess",
				ReferenceSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				ModifiedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected virtual EntitySchemaColumn CreateSubProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a3aced01-18cf-43bb-ab73-dca82a7cfa3e"),
				Name = @"SubProcess",
				ReferenceSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				ModifiedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected virtual EntitySchemaColumn CreateParentSubProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("92ca3bc9-2ed6-4388-b826-697e1d1c7fa0"),
				Name = @"ParentSubProcess",
				ReferenceSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				ModifiedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveSubProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a783861-0266-486a-b584-e68d40e9a48b"),
				Name = @"ActiveSubProcess",
				ReferenceSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				ModifiedInSchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSubProcessInProcess(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSubProcessInProcess_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSubProcessInProcessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSubProcessInProcessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSubProcessInProcess

	/// <summary>
	/// VwSubProcessInProcess.
	/// </summary>
	public class VwSubProcessInProcess : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSubProcessInProcess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSubProcessInProcess";
		}

		public VwSubProcessInProcess(VwSubProcessInProcess source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid HostProcessId {
			get {
				return GetTypedColumnValue<Guid>("HostProcessId");
			}
			set {
				SetColumnValue("HostProcessId", value);
				_hostProcess = null;
			}
		}

		/// <exclude/>
		public string HostProcessCaption {
			get {
				return GetTypedColumnValue<string>("HostProcessCaption");
			}
			set {
				SetColumnValue("HostProcessCaption", value);
				if (_hostProcess != null) {
					_hostProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _hostProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public VwProcessLib HostProcess {
			get {
				return _hostProcess ??
					(_hostProcess = LookupColumnEntities.GetEntity("HostProcess") as VwProcessLib);
			}
		}

		/// <exclude/>
		public Guid ParentProcessId {
			get {
				return GetTypedColumnValue<Guid>("ParentProcessId");
			}
			set {
				SetColumnValue("ParentProcessId", value);
				_parentProcess = null;
			}
		}

		/// <exclude/>
		public string ParentProcessCaption {
			get {
				return GetTypedColumnValue<string>("ParentProcessCaption");
			}
			set {
				SetColumnValue("ParentProcessCaption", value);
				if (_parentProcess != null) {
					_parentProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _parentProcess;
		/// <summary>
		/// Parent version process.
		/// </summary>
		public VwProcessLib ParentProcess {
			get {
				return _parentProcess ??
					(_parentProcess = LookupColumnEntities.GetEntity("ParentProcess") as VwProcessLib);
			}
		}

		/// <exclude/>
		public Guid SubProcessId {
			get {
				return GetTypedColumnValue<Guid>("SubProcessId");
			}
			set {
				SetColumnValue("SubProcessId", value);
				_subProcess = null;
			}
		}

		/// <exclude/>
		public string SubProcessCaption {
			get {
				return GetTypedColumnValue<string>("SubProcessCaption");
			}
			set {
				SetColumnValue("SubProcessCaption", value);
				if (_subProcess != null) {
					_subProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _subProcess;
		/// <summary>
		/// Sub-process.
		/// </summary>
		public VwProcessLib SubProcess {
			get {
				return _subProcess ??
					(_subProcess = LookupColumnEntities.GetEntity("SubProcess") as VwProcessLib);
			}
		}

		/// <exclude/>
		public Guid ParentSubProcessId {
			get {
				return GetTypedColumnValue<Guid>("ParentSubProcessId");
			}
			set {
				SetColumnValue("ParentSubProcessId", value);
				_parentSubProcess = null;
			}
		}

		/// <exclude/>
		public string ParentSubProcessCaption {
			get {
				return GetTypedColumnValue<string>("ParentSubProcessCaption");
			}
			set {
				SetColumnValue("ParentSubProcessCaption", value);
				if (_parentSubProcess != null) {
					_parentSubProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _parentSubProcess;
		/// <summary>
		/// Parent version sub-process.
		/// </summary>
		public VwProcessLib ParentSubProcess {
			get {
				return _parentSubProcess ??
					(_parentSubProcess = LookupColumnEntities.GetEntity("ParentSubProcess") as VwProcessLib);
			}
		}

		/// <exclude/>
		public Guid ActiveSubProcessId {
			get {
				return GetTypedColumnValue<Guid>("ActiveSubProcessId");
			}
			set {
				SetColumnValue("ActiveSubProcessId", value);
				_activeSubProcess = null;
			}
		}

		/// <exclude/>
		public string ActiveSubProcessCaption {
			get {
				return GetTypedColumnValue<string>("ActiveSubProcessCaption");
			}
			set {
				SetColumnValue("ActiveSubProcessCaption", value);
				if (_activeSubProcess != null) {
					_activeSubProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _activeSubProcess;
		/// <summary>
		/// Active version of sub-process.
		/// </summary>
		public VwProcessLib ActiveSubProcess {
			get {
				return _activeSubProcess ??
					(_activeSubProcess = LookupColumnEntities.GetEntity("ActiveSubProcess") as VwProcessLib);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSubProcessInProcess_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSubProcessInProcessDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSubProcessInProcess(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSubProcessInProcess_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class VwSubProcessInProcess_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSubProcessInProcess
	{

		public VwSubProcessInProcess_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSubProcessInProcess_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a10f252b-6909-4b86-ae7f-5eae28c78e12");
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

	#region Class: VwSubProcessInProcess_ProcessLibraryEventsProcess

	/// <exclude/>
	public class VwSubProcessInProcess_ProcessLibraryEventsProcess : VwSubProcessInProcess_ProcessLibraryEventsProcess<VwSubProcessInProcess>
	{

		public VwSubProcessInProcess_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSubProcessInProcess_ProcessLibraryEventsProcess

	public partial class VwSubProcessInProcess_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSubProcessInProcessEventsProcess

	/// <exclude/>
	public class VwSubProcessInProcessEventsProcess : VwSubProcessInProcess_ProcessLibraryEventsProcess
	{

		public VwSubProcessInProcessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

