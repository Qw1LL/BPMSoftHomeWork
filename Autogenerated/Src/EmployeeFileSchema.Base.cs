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

	#region Class: EmployeeFileSchema

	/// <exclude/>
	public class EmployeeFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public EmployeeFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmployeeFileSchema(EmployeeFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmployeeFileSchema(EmployeeFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("10f8d911-7359-470e-9ff1-321d9211efab");
			RealUId = new Guid("10f8d911-7359-470e-9ff1-321d9211efab");
			Name = "EmployeeFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e792ec57-91cc-418c-bebd-e4c53d3735b2")) == null) {
				Columns.Add(CreateEmployeeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEmployeeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e792ec57-91cc-418c-bebd-e4c53d3735b2"),
				Name = @"Employee",
				ReferenceSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("10f8d911-7359-470e-9ff1-321d9211efab"),
				ModifiedInSchemaUId = new Guid("10f8d911-7359-470e-9ff1-321d9211efab"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmployeeFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmployeeFile_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmployeeFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmployeeFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("10f8d911-7359-470e-9ff1-321d9211efab"));
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeFile

	/// <summary>
	/// File and link of employee.
	/// </summary>
	public class EmployeeFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public EmployeeFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmployeeFile";
		}

		public EmployeeFile(EmployeeFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EmployeeId {
			get {
				return GetTypedColumnValue<Guid>("EmployeeId");
			}
			set {
				SetColumnValue("EmployeeId", value);
				_employee = null;
			}
		}

		/// <exclude/>
		public string EmployeeName {
			get {
				return GetTypedColumnValue<string>("EmployeeName");
			}
			set {
				SetColumnValue("EmployeeName", value);
				if (_employee != null) {
					_employee.Name = value;
				}
			}
		}

		private Employee _employee;
		/// <summary>
		/// Employee.
		/// </summary>
		public Employee Employee {
			get {
				return _employee ??
					(_employee = LookupColumnEntities.GetEntity("Employee") as Employee);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmployeeFile_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmployeeFileDeleted", e);
			Updated += (s, e) => ThrowEvent("EmployeeFileUpdated", e);
			Validating += (s, e) => ThrowEvent("EmployeeFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmployeeFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeFile_BaseEventsProcess

	/// <exclude/>
	public partial class EmployeeFile_BaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : EmployeeFile
	{

		public EmployeeFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmployeeFile_BaseEventsProcess";
			SchemaUId = new Guid("10f8d911-7359-470e-9ff1-321d9211efab");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("10f8d911-7359-470e-9ff1-321d9211efab");
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

	#region Class: EmployeeFile_BaseEventsProcess

	/// <exclude/>
	public class EmployeeFile_BaseEventsProcess : EmployeeFile_BaseEventsProcess<EmployeeFile>
	{

		public EmployeeFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmployeeFile_BaseEventsProcess

	public partial class EmployeeFile_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmployeeFileEventsProcess

	/// <exclude/>
	public class EmployeeFileEventsProcess : EmployeeFile_BaseEventsProcess
	{

		public EmployeeFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

