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

	#region Class: WebFormContactIdentifierSchema

	/// <exclude/>
	public class WebFormContactIdentifierSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public WebFormContactIdentifierSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebFormContactIdentifierSchema(WebFormContactIdentifierSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebFormContactIdentifierSchema(WebFormContactIdentifierSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8f731e95-b20d-4f60-95ae-f86d44191558");
			RealUId = new Guid("8f731e95-b20d-4f60-95ae-f86d44191558");
			Name = "WebFormContactIdentifier";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("84ecde12-5de7-a179-8681-b6802e5d84c2")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("84ecde12-5de7-a179-8681-b6802e5d84c2"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("8f731e95-b20d-4f60-95ae-f86d44191558"),
				ModifiedInSchemaUId = new Guid("8f731e95-b20d-4f60-95ae-f86d44191558"),
				CreatedInPackageId = new Guid("562f1acd-62c8-4466-b19f-73d792872a6e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebFormContactIdentifier(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebFormContactIdentifier_WebFormEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebFormContactIdentifierSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebFormContactIdentifierSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8f731e95-b20d-4f60-95ae-f86d44191558"));
		}

		#endregion

	}

	#endregion

	#region Class: WebFormContactIdentifier

	/// <summary>
	/// Web form contact identification process.
	/// </summary>
	public class WebFormContactIdentifier : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public WebFormContactIdentifier(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebFormContactIdentifier";
		}

		public WebFormContactIdentifier(WebFormContactIdentifier source)
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

		/// <exclude/>
		public string SysProcessCaption {
			get {
				return GetTypedColumnValue<string>("SysProcessCaption");
			}
			set {
				SetColumnValue("SysProcessCaption", value);
				if (_sysProcess != null) {
					_sysProcess.Caption = value;
				}
			}
		}

		private VwProcessLib _sysProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public VwProcessLib SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as VwProcessLib);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebFormContactIdentifier_WebFormEventsProcess(UserConnection);
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
			return new WebFormContactIdentifier(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebFormContactIdentifier_WebFormEventsProcess

	/// <exclude/>
	public partial class WebFormContactIdentifier_WebFormEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : WebFormContactIdentifier
	{

		public WebFormContactIdentifier_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebFormContactIdentifier_WebFormEventsProcess";
			SchemaUId = new Guid("8f731e95-b20d-4f60-95ae-f86d44191558");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8f731e95-b20d-4f60-95ae-f86d44191558");
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

	#region Class: WebFormContactIdentifier_WebFormEventsProcess

	/// <exclude/>
	public class WebFormContactIdentifier_WebFormEventsProcess : WebFormContactIdentifier_WebFormEventsProcess<WebFormContactIdentifier>
	{

		public WebFormContactIdentifier_WebFormEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebFormContactIdentifier_WebFormEventsProcess

	public partial class WebFormContactIdentifier_WebFormEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebFormContactIdentifierEventsProcess

	/// <exclude/>
	public class WebFormContactIdentifierEventsProcess : WebFormContactIdentifier_WebFormEventsProcess
	{

		public WebFormContactIdentifierEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

